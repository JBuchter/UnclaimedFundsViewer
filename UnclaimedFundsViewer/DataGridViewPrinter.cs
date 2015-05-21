using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;

class DataGridViewPrinter
{
    private DataGridView _dataGridView; // The DataGridView Control which will be printed
    private PrintDocument _printDocument; // The PrintDocument to be used for printing
    private string _headerText = string.Empty;
    private Font _headerFont = new Font("Ariel",14);
    private Font _bodyFont = new Font("Ariel", 10);
    private PointF _column1 = new PointF();
    private PointF _column2 = new PointF();
    private Pen _linePen = new Pen(Color.Black);
    private int _cellHeight = 0;
    private bool _printPageNumbers = false;

    static int _currentRow; // A static parameter that keep track on which Row (in the DataGridView control) should be printed

    static int _pageNumber;
               
    // The class constructor
    public DataGridViewPrinter(DataGridView dataGridView, PrintDocument printDocument, string headerText, bool printPageNumbers)
    {
        _dataGridView = dataGridView;
        _printDocument = printDocument;
        _headerText = headerText;
        _cellHeight = _bodyFont.Height + 5;
        _pageNumber = 0;
        _currentRow = 0;
        _printPageNumbers = printPageNumbers;
    }
        
    // The function that prints the title and header row
    private void drawHeader(PrintPageEventArgs e)
    {
        //initialize local fields
        _cellHeight = (int)_bodyFont.Height + 5;       // set cell height
        _column1.X = e.MarginBounds.Left;
        _column1.Y = e.MarginBounds.Top;
        _column2.X = e.MarginBounds.Left + e.MarginBounds.Width / 2;
        _column2.Y = e.MarginBounds.Top;
        
        //Draw Header
        e.Graphics.DrawString(_headerText,
            _headerFont, Brushes.Black, _column1.X, _column1.Y - 20);
        
        //Draw Date
        e.Graphics.DrawString(DateTime.Now.ToLongDateString(),
           _headerFont, Brushes.Black, _column2.X, _column2.Y - 20);

        drawRow(e.Graphics);

        // reset Column Points
        _column1.Y += _cellHeight;
        _column2.Y += _cellHeight;

       
    }
    
    private void drawFooter(PrintPageEventArgs e)
    {
        var pageWidth = _printDocument.DefaultPageSettings.PaperSize.Width;

        _pageNumber++;
        string PageString = "Page " + _pageNumber.ToString();

        StringFormat PageStringFormat = new StringFormat();
        PageStringFormat.Trimming = StringTrimming.Word;
        PageStringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
        PageStringFormat.Alignment = StringAlignment.Far;

        Font PageStringFont = new Font("Ariel", 8, FontStyle.Regular, GraphicsUnit.Point);

        RectangleF PageStringRectangle = new RectangleF((float)e.MarginBounds.Right, e.MarginBounds.Bottom, (float)pageWidth - (float)e.MarginBounds.Right - (float)e.MarginBounds.Left, e.Graphics.MeasureString(PageString, PageStringFont).Height);

        e.Graphics.DrawString(PageString, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle, PageStringFormat);
    }

    private void drawRow(Graphics g, string column1Value = null, string column2Value = null)
    {
        if(column1Value != null)
            g.DrawString(column1Value, _bodyFont, Brushes.Black, _column1.X, _column1.Y);
        if(column2Value != null)
            g.DrawString(column2Value, _bodyFont, Brushes.Black, _column2.X, _column2.Y);

        _column1.Y += _cellHeight;
        _column2.Y += _cellHeight;
    }

    // The function that print a bunch of rows that fit in one page
    // Returns true if there are more rows to print, so another PagePrint action is required
    // Returns false when all rows are printed (the _currentRow parameter reaches the last row of the DataGridView control) and no further PagePrint action is required
    private bool drawRows(PrintPageEventArgs e)
    {
        var rowsPrinted = 0;

        while (_currentRow < _dataGridView.Rows.Count -1)
        {
            if (rowsPrinted == 5)
                return true;

            if (_dataGridView.Rows[_currentRow].Visible) // Print the cells of the _currentRow only if that row is visible
            {
                var row = _dataGridView.Rows[_currentRow];

                //draw ownername and holdername
                var owner = row.Cells["OwnerName"].Value ?? string.Empty;
                var holder = row.Cells["HolderName"].Value ?? string.Empty;
                drawRow(e.Graphics, owner.ToString(), holder.ToString());
                
                //Draw Address and Prop ID
                var address = row.Cells["Address"].Value ?? string.Empty;
                var propertyID = row.Cells["PropertyID"].Value ?? string.Empty;
                drawRow(e.Graphics,address.ToString(), propertyID.ToString());
                
                //Draw Addr2 and Prop Desc
                var address2 = row.Cells["Address2"].Value ?? string.Empty;
                var propertyDesc = row.Cells["PropertyDescription"].Value ?? string.Empty;
                drawRow(e.Graphics,address2.ToString(), propertyDesc.ToString());

                //Draw Addr3
                var address3 = row.Cells["Address3"].Value ?? string.Empty;
                drawRow(e.Graphics, address3.ToString());
                               
                //Draw City, State Zip
                var city = row.Cells["City"].Value ?? string.Empty;
                var state = row.Cells["State"].Value ?? string.Empty;
                var zip = row.Cells["Zip"].Value ?? string.Empty;
                var formatted = string.Format("{0}, {1} {2}",city,state,zip);

                drawRow(e.Graphics, formatted);

                // draw line
                e.Graphics.DrawLine(_linePen, _column1.X, _column1.Y, 750, _column1.Y);

                // add a touch to the Y axis
                _column1.Y += 6;
                _column2.Y += 6;

                // draw Date and Amount
                var date = Convert.ToDateTime(row.Cells["DateReceived"].Value);
                var dateFormatted = date.ToString("MM/dd/yyyy") ?? string.Empty;
                var amount = row.Cells["Value"].FormattedValue ?? string.Empty;
                formatted = string.Format("{0}     {1}", dateFormatted, amount);
                drawRow(e.Graphics, formatted);

                // draw line
                e.Graphics.DrawLine(_linePen, _column1.X, _column1.Y, 750, _column1.Y);

                drawRow(e.Graphics);

                rowsPrinted += 1;
            }
            _currentRow ++;
        }

        return false;
    }

    

    // The method that calls all other functions
    public bool DrawDataGridView(PrintPageEventArgs e)
    {
        try
        {
            drawHeader(e);
            bool bContinue = drawRows(e);
            if (_printPageNumbers)
                drawFooter(e);

            return bContinue;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Operation failed: " + ex.Message.ToString(), Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
