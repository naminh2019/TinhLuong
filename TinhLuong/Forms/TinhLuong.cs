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
using System.IO;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

namespace TinhLuong.Forms
{
    public partial class Tinhluong : Form
    {
        public Tinhluong()
        {
            InitializeComponent();
        }

        #region//==================== Declare variable ====================//

        List<Salary.Allowance> sThunhap = null;
        List<Salary.Deduct> sKhautru = null;
        List<Salary.Allowance> emThunhap = null;
        List<Salary.Deduct> emKhautru = null;
        List<Keeptime> sKeeptime = null;
        string sLeave = null;
        string sLate = null;
        string sOvertime = null;
        string sMonth = null;
        string strMonth = null;
        string sName = null;
        int tongTN = 0;
        int tongKT = 0;
        int giocong = 0;
        int MaNV = 0;
        string sRank = null;
        DataTable nhanvien = null;
        #endregion

        #region//====================  Form Open & Close ====================//
        private void PhuCapLuong_Load(object sender, EventArgs e)
        {
            panel1.Size = new Size(1150, 840);
            panel1.Location = new Point(100, 10);

            lblYear.Text = DateTime.Now.Year.ToString();

            string query = string.Format("select * from nhanvien");
            nhanvien = ConnectionUtils.findAll(query);
            if (nhanvien.Rows.Count > 0)
            {
                cboNhanvien.DataSource = null;
                cboNhanvien.DisplayMember = "Tennhanvien";
                cboNhanvien.ValueMember = "MaNV";
                cboNhanvien.DataSource = nhanvien;
                cboNhanvien.SelectedIndex = 0;
            }
            foreach (Control controls in Controls)
                controls.Enabled = false;

            panel2.Enabled = true;
            panel2.Visible = true;
            panel2.Size = new Size(1000, 700);
            panel2.Location = new Point(this.ClientSize.Width / 2 - panel2.Size.Width / 2, this.ClientSize.Height / 2 - panel2.Size.Height / 2);
            panel2.Anchor = AnchorStyles.None;
            panel2.BringToFront();
            OnMouseEnter(e);
            OnMouseLeave(e);
        }
        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region//====================  Control Process ====================//

        protected override void OnMouseEnter(System.EventArgs e)
        {
            lblSum.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblOK.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblCancel.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblPrint.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            label13.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            label12.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblSum.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblOK.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblCancel.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblPrint.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            label13.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            label12.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            base.OnMouseLeave(e);
        }
        #endregion

        #region//==================== DataContainer Process ====================//


        private void cboNhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            sRank = null;
            if (sMonth != null)
                fillDatagrid();
        }
        #endregion

        #region//==================== FormDisplay Process ====================//
        private void btnYearback_Click(object sender, EventArgs e)
        {
            int backYear = int.Parse(lblYear.Text.ToString()) - 1;
            lblYear.Text = backYear.ToString();
        }
        private void btnYearnext_Click(object sender, EventArgs e)
        {
            int nextYear = int.Parse(lblYear.Text.ToString()) + 1;
            lblYear.Text = nextYear.ToString();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            int soNV = nhanvien.Rows.Count;
            if (cboNhanvien.SelectedIndex >= soNV - 1) return;
            cboNhanvien.SelectedIndex = cboNhanvien.SelectedIndex + 1;
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (cboNhanvien.SelectedIndex <= 0) return;
            cboNhanvien.SelectedIndex = cboNhanvien.SelectedIndex - 1;
        }
        private void lblPrint_Click(object sender, EventArgs e)
        {
            PrintSalary PrintSalary = new PrintSalary(emThunhap, emKhautru, strMonth, sName, sLate, sLeave, sOvertime, tongTN, tongKT, MaNV, sRank, giocong);
            PrintSalary.ShowDialog();
        }
        private void lblSum_Click(object sender, EventArgs e)
        {
            List<Salary.TotalSalary> sTolalSalary = new List<Salary.TotalSalary>();

            string queryMa = string.Format("select * from nhanvien");
            DataTable disMA = ConnectionUtils.findAll(queryMa);

            int TotalAllowance = 0;
            int TotalDeduct = 0;
            foreach (DataRow sMa in disMA.Rows)
            {
                int sManhanvien = int.Parse(sMa["MaNV"].ToString());
                string tenNV = sMa["Tennhanvien"].ToString();
                TotalAllowance = 0;
                TotalDeduct = 0;

                foreach (Salary.Allowance totalTN in sThunhap)
                {
                    if (totalTN.MaNV == sManhanvien)
                    {
                        int tTN = int.Parse(totalTN.AllowanceMoney.ToString());
                        TotalAllowance = TotalAllowance + tTN;
                    }
                }
                foreach (Salary.Deduct totalKT in sKhautru)
                {
                    if (totalKT.MaNV == sManhanvien)
                    {
                        int tKT = int.Parse(totalKT.DeductMoney.ToString());
                        TotalDeduct = TotalDeduct + tKT;
                    }
                }
                int realReceive = TotalAllowance - TotalDeduct;
                sTolalSalary.Add(new Salary.TotalSalary
                {
                    MaNV = (int)sManhanvien,
                    TenNV = (string)tenNV,
                    TolalAllowance = (int)TotalAllowance,
                    TotalDeduct = (int)TotalDeduct,
                    RealReceive = (int)realReceive
                });
            }
            int SummaryAllowance = sTolalSalary.Sum(x => x.TolalAllowance);
            int SummaryDeduct = sTolalSalary.Sum(x => x.TotalDeduct);
            int SummaryRealReceive = sTolalSalary.Sum(x => x.RealReceive);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sTolalSalary;
            lblTitleSum.Text = strMonth;
            lbltongTN.Text = SummaryAllowance.ToString("###,###,###");
            lbltongKT.Text = SummaryDeduct.ToString("###,###,###");
            lblThuclanh.Text = SummaryRealReceive.ToString("###,###,###");
            panel1.Visible = true;
        }
        private void label12_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        private void lblExportExcel_Click(object sender, EventArgs e)
        {
            Utils.ExportExcel.exportDataToExcel("TỔNG LƯƠNG " + strMonth, dataGridView1);
            MessageBox.Show("Export Successful");
        }
        #endregion

        #region//====================  CURD Button Click ====================//

        private void lblOK_Click(object sender, EventArgs e) // Tính lương và khấu trừ, lưu vào SalaryHistory
        {
            Boolean deleted = false;
            int luongtong = 0;
            int luongBH = 0;
            Boolean chedo = false;
            int latePenalty = 0;
            int MaNVs = 0;
            int Seniority = 0;
            int Late = 0;
            int heso = 0;
            string NumberOfOvertime = null;
            string extraOvertime = "0:0:0";
            List<string> CheckDuplicate = new List<string>();

            int year = int.Parse(lblYear.Text.ToString());
            int month = getMonth();
            if (month == 0)
            {
                MessageBox.Show("Chua chon thang");
                return;
            }
            sMonth = (month.ToString() + "-" + year.ToString());
            strMonth = ("THÁNG " + month + " NĂM " + year);

            string queryCheckSalary = String.Format("select * from SalaryHistory where CheckDuplicate like 'FA%' and Date = '{0}'", sMonth);
            DataTable checkSalaryHistory = ConnectionUtils.findAll(queryCheckSalary);
            if (checkSalaryHistory.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phụ cấp");
                return;
            }

            string queryCheckDeduct = String.Format("select * from SalaryHistory where CheckDuplicate like 'AD%' and DeductID = 2 and Date = '{0}'", sMonth);
            DataTable checkDeduct = ConnectionUtils.findAll(queryCheckDeduct);
            if (checkDeduct.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu ứng lương");
                return;
            }

            String queryCheckTime = string.Format("SELECT * FROM KeeptimeHistory where Date = '{0}'", sMonth);
            DataTable checkKeeptime = ConnectionUtils.findAll(queryCheckTime);

            if (checkKeeptime.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu chấm công");
                return;
            }


            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);

            String queryIDSelect = string.Format("SELECT * FROM nhanvien");
            DataTable IDselect = ConnectionUtils.findAll(queryIDSelect);

