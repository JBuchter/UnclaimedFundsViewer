using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;

namespace UnclaimedFundsViewer
{
    public enum RecordMode
    {
        Detail,
        Matching
    }

    public partial class frmMain : Form
    {
        private OhioFindersListEntities _context;
        private PrintDocument _printDoc;
        private DataGridView _printDataGridView;
        private DataGridViewPrinter _gridPrinter;
        private ServiceController _svcController;
        private string _dbServiceName;
        private int _pagingIndex = 0;
        private int _pagingSize = 20;
        private int _pagesTotal = 0;
        private int _recordTotal = 0;
        private int _matchSize = 100;
        private int _amountFloor = 5000;
        private int _savedPageIndex = 0;
        private int _savedRowIndex = 0;
        private bool _gridInitializing = true;

        public frmMain()
        {
            InitializeComponent();
            _context = new OhioFindersListEntities();
            
            _context.Database.CommandTimeout = 60; // 1 minute
                      
            _printDoc = new PrintDocument();
            _printDoc.PrintPage += _printDoc_PrintPage;
            _printDataGridView = new DataGridView();

            _savedPageIndex = Convert.ToInt32(Properties.Settings.Default["CurrentPageIndex"]);
            _savedRowIndex = Convert.ToInt32(Properties.Settings.Default["CurrentRowIndex"]);
            _dbServiceName = Convert.ToString(Properties.Settings.Default["DatabaseServiceName"]);

            _svcController = new ServiceController(_dbServiceName);

            if (_svcController.Status != ServiceControllerStatus.Running)
                restartDatabaseService();

        }

        private void restartDatabaseService()
        {
            lblStatus.Text = "Restarting Database Service. Please wait...";
            ProcessStartInfo psi = new ProcessStartInfo("restartdbservice.exe");
            psi.Arguments = "\"" + _dbServiceName + "\"";
            psi.Verb = "runas";

            var proc = new Process();
            proc.StartInfo = psi;
            proc.Start();
            proc.WaitForExit();
            if (!proc.ExitCode.Equals(0))
                lblStatus.Text = "Could not restart DB service.";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _recordTotal = _context.FindersLists.Where(c => c.Amount > _amountFloor).Count();
                _pagesTotal = _recordTotal / _pagingSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            _pagingIndex = _savedPageIndex;
            
            loadDetailGridAsync();

        }

        /// <summary>
        /// loads match data into the dataGridViewMatch in seperate thread.
        /// </summary>
        /// <param name="lastname">The last name to find</param>
        /// <param name="address">The address to find</param>
        /// <returns>Task</returns>
        private async Task loadMatchGridAsync(string lastname, string address)
        {
            preLoad(RecordMode.Matching);
            var timer = new Stopwatch();

            timer.Start();
            string[] Ids = (from c in this._context.FindersLists
                            where c.OwnerName.Contains(lastname)
                            select c.PropertyID).ToArray<string>();

            if (address.ToLower().Equals("unknown"))
                address = "NA";

            try
            {
                if (address.Equals("NA"))
                {
                    
                    var query = (from c in _context.FindersLists
                                where c.OwnerName.Contains(lastname) || Ids.Contains<string>(c.PropertyID)
                                orderby c.Amount descending
                                select new
                                {
                                    OwnerName = c.OwnerName,
                                    Address = c.Address1,
                                    Value = c.Amount,
                                    DateReceived = c.DateReceived,
                                    ReportYear = c.ReportYear,
                                    PropertyID = c.PropertyID,
                                    HolderID = c.HolderID,
                                    HolderName = c.HolderName,
                                    Address2 = c.Address2,
                                    Address3 = c.Address3,
                                    City = c.City,
                                    State = c.State,
                                    Zip = c.Zip,
                                    AccountNumber = c.HolderAccountNumber,
                                    PropertyDescription = c.PropertyDescription
                                }).Take(_matchSize);

                    dataGridViewMatch.DataSource = await Task.Run(() => query.ToList());
                    
                }
                else
                {
                    var query = (from c in _context.FindersLists
                                where c.OwnerName.Contains(lastname) || c.Address1.Contains(address) || Ids.Contains(c.PropertyID)
                                select new
                                {
                                    OwnerName = c.OwnerName,
                                    Address = c.Address1,
                                    Value = c.Amount,
                                    DateReceived = c.DateReceived,
                                    ReportYear = c.ReportYear,
                                    PropertyID = c.PropertyID,
                                    HolderID = c.HolderID,
                                    HolderName = c.HolderName,
                                    Address2 = c.Address2,
                                    Address3 = c.Address3,
                                    City = c.City,
                                    State = c.State,
                                    Zip = c.Zip,
                                    AccountNumber = c.HolderAccountNumber,
                                    PropertyDescription = c.PropertyDescription
                                }).Take(_matchSize);
                    dataGridViewMatch.DataSource = await Task.Run(() => query.ToList());
                }
            }
            catch (Exception ex)
            {
                timer.Stop();
                postLoad(RecordMode.Matching,timer.Elapsed.Seconds.ToString());
                MessageBox.Show(ex.ToString());
                return;
            }

            if (!dataGridViewMatch.Columns.Contains("Print"))
            {
                dataGridViewMatch.Columns.Insert(0, new DataGridViewCheckBoxColumn()
                {
                    Name = "Print",
                    TrueValue = true,
                    FalseValue = false,
                    ReadOnly = false,
                    IndeterminateValue = false
                });
            }

            dataGridViewMatch.Columns["Value"].DefaultCellStyle.Format = "c";
            foreach (DataGridViewRow row in dataGridViewMatch.Rows)
            {
                row.Cells["Print"].Value = false;
            }
            timer.Stop();
            postLoad(RecordMode.Matching,timer.Elapsed.Seconds.ToString());
        }

