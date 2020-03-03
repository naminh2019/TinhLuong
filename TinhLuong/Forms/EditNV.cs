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

namespace TinhLuong
{
    public partial class EditNV : Form
    {
        public EditNV()
        {
            InitializeComponent();
        }
        public EditNV(string sEdit, int MaNV)
        {
            InitializeComponent();
            this.sEdit = sEdit;
            this.MaNV = MaNV;
        }

        #region //==================== Declare variable ====================// 
        string sEdit;
        int MaNV = 0;
        Boolean sKey = false;
        #endregion

        #region //==================== Form Open & Close ====================// 
        private void EditNV_Load(object sender, EventArgs e)
        {
            string query = string.Format("select * from nhanvien");
            DataTable nhanvien = ConnectionUtils.findAll(query);

            string queryNV = string.Format("select * from Nhomviec");
            DataTable nhomviec = ConnectionUtils.findAll(queryNV);
            if (nhanvien.Rows.Count > 0)
            {
                cboWorkID.DataSource = null;
                cboWorkID.DisplayMember = "Nhomviec";
                cboWorkID.ValueMember = "MaCV";
                cboWorkID.DataSource = nhomviec;
            }
            cboInsurance.Items.Add("Không bảo hiểm ");
            cboInsurance.Items.Add("Có bảo hiểm");

            if (sEdit.Trim() == "NEW")
            {
                lblLetterHead.Text = "NHẬP MỚI THÔNG TIN NHÂN VIÊN";
                for (int i = 0; i < nhanvien.Rows.Count; i++)
                {
                    foreach (DataRow sMaNV in nhanvien.Rows)
                    {
                        if (i != int.Parse(sMaNV["MaNV"].ToString()))
                        {
                            MaNV = i + 1;
                            cboWorkID.SelectedIndex = -1;
                            txtInMorning.Text = "00:00:00";
                            txtOutMorning.Text = "00:00:00";
                            txtInAfternoon.Text = "00:00:00";
                            txtOutAfternoon.Text = "00:00:00";
                            txtInsuranceSalary.Text = "0";
                            txtMothlySalary.Text = "0";
                            txtHeso.Text = "0";
                            break;
                        }
                    }
                }
                this.lblMaNV.Text = MaNV.ToString();
               

            }
            else
            {
                lblLetterHead.Text = "SỬA THÔNG TIN NHÂN VIÊN";
                foreach (DataRow sMaNV in nhanvien.Rows)
                {
                    if (int.Parse(sMaNV["MaNV"].ToString()) == MaNV)
                    {
                        lblMaNV.Text = sMaNV["MaNV"].ToString();
                        txtTenNV.Text = sMaNV["Tennhanvien"].ToString();
                        txtBirthDate.Text = sMaNV["Namsinh"].ToString().Trim();
                        txtAddress.Text = sMaNV["Diachi"].ToString().Trim();
                        txtPhone.Text = sMaNV["Dienthoai"].ToString().Trim();
                        txtIDcard.Text = sMaNV["soCMND"].ToString().Trim();
                        txtIssuedby.Text = sMaNV["Noicap"].ToString().Trim();
                        txtInsuranceSalary.Text = int.Parse(sMaNV["luongBH"].ToString()).ToString("###,###,###");
                        txtMothlySalary.Text = int.Parse(sMaNV["luongthucte"].ToString()).ToString("###,###,###");
                        txtYearAtWork.Text = sMaNV["YearAtWork"].ToString();
                        txtHeso.Text = sMaNV["OvertimeCoefficient"].ToString();
                        txtInMorning.Text = sMaNV["InMorning"].ToString();
                        txtOutMorning.Text = sMaNV["OutMorning"].ToString();
                        txtInAfternoon.Text = sMaNV["InAfternoon"].ToString();
                        txtOutAfternoon.Text = sMaNV["OutAfternoon"].ToString();
                        cboInsurance.Text = sMaNV["chedoBH"].ToString();
                        cboWorkID.SelectedValue = sMaNV["MaCV"].ToString();
                        if (Convert.ToBoolean(sMaNV["chedoBH"]) == true)
                            cboInsurance.SelectedIndex = 1;
                        else
                            cboInsurance.SelectedIndex = 0;
                    }
                }
            }
            txtInAfternoon.Focus();
            SendKeys.Send("{TAB}");
            OnMouseEnter(e);
            OnMouseLeave(e);
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region //==================== Control Process ====================// 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            txtInMorning.Enter += new EventHandler(TextboxGetFocus);
            txtOutMorning.Enter += new EventHandler(TextboxGetFocus);
            txtInAfternoon.Enter += new EventHandler(TextboxGetFocus);
            txtOutAfternoon.Enter += new EventHandler(TextboxGetFocus);
            txtInMorning.Leave += new EventHandler(TextboxLeaveFocus);
            txtOutMorning.Leave += new EventHandler(TextboxLeaveFocus);
            txtInAfternoon.Leave += new EventHandler(TextboxLeaveFocus);
            txtOutAfternoon.Leave += new EventHandler(TextboxLeaveFocus);

            txtInMorning.KeyPress += new KeyPressEventHandler(TextboxKeyPress);
            txtOutMorning.KeyPress += new KeyPressEventHandler(TextboxKeyPress);
            txtInAfternoon.KeyPress += new KeyPressEventHandler(TextboxKeyPress);
            txtOutAfternoon.KeyPress += new KeyPressEventHandler(TextboxKeyPress);
            txtInMorning.TextChanged += new EventHandler(texboxTextChange);
            txtOutMorning.TextChanged += new EventHandler(texboxTextChange);
            txtInAfternoon.TextChanged += new EventHandler(texboxTextChange);
            txtOutAfternoon.TextChanged += new EventHandler(texboxTextChange);

            txtYearAtWork.KeyPress += new KeyPressEventHandler(TextboxKeyPress);
            txtYearAtWork.TextChanged += new EventHandler(texboxTextChange);

            txtMothlySalary.Leave += new EventHandler(TextboxLeaveFocus);
            txtInsuranceSalary.Leave += new EventHandler(TextboxLeaveFocus);
            txtMothlySalary.KeyPress += new KeyPressEventHandler(TextboxKeyPress);
            txtInsuranceSalary.KeyPress += new KeyPressEventHandler(TextboxKeyPress);

            txtYearAtWork.KeyPress += new KeyPressEventHandler(TextboxKeyPress);
            txtBirthDate.KeyPress += new KeyPressEventHandler(TextboxKeyPress);

            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            lblSave.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblSave.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);