            try
            {
                sqlConnection.Open();
                foreach (DataRow idNhanvien in IDselect.Rows)
                {
                    MaNVs = int.Parse(idNhanvien["MaNV"].ToString());
                    //luongtong = int.Parse(idNhanvien["luongthucte"].ToString());
                    //luongBH = int.Parse(idNhanvien["luongBH"].ToString());
                    //chedo = (Boolean)(idNhanvien["chedoBH"]);

                    DateTime YearWork = Convert.ToDateTime(idNhanvien["YearAtWork"].ToString());
                    DateTime dateNow = Convert.ToDateTime(sMonth.ToString());
                    TimeSpan Years = dateNow.Subtract(YearWork);
                    int thamnien = Years.Days / 365;

                    String queryTimeSelect = string.Format("SELECT * FROM KeeptimeHistory where Date = '{0}' and MaNV = {1}", sMonth, MaNVs);
                    DataTable TimeHistory = ConnectionUtils.findAll(queryTimeSelect);

                    foreach (DataRow Time in TimeHistory.Rows)
                    {
                        luongtong = int.Parse(Time["MonthlySalary"].ToString());
                        luongBH = int.Parse(Time["InsurranceSalary"].ToString());
                        chedo = (Boolean)(Time["Insurrance"]);
                        heso = int.Parse(Time["OvertimeCoefficient"].ToString());

                        Late = int.Parse(Time["Late"].ToString());
                        NumberOfOvertime = Time["NumberOfOvertime"].ToString();
                        if (Time["ExtraOvertime"] != DBNull.Value)
                            extraOvertime = Time["ExtraOvertime"].ToString();
                    }

                    Seniority = ((int)(thamnien / 5)) * luongBH * 10 / 100;
                    latePenalty = Late * 50000;

                    string[] overTime = NumberOfOvertime.ToString().Split(':');
                    string[] exOvertime = extraOvertime.ToString().Split(':');

                    int sHour = int.Parse(overTime[0].ToString());
                    int exHour = int.Parse(exOvertime[0].ToString());
                    double sMin = Math.Round((float.Parse(overTime[1].ToString()) + float.Parse(exOvertime[1].ToString())) / 60, 2);

                    double sOvertime = sHour + sMin + exHour;

                    int tangca = int.Parse(Math.Round(Convert.ToDouble(luongtong / 26 / 8 * heso * sOvertime), 0).ToString());

                    int luongHQ = luongtong - luongBH;
                    int tienBH = 0;
                    if (chedo == true)
                    {
                        tienBH = luongBH * 105 / 1000;
                    }
                    if (deleted == false)
                    {
                        foreach (DataRow checkNhanvien in IDselect.Rows)
                        {
                            int NhanvienID = int.Parse(checkNhanvien["MaNV"].ToString());
                            String queryKindA = string.Format("SELECT * FROM AllowanceSalary where CodeEdit = 1");
                            DataTable KindA = ConnectionUtils.findAll(queryKindA);
                            {
                                foreach (DataRow idKind in KindA.Rows)
                                {
                                    string sAllowanceID = idKind["AllowanceID"].ToString();
                                    string CheckAllowance = ("AA" + sMonth.Replace("-", String.Empty) + NhanvienID.ToString() + sAllowanceID);
                                    CheckDuplicate.Add(CheckAllowance);
                                }
                            }

                            String queryKindD = string.Format("SELECT * FROM DeductionsPay where CodeEdit = 1 and DeductID <> 2");
                            DataTable KindD = ConnectionUtils.findAll(queryKindD);
                            {
                                foreach (DataRow idKind in KindD.Rows)
                                {
                                    string sDeductID = idKind["DeductID"].ToString();
                                    string CheckDeduct = ("AD" + sMonth.Replace("-", String.Empty) + NhanvienID.ToString() + sDeductID);
                                    CheckDuplicate.Add(CheckDeduct);
                                }
                            }
                        }
                    }

                    if (CheckDuplicate != null)
                    {
                        foreach (string CheckD in CheckDuplicate)
                        {
                            string queryDelete = String.Format("Delete from SalaryHistory where CheckDuplicate = '{0}'", CheckD);
                            SqlCommand sqlDelete = new SqlCommand(queryDelete, sqlConnection);
                            ConnectionUtils.ExeCuteReader(sqlDelete);
                        }
                        deleted = true;
                        CheckDuplicate.Clear();
                    }

                    string Check = ("AA" + sMonth.Replace("-", String.Empty) + MaNVs.ToString() + "1");
                    string queryLBH = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, AllowanceID, money) VALUES ('{0}', {1}, '{2}', {3}, {4}) " +
                                                        "", Check, MaNVs, sMonth, 1, luongBH);
                    SqlCommand cmdLBH = new SqlCommand(queryLBH, sqlConnection);
                    ConnectionUtils.ExeCuteNonquery(cmdLBH);

