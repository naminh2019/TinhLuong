using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.OleDb;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

using Excel = Microsoft.Office.Interop.Excel;



namespace TinhLuong
{
    public partial class ImportExcel : Form
    {
        public ImportExcel()
        {
            InitializeComponent();
        }
        #region //==================== Declare variable ====================//

        #endregion

        #region //==================== Form Open & Close ====================//
        private void ImportExcel_Load(object sender, EventArgs e)
        {
            OnMouseEnter(e);
            OnMouseLeave(e);
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region //==================== Control Process ====================//

        protected override void OnMouseEnter(System.EventArgs e)
        {
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblImport.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblBrowse.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblOpen.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
        
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblImport.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblBrowse.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblOpen.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
  
            base.OnMouseLeave(e);
        }


        #endregion

        #region //==================== DataContainer Process ====================//
        private void lblOpen_Click(object sender, EventArgs e)
        {
            string PathCpnn = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox_path.Text + ";Extended Properties=\"Excel 8.0;HDR=No;\";";
            OleDbConnection conn = new OleDbConnection(PathCpnn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + cboSheet.Text + "$]", conn);
            DataTable dt = new DataTable();
            try
            {
                myDataAdapter.Fill(dt);
                string _time = (dt.Rows[0][1].ToString());
                DateTime dateTime;
                if (cboData.SelectedIndex == 0)
                {
                    int _count = dt.Columns.Count;
                    if (_count != 2 || !DateTime.TryParse(_time, out dateTime))
                    {
                        MessageBox.Show("Không đúng file");
                        return;
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[1].HeaderText = "Chấm công";

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        String emptyRow = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        if (String.IsNullOrEmpty(emptyRow))
                        {
                            dataGridView1.Rows.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    int _count = dt.Columns.Count;
                    if (_count != 4 || !DateTime.TryParse(_time, out dateTime))
                    {
                        MessageBox.Show("Không đúng file");
                        return;
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[1].HeaderText = "Ngày tháng";
                    dataGridView1.Columns[2].HeaderText = "Tên nhân viên";
                    dataGridView1.Columns[3].HeaderText = "Tiền ứng lương";

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        String emptyRow = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        if (String.IsNullOrEmpty(emptyRow))
                        {
                            dataGridView1.Rows[i].Cells[3].Value = "0";
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("loi mo file - dong file dang mo hoac chuyen version excel 97");
            }
            lblImport.Visible = true;
        }
        private void cboData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboData.SelectedIndex == 0)
            {
                dataGridView1.Size = new Size(258, 480);
                dataGridView1.Location = new Point(226, 190);
            }
            else
            {
                dataGridView1.Size = new Size(458, 488);
                dataGridView1.Location = new Point(126, 190);
            }

            dataGridView1.DataSource = null;
            cboSheet.Text = "";
            textBox_path.Text = "";
            lblOpen.Visible = false;
            lblImport.Visible = false;
            textBox_path.Focus();
        }

        #endregion

        #region //==================== FormDiplay Process ====================//
        private void lblBrowse_Click(object sender, EventArgs e)
        {
            if (cboData.Text == "")
            {
                MessageBox.Show("chua chon du lieu ket noi");
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_path.Text = openFileDialog1.FileName;
            }
            try
            {
                Excel.Application oXL = new Excel.Application();
                Excel.Workbook oWB = oXL.Workbooks.Open(openFileDialog1.FileName);
                oXL.Visible = false;

                cboSheet.Items.Clear();
                foreach (Excel.Worksheet oSheet in oWB.Sheets)
                {
                    if (oSheet.Rows.Count == 0 || oSheet == null)
                        lblOpen.Visible = false;
                    else lblOpen.Visible = true;
                    cboSheet.Items.Add(oSheet.Name);
                }

                cboSheet.SelectedIndex = 0;

                oXL.ActiveWorkbook.Close(false);
                oXL.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region //==================== CURD Botton Click ====================//
        private void lblImport_Click(object sender, EventArgs e)
        {
            Boolean sUpdate = false;
            DateTime sDateDGV = new DateTime();
            int sManvDGV = 0;

            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);
            sqlConnection.Open();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                sDateDGV = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                sManvDGV = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }
            //==================== Import Keeptime ====================//

            if (cboData.SelectedIndex == 0)
            {
                String queryTime = string.Format("SELECT * FROM dulieu");
                DataTable keeptimeDB = ConnectionUtils.findAll(queryTime);
                foreach (DataRow sTime in keeptimeDB.Rows)
                {
                    DateTime sDateDBkeeptime = DateTime.Parse(sTime["timekeep"].ToString());
                    int sMonth = sDateDGV.Month;
                    int sYear = sDateDGV.Year;

                    if (sDateDGV.CompareTo(sDateDBkeeptime) == 0)
                    {
                        if (sUpdate == false)
                        {
                            sUpdate = true;
                            DialogResult result = MessageBox.Show("Du lieu trung, Update?", "err",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                string queryDataDelete = String.Format(" Delete from dulieu where month(Timekeep) = '{0}' and year(timekeep) = {1}", sMonth, sYear);
                                SqlCommand sqlDataDelete = new SqlCommand(queryDataDelete, sqlConnection);
                                ConnectionUtils.ExeCuteReader(sqlDataDelete);
                            }
                            else return;
                        }
                    }
                }
                try
                {
                    int j = 0;
                    int i = 0;
                    for (i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        int MaNV = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        DateTime Timekeep = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        String time = Timekeep.ToString("dd-MM-yy HH:mm:ss");
                        String query = String.Format("INSERT INTO dulieu (MaNV, Timekeep) values ({0}, convert(datetime,'{1}', 5))", MaNV, time);
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        int imp = sqlCommand.ExecuteNonQuery();
                        j += 1;
                    }
                    if (sUpdate == true)
                    {
                        MessageBox.Show(string.Format("{0} Updated Successful!", j));
                        sUpdate = false;
                    }
                    else
                        MessageBox.Show(string.Format("{0} record import OK!", i));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //==================== Import Advance Payment ====================//

            else
            {
                int MaNV = 0;
                string cDuplicate = null;
                String sDateGrid = sDateDGV.ToString("M-yyyy");
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    MaNV = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    cDuplicate = ("AD" + sDateGrid.Replace("-", String.Empty) + MaNV.ToString() + "2");
                }

                try
                {
                    String queryDeduct = string.Format("SELECT * FROM SalaryHistory where DeductID = 2");
                    DataTable sDeduct = ConnectionUtils.findAll(queryDeduct);

                    foreach (DataRow DeductPay in sDeduct.Rows)
                    {
                        string ChkDuplicate = DeductPay["CheckDuplicate"].ToString().Trim();
                        if (cDuplicate.CompareTo(ChkDuplicate) == 0)
                        {
                            if (sUpdate == false)
                            {
                                sUpdate = true;
                                DialogResult result = MessageBox.Show("Du lieu trung, Update?", "err",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    string queryDataDelete = String.Format(" Delete from SalaryHistory where Date = '{0}' and DeductID = 2", sDateGrid);
                                    SqlCommand sqlDataDelete = new SqlCommand(queryDataDelete, sqlConnection);
                                    ConnectionUtils.ExeCuteReader(sqlDataDelete);
                                }

                                else return;
                            }
                        }
                    }
                    int j = 0;
                    int i = 0;
                    for (i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        MaNV = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        int DeductID = 2;
                        int advMoney = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        if (advMoney > 0)
                        {
                            String queryKT = string.Format(" INSERT INTO SalaryHistory (CheckDuplicate, MaNV, DeductID, Date, money) values" +
                                                           " ('{0}', {1}, {2}, '{3}', {4}) ", cDuplicate, MaNV, DeductID, sDateGrid, advMoney);
                            SqlCommand sqlCommand = new SqlCommand(queryKT, sqlConnection);
                            int imp = sqlCommand.ExecuteNonQuery();
                            j += 1;
                        }
                    }
                    if (sUpdate == true)
                    {
                        MessageBox.Show(string.Format("{0} Updated Successful!", j));
                        sUpdate = false;
                    }
                    else
                        MessageBox.Show(string.Format("{0} record import OK!", i));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
    }
}
