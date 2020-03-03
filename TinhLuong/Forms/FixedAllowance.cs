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
    public partial class FixedAllowance : Form
    {
        public FixedAllowance()
        {
            InitializeComponent();
        }

        #region //==================== Declare variable ====================//

        Boolean NEW = false;
        int ITEMID = -1;
        int PSITEMID = -1;
        bool select = true;
        int rowIndex = 0;
        int NVcount = 0;
        Boolean check = false;
        string sDate;
        int Manhanvien = -1;
        List<Salary.SalaryHistory> HistorybyMonth = new List<Salary.SalaryHistory>();
        List<Salary.Allowance> allAllowance = new List<Salary.Allowance>();
        List<Salary.ProductSalary> allProdSalary = new List<Salary.ProductSalary>();
        List<Salary.Deduct> allDeduct = new List<Salary.Deduct>();
        List<Salary.Deduct> sDeductPay = null;
        HashSet<int> distNhanvien = new HashSet<int>();

        #endregion

        #region //==================== Form Open & Close ====================//
        private void FixedAllowance_Load(object sender, EventArgs e)
        {
            string query = string.Format("select * from nhanvien");
            DataTable nhanvien = ConnectionUtils.findAll(query);
            NVcount = nhanvien.Rows.Count - 1;
            foreach (DataRow newNV in nhanvien.Rows)
            {
                int newMNV = int.Parse(newNV["MaNV"].ToString());
                string queryFIX = string.Format("select * from FixedAllowance");
                DataTable FixAll = ConnectionUtils.findAll(queryFIX);

                DataRow findMNV = FixAll.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["MaNV"]) == newMNV); //tìm kiếm
                if (findMNV == null)
                {
                    string queryAllowanceSalary = string.Format("select * from AllowanceSalary where CodeEdit = 0");
                    DataTable AllowanceSalary = ConnectionUtils.findAll(queryAllowanceSalary);
                    foreach (DataRow Als in AllowanceSalary.Rows)
                    {
                        int AllowanceID = int.Parse(Als["AllowanceID"].ToString());

                        string queryNewFIX = String.Format("INSERT INTO FixedAllowance(MaNV, AllowanceID, Money)" +
                                                      " VALUES({0}, {1}, {2})", newMNV, AllowanceID, 0);
                        SqlCommand insertNewFIX = new SqlCommand(queryNewFIX);
                        ConnectionUtils.ExeCuteNonquery(insertNewFIX);
                    }
                }
            }

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

            cboYear.BackColor = Color.White;
            cboMonth.BackColor = Color.White;

            foreach (DataRow sNhanvien in nhanvien.Rows)
            {
                int sMaNV = int.Parse(sNhanvien["MaNV"].ToString());
                distNhanvien.Add(sMaNV);
            }

            if (NVcount > 0)
            {
                cboNhanvien.DataSource = null;
                cboNhanvien.DisplayMember = "Tennhanvien";
                cboNhanvien.ValueMember = "MaNV";
                cboNhanvien.DataSource = nhanvien;
                cboNhanvien.SelectedIndex = 0;
            }

            panel1.Size = new Size(310, 185);
            panel1.Location = new Point(400, 290);
            panel1.BackColor = Color.Maroon;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Visible = false;

            panel3.Location = new Point(440, 290);
            panel3.Size = new Size(245, 170);
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Visible = false;

            panel4.Size = new Size(320, 225);
            panel4.Location = new Point(397, 275);
            panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel4.Visible = false;
            cboNhanvien.BackColor = Color.White;

            panel5.Location = new Point(440, 290);
            panel5.Size = new Size(245, 170);
            panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel5.Visible = false;

            loadData("Allowance");
            filldagird(0);
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
            lblUpdate.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblNew.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblEdit.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblDelete.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblUpdate.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblNew.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblEdit.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblDelete.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);

            base.OnMouseLeave(e);
        }
        private void FixedAllowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                lblNew_Click(sender, e);
            }
        }
        private void txtPSamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressLimit(sender, e);
        }
        private void txtPSprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressLimit(sender, e);
        }
        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressLimit(sender, e);
        }
        #endregion

        #region //==================== DataContainer Process ====================//
        private void cboNhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            filldagird(0);
        }
        private void SalaryControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboNhanvien.SelectedIndex = 1;
            switch (SalaryControl.SelectedIndex)
            {
                case 0:
                    tabFixed.Controls.Add(panel2);
                    tabFixed.Controls.Add(ButtonPanel);
                    cboNhanvien.SelectedIndex = 0;
                    lblTitle.Text = "PHỤ CẤP CỐ ĐỊNH";
                    label4.ForeColor = Color.White;
                    label7.ForeColor = Color.Brown;
                    label13.ForeColor = Color.Brown;
                    loadData("Allowance");
                    break;
                case 1:
                    tabProduct.Controls.Add(panel2);
                    tabProduct.Controls.Add(ButtonPanel);
                    cboNhanvien.SelectedIndex = 0;
                    lblTitle.Text = "PHỤ CẤP THEO SẢN PHẨM";
                    label4.ForeColor = Color.Brown;
                    label7.ForeColor = Color.White;
                    label13.ForeColor = Color.Brown;
                    loadData("ProdSalary");
                    break;
                case 2:
                    tabDeduction.Controls.Add(panel2);
                    tabDeduction.Controls.Add(ButtonPanel);
                    label4.ForeColor = Color.Brown;
                    label7.ForeColor = Color.Brown;
                    label13.ForeColor = Color.White;
                    lblTitle.Text = "KHẤU TRỪ";
                    cboNhanvien.SelectedIndex = 0;
                    loadData("Deduct");
                    break;
            }
            filldagird(0);
        }
        private void dgvAllowance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = dgvAllowance.CurrentCell.RowIndex;
        }
        private void dgvProductSalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = dgvProductSalary.CurrentCell.RowIndex;
        }
        private void dgvDeduction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = dgvDeduction.CurrentCell.RowIndex;
        }
        private void dgvAllowance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                EnableAllControl(tabFixed, false);
                EnableControlwithName("panel3", true);
                DataGridViewRow row = dgvAllowance.Rows[rowIndex];
                string _ItemName = row.Cells["AllowanceName"].Value.ToString();
                int _Money = int.Parse(row.Cells["Money"].Value.ToString().Trim());
                txtMoney.Text = string.Format("{0:###,###,###}", _Money);
                if (txtMoney.Text == "") txtMoney.Text = "0";
                lblItemname.Text = _ItemName.ToString();
                txtMoney.Focus();
            }
        }
        private void dgvDeduction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                EnableAllControl(tabDeduction, false);
                EnableControlwithName("panel3", true);
                DataGridViewRow row = dgvDeduction.Rows[rowIndex];
                string _ItemName = row.Cells["DeductName"].Value.ToString();
                int _Money = int.Parse(row.Cells["DeductionMoney"].Value.ToString().Trim());
                txtMoney.Text = string.Format("{0:###,###,###}", _Money);
                if (txtMoney.Text == "") txtMoney.Text = "0";
                lblItemname.Text = _ItemName.ToString();
                txtMoney.Focus();
            }
        }
        private void dgvProductSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    EnableAllControl(tabProduct, false);
                    EnableControlwithName("panel5", true);
                    DataGridViewRow row = dgvProductSalary.Rows[rowIndex];
                    string _ItemName = row.Cells["ProdSalaryName"].Value.ToString();

                    txtPSamount.Text = "0";
                    label11.Text = _ItemName.ToString().Trim();
                    txtPSamount.Focus();
                }
            }
        }
        #endregion

        #region //==================== FormDiplay Process ====================//
        private void btnView_Click(object sender, EventArgs e)
        {
            HistorybyMonth.Clear();
            switch (SalaryControl.SelectedIndex)
            {
                case 0:
                    cboNhanvien.SelectedIndex = 0;
                    loadData("Allowance");
                    break;
                case 1:
                    cboNhanvien.SelectedIndex = 0;
                    loadData("ProdSalary");
                    break;
                case 2:
                    cboNhanvien.SelectedIndex = 0;
                    loadData("Deduct");
                    break;
            }
            filldagird(0);
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (cboNhanvien.SelectedIndex == 0)
                return;
            cboNhanvien.SelectedIndex = cboNhanvien.SelectedIndex - 1;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cboNhanvien.SelectedIndex == NVcount)
                return;
            cboNhanvien.SelectedIndex = cboNhanvien.SelectedIndex + 1;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            SalaryControl.SelectedIndex = 0;
        }
        private void label7_Click(object sender, EventArgs e)
        {
            SalaryControl.SelectedIndex = 1;
        }
        private void label13_Click(object sender, EventArgs e)
        {
            SalaryControl.SelectedIndex = 2;
        }
        #endregion

        #region //==================== CURD Button Click ====================//
        private void lblNew_Click(object sender, EventArgs e)
        {
            if (SalaryControl.SelectedIndex == 0) // Allowance Item btnNew_Click
            {
                lblName.Text = "THÊM HẠNG MỤC PHỤ CẤP";

                DataTable maxID = ConnectionUtils.findAll("SELECT max(AllowanceID) FROM AllowanceSalary");
                ITEMID = int.Parse(maxID.Rows[0][0].ToString());
                ITEMID = ITEMID + 1;

                EnableAllControl(tabFixed, false);
                EnableControlwithName("panel1", true);

                txtID.Text = ITEMID.ToString();
                txtNew.Text = "";
                txtNew.Focus();
            }
            if (SalaryControl.SelectedIndex == 1) // Product Salary btnNew_click
            {
                DataTable maxID = ConnectionUtils.findAll("SELECT max(SAprodID) FROM ProductSalary");
                ITEMID = int.Parse(maxID.Rows[0][0].ToString());
                ITEMID = ITEMID + 1;

                EnableAllControl(tabProduct, false);
                EnableControlwithName("panel4", true);

                txtPSID.Text = ITEMID.ToString();
                txtPSname.Text = "";
                txtPSprice.Text = "";
                txtPSname.Focus();
            }
            if (SalaryControl.SelectedIndex == 2) // Deductions Pay btnNew_click
            {
                DataTable maxID = ConnectionUtils.findAll("SELECT max(DeductID) FROM DeductionsPay");
                ITEMID = int.Parse(maxID.Rows[0][0].ToString());
                ITEMID = ITEMID + 1;

                EnableAllControl(tabProduct, false);
                EnableControlwithName("panel1", true);

                txtID.Text = ITEMID.ToString();
                txtNew.Text = "";
                txtNew.Focus();
            }
            NEW = true;
        }
        private void lblEdit_Click(object sender, EventArgs e)
        {
            if (SalaryControl.SelectedIndex == 0) // Allowance Item btnEdit_Click
            {
                lblName.Text = "SỬA HẠNG MỤC PHỤ CẤP";
                DataGridViewRow row = dgvAllowance.Rows[rowIndex];
                int _AllowanceID = int.Parse(row.Cells["AllowanceID"].Value.ToString());
                string _ItemName = row.Cells["AllowanceName"].Value.ToString();

                EnableAllControl(tabFixed, false);
                EnableControlwithName("panel1", true);

                txtID.Text = _AllowanceID.ToString();
                txtNew.Text = _ItemName;
                txtNew.Focus();
            }
            if (SalaryControl.SelectedIndex == 1) // Product Salary btnEdit_Click
            {
                DataGridViewRow row = dgvProductSalary.Rows[rowIndex];
                int _AllowanceID = int.Parse(row.Cells["IDProdsalary"].Value.ToString());
                string _ItemName = row.Cells["ProdSalaryName"].Value.ToString();
                int _ItemPrice = int.Parse(row.Cells["ProdSalaryPrice"].Value.ToString().Replace(".", String.Empty));

                EnableAllControl(tabProduct, false);
                EnableControlwithName("panel4", true);

                txtPSID.Text = _AllowanceID.ToString();
                txtPSname.Text = _ItemName.ToString();
                txtPSprice.Text = _ItemPrice.ToString();
                txtPSname.Focus();
            }
            if (SalaryControl.SelectedIndex == 2) // Deductions Pay btnEdit_click
            {
                lblName.Text = "SỬA HẠNG MỤC KHẤU TRỪ";
                DataGridViewRow row = dgvDeduction.Rows[rowIndex];
                int DeductionID = int.Parse(row.Cells["DeductID"].Value.ToString());
                string DeductionName = row.Cells["DeductName"].Value.ToString();

                EnableAllControl(tabFixed, false);
                EnableControlwithName("panel1", true);

                txtID.Text = DeductionID.ToString();
                txtNew.Text = DeductionName;
                txtNew.Focus();
            }
        }
        /******************** Save Alowance Item ********************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNew.Text.ToString().Trim() == "")
            {
                MessageBox.Show("chua co ten");
                return;
            }

            String _itemName = txtNew.Text.Trim().ToLower().ToString();
            string newitemName = convertToUnSign3(_itemName);
            newitemName = newitemName.Replace(" ", String.Empty);

            string queryName = String.Format("select * from DeductionsPay DP" +
                                             " full outer join AllowanceSalary SA on SA.AllowanceID = DP.DeductID");
            DataTable nameDB = ConnectionUtils.findAll(queryName);
            String AllowanceBDName = null;
            String DeductBDName = null;

            ITEMID = int.Parse(txtID.Text.ToString());
            string ItemName = txtNew.Text.ToString().Trim();

            foreach (DataRow s_name in nameDB.Rows)
            {
                string sAllowanceBDName = s_name["AllowanceName"].ToString().ToLower().Trim();
                string sDeductBDName = s_name["DeductName"].ToString().ToLower().Trim();

                AllowanceBDName = convertToUnSign3(sAllowanceBDName);
                AllowanceBDName = AllowanceBDName.Replace(" ", String.Empty);

                DeductBDName = convertToUnSign3(sDeductBDName);
                DeductBDName = DeductBDName.Replace(" ", String.Empty);
            }

            if (SalaryControl.SelectedIndex == 0) // Save Allowance Item
            {
                if (newitemName.CompareTo(AllowanceBDName) == 0)
                {
                    MessageBox.Show("trung");
                    return;
                }
                if (NEW == true)
                {
                    string queryNItem = String.Format(" INSERT INTO AllowanceSalary(AllowanceID, AllowanceName, CodeEdit) VALUES({0}, N'{1}', {2}) ", ITEMID, ItemName, 0);
                    SqlCommand nItems = new SqlCommand(queryNItem);
                    ITEMID = int.Parse(txtID.Text.ToString()) + 1;
                    ConnectionUtils.ExeCuteNonquery(nItems);

                    DataTable outOfItem = ConnectionUtils.findAll("SELECT * FROM AllowanceSalary WHERE AllowanceSalary.AllowanceID NOT In(SELECT distinct(AllowanceID) FROM FixedAllowance)");
                    foreach (int sMaNV in distNhanvien)
                    {
                        for (int j = 0; j < outOfItem.Rows.Count; j++)
                        {
                            int sAllowanceID = int.Parse(outOfItem.Rows[j][0].ToString());
                            string queryAdd = String.Format("INSERT INTO FixedAllowance(MaNV, AllowanceID, money) VALUES({0}, {1}, {2}) ", sMaNV, sAllowanceID, 0);
                            SqlCommand AddFixAllowance = new SqlCommand(queryAdd);
                            ConnectionUtils.ExeCuteNonquery(AddFixAllowance);
                        }
                    }
                    ITEMID++;
                }
                else
                {
                    DataGridViewRow row = dgvAllowance.Rows[rowIndex];
                    string queryEItem = String.Format("Update AllowanceSalary set AllowanceName = N'{0}', CodeEdit = {1} where  AllowanceID =  {2} ", ItemName, 0, ITEMID);
                    SqlCommand eItems = new SqlCommand(queryEItem);
                    ConnectionUtils.ExeCuteNonquery(eItems);
                    EnableAllControl(tabFixed, true);
                    EnableControlwithName("panel1", false);
                }
                allAllowance.Clear();
                loadData("Allowance");
            }
            if (SalaryControl.SelectedIndex == 2) // Save Deduct Item
            {
                if (newitemName.CompareTo(DeductBDName) == 0)
                {
                    MessageBox.Show("trung");
                    return;
                }
                if (NEW == true)
                {
                    string queryNItem = String.Format(" INSERT INTO DeductionsPay(DeductID, DeductName, CodeEdit) VALUES({0}, N'{1}', {2}) ", ITEMID, ItemName, 0);
                    SqlCommand nItems = new SqlCommand(queryNItem);
                    ITEMID = int.Parse(txtID.Text.ToString()) + 1;
                    ConnectionUtils.ExeCuteNonquery(nItems);
                    ITEMID++;
                }
                else
                {
                    DataGridViewRow row = dgvAllowance.Rows[rowIndex];
                    string queryEItem = String.Format("Update DeductionsPay set DeductName = N'{0}', CodeEdit = {1} where  DeductID =  {2} ", ItemName, 0, ITEMID);
                    SqlCommand eItems = new SqlCommand(queryEItem);
                    ConnectionUtils.ExeCuteNonquery(eItems);
                    EnableAllControl(tabDeduction, true);
                    EnableControlwithName("panel1", false);
                }
                allDeduct.Clear();
                loadData("Deduct");
            }
            txtID.Text = ITEMID.ToString();
            txtNew.Text = "";
            txtNew.Focus();
            filldagird(rowIndex);
        }
        private void btnSAProdSave_Click(object sender, EventArgs e)  //
        {
            if (txtPSname.Text.ToString().Trim() == "")
            {
                MessageBox.Show("chua co ten");
                return;
            }
            if (txtPSprice.Text.Trim() == "")
            {
                MessageBox.Show("chua co gia");
                return;
            }

            String _itemName = txtPSname.Text.Trim().ToLower().ToString();
            string newitemName = convertToUnSign3(_itemName);
            newitemName = newitemName.Replace(" ", String.Empty);

            string queryName = String.Format("select * from ProductSalary");
            DataTable nameDB = ConnectionUtils.findAll(queryName);

            foreach (DataRow s_name in nameDB.Rows)
            {
                string _itemNameDB = s_name["SAprodName"].ToString().ToLower().Trim();
                string itemNameDB = convertToUnSign3(_itemNameDB);
                itemNameDB = itemNameDB.Replace(" ", String.Empty);
                if (newitemName.CompareTo(itemNameDB) == 0)
                {
                    MessageBox.Show("trung");
                    return;
                }
            }

            PSITEMID = int.Parse(txtPSID.Text.ToString());
            string PSname = txtPSname.Text.ToString().Trim();
            int PSprice = int.Parse(txtPSprice.Text.ToString());

            if (NEW == true)
            {
                string queryPSItem = String.Format(" INSERT INTO ProductSalary(SAprodID, SAprodName, SAprodPrice) VALUES({0}, N'{1}', {2}) ", PSITEMID, PSname, PSprice);
                SqlCommand newItems = new SqlCommand(queryPSItem);
                ConnectionUtils.ExeCuteNonquery(newItems);

                foreach (int sMaNV in distNhanvien)
                {
                    allProdSalary.Add(new Salary.ProductSalary()
                    {
                        MaNV = (int)sMaNV,
                        PrSalaryID = (int)PSITEMID,
                        PrSalaryName = PSname,
                        PrSalaryPrice = (int)PSprice,
                        PrSalaryAmount = (int)0,
                        PrSalaryTotal = (int)0,
                    });
                }
                txtPSID.Text = (PSITEMID + 1).ToString();
                txtPSname.Text = "";
                txtPSprice.Text = "0";
            }
            else
            {
                string queryEItem = String.Format("Update ProductSalary set SAprodName = N'{0}', SAprodPrice = {1} where  SAprodID =  {2} ", PSname, PSprice, PSITEMID);
                SqlCommand eItems = new SqlCommand(queryEItem);
                ConnectionUtils.ExeCuteNonquery(eItems);

                foreach (Salary.ProductSalary Ps in allProdSalary)
                {
                    if (Ps.PrSalaryID == PSITEMID)
                    {
                        Ps.PrSalaryName = PSname;
                        Ps.PrSalaryPrice = PSprice;
                    }
                }
                EnableAllControl(tabProduct, true);
                EnableControlwithName("panel4", false);
                filldagird(rowIndex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)// Allowance Item
        {
            EnableAllControl(tabFixed, true);
            EnableControlwithName("panel1", false);
            filldagird(rowIndex);
            NEW = false;
        }
        /******************** Save Product Salary ********************/
        private void btnPScancel_Click(object sender, EventArgs e) //Product Salary
        {
            EnableAllControl(tabProduct, true);
            EnableControlwithName("panel4", false);
            filldagird(rowIndex);
            NEW = false;
        }
        private void btnMoneyOK_Click(object sender, EventArgs e)
        {
            if (txtMoney.Text == "")
            {
                MessageBox.Show("Số tiền không được trống. Vui lòng nhập số tiền. ");
                return;
            }
            if (SalaryControl.SelectedIndex == 0)
            {
                DataGridViewRow row = dgvAllowance.Rows[rowIndex];
                int _AllowanceID = int.Parse(row.Cells["AllowanceID"].Value.ToString());
                int _Money = int.Parse(txtMoney.Text.ToString().Replace(".", String.Empty));

                string queryEMoney = String.Format("Update FixedAllowance set money = {0} where  MaNV = {1} and AllowanceID =  {2} ", _Money, Manhanvien, _AllowanceID);
                SqlCommand eMoney = new SqlCommand(queryEMoney);
                ConnectionUtils.ExeCuteNonquery(eMoney);

                string queryHSdelete = String.Format("delete from SalaryHistory where Date = '{0}' and MaNV = {1} and AllowanceID = {2}", sDate, Manhanvien, _AllowanceID);
                SqlCommand HSdelete = new SqlCommand(queryHSdelete);
                ConnectionUtils.ExeCuteNonquery(HSdelete);

                EnableAllControl(tabFixed, true);
                EnableControlwithName("panel3", false);
                loadData("Allowance");
                filldagird(rowIndex);
            }
            if (SalaryControl.SelectedIndex == 2)
            {
                DataGridViewRow row = dgvDeduction.Rows[rowIndex];
                int ddID = int.Parse(row.Cells["DeductID"].Value.ToString());
                string ddName = row.Cells["DeductName"].Value.ToString();
                int ddMoney = int.Parse(txtMoney.Text.ToString().Replace(".", String.Empty));

                foreach (Salary.Deduct ddA in allDeduct)
                {
                    if (ddA.MaNV == Manhanvien && ddA.DeductID == ddID)
                    {
                        ddA.MaNV = (int)Manhanvien;
                        ddA.DeductID = (int)ddID;
                        ddA.DeductName = ddName.ToString();
                        ddA.DeductMoney = (int)ddMoney;
                    }
                }

                foreach (Salary.Deduct dd in sDeductPay)
                {
                    if (dd.MaNV == Manhanvien && dd.DeductID == ddID)
                    {
                        dd.MaNV = (int)Manhanvien;
                        dd.DeductID = (int)ddID;
                        dd.DeductName = ddName.ToString();
                        dd.DeductMoney = (int)ddMoney;
                    }
                    EnableAllControl(tabDeduction, true);
                    EnableControlwithName("panel3", false);
                    filldagird(rowIndex);
                }
            }
        }
        private void btnMoneyClose_Click(object sender, EventArgs e)
        {
            if (SalaryControl.SelectedIndex == 0)
            {
                EnableAllControl(tabFixed, true);
            }
            if (SalaryControl.SelectedIndex == 2)
            {
                EnableAllControl(tabDeduction, true);
            }
            EnableControlwithName("panel3", false);
        }
        private void btnOKprod_Click(object sender, EventArgs e)
        {
            if (txtPSamount.Text == "")
            {
                MessageBox.Show("Số lượng không được trống. Vui lòng nhập số lượng. ");
                return;
            }
            DataGridViewRow row = dgvProductSalary.Rows[rowIndex];
            int psID = int.Parse(row.Cells["IDProdsalary"].Value.ToString());
            int psAmount = int.Parse(txtPSamount.Text.ToString());

            foreach (Salary.ProductSalary Ps in allProdSalary)
            {
                if (Ps.MaNV == Manhanvien && Ps.PrSalaryID == psID)
                {
                    Ps.PrSalaryAmount = (int)psAmount;
                    Ps.PrSalaryTotal = (int)Ps.PrSalaryPrice * psAmount;
                }
            }
            EnableAllControl(tabProduct, true);
            EnableControlwithName("panel5", false);
            filldagird(rowIndex);
        }
        private void btnCloseProd_Click(object sender, EventArgs e)
        {
            EnableAllControl(tabProduct, true);
            EnableControlwithName("panel5", false);
        }
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            string cDuplicate = null;
            string chkDuplicate = null;

            if (SalaryControl.SelectedIndex == 0)
            {
                foreach (Salary.Allowance Allowance in allAllowance)
                {

                    int sMaNV = int.Parse(Allowance.MaNV.ToString());
                    int sAllowanceID = int.Parse(Allowance.AllowanceID.ToString());
                    int sMoney = int.Parse(Allowance.AllowanceMoney.ToString());
                    chkDuplicate = ("FA" + sDate.Replace("-", String.Empty) + sMaNV.ToString().Trim() + sAllowanceID.ToString().Trim());

                    string queryAllowance = string.Format("select * from SalaryHistory where CheckDuplicate like 'FA%'");
                    DataTable FA = ConnectionUtils.findAll(queryAllowance);
                    foreach (DataRow FAs in FA.Rows)
                    {
                        cDuplicate = FAs["CheckDuplicate"].ToString();
                        if (chkDuplicate.CompareTo(cDuplicate) == 0)
                        {
                            if (check == false)
                            {
                                DialogResult result = MessageBox.Show("Du lieu trung, ban muon xoa?", "Confirmation", MessageBoxButtons.OKCancel);
                                if (result == DialogResult.OK)
                                {
                                    check = true;
                                    string queryDeleteSA = String.Format("delete from SalaryHistory where CheckDuplicate like 'FA%' and Date = '{0}'", sDate);
                                    SqlCommand DeleteSA = new SqlCommand(queryDeleteSA);
                                    ConnectionUtils.ExeCuteNonquery(DeleteSA);
                                }
                                else return;
                            }
                        }
                    }
                    if (sMoney > 0)
                    {
                        string queryInsertSA = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, AllowanceID, money)" +
                                                      " VALUES('{0}', {1}, '{2}', {3}, {4})", chkDuplicate, sMaNV, sDate, sAllowanceID, sMoney);
                        SqlCommand insertSA = new SqlCommand(queryInsertSA);
                        ConnectionUtils.ExeCuteNonquery(insertSA);
                    }
                }
                check = false;
            }

            if (SalaryControl.SelectedIndex == 1)
            {

                foreach (Salary.ProductSalary prSalary in allProdSalary)
                {
                    int sMaNV = int.Parse(prSalary.MaNV.ToString());
                    int sSAprodID = int.Parse(prSalary.PrSalaryID.ToString());
                    int sPrice = int.Parse(prSalary.PrSalaryPrice.ToString());
                    int sAmount = int.Parse(prSalary.PrSalaryAmount.ToString());
                    int sMoney = int.Parse(prSalary.PrSalaryTotal.ToString());
                    chkDuplicate = ("PS" + sDate.Replace("-", String.Empty) + sMaNV.ToString().Trim() + sSAprodID.ToString().Trim());

                    string queryProd = string.Format("select * from SalaryHistory where CheckDuplicate like 'PS%'");
                    DataTable PD = ConnectionUtils.findAll(queryProd);
                    foreach (DataRow PDs in PD.Rows)
                    {
                        cDuplicate = PDs["CheckDuplicate"].ToString();
                        if (chkDuplicate.CompareTo(cDuplicate) == 0)
                        {
                            if (check == false)
                            {
                                DialogResult result = MessageBox.Show("Du lieu trung, ban muon xoa?", "Confirmation", MessageBoxButtons.OKCancel);
                                if (result == DialogResult.OK)
                                {
                                    check = true;
                                    string queryDeletePS = String.Format("delete from SalaryHistory where checkDuplicate like 'PS%' and Date = '{0}'", sDate);
                                    SqlCommand DeletePS = new SqlCommand(queryDeletePS);
                                    ConnectionUtils.ExeCuteNonquery(DeletePS);
                                }
                                else return;
                            }
                        }
                    }
                    if (sMoney > 0)
                    {
                        string queryInsertPS = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, SAprodID, SAprodPrice, SAprodAmount, Money)" +
                                                         " VALUES('{0}', {1}, '{2}', {3}, {4}, {5}, {6})", chkDuplicate, sMaNV, sDate, sSAprodID, sPrice, sAmount, sMoney);
                        SqlCommand insertPS = new SqlCommand(queryInsertPS);
                        ConnectionUtils.ExeCuteNonquery(insertPS);
                    }
                }
                check = false;
            }

            if (SalaryControl.SelectedIndex == 2)
            {
                foreach (Salary.Deduct Deduct in allDeduct)
                {

                    int sMaNV = int.Parse(Deduct.MaNV.ToString());
                    int sDeductID = int.Parse(Deduct.DeductID.ToString());
                    int sMoney = int.Parse(Deduct.DeductMoney.ToString());
                    chkDuplicate = ("DD" + sDate.Replace("-", String.Empty) + sMaNV.ToString().Trim() + sDeductID.ToString().Trim());


                    string queryDeduct = string.Format("select * from SalaryHistory where CheckDuplicate like 'DD%'");
                    DataTable DD = ConnectionUtils.findAll(queryDeduct);
                    foreach (DataRow DDs in DD.Rows)
                    {
                        cDuplicate = DDs["CheckDuplicate"].ToString();

                        if (chkDuplicate.CompareTo(cDuplicate) == 0)
                        {
                            if (check == false)
                            {
                                DialogResult result = MessageBox.Show("Du lieu trung, ban muon xoa?", "Confirmation", MessageBoxButtons.OKCancel);
                                if (result == DialogResult.OK)
                                {
                                    check = true;
                                    string queryDeletePS = String.Format("delete from SalaryHistory where checkDuplicate like 'DD%' and Date = '{0}'", sDate);
                                    SqlCommand DeletePS = new SqlCommand(queryDeletePS);
                                    ConnectionUtils.ExeCuteNonquery(DeletePS);
                                }
                                else return;
                            }
                        }
                    }
                    if (sMoney > 0)
                    {
                        string queryInsertDD = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, DeductID, money)" +
                                                        " VALUES('{0}', {1}, '{2}', {3}, {4})", chkDuplicate, sMaNV, sDate, sDeductID, sMoney);
                        SqlCommand insertDD = new SqlCommand(queryInsertDD);
                        ConnectionUtils.ExeCuteNonquery(insertDD);
                        check = false;
                    }
                }
                check = false;
            }
            MessageBox.Show("Updated!");
        }
        private void lblDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("xoa?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (SalaryControl.SelectedIndex == 0)
                {
                    DataGridViewRow row = dgvAllowance.Rows[rowIndex];
                    int maAllowance = int.Parse(row.Cells["AllowanceID"].Value.ToString());

                    String delItem = String.Format("delete from AllowanceSalary where AllowanceID = {0}", maAllowance);
                    SqlCommand deleleItem = new SqlCommand(delItem);
                    ConnectionUtils.ExeCuteNonquery(deleleItem);

                    String delFixed = String.Format("delete from FixedAllowance where AllowanceID = {0}", maAllowance);
                    SqlCommand deleleFixed = new SqlCommand(delFixed);
                    ConnectionUtils.ExeCuteNonquery(deleleFixed);

                    String delHistory = String.Format("delete from SalaryHistory where Date = '{0}' and MaNV = {1} and AllowanceID = {2}", sDate, Manhanvien, maAllowance);
                    SqlCommand deleleHistory = new SqlCommand(delHistory);
                    ConnectionUtils.ExeCuteNonquery(deleleHistory);

                    allAllowance.Clear();
                    loadData("Allowance");
                    filldagird(rowIndex - 1);
                }
                if (SalaryControl.SelectedIndex == 1)
                {
                    DataGridViewRow row = dgvProductSalary.Rows[rowIndex];
                    int psID = int.Parse(row.Cells["IDProdsalary"].Value.ToString());

                    String delItem = String.Format("delete from ProductSalary where SAprodID = {0}", psID);
                    SqlCommand deleleItem = new SqlCommand(delItem);
                    ConnectionUtils.ExeCuteNonquery(deleleItem);

                    String delHistory = String.Format("delete from SalaryHistory where Date = '{0}' and MaNV = {1} and AllowanceID = {2}", sDate, Manhanvien, psID);
                    SqlCommand deleleHistory = new SqlCommand(delHistory);
                    ConnectionUtils.ExeCuteNonquery(deleleHistory);

                    for (int i = 0; i < allProdSalary.Count; i++)
                    {
                        var itemToRemove = allProdSalary.Find(r => r.PrSalaryID == psID);
                        if (itemToRemove != null)
                            allProdSalary.Remove(itemToRemove);
                    }
                    allProdSalary.Clear();
                    loadData("ProdSalary");
                    filldagird(rowIndex - 1);
                }
                if (SalaryControl.SelectedIndex == 2)
                {
                    DataGridViewRow row = dgvDeduction.Rows[rowIndex];
                    int DedID = int.Parse(row.Cells["DeductID"].Value.ToString());

                    String delDeduct = String.Format("delete from DeductionsPay where DeductID = {0}", DedID);
                    SqlCommand deleleDeduct = new SqlCommand(delDeduct);
                    ConnectionUtils.ExeCuteNonquery(deleleDeduct);

                    String delHistory = String.Format("delete from SalaryHistory where Date = '{0}' and MaNV = {1} and AllowanceID = {2}", sDate, Manhanvien, DedID);
                    SqlCommand deleleHistory = new SqlCommand(delHistory);
                    ConnectionUtils.ExeCuteNonquery(deleleHistory);

                    allDeduct.Clear();
                    loadData("Deduct");
                    filldagird(rowIndex - 1);
                }
            }
        }
        #endregion

        #region //==================== Procedure ====================//
        private String loadData(string dataSQL)
        {
            if (allAllowance.Count > 0)
                allAllowance.Clear();
            if (allProdSalary.Count > 0)
                allProdSalary.Clear();
            if (allDeduct.Count > 0)
                allDeduct.Clear();

            //
            // Lấy dữ liệu từ table SalaryHistory
            //
            sDate = (cboMonth.Text.Trim() + "-" + cboYear.Text.Trim());
            string History = string.Format("SELECT MaNV, IIF(AllowanceID is null, 0,AllowanceID) as AllowanceID," +
                                           " IIF(SAprodID is null, 0, SAprodID) as SAprodID," +
                                           " IIF(DeductID is null, 0, DeductID) as DeductID," +
                                           " IIF(SAprodPrice is null, 0, SAprodPrice) as SAprodPrice," +
                                           " IIF(SAprodAmount is null, 0, SAprodAmount) as SAprodAmount, Money" +
                                           " from SalaryHistory where Date = '{0}' order by MaNV", sDate);

            SqlCommand cmdHistory = new SqlCommand(History, ConnectionUtils.getConnection());
            SqlDataReader exeHistory = cmdHistory.ExecuteReader();

            while (exeHistory.Read())
            {
                HistorybyMonth.Add(new Salary.SalaryHistory()
                {
                    MaNV = (int)exeHistory["MaNV"],
                    AllowanceID = (int)exeHistory["AllowanceID"],
                    SAprodID = (int)exeHistory["SAprodID"],
                    DeductID = (int)exeHistory["DeductID"],
                    SAprodPrice = (int)exeHistory["SAprodPrice"],
                    SAprodAmount = (int)exeHistory["SAprodAmount"],
                    Money = (int)exeHistory["Money"]
                });
            }

            String dataSQLs = null;
            foreach (int sMaNV in distNhanvien)
            {
                //
                //Load data for allAllowance
                //
                if (dataSQL == "Allowance")
                {
                    SqlConnection sqlConnection = null;
                    try
                    {
                        sqlConnection = ConnectionUtils.getConnection();
                        dataSQLs = string.Format("select * from AllowanceSalary SI inner join FixedAllowance FA" +
                                         " on FA.AllowanceID = SI.AllowanceID And SI.CodeEdit = 0 and FA.MaNV = {0}", sMaNV);
                        SqlCommand cmdAllowance = new SqlCommand(dataSQLs, sqlConnection);
                        SqlDataReader exeAllowance = cmdAllowance.ExecuteReader();
                        while (exeAllowance.Read())
                        {
                            allAllowance.Add(new Salary.Allowance()
                            {
                                MaNV = (int)sMaNV,
                                AllowanceID = (int)exeAllowance["AllowanceID"],
                                AllowanceName = exeAllowance["AllowanceName"].ToString(),
                                AllowanceMoney = (int)exeAllowance["Money"],
                            });
                        }
                        if (HistorybyMonth.Count != 0)
                        {
                            foreach (Salary.SalaryHistory Ds in HistorybyMonth)
                            {
                                int MaNVs = int.Parse(Ds.MaNV.ToString());
                                int sAllowanceID = int.Parse(Ds.AllowanceID.ToString());
                                int sMoney = int.Parse(Ds.Money.ToString());
                                foreach (Salary.Allowance sAls in allAllowance)
                                {
                                    if (sAls.MaNV.CompareTo(MaNVs) == 0 && sAls.AllowanceID.CompareTo(sAllowanceID) == 0)
                                        sAls.AllowanceMoney = sMoney;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // báo lỗi
                        throw new Exception("Error");
                    }
                    finally
                    {
                        // cuối cùng đóng kết nối
                        sqlConnection.Close();
                    }

                }
                //
                // Load data for allProdSalary
                //
                if (dataSQL == "ProdSalary")
                {
                    SqlConnection sqlConnection = null;
                    try
                    {
                        // đây là đoạn anh xử lý
                        sqlConnection = ConnectionUtils.getConnection();
                        dataSQLs = string.Format("select * from ProductSalary");
                        SqlCommand cmdProdSalary = new SqlCommand(dataSQLs, sqlConnection);
                        SqlDataReader exeProdSalary = cmdProdSalary.ExecuteReader();

                        while (exeProdSalary.Read())
                        {
                            allProdSalary.Add(new Salary.ProductSalary()
                            {
                                MaNV = (int)sMaNV,
                                PrSalaryID = (int)exeProdSalary["SAprodID"],
                                PrSalaryName = exeProdSalary["SAprodName"].ToString(),
                                PrSalaryPrice = (int)exeProdSalary["SAprodPrice"],
                                PrSalaryAmount = (int)0,
                                PrSalaryTotal = (int)0,
                            });
                        }
                        if (HistorybyMonth.Count != 0)
                        {
                            foreach (Salary.SalaryHistory Ds in HistorybyMonth)
                            {
                                int MaNVs = int.Parse(Ds.MaNV.ToString());
                                int sProdsID = int.Parse(Ds.SAprodID.ToString());
                                int sProdAmount = int.Parse(Ds.SAprodAmount.ToString());
                                int sMoney = int.Parse(Ds.Money.ToString());

                                foreach (Salary.ProductSalary sPrd in allProdSalary)
                                {
                                    if (sPrd.MaNV.CompareTo(MaNVs) == 0 && sPrd.PrSalaryID.CompareTo(sProdsID) == 0)
                                    {
                                        sPrd.PrSalaryAmount = sProdAmount;
                                        sPrd.PrSalaryTotal = sMoney;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // báo lỗi
                        throw new Exception("Error");
                    }
                    finally
                    {
                        // cuối cùng đóng kết nối
                        sqlConnection.Close();
                    }
                }
                //
                //Load data for allDeduct
                //
                if (dataSQL == "Deduct")
                {
                    SqlConnection sqlConnection = null;
                    try
                    {
                        // đây là đoạn anh xử lý
                        sqlConnection = ConnectionUtils.getConnection();
                        dataSQLs = string.Format("select * from DeductionsPay where CodeEdit = 0");
                        SqlCommand cmdDeductionsPay = new SqlCommand(dataSQLs, sqlConnection);
                        SqlDataReader exeDeductionsPay = cmdDeductionsPay.ExecuteReader();
                        while (exeDeductionsPay.Read())
                        {
                            allDeduct.Add(new Salary.Deduct()
                            {
                                MaNV = (int)sMaNV,
                                DeductID = (int)exeDeductionsPay["DeductID"],
                                DeductName = exeDeductionsPay["DeductName"].ToString(),
                                DeductMoney = (int)0,
                            });
                        }
                        if (HistorybyMonth.Count != 0)
                        {
                            foreach (Salary.SalaryHistory Ds in HistorybyMonth)
                            {
                                int MaNVs = int.Parse(Ds.MaNV.ToString());
                                int sDeductID = int.Parse(Ds.DeductID.ToString());
                                int sMoney = int.Parse(Ds.Money.ToString());

                                foreach (Salary.Deduct sDed in allDeduct)
                                {
                                    if (sDed.MaNV.CompareTo(MaNVs) == 0 && sDed.DeductID.CompareTo(sDeductID) == 0 && sDed.DeductMoney == 0)
                                        sDed.DeductMoney = sMoney;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // báo lỗi
                        throw new Exception("Error");
                    }
                    finally
                    {
                        // cuối cùng đóng kết nối
                        sqlConnection.Close();
                    }
                }
            }
            return dataSQLs;
        }
        private void filldagird(int roWindex)
        {
            Manhanvien = int.Parse(cboNhanvien.SelectedValue.ToString());

            List<Salary.Allowance> sAllowance = new List<Salary.Allowance>();
            foreach (Salary.Allowance As in allAllowance)
            {
                if (int.Parse(As.MaNV.ToString()) == Manhanvien)
                {
                    sAllowance.Add(As);
                }
            }

            dgvAllowance.AutoGenerateColumns = false;
            dgvAllowance.DataSource = null;
            dgvAllowance.DataSource = sAllowance.OrderBy(r => r.AllowanceName).ToList(); ;
            dgvAllowance.Columns["money"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            //Grid phụ cấp theo sản phấm
            //
            List<Salary.ProductSalary> sProdSalary = new List<Salary.ProductSalary>();
            foreach (Salary.ProductSalary Ps in allProdSalary)
            {
                if (int.Parse(Ps.MaNV.ToString()) == Manhanvien)
                {
                    sProdSalary.Add(Ps);
                }
            }

            dgvProductSalary.AutoGenerateColumns = false;
            dgvProductSalary.DataSource = null;
            dgvProductSalary.DataSource = sProdSalary.OrderBy(r => r.PrSalaryName).ToList(); ;
            dgvProductSalary.Columns["ProdSalaryAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductSalary.Columns["ProdSalaryPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductSalary.Columns["ProdSalaryTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            //Grid Khấu trừ
            //
            sDeductPay = new List<Salary.Deduct>();

            if (allDeduct != null && allDeduct.Count > 0)
            {
                foreach (Salary.Deduct dP in allDeduct)
                {
                    if (int.Parse(dP.MaNV.ToString()) == Manhanvien)
                    {
                        sDeductPay.Add(dP);
                    }
                }
            }

            dgvDeduction.AutoGenerateColumns = false;
            dgvDeduction.DataSource = null;
            dgvDeduction.DataSource = sDeductPay.OrderBy(r => r.DeductName).ToList(); ;
            dgvDeduction.Columns["DeductionMoney"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            //Sellection rowIndex
            //
            if (roWindex > 0)
            {
                if (SalaryControl.SelectedIndex == 0)
                {
                    dgvAllowance.ClearSelection();
                    dgvAllowance.Rows[roWindex].Selected = true;
                }
                if (SalaryControl.SelectedIndex == 1)
                {
                    dgvProductSalary.ClearSelection();
                    dgvProductSalary.Rows[roWindex].Selected = true;
                }
                if (SalaryControl.SelectedIndex == 2)
                {
                    dgvDeduction.ClearSelection();
                    dgvDeduction.Rows[roWindex].Selected = true;
                }
            }
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        private void EnableAllControl(Control eControl, Boolean Enabled)
        {
            foreach (Control control in eControl.Controls)
            {
                if (Enabled == false)
                    control.Enabled = false;
                else
                    control.Enabled = true;
            }
        }
        private Control EnableControlwithName(string Panels, Boolean sEnabled)
        {
            foreach (Control controls in Controls)
            {
                if (sEnabled == true)
                {
                    if (controls.Name == Panels)
                    {
                        controls.Visible = true;
                        controls.Enabled = true;
                        controls.BringToFront();
                        foreach (TabPage tab in SalaryControl.TabPages)
                        {
                            tab.Enabled = false;
                        }
                        select = false;
                        break;
                    }
                }
                else
                {
                    if (controls.Name == Panels)
                    {
                        controls.Visible = false;
                        controls.Enabled = false;
                        foreach (TabPage tab in SalaryControl.TabPages)
                        {
                            tab.Enabled = true;
                        }
                        select = true;
                        break;
                    }
                }
            }
            return null;
        }
        private void SalaryControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!select)
            {
                e.Cancel = true;
            }
        }
        void KeyPressLimit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion



















    }
}