                    Check = ("AA" + sMonth.Replace("-", String.Empty) + MaNVs.ToString() + "2");
                    string queryLHQSave = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, AllowanceID, money) VALUES('{0}', {1}, '{2}', {3}, {4}) " +
                                                        "", Check, MaNVs, sMonth, 2, luongHQ);
                    SqlCommand cmdLHQ = new SqlCommand(queryLHQSave, sqlConnection);
                    ConnectionUtils.ExeCuteNonquery(cmdLHQ);

                    if (tangca > 0) // tiền tăng ca
                    {
                        Check = ("AA" + sMonth.Replace("-", String.Empty) + MaNVs.ToString() + "3");
                        string queryLTC = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, AllowanceID, money) VALUES('{0}', {1}, '{2}', {3}, {4}) " +
                                                        "", Check, MaNVs, sMonth, 3, tangca);
                        SqlCommand cmdLTC = new SqlCommand(queryLTC, sqlConnection);
                        ConnectionUtils.ExeCuteNonquery(cmdLTC);
                    }

                    if (Seniority > 0) // tiền thâm niên
                    {
                        Check = ("AA" + sMonth.Replace("-", String.Empty) + MaNVs.ToString() + "13");

                        string queryLTN = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, AllowanceID, money) VALUES('{0}', {1}, '{2}', {3}, {4}) " +
                                                        " ", Check, MaNVs, sMonth, 13, Seniority);
                        SqlCommand cmdLTN = new SqlCommand(queryLTN, sqlConnection);
                        ConnectionUtils.ExeCuteNonquery(cmdLTN);
                    }

                    if (tienBH > 0) // Khấu trừ tiền bảo hiểm
                    {
                        Check = ("AD" + sMonth.Replace("-", String.Empty) + MaNVs.ToString() + "1");
                        string queryKTBH = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, DeductID, money) VALUES('{0}', {1}, '{2}', {3}, {4})" +
                                                        "", Check, MaNVs, sMonth, 1, tienBH);
                        SqlCommand cmdKTBH = new SqlCommand(queryKTBH, sqlConnection);
                        ConnectionUtils.ExeCuteNonquery(cmdKTBH);
                    }

                    if (latePenalty > 0) //Khấu trừ đi trể
                    {
                        String queryMaCV = string.Format("SELECT * FROM Nhanvien where MaNV = {0}", MaNVs);
                        DataTable tMaCV = ConnectionUtils.findAll(queryMaCV);
                        foreach (DataRow sMaCV in tMaCV.Rows)
                        {
                            if (int.Parse(sMaCV["MaCV"].ToString()) != 5)
                            {
                                Check = ("AD" + sMonth.Replace("-", String.Empty) + MaNVs.ToString() + "6");
                                string queryKTLate = String.Format("INSERT INTO SalaryHistory(CheckDuplicate, MaNV, Date, DeductID, money) VALUES('{0}', {1}, '{2}', {3}, {4})" +
                                                                "", Check, MaNVs, sMonth, 6, latePenalty);
                                SqlCommand cmdKTLate = new SqlCommand(queryKTLate, sqlConnection);
                                ConnectionUtils.ExeCuteNonquery(cmdKTLate);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            foreach (Control controls in Controls)
                controls.Enabled = true;

            panel2.Enabled = false;
            panel2.Visible = false;
            loadData();
            fillDatagrid();
        }
        #endregion

        #region//====================  Procedure ====================//
        private void loadData()
        {
            sKeeptime = new List<TinhLuong.Keeptime>();
            sThunhap = new List<Salary.Allowance>();
            sKhautru = new List<Salary.Deduct>();

            SqlConnection sqlConnection = null;

            foreach (DataRow IDNhanvien in nhanvien.Rows)
            {
                int sMaNV = int.Parse(IDNhanvien["MaNV"].ToString());

                try
                {
                    sqlConnection = null;
                    sqlConnection = ConnectionUtils.getConnection();
                    string querySalary = string.Format("select* from AllowanceSalary SI inner join SalaryHistory SH on SI.AllowanceID = SH.AllowanceID" +
                                         " where SH.MaNV = {0} and SH.Date = '{1}' and SH.money <> 0", sMaNV, sMonth);
                    SqlCommand cmdSalary = new SqlCommand(querySalary, sqlConnection);
                    SqlDataReader exeSalary = cmdSalary.ExecuteReader();
                    while (exeSalary.Read())
                    {
                        sThunhap.Add(new Salary.Allowance()
                        {
                            MaNV = (int)exeSalary["MaNV"],
                            AllowanceID = (int)exeSalary["AllowanceID"],
                            AllowanceName = exeSalary["AllowanceName"].ToString(),
                            AllowanceMoney = (int)exeSalary["money"],
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

                try
                {
                    sqlConnection = null;
                    sqlConnection = ConnectionUtils.getConnection();
                    string queryProdSalary = string.Format("select* from ProductSalary PS inner join SalaryHistory SH on PS.SAprodID = SH.SAprodID" +
                                                       " where SH.MaNV = {0} and SH.Date = '{1}' and SH.money <> 0", sMaNV, sMonth);
                    SqlCommand cmdProdSalary = new SqlCommand(queryProdSalary, sqlConnection);
                    SqlDataReader exeProdSalary = cmdProdSalary.ExecuteReader();

                    while (exeProdSalary.Read())
                    {
                        sThunhap.Add(new Salary.Allowance()
                        {
                            MaNV = (int)exeProdSalary["MaNV"],
                            AllowanceID = (int)exeProdSalary["SAprodID"],
                            AllowanceName = exeProdSalary["SAprodName"].ToString(),
                            AllowanceMoney = (int)exeProdSalary["money"],
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

                try
                {
                    sqlConnection = null;
                    sqlConnection = ConnectionUtils.getConnection();
                    string queryDeduction = string.Format("select* from SalaryHistory SH inner join DeductionsPay DP on DP.DeductID = SH.DeductID" +
                                      " where SH.MaNV = {0} and SH.Date = '{1}' and SH.money <> 0", sMaNV, sMonth);
                    SqlCommand cmdDeduction = new SqlCommand(queryDeduction, sqlConnection);
                    SqlDataReader exeDeduction = cmdDeduction.ExecuteReader();
                    while (exeDeduction.Read())
                    {
                        sKhautru.Add(new Salary.Deduct()
                        {
                            MaNV = (int)exeDeduction["MaNV"],
                            DeductID = (int)exeDeduction["DeductID"],
                            DeductName = exeDeduction["DeductName"].ToString(),
                            DeductMoney = (int)exeDeduction["money"],
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

                try
                {
                    sqlConnection = null;
                    sqlConnection = ConnectionUtils.getConnection();

                    string ktHistory = string.Format("SELECT * from KeeptimeHistory where Date = '{0}'", sMonth);
                    SqlCommand cmdktHistory = new SqlCommand(ktHistory, sqlConnection);
                    SqlDataReader exektHistory = cmdktHistory.ExecuteReader();

                    while (exektHistory.Read())
                    {
                        string Overtime = exektHistory["NumberOfOvertime"].ToString();
                        string extraOvertime = "0:0:0";
                        if (exektHistory["ExtraOvertime"] != DBNull.Value)
                        {
                            extraOvertime = exektHistory["ExtraOvertime"].ToString();
                        }
                        string[] overTime = Overtime.ToString().Split(':');
                        string[] exOvertime = extraOvertime.ToString().Split(':');

                        int sHour = int.Parse(overTime[0].ToString()) + int.Parse(exOvertime[0].ToString());
                        int sMin = int.Parse(overTime[1].ToString()) + int.Parse(exOvertime[1].ToString());

                        if (sMin >= 60)
                        {
                            sHour = sHour + 1;
                            sMin = sMin - 60;
                        }

                        string fullOvertime = (sHour.ToString("00") + ":" + sMin.ToString("00"));

                        sKeeptime.Add(new TinhLuong.Keeptime()
                        {
                            Date = exektHistory["Date"].ToString(),
                            MaNV = (int)exektHistory["MaNV"],
                            NumberOfOvertime = fullOvertime.ToString(),
                            Absent = (int)exektHistory["Absent"],
                            Late = (int)exektHistory["Late"]
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
            }
        }
        private void fillDatagrid()
        {
            MaNV = int.Parse(cboNhanvien.SelectedValue.ToString());
            sName = cboNhanvien.Text.ToString();
            foreach (DataRow sluong in nhanvien.Rows)
            {
                if (int.Parse(sluong["Manv"].ToString()) == MaNV)
                {
                    int luong = int.Parse(sluong["luongthucte"].ToString());
                    giocong = luong / 208;
                    lblGiocong.Text = giocong.ToString("###,###");
                }
            }
            foreach (Keeptime textfill in sKeeptime)
            {
                if (textfill.MaNV == MaNV)
                {
                    sLeave = textfill.Absent.ToString();
                    sLate = textfill.Late.ToString();
                    sOvertime = textfill.NumberOfOvertime.ToString();

                    lblLeave.Text = sLeave;
                    lblLate.Text = sLate;
                    lblOvertime.Text = sOvertime;
                }
            }

            string query = string.Format("select * from Classification where date = '{0}'", sMonth);
            DataTable Classification = ConnectionUtils.findAll(query);

            foreach (DataRow sClassification in Classification.Rows)
            {
                if (int.Parse(sClassification["MaNV"].ToString()) == MaNV)
                {
                    sRank = sClassification["Rank"].ToString();

                }
            }
            lblRank.Text = sRank;

            emThunhap = new List<Salary.Allowance>();
            emKhautru = new List<Salary.Deduct>();

            foreach (Salary.Allowance emTN in sThunhap)
            {
                if (emTN.MaNV == MaNV)
                {
                    emThunhap.Add(emTN);
                }
            }
            foreach (Salary.Deduct emKT in sKhautru)
            {
                if (emKT.MaNV == MaNV)
                {
                    emKhautru.Add(emKT);
                }
            }

            tongTN = emThunhap.Sum(x => x.AllowanceMoney);
            lblAlowanceTotal.Text = tongTN.ToString("###,###,###");

            dgvCTphucap.AutoGenerateColumns = false;
            dgvCTphucap.DataSource = null;
            dgvCTphucap.DataSource = emThunhap.OrderBy(r => r.AllowanceName).ToList();
            dgvCTphucap.Columns["AllowanceMoney"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            tongKT = emKhautru.Sum(x => x.DeductMoney);
            lblDeductTotal.Text = tongKT.ToString("###,###,###");

            dgvCTkhautru.AutoGenerateColumns = false;
            dgvCTkhautru.DataSource = null;
            dgvCTkhautru.DataSource = emKhautru.OrderBy(r => r.DeductName).ToList(); ;
            dgvCTkhautru.Columns["DeductMoney"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lblTotalSalary.Text = (tongTN - tongKT).ToString("###,###,###");

        }
        private int getMonth()
        {
            if (radioButton1.Checked == true)
                return 01;
            if (radioButton2.Checked == true)
                return 2;
            if (radioButton3.Checked == true)
                return 3;
            if (radioButton4.Checked == true)
                return 4;
            if (radioButton5.Checked == true)
                return 5;
            if (radioButton6.Checked == true)
                return 6;
            if (radioButton7.Checked == true)
                return 7;
            if (radioButton8.Checked == true)
                return 8;
            if (radioButton9.Checked == true)
                return 9;
            if (radioButton10.Checked == true)
                return 10;
            if (radioButton11.Checked == true)
                return 11;
            if (radioButton12.Checked == true)
                return 12;
            return 0;
        }

        #endregion

    }
}