        /// <summary>
        /// Loads the detail grid in a seperate thread.
        /// </summary>
        /// <returns>Task</returns>
        private async Task loadDetailGridAsync()
        {
            //Loading the detail grid, reset the search text.
            txtSearch.Text = string.Empty;

            preLoad(RecordMode.Detail);

            try
            {
                var query = (from c in _context.FindersLists
                             where c.Amount > _amountFloor
                             orderby c.Amount descending
                             select new { Value = c.Amount, OwnerName = c.OwnerName, Address = c.Address1, DateReceived = c.DateReceived, PropertyID = c.PropertyID }).Skip(_pagingIndex * _pagingSize).Take(_pagingSize);

                dataGridViewDetail.DataSource = await Task.Run(() => query.ToList());
                dataGridViewDetail.Columns[0].DefaultCellStyle.Format = "c";
                if(_gridInitializing)
                {
                    dataGridViewDetail.Rows[_savedRowIndex].Selected = true;
                    dataGridViewDetail.Rows[_savedRowIndex].Cells[0].Selected = true;
                    _gridInitializing = false;
                }
            }
            catch (Exception ex)
            {
                postLoad(RecordMode.Detail,string.Empty);
                MessageBox.Show(ex.ToString());
                return;
            }

            postLoad(RecordMode.Detail,string.Empty);
        }

        /// <summary>
        /// Handles UI sync for pre load of data grids.
        /// </summary>
        /// <param name="mode">The grid we are loading.</param>
        private void preLoad(RecordMode mode)
        {
            var action = string.Empty;

            if (mode == RecordMode.Matching)
                action = "Searching";
            else
            {
                if (dataGridViewMatch.Columns["Print"] != null)
                    dataGridViewMatch.Columns.Remove("Print");

                dataGridViewMatch.DataSource = null;
                action = "Loading";
            }

            lblStatus.Text = string.Format("{0} {1} records...please wait.", action, mode);
            groupBoxDetail.Enabled = false;
            groupBoxMatch.Enabled = false;
            groupBoxSearch.Enabled = false;
        }

        /// <summary>
        /// Handles UI sync for post load of data grids.
        /// </summary>
        /// <param name="mode">The grid we are loading.</param>
        private void postLoad(RecordMode mode, string elapsed)
        {
            var count = 0;
           
            if (mode == RecordMode.Detail)
            {
                var startRecord = _pagingIndex * _pagingSize +1;
                var endRecord = startRecord -1 + _pagingSize;

                if (_pagingIndex == _pagesTotal)
                    endRecord = _recordTotal;

                btnPrintPreview.Enabled = false;
                btnPrint.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Text = "Select All Records";

                lblPaging.Text = string.Format("Showing records {0} - {1} of {2}",startRecord, endRecord, _recordTotal);
                lblStatus.Text = string.Empty;
            }
            else
            {
                count = dataGridViewMatch.Rows.Count;
                
                btnPrintPreview.Enabled = (count > 0);
                btnPrint.Enabled = (count > 0);
                selectAllToolStripMenuItem.Enabled = (count > 0);
                selectAllToolStripMenuItem.Text = "Select All Records";

                lblStatus.Text = string.Format("{0} record(s) loaded in {1} sec.", count,elapsed);
            }

           
            groupBoxDetail.Enabled = true;
            groupBoxMatch.Enabled = true;
            groupBoxSearch.Enabled = true;
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text)) return;
            var address = "NA";

            if(dataGridViewDetail.SelectedRows.Count > 0)
                address = dataGridViewDetail.SelectedRows[0].Cells["Address"].Value.ToString();

            if (string.IsNullOrEmpty(address))
                address = "NA";

