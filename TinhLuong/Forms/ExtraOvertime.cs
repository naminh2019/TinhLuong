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
using System.Text.RegularExpressions;

namespace TinhLuong.Forms
{
    public partial class ExtraOvertime : Form
    {
        public ExtraOvertime()
        {
            InitializeComponent();
        }

        #region//====================  Declare variable ====================//
        List<TinhLuong.Entities.ExtraOvertime> sExtraOvertime = null;
        string Date = null;
        DataTable sExtraTime = null;
        Boolean sKey = false;
        #endregion

        #region//====================  Form Open & Close ====================//
        private void ExtraOvertime_Load(object sender, EventArgs e)
        {
            for (int cMonth = 1; cMonth < 13; cMonth++)
            {
                cboMonth.Items.Add(cMonth);
                cboMonth.Text = (DateTime.Now.Month - 1).ToString();
                if (cboMonth.Text == "") cboMonth.Text = "12";
            }

            for (int cYear = 0; cYear < 50; cYear++)
            {
                cboYear.Items.Add(cYear + 2010);
                cboYear.Text = DateTime.Now.Year.ToString();
                if (DateTime.Now.Month - 1 == 0)
                    cboYear.Text = (DateTime.Now.Year - 1).ToString();
            }
            fillDadagrid();
            //  cboYear.Focus();
            OnMouseEnter(e);
            OnMouseLeave(e);
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region//====================  Control Process ====================//
        protected override void OnMouseEnter(System.EventArgs e)
        {
            label1.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblSave.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            label1.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblSave.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);

            base.OnMouseLeave(e);
        }
        #endregion

        #region//====================  DataContainer Process ====================//
        private void dgvExtraTime_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvExtraTime.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;

                tb.TextChanged += new EventHandler(tb_TextChanged);
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnKeyPress);
                }
            }
        }
        private void dgvExtraTime_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
            int colIdx = e.ColumnIndex;
            var dgv = dgvExtraTime;
            var cellData = dgv.Rows[rowIdx].Cells[4].Value;
            int textLengh = dgv.Rows[rowIdx].Cells[4].Value.ToString().Length;

            if (!string.IsNullOrEmpty(cellData.ToString()))
            {
                if (textLengh == 1)
                    dgv.Rows[rowIdx].Cells[colIdx].Value = "0" + cellData.ToString() + ":00";
                if (textLengh == 3)
                    dgv.Rows[rowIdx].Cells[colIdx].Value = cellData.ToString() + "00";
                if (textLengh == 4)
                {
                    char[] sChar = new char[textLengh];
                    sChar = cellData.ToString().ToCharArray();
                    for (int i = 0; i < textLengh; i++)
                        dgv.Rows[rowIdx].Cells[colIdx].Value = "0" + sChar[0].ToString() + ":" + sChar[1].ToString() + sChar[3].ToString();
                }
                if (cellData.ToString().ToLower().Contains(':'))
                {
                    string[] cellSplit = dgv.Rows[rowIdx].Cells[colIdx].Value.ToString().Split(':');
                    if (int.Parse(cellSplit[1].ToString()) >= 60)
                    {
                        MessageBox.Show("Chuoi nhap sai");
                        SendKeys.Send("{UP}");
                    }
                }
                else
                {
                    MessageBox.Show("Chuoi nhap sai");
                    SendKeys.Send("{UP}");
                }
            }
        }
        #endregion

        #region//====================  FormDisplay Process ====================//
        private void label1_Click(object sender, EventArgs e)
        {
            fillDadagrid();
        }
        #endregion

        #region//====================  CURD Click ====================//
        private void lblSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvExtraTime.Rows)
            {
                int sMaNV = int.Parse(row.Cells[1].Value.ToString());
                string sExTime = row.Cells[4].Value.ToString();
                foreach (DataRow _time in sExtraTime.Rows)
                {
                    string queryInsertOvertime = String.Format("UPDATE KeeptimeHistory SET ExtraOvertime = '{0}' where MaNV = {1}", sExTime, sMaNV);
                    SqlCommand insertOvertime = new SqlCommand(queryInsertOvertime);
                    ConnectionUtils.ExeCuteNonquery(insertOvertime);
                }
            }
            MessageBox.Show("Update ok!");
        }
        #endregion

        #region//====================  Procedure ====================//
        private void fillDadagrid()
        {
            sExtraOvertime = new List<Entities.ExtraOvertime>();
            Date = cboMonth.Text + "-" + cboYear.Text;

            string query = string.Format("select * from KeeptimeHistory where Date = '{0}'", Date);
            sExtraTime = ConnectionUtils.findAll(query);

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = null;
                sqlConnection = ConnectionUtils.getConnection();
                string snoOvertime = "";

                string queryNhanvien = string.Format("select * from nhanvien");
                SqlCommand cmdNhanvien = new SqlCommand(queryNhanvien, sqlConnection);
                SqlDataReader exeNhanvien = cmdNhanvien.ExecuteReader();
                while (exeNhanvien.Read())
                {
                    foreach (DataRow sOvertime in sExtraTime.Rows)
                    {
                        if (int.Parse(sOvertime["MaNV"].ToString()) == (int)exeNhanvien["MaNV"])
                        {
                            snoOvertime = sOvertime["NumberOfOvertime"].ToString();
                        }
                    }
                    sExtraOvertime.Add(new TinhLuong.Entities.ExtraOvertime()
                    {
                        Date = Date.ToString(),
                        MaNV = (int)exeNhanvien["MaNV"],
                        TenNV = exeNhanvien["Tennhanvien"].ToString(),
                        NumberOvertime = snoOvertime.ToString(),
                        Extratime = "",
                    });
                }
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
            finally
            {
                sqlConnection.Close();
            }
            foreach (TinhLuong.Entities.ExtraOvertime exTime in sExtraOvertime)
            {
                int sMaNV = int.Parse(exTime.MaNV.ToString());
                foreach (DataRow sTime in sExtraTime.Rows)
                {
                    if (sTime["MaNV"].ToString() == sMaNV.ToString())
                    {
                        if (sTime["ExtraOvertime"] == DBNull.Value)
                            exTime.Extratime = "00:00";
                        else
                            exTime.Extratime = sTime["ExtraOvertime"].ToString();
                    }
                }
            }
            if (sExtraOvertime.Count > 0)
            {
                dgvExtraTime.AutoGenerateColumns = false;
                dgvExtraTime.DataSource = null;
                dgvExtraTime.DataSource = sExtraOvertime;
            }
            dgvExtraTime.Rows[0].Cells[4].Selected = true;
        }
        protected void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.MaxLength = 5;
            if (tb.Text.Length == 2 && sKey == false && !tb.Text.EndsWith(":"))
            {
                SendKeys.Send(":");
                sKey = true;
            }
        }
        private void ColumnKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }

            if (e.KeyChar == 8)
            {
                sKey = true;
                if (tb.Text.EndsWith("0") && tb.Text.EndsWith("1") && tb.Text.EndsWith("2") && tb.Text.EndsWith("3") && tb.Text.EndsWith("4")
                && tb.Text.EndsWith("5") && tb.Text.EndsWith("6") && tb.Text.EndsWith("7") && tb.Text.EndsWith("8") && tb.Text.EndsWith("9")
                && tb.Text.EndsWith(":"))
                    SendKeys.Send("{BACKSPACE}");
            }
            if (e.KeyChar != 8)
                sKey = false;
        }
        #endregion
    }
}
