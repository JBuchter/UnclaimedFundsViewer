using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnclaimedFundsViewer
{
    internal static class DataGridViewUtilities
    {

        public static DataGridView CopyDataGridViewPrintSelected(DataGridView source)
        {
            DataGridView copy = new DataGridView();

            try
            {
                if (copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn column in source.Columns)
                    {
                        copy.Columns.Add(column.Clone() as DataGridViewColumn);
                    }
                }

                var row = new DataGridViewRow();

                for (int i = 0; i < source.Rows.Count; i++)
                {
                    row = (DataGridViewRow)source.Rows[i].Clone();
                    if ((bool)source.Rows[i].Cells["Print"].Value == true)
                    {
                        var columnIndex = 0;
                        foreach (DataGridViewCell cell in source.Rows[i].Cells)
                        {
                            row.Cells[columnIndex].Value = cell.Value;
                            columnIndex++;
                        }
                        copy.Rows.Add(row);
                    }
                }
                copy.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return copy;
        }

        public static DataGridView CopyDataGridViewAllRows(DataGridView source)
        {
            DataGridView copy = new DataGridView();

            try
            {
                if (copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn column in source.Columns)
                    {
                        copy.Columns.Add(column.Clone() as DataGridViewColumn);
                    }
                }

                var row = new DataGridViewRow();

                for (int i = 0; i < source.Rows.Count; i++)
                {
                    row = (DataGridViewRow)source.Rows[i].Clone();
                   
                    var columnIndex = 0;
                    foreach (DataGridViewCell cell in source.Rows[i].Cells)
                    {
                        row.Cells[columnIndex].Value = cell.Value;
                        columnIndex++;
                    }
                    copy.Rows.Add(row);
                   
                }
                copy.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return copy;
        }

        public static DataGridView CopyDataGridViewSelectedRows(DataGridView source)
        {
            DataGridView copy = new DataGridView();

            try
            {
                if (copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn column in source.Columns)
                    {
                        copy.Columns.Add(column.Clone() as DataGridViewColumn);
                    }
                }

                var row = new DataGridViewRow();

                for(int i = 0; i < source.Rows.Count; i++)
                {
                    row = (DataGridViewRow) source.Rows[i].Clone();
                    
                    if(source.Rows[i].Selected)
                    {
                        var columnIndex = 0;
                        foreach(DataGridViewCell cell in source.Rows[i].Cells)
                        {
                            row.Cells[columnIndex].Value = cell.Value;
                            columnIndex++;
                        }
                        copy.Rows.Add(row);
                    }
                }
                copy.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return copy;
        }

       
    }
}