            loadMatchGridAsync(txtSearch.Text, address);

        }

        private void dataGridViewDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtSearch.Text = (string)dataGridViewDetail.Rows[e.RowIndex].Cells[1].FormattedValue;


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (initPrintSettings())
                _printDoc.Print();
        }

        /// <summary>
        /// Checks if any records are selected for printing in the match data grid.
        /// </summary>
        /// <returns>True if records areselected for printing.</returns>
        private bool recordsSelectedForPrint()
        {
            foreach (DataGridViewRow row in dataGridViewMatch.Rows)
            {
                if ((bool)row.Cells["Print"].Value == true)
                    return true;
            }
            return false;

        }

        /// <summary>
        /// Initializes the print dialog.
        /// </summary>
        /// <returns>True if initialization succedded.</returns>
        private bool initPrintSettings()
        {

            if (!recordsSelectedForPrint())
                return false;

            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowCurrentPage = false;
            printDialog.AllowPrintToFile = false;
            printDialog.AllowSelection = false;
            printDialog.AllowSomePages = false;
            printDialog.PrintToFile = false;
            printDialog.ShowHelp = false;
            printDialog.ShowNetwork = false;

            if (printDialog.ShowDialog() != DialogResult.OK)
                return false;

            _printDoc.DocumentName = "UnclaimedFundsList";
            _printDoc.PrinterSettings =
                                printDialog.PrinterSettings;
            _printDoc.DefaultPageSettings =
            printDialog.PrinterSettings.DefaultPageSettings;
            _printDoc.DefaultPageSettings.Margins =
                             new Margins(40, 40, 40, 40);

            _printDataGridView = DataGridViewUtilities.CopyDataGridViewPrintSelected(dataGridViewMatch);
            
            _printDataGridView.Refresh();

            _gridPrinter = new DataGridViewPrinter(_printDataGridView,
            _printDoc, "TIM HOWARD'S LIST", true);
           
            return true;

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if(recordsSelectedForPrint())
            {
                var printPreview = new PrintPreviewDialog();
                //Disable the print button. Printing through the preview does not work.
                ((ToolStripButton)((ToolStrip)printPreview.Controls[1]).Items[0]).Enabled = false;
                printPreview.Document = _printDoc;
                ((Form)printPreview).WindowState = FormWindowState.Maximized;
                _printDataGridView = DataGridViewUtilities.CopyDataGridViewPrintSelected(dataGridViewMatch);

                _printDataGridView.Refresh();

                _gridPrinter = new DataGridViewPrinter(_printDataGridView,
                _printDoc, "TIM HOWARD'S LIST", true);
                printPreview.ShowDialog();
            }
        }

        void _printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if( _gridPrinter.DrawDataGridView(e))
                e.HasMorePages = true;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMatch.Rows.Count == 0) return;
            var value = true;

            if ((string)selectAllToolStripMenuItem.Tag == "DeSelect")
            {
                value = false;
                selectAllToolStripMenuItem.Tag = "Select";
                selectAllToolStripMenuItem.Text = "Select All Records";
            }
            else
            {
                selectAllToolStripMenuItem.Tag = "DeSelect";
                selectAllToolStripMenuItem.Text = "DeSelect All Records";
            }

            foreach (DataGridViewRow row in dataGridViewMatch.Rows)
            {
                row.Cells["Print"].Value = value;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewDetail.ClearSelection();
            if (e.KeyChar.Equals('\r'))
            {
                if (txtSearch.Text.Count() > 0)
                {
                    dataGridViewDetail.ClearSelection();
                    bnSearch.PerformClick();
                }
            }
        }

        private void toolStripButtonFirst_Click(object sender, EventArgs e)
        {
            if (_pagingIndex > 0)
            {
                _pagingIndex = 0;
                loadDetailGridAsync();
            }
        }

        private void toolStripButtonBackward_Click(object sender, EventArgs e)
        {
            if (_pagingIndex > 0)
            {
                _pagingIndex--;
                loadDetailGridAsync();
            }
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            if (_pagingIndex < _pagesTotal)
            {
                _pagingIndex++;
                loadDetailGridAsync();
            }
        }

        private void toolStripButtonLast_Click(object sender, EventArgs e)
        {
            _pagingIndex = _pagesTotal;
            loadDetailGridAsync();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dataGridViewDetail.SelectedRows.Count > 0)
                {
                    Properties.Settings.Default["CurrentPageIndex"] = _pagingIndex;
                    Properties.Settings.Default["CurrentRowIndex"] = dataGridViewDetail.SelectedRows[0].Index;
                }
                else
                {
                    Properties.Settings.Default["CurrentPageIndex"] = 0;
                    Properties.Settings.Default["CurrentRowIndex"] = 0;
                }
               
                Properties.Settings.Default.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
    }
        
}
