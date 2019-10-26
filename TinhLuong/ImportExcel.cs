using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Data.SqlClient;
//using System.Data.OleDb;
//using System.Data.Odbc;

using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace TinhLuong
{
    public partial class ImportExcel : Form
    {
        public ImportExcel()
        {
            InitializeComponent();
        }

        //bool Insert;

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Excel File Dialog";
            // fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }


            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            // dt.Column = colCount;  
            dataGridView1.ColumnCount = colCount;
            dataGridView1.RowCount = rowCount;

            for (int i = 2; i <= 50; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //write the value to the Grid  
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        String value = xlRange.Cells[i, j].Value2.ToString();
                        if (value.Trim() == "")
                        {
                            value = "00:00:00";
                        }
                        else
                        {
                            if (j == 2)
                            {
                                double date = double.Parse(value);

                                var dateTime = DateTime.FromOADate(date).ToString("dd/MM/yyyy");

                                value = dateTime.ToString();
                            }

                            if (j >= 4 && j <= 8)
                            {
                                double date = double.Parse(value);

                                var dateTime = DateTime.FromOADate(date).ToString("HH:mm:ss");

                                DateTime d = DateTime.FromOADate(date);

                                // dd/MM/yyyy HH:mm:ss

                                value = dateTime.ToString();
                            }
                        }

                        //if (j == 1 && value == "1")
                        dataGridView1.Rows[i - 1].Cells[j - 1].Value = value;
                    }
                    // Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");  

                    //add useful things here!     
                }
            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:  
            //  never use two dots, all COM objects must be referenced and released individually  
            //  ex: [somthing].[something].[something] is bad  

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}