            base.OnMouseLeave(e);
        }
        private void cboWorkID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cboInsurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region //==================== CURD Button Click ====================// 
        private void lblSave_Click(object sender, EventArgs e)
        {
            DateTime dDate;
            Boolean missValue = false;
            Boolean errorValue = false;
            string[] sInM = txtInMorning.Text.ToString().Split(':');
            string[] sOutM = txtOutMorning.Text.ToString().Split(':');
            string[] sInA = txtInAfternoon.Text.ToString().Split(':');
            string[] sOutA = txtOutAfternoon.Text.ToString().Split(':');

            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);

            foreach (Control nullValue in Controls)
            {
                if (nullValue is TextBox || nullValue is ComboBox)
                {
                    if (nullValue.Text == "" || nullValue.Text == "0" || nullValue.Text == "00:00:00")
                    {
                        if (nullValue.Name != "txtHeso")
                        {
                            nullValue.BackColor = Color.Yellow;
                            missValue = true;
                        }
                    }
                    if (nullValue.Text != "" && nullValue.Text != "0" && nullValue.Text != "00:00:00")
                        nullValue.BackColor = Color.White;
                }

                if (nullValue == txtInMorning || nullValue == txtOutMorning || nullValue == txtInAfternoon || nullValue == txtOutAfternoon || nullValue == txtYearAtWork)
                {
                    if (DateTime.TryParse(nullValue.Text.ToString(), out dDate))
                    {
                        nullValue.ForeColor = Color.Black;
                    }
                    else
                    {
                        nullValue.ForeColor = Color.Red;
                        nullValue.Focus();
                        errorValue = true;
                    }
                }
            }
            if (missValue == true)
            {
                MessageBox.Show("Nhập thiếu mấy chổ màu vàng");
                return;
            }
            if (errorValue == true)
            {
                MessageBox.Show("Mấy chổ màu đỏ bị sai");
                return;
            }

            int sMaNV = int.Parse(lblMaNV.Text.Trim());
            string sName = txtTenNV.Text.Trim();
            int sBirthday = int.Parse(txtBirthDate.Text.ToString());
            string sAddress = txtAddress.Text.Trim();
            string sPhone = txtPhone.Text.Trim();
            string sIDcard = txtIDcard.Text.Trim();
            string sIssuedby = txtIssuedby.Text.Trim();
            int sInsuranceSalary = int.Parse(txtInsuranceSalary.Text.ToString().Replace(".", ""));
            int sMonthlySalary = int.Parse(txtMothlySalary.Text.ToString().Replace(".", ""));
            string sYeatAtWork = txtYearAtWork.Text.Trim();
            int Heso = int.Parse(txtHeso.Text.ToString());
            int sWorkID = int.Parse(cboWorkID.SelectedValue.ToString());
            int sInsurance = cboInsurance.SelectedIndex;
            TimeSpan sInMorning = new TimeSpan(int.Parse(sInM[0]), int.Parse(sInM[1]), int.Parse(sInM[2]));
            TimeSpan sOutMorning = new TimeSpan(int.Parse(sOutM[0]), int.Parse(sOutM[1]), int.Parse(sOutM[2]));
            TimeSpan sInAfternoon = new TimeSpan(int.Parse(sInA[0]), int.Parse(sInA[1]), int.Parse(sInA[2]));
            TimeSpan sOutAfternoon = new TimeSpan(int.Parse(sOutA[0]), int.Parse(sOutA[1]), int.Parse(sOutA[2]));

