using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace TinhLuong.Utils
{
    class ExportExcel
    {
        static public bool exportDataToExcel(string tieude, DataGridView dt)
        {
            bool result = false;
            int socot = dt.ColumnCount;
            int sohang = dt.RowCount;
            int i, j;

            Excel.ApplicationClass xlApp;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;
            object missValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlBook = xlApp.Workbooks.Add(missValue);
            xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
            xlApp.Visible = false;

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
            if (f.ShowDialog() == DialogResult.OK)
            {
                xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1").Merge(false);
                Excel.Range caption = xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1");
                caption.Select();
                caption.FormulaR1C1 = tieude;
                caption.HorizontalAlignment = Excel.Constants.xlCenter;
                caption.Font.Bold = true;
                caption.VerticalAlignment = Excel.Constants.xlCenter;
                caption.Font.Size = 15;
                caption.Interior.ColorIndex = 20;
                caption.RowHeight = 30;

                Excel.Range header = xlSheet.get_Range("A2", Convert.ToChar(socot + 65) + "2");
                header.Select();
                header.HorizontalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;

                for (i = 0; i < socot; i++)
                    xlSheet.Cells[2, i + 2] = dt.Columns[i].HeaderText;
                xlSheet.Cells[2, 1] = "STT";

                for (i = 0; i < sohang; i++)
                    xlSheet.Cells[i + 3, 1] = i + 1;

                for (i = 0; i < sohang; i++)
                    for (j = 0; j < socot; j++)
                    {
                        xlSheet.Cells[i + 3, j + 2] = dt.Rows[i].Cells[j].Value.ToString();
                    }

                for (i = 0; i < sohang; i++)
                    ((Excel.Range)xlSheet.Cells[1, i + 1]).EntireColumn.AutoFit();

                xlBook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();

                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
                result = true;
            }
            return result;
        }
        static public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