            try
            {
                sqlConnection.Open();
                if (sEdit == "NEW")
                {
                    string query = String.Format(" INSERT INTO Nhanvien(MaNV, Tennhanvien, Namsinh, Diachi, Dienthoai, soCMND, Noicap, MaCV," +
                                                 " LuongBH, Luongthucte, ChedoBH, YearAtWork, InMorning, OutMorning, InAfternoon, OutAfternoon, OvertimeCoefficient)" +
                                                 " VALUES ({0}, N'{1}',{2}, N'{3}', '{4}', '{5}', N'{6}', {7}, {8}, {9}, {10}, '{11}', '{12}', '{13}', '{14}', '{15}', {16})" +
                                                 " ", sMaNV, sName, sBirthday, sAddress, sPhone, sIDcard, sIssuedby, sWorkID, sInsuranceSalary, sMonthlySalary,
                                                    sInsurance, sYeatAtWork, sInMorning, sOutMorning, sInAfternoon, sOutAfternoon, Heso);

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    Int32 kq = sqlCommand.ExecuteNonQuery();

                    foreach (Control containValue in Controls)
                    {
                        if (containValue is TextBox || containValue is ComboBox)
                            containValue.Text = "";
                        if (containValue == txtInMorning || containValue == txtOutMorning || containValue == txtInAfternoon || containValue == txtOutAfternoon)
                            containValue.Text = "00:00:00";
                    }
                    sMaNV = sMaNV + 1;
                    lblMaNV.Text = sMaNV.ToString();
                    txtMothlySalary.Text = "0";
                    txtInsuranceSalary.Text = "0";
                    txtTenNV.Focus();
                    MessageBox.Show("Create successful!");
                }
                else
                {
                    MessageBox.Show("Chưa có code Edit nhân viên");
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Loi" + ex.Message);
                MessageBox.Show("Loi" + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        #endregion

        #region //==================== Procedure ====================// 
        private void TextboxGetFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "00:00:00")
                tb.Text = "";
        }
        private void TextboxLeaveFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == txtInsuranceSalary || tb == txtMothlySalary)
            {
                if (tb.Text != "")
                {
                    tb.Text = string.Format("{0:#,##0}", double.Parse(tb.Text));
                    return;
                }
            }
            if (tb.Text == "")
                tb.Text = "00:00:00";
        }
        private void texboxTextChange(object sender, EventArgs e)
        {
            TextBox cTextbox = sender as TextBox;
            if (cTextbox == txtYearAtWork)
            {
                cTextbox.MaxLength = 7;
                if (cTextbox.Text.Length == 2 && sKey == false && !cTextbox.Text.EndsWith("-"))
                {
                    SendKeys.Send("-");
                    sKey = true;
                }
            }
            else
            {
                cTextbox.MaxLength = 8;
                if (cTextbox.Text.Length == 2 && sKey == false && !cTextbox.Text.EndsWith(":"))
                {
                    SendKeys.Send(":");
                    sKey = true;
                }
                if (cTextbox.Text.Length == 5 && sKey == false && !cTextbox.Text.EndsWith(":"))
                {
                    SendKeys.Send(":");
                    sKey = true;
                }
            }
        }
        private void TextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox pressTexbox = sender as TextBox;

            if (pressTexbox == txtInMorning || pressTexbox == txtOutMorning || pressTexbox == txtInAfternoon || pressTexbox == txtOutAfternoon || pressTexbox == txtYearAtWork)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 8)
                {
                    sKey = true;
                    if (pressTexbox.Text.EndsWith("0") && pressTexbox.Text.EndsWith("1") && pressTexbox.Text.EndsWith("2") && pressTexbox.Text.EndsWith("3")
                        && pressTexbox.Text.EndsWith("4") && pressTexbox.Text.EndsWith("5") && pressTexbox.Text.EndsWith("6") && pressTexbox.Text.EndsWith("7")
                        && pressTexbox.Text.EndsWith("8") && pressTexbox.Text.EndsWith("9") && pressTexbox.Text.EndsWith(":") && pressTexbox.Text.EndsWith("-"))
                        SendKeys.Send("{BACKSPACE}");
                }
                if (e.KeyChar != 8)
                    sKey = false;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

    }
}