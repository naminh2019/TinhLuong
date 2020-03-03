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
using System.Globalization;
using TinhLuong.Entities;
using System.Threading;
using DGVPrinterHelper;
using System.Drawing.Printing;

namespace TinhLuong
{

    public partial class frmChamcong : Form
    {
        public frmChamcong()
        {
            InitializeComponent();
        }
        public frmChamcong(int month, int year, int holiday)
        {
            InitializeComponent();
            this.MONTH = month;
            this.YEAR = year;
            this.HOLIDAY = holiday;
        }

        #region //==================== Declare variable ====================//
        int YEAR;
        int MONTH;
        int HOLIDAY;
        int B_NUMBER = 1;
        List<TotalChamCong> _TOTAL_CHAMCONGS = new List<TotalChamCong>();
        List<Keeptime> KEEPTIME_HISTORY = new List<Keeptime>();
        int NUMBER_RECORD = -1;
        int PAGE = 1;
        #endregion

        #region //==================== Form Open & Close ====================//
        private void Chamcong_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(129, 300);
            panel1.Size = new Size(484, 260);

            lblHead.Text = string.Format("Tháng {0} năm {1}", MONTH, YEAR);

            NUMBER_RECORD = DateTime.DaysInMonth(YEAR, MONTH);

            DataTable NhanViens = findAllNhanVien();
            parseDataToList(NhanViens);
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
            lblFind.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblPrint.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblSave.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblPanelClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblPanelPrint.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblFind.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblPrint.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblSave.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblPanelClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblPanelPrint.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);

            base.OnMouseLeave(e);
        }
        #endregion

        #region //==================== DataContainer Process ====================//

        #endregion

        #region //==================== FormDisplay Process ====================//

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (int.Parse(grpPagination.Controls[0].Text) == 1)
            {
                if (PAGE > 1)
                {
                    PAGE--;
                    loadGridview(_TOTAL_CHAMCONGS[PAGE - 1]._ChamCongs);
                    showLabelInfo(_TOTAL_CHAMCONGS[PAGE - 1].sKeeptime);
                }
                return;
            }
            for (int i = 1; i <= 10; i++)
            {
                foreach (Control btn in grpPagination.Controls)
                {
                    if (btn.Name == string.Format("btn{0}", i))
                        btn.Text = Convert.ToString(int.Parse(btn.Text) - 1);
                }
            }

            PAGE--;
            loadGridview(_TOTAL_CHAMCONGS[PAGE - 1]._ChamCongs);
            showLabelInfo(_TOTAL_CHAMCONGS[PAGE - 1].sKeeptime);

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (int.Parse(grpPagination.Controls[0].Text) == (B_NUMBER - (B_NUMBER / 4) + 1))
            {
                if (PAGE < B_NUMBER)
                {
                    PAGE++;
                    loadGridview(_TOTAL_CHAMCONGS[PAGE - 1]._ChamCongs);
                    showLabelInfo(_TOTAL_CHAMCONGS[PAGE - 1].sKeeptime);
                }
                return;
            }
            for (int i = 1; i <= 10; i++)
            {
                foreach (Control btn in grpPagination.Controls)
                {
                    if (btn.Name == string.Format("btn{0}", i))
                        btn.Text = Convert.ToString(int.Parse(btn.Text) + 1);
                }
            }
            PAGE++;
            loadGridview(_TOTAL_CHAMCONGS[PAGE - 1]._ChamCongs);
            showLabelInfo(_TOTAL_CHAMCONGS[PAGE - 1].sKeeptime);
        }
        private void btnPage_Click(object sender, EventArgs e)
        {
            foreach (Control btn in grpPagination.Controls)
            {
                if (sender == btn)
                {
                    PAGE = int.Parse(btn.Text);
                    loadGridview(_TOTAL_CHAMCONGS[PAGE - 1]._ChamCongs);
                    showLabelInfo(_TOTAL_CHAMCONGS[PAGE - 1].sKeeptime);
                }
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _TOTAL_CHAMCONGS.Count(); i++)
            {
                int maxPage = (B_NUMBER - (B_NUMBER / 4) + 1);

                int mMaNV = int.Parse(txtFind.Text.Trim().ToString());
                if (_TOTAL_CHAMCONGS[i].MaNV == mMaNV)
                {
                    PAGE = i + 1;
                    loadGridview(_TOTAL_CHAMCONGS[i]._ChamCongs);
                    showLabelInfo(_TOTAL_CHAMCONGS[i].sKeeptime);

                    if (PAGE > maxPage)
                        PAGE = maxPage;

                    grpPagination.Controls[0].Text = PAGE.ToString();

                    for (int _i = 0; _i < B_NUMBER / 4; _i++)
                    {
                        grpPagination.Controls[_i].Text = (PAGE + _i).ToString();
                    }

                    PAGE = i + 1;
                }
            }
            foreach (Control btn in grpPagination.Controls)
            {
                if (btn.Text.Trim() == PAGE.ToString())
                    btn.BackColor = Color.SkyBlue;
                else btn.BackColor = Color.Transparent;
            }
            pnlFind.Visible = false;
        }
        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void lblFind_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = true;
            pnlFind.BringToFront();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = false;
        }
        private void lblPrint_Click(object sender, EventArgs e)
        {
            foreach (Control AllControl in Controls)
            {
                AllControl.Enabled = false;
            }

            panel1.Visible = true;
            panel1.Enabled = true;
            panel1.BringToFront();
            rbtPrintOne.Checked = true;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(strPrinter);
                PrinterSettings settings = new PrinterSettings();
                string strDefaultPrinter = settings.PrinterName.ToString();
                if (strPrinter == strDefaultPrinter)
                {
                    cboPrinter.SelectedIndex = cboPrinter.Items.IndexOf(strPrinter);
                }
            }
        }
        private void lblPanelClose_Click(object sender, EventArgs e)
        {
            foreach (Control AllControl in Controls)
                AllControl.Enabled = true;
            panel1.Visible = false;
        }
        private void lblPanelPrint_Click(object sender, EventArgs e)
        {
            string thang = null;
            string ma = null;
            string ten = null;
            string vang = null;
            string tre = null;
            string tangca = null;
            Boolean printed = false;
            Boolean PrintAll = false; ;
            int maNhanvien = int.Parse(lblManv.Text);
            List<ChamCong> sChamcong = new List<ChamCong>();
            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);
            sqlConnection.Open();
            string queryCount = "SELECT Count(manv) FROM nhanvien";
            SqlCommand cmdCount = new SqlCommand(queryCount, sqlConnection);
            Int32 count = (Int32)cmdCount.ExecuteScalar();
            sqlConnection.Close();
            if (chkPrint.Checked == true)
                PrintAll = true;
            else
                PrintAll = false;


            for (int i = 0; i < count; i++)
            {
                sChamcong.Clear();
                if (rbtPrintOne.Checked == true && printed == true)
                    break;

                TotalChamCong _TotalChamCong = _TOTAL_CHAMCONGS[i];

                if (rbtPrintAll.Checked == true)
                {
                    chkPrint.Checked = true;
                    sChamcong.AddRange(_TotalChamCong._ChamCongs);
                    thang = ("Tháng " + MONTH + " năm " + YEAR);
                    ma = (_TotalChamCong.sKeeptime.MaNV.ToString());
                    ten = (_TotalChamCong.sKeeptime.TenNV.ToString());
                    vang = (_TotalChamCong.sKeeptime.Absent.ToString());
                    tre = (_TotalChamCong.sKeeptime.Late.ToString());
                    tangca = (_TotalChamCong.sKeeptime.NumberOfOvertime.ToString());
                    using (PrintTimekeeping printTimekeeping = new PrintTimekeeping(sChamcong, thang, ma, ten, vang, tre, tangca, PrintAll))
                    {
                        printTimekeeping.ShowDialog();
                    }
                }
                if (rbtPrintOne.Checked == true)
                {
                    chkPrint.Checked = false;
                    foreach (ChamCong totalCC in _TotalChamCong._ChamCongs)
                    {
                        if (totalCC.MaNhanVien == maNhanvien)
                        {
                            sChamcong.AddRange(_TotalChamCong._ChamCongs);
                            thang = ("Tháng " + MONTH + " năm " + YEAR);
                            ma = (_TotalChamCong.sKeeptime.MaNV.ToString());
                            ten = (_TotalChamCong.sKeeptime.TenNV.ToString());
                            vang = (_TotalChamCong.sKeeptime.Absent.ToString());
                            tre = (_TotalChamCong.sKeeptime.Late.ToString());
                            tangca = (_TotalChamCong.sKeeptime.NumberOfOvertime.ToString());

                            using (PrintTimekeeping printTimekeeping = new PrintTimekeeping(sChamcong, thang, ma, ten, vang, tre, tangca, PrintAll))
                            {
                                printTimekeeping.ShowDialog();
                            }
                            printed = true;
                            break;
                        }
                    }
                    if (printed == true)
                        break;
                }
            }
        }
        #endregion

        #region //==================== CURD Button Click ====================//
        private void lblSave_Click(object sender, EventArgs e)
        {
            string checkDate = (MONTH + "-" + YEAR);

            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);

            if (KEEPTIME_HISTORY == null || KEEPTIME_HISTORY.Count == 0)
            {
                MessageBox.Show("No data");
                return;
            }

            string queryCheck = String.Format("select * from KeeptimeHistory where date = '{0}'", checkDate);
            DataTable CheckDup = ConnectionUtils.findAll(queryCheck);

            //MessageBox.Show(CheckDup.Rows.Count.ToString());
            int i = 0;
            int SaveCount = CheckDup.Rows.Count;
            if (SaveCount > 0)
            {
                DialogResult result = MessageBox.Show("Dữ liệu chấm công đang bị trùng, Bạn có muốn Update?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string queryTimeDelete = String.Format("Delete from KeeptimeHistory where Date = '{0}'", checkDate);
                    SqlCommand sqlTimeDelete = new SqlCommand(queryTimeDelete, sqlConnection);
                    ConnectionUtils.ExeCuteReader(sqlTimeDelete);
                }
                else
                    return;
            }

            try
            {
                sqlConnection.Open();
                foreach (Keeptime keeptime_History in KEEPTIME_HISTORY)
                {

                    int MaNV = keeptime_History.MaNV;
                    string Date = keeptime_History.Date;
                    string NumberOfOvertime = keeptime_History.NumberOfOvertime;
                    int Absent = keeptime_History.Absent;
                    int Late = keeptime_History.Late;


                    String querySalary = string.Format("SELECT * FROM nhanvien where MaNV = {0}", MaNV);
                    DataTable SalarySelect = ConnectionUtils.findAll(querySalary);
                    foreach (DataRow SSelect in SalarySelect.Rows)
                    {
                        int MonthlySalary = int.Parse(SSelect["Luongthucte"].ToString());
                        int InsurranceSalary = int.Parse(SSelect["LuongBH"].ToString());
                        int OvertimeCoefficient = int.Parse(SSelect["OvertimeCoefficient"].ToString());
                        Boolean Insurrance = Convert.ToBoolean(SSelect["ChedoBH"].ToString());
                        int Ins = 0;
                        if (Insurrance == true)
                            Ins = 1;
                        string queryTimeSave = String.Format("INSERT INTO KeeptimeHistory(MaNV, Date, NumberOfOvertime, Absent, Late, MonthlySalary, InsurranceSalary, Insurrance, OvertimeCoefficient)" +
                                                            " VALUES({0}, '{1}', '{2}', {3}, {4}, {5}, {6}, {7}, {8}) " +
                                                            " ", MaNV, Date, NumberOfOvertime, Absent, Late, MonthlySalary, InsurranceSalary, Ins, OvertimeCoefficient);
                        SqlCommand cmdTime = new SqlCommand(queryTimeSave, sqlConnection);
                        ConnectionUtils.ExeCuteNonquery(cmdTime);
                        i += 1;
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
            MessageBox.Show(i.ToString() + " records saved successful !");
        }
        #endregion

        #region //==================== Procedure ====================//
        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(SystemColors.Control);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Maroon, 0, 0);
        }
        private void createPaginationButton()
        {
            B_NUMBER = _TOTAL_CHAMCONGS.Count;

            for (int i = 1; i <= B_NUMBER / 4; i++)
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                btn.Size = new System.Drawing.Size(30, 30);
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Top = 5;
                btn.Left = i * 30;
                btn.Text = i.ToString();
                btn.Name = string.Format("btn{0}", i);
                btn.Click += new System.EventHandler(this.btnPage_Click);
                grpPagination.Controls.Add(btn);

            }

            System.Windows.Forms.Button btnPrevious = new System.Windows.Forms.Button();
            btnPrevious.Size = new System.Drawing.Size(30, 30);
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrevious.Top = 5;
            btnPrevious.Left = 0;
            btnPrevious.Text = "<<";
            btnPrevious.Name = string.Format("btnPrevious");
            btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            grpPagination.Controls.Add(btnPrevious);

            System.Windows.Forms.Button btnNext = new System.Windows.Forms.Button();
            btnNext.Size = new System.Drawing.Size(30, 30);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNext.Top = 5;
            btnNext.Left = (B_NUMBER / 4 * 30) + 30; ;
            btnNext.Text = ">>";
            btnNext.Name = string.Format("btnNext");
            btnNext.Click += new System.EventHandler(this.btnNext_Click);
            grpPagination.Controls.Add(btnNext);
        }
        private Keeptime calculateKeeptime(List<ChamCong> _ChamCongs)
        {

            TimeSpan lateTime = new TimeSpan(8, 10, 0);
            int totalLate = 0;
            int totalLeave = 0;
            TimeSpan total = new TimeSpan();
            int MaNhanVien = 0;
            foreach (ChamCong sTime in _ChamCongs)
            {
                MaNhanVien = sTime.MaNhanVien;

                if (TimeSpan.Parse(sTime.InMorning.ToString()).CompareTo(lateTime) > 0)
                {
                    totalLate = totalLate + 1;
                }
                if (DateTime.Parse(sTime.Date.ToString()).DayOfWeek != DayOfWeek.Sunday //
                    && sTime.InMorning.ToString().Trim() == "00:00:00" //
                    && sTime.InAfternoon.ToString().Trim() == "00:00:00")
                    totalLeave = totalLeave + 1;

                int mNhanvien = sTime.MaNhanVien;
                total = total.Add(TimeSpan.Parse(sTime.NumberOvertime.ToString()));
                StringBuilder sb = FormatNumberOvertime(total);
            }
            StringBuilder buider = FormatNumberOvertime(total);
            Keeptime _KeepTime = new Keeptime();

            _KeepTime.MaNV = MaNhanVien;
            _KeepTime.Date = Convert.ToString(MONTH + "-" + YEAR);
            _KeepTime.NumberOfOvertime = buider.ToString();
            _KeepTime.Absent = totalLeave - HOLIDAY;
            _KeepTime.Late = totalLate;
            return _KeepTime;
        }
        private static StringBuilder FormatNumberOvertime(TimeSpan total)
        {
            StringBuilder sb = new StringBuilder();
            int days = total.Days;
            int hours = total.Hours;
            int totalHours = hours;
            if (days > 0)
            {
                totalHours = days * 24 + totalHours;
            }

            int minutes = total.Minutes;
            int seconds = total.Seconds;
            sb.AppendFormat("{0}:{1}:{2}", totalHours, minutes, seconds);
            return sb;
        }
        private List<ChamCong> createDefaultDataByMonth(int month, int year, int MaNhanVien)
        {
            List<ChamCong> chamCongs = new List<ChamCong>();

            int firstDayOfMonth = 1;
            int lastDayOfMonth = DateTime.DaysInMonth(year, month);
            int i = firstDayOfMonth;

            ChamCong _clsChamCong = null;
            while (i <= lastDayOfMonth)
            {
                _clsChamCong = new ChamCong();
                DateTime date = new DateTime(year, month, i);

                _clsChamCong.MaNhanVien = MaNhanVien;
                _clsChamCong.Date = date;

                chamCongs.Add(_clsChamCong);
                i++;
            }
            return chamCongs;
        }
        private void parseDataToList(DataTable NhanViens)
        {
            foreach (DataRow IDnhanvien in NhanViens.Rows)
            {
                int MaNhanVien = int.Parse(IDnhanvien["MaNV"].ToString());
                String TenNhanVien = IDnhanvien["Tennhanvien"].ToString();
                if (MaNhanVien <= 0)
                {
                    return;
                }
                string query2 = string.Format("select * from dulieu where month(Timekeep) = {0} and MaNV = {1}", MONTH, MaNhanVien);
                DataTable tChamcong = ConnectionUtils.findAll(query2);
                List<ChamCong> ChamCongs = createDefaultDataByMonth(MONTH, YEAR, MaNhanVien);

                foreach (DataRow rows in tChamcong.Rows)
                {
                    DateTime date = DateTime.Parse(rows[1].ToString());

                    DateTime dateOnly = date.Date;
                    TimeSpan timeOnly = date.TimeOfDay;

                    String queryIDSelect = string.Format("SELECT * FROM nhanvien where MaNV = {0}", MaNhanVien);
                    DataTable IDselect = ConnectionUtils.findAll(queryIDSelect);

                    TimeSpan latetimein = new TimeSpan(2, 0, 0);
                    TimeSpan latetimeout = new TimeSpan(0, 30, 0);

                    foreach (DataRow DefaultTime in IDselect.Rows)
                    {
                        TimeSpan DefaultInMorning = TimeSpan.Parse(DefaultTime["Inmorning"].ToString()).Add(latetimein);
                        TimeSpan DefaultOutMorning = TimeSpan.Parse(DefaultTime["Outmorning"].ToString()).Add(latetimeout);
                        TimeSpan DefaultInAfternoon = TimeSpan.Parse(DefaultTime["InAfternoon"].ToString()).Add(latetimein);
                        TimeSpan DefaultOutAfternoon = TimeSpan.Parse(DefaultTime["OutAfternoon"].ToString()).Add(latetimeout);
                        TimeSpan DefaultInOvertime = TimeSpan.Parse(DefaultTime["OutAfternoon"].ToString());
                        TimeSpan DefaultTimeSpan = new TimeSpan(0, 0, 0);

                        TimeSpan InMorning = new TimeSpan();
                        TimeSpan OutMorning = new TimeSpan();
                        TimeSpan InAfternoon = new TimeSpan();
                        TimeSpan OutAfternoon = new TimeSpan();
                        TimeSpan InOvertime = new TimeSpan();
                        TimeSpan OutOvertime = new TimeSpan();
                        TimeSpan NumberOvertime = new TimeSpan();

                        int macongviec = int.Parse(DefaultTime["MaCV"].ToString());

                        if (dateOnly.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (timeOnly.CompareTo(DefaultInMorning) <= 0)
                                InMorning = timeOnly;
                            if (timeOnly.CompareTo(DefaultInMorning) > 0 && timeOnly.CompareTo(DefaultOutMorning) <= 0)
                                OutMorning = timeOnly;
                            if (timeOnly.CompareTo(DefaultOutMorning) > 0 && timeOnly.CompareTo(DefaultInAfternoon) <= 0)
                                InAfternoon = timeOnly;
                            if (timeOnly.CompareTo(DefaultInAfternoon) > 0 && timeOnly.CompareTo(DefaultOutAfternoon) <= 0)
                                OutAfternoon = timeOnly;
                            if (timeOnly.CompareTo(DefaultInOvertime) > 0)
                            {
                                InOvertime = DefaultInOvertime;
                                OutOvertime = timeOnly;
                            }
                        }

                        //=================================================================================================================

                        foreach (ChamCong objInList in ChamCongs)
                        {
                            if (objInList.Date.CompareTo(dateOnly) == 0)
                            {
                                if (dateOnly.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    if (objInList.InOvertime.CompareTo(DefaultTimeSpan) > 0 && timeOnly.CompareTo(objInList.InOvertime) > 0)
                                    {
                                        objInList.OutOvertime = timeOnly;
                                    }
                                    else
                                    {
                                        objInList.InOvertime = timeOnly;
                                    }
                                }

                                /*========================== InMorning =================================*/

                                if (InMorning.CompareTo(DefaultTimeSpan) > 0)
                                {
                                    if (objInList.InMorning.CompareTo(DefaultTimeSpan) == 0)
                                    {
                                        objInList.InMorning = InMorning;
                                    }
                                    else
                                    {
                                        if (objInList.InMorning.CompareTo(InMorning) > 0)
                                        {
                                            objInList.InMorning = InMorning;
                                        }
                                    }
                                }

                                /*========================== OutMorning =================================*/

                                if (OutMorning.CompareTo(DefaultTimeSpan) > 0)
                                {
                                    if (objInList.OutMorning.CompareTo(DefaultTimeSpan) == 0)
                                    {
                                        objInList.OutMorning = OutMorning;
                                    }
                                    else
                                    {
                                        if (objInList.OutMorning.CompareTo(OutMorning) < 0)
                                        {
                                            objInList.OutMorning = OutMorning;
                                        }
                                    }
                                }

                                /*========================== InAfternoon =================================*/

                                if (InAfternoon.CompareTo(DefaultTimeSpan) > 0)
                                {
                                    if (objInList.InAfternoon.CompareTo(DefaultTimeSpan) == 0)
                                    {
                                        objInList.InAfternoon = InAfternoon;
                                    }
                                    else
                                    {
                                        if (objInList.InAfternoon.CompareTo(InAfternoon) > 0)
                                        {
                                            objInList.InAfternoon = InAfternoon;
                                        }
                                    }
                                }

                                /*========================== OutAfternoon =================================*/

                                if (OutAfternoon.CompareTo(DefaultTimeSpan) > 0)
                                {
                                    if (objInList.OutAfternoon.CompareTo(DefaultTimeSpan) == 0)
                                    {
                                        objInList.OutAfternoon = OutAfternoon;
                                    }
                                    else
                                    {
                                        if (objInList.OutAfternoon.CompareTo(OutAfternoon) < 0)
                                        {
                                            objInList.OutAfternoon = OutAfternoon;
                                        }
                                    }
                                }

                                /*========================== InOvertime =================================*/
                                if (macongviec == 5)
                                {
                                    objInList.InOvertime = new TimeSpan(0, 0, 0);
                                    objInList.OutOvertime = new TimeSpan(0, 0, 0);
                                }
                                else
                                {
                                    if (InOvertime.CompareTo(DefaultTimeSpan) != 0)
                                    {
                                        if (objInList.InOvertime.CompareTo(DefaultTimeSpan) == 0)
                                        {
                                            if (dateOnly.DayOfWeek != DayOfWeek.Sunday)
                                                objInList.InOvertime = DefaultInOvertime;
                                        }
                                        else
                                        {
                                            if (objInList.InOvertime.CompareTo(InOvertime) > 0)
                                            {
                                                objInList.InOvertime = InOvertime;
                                            }
                                        }
                                    }
                                    /*========================== OutOvertime =================================*/

                                    if (OutOvertime.CompareTo(DefaultTimeSpan) > 0)
                                    {
                                        if (objInList.OutOvertime.CompareTo(DefaultTimeSpan) == 0)
                                        {
                                            objInList.OutOvertime = OutOvertime;
                                        }
                                        else
                                        {
                                            if (objInList.OutOvertime.CompareTo(OutOvertime) < 0)
                                            {
                                                objInList.OutOvertime = OutOvertime;
                                            }
                                        }
                                    }
                                }

                                /*========================== NumberOvertime =================================*/

                                TimeSpan interval = objInList.OutOvertime.Subtract(objInList.InOvertime);
                                if (dateOnly.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    if (interval >= new TimeSpan(6, 0, 0))
                                        NumberOvertime = interval - new TimeSpan(1, 0, 0);
                                    else
                                        NumberOvertime = interval;
                                }
                                else
                                {
                                    if (interval <= new TimeSpan(0, 20, 0))
                                        NumberOvertime = new TimeSpan(0, 0, 0);
                                    else
                                        NumberOvertime = interval;
                                }
                                objInList.NumberOvertime = NumberOvertime;
                            }
                        }
                    }
                }

                TotalChamCong _TotalChamCong = new TotalChamCong();
                _TotalChamCong.MaNV = MaNhanVien;
                Keeptime sKeeptime = calculateKeeptime(ChamCongs);
                sKeeptime.TenNV = TenNhanVien;
                _TotalChamCong.sKeeptime = sKeeptime;
                _TotalChamCong._ChamCongs = ChamCongs;
                KEEPTIME_HISTORY.Add(sKeeptime);
                _TOTAL_CHAMCONGS.Add(_TotalChamCong);

                TotalChamCong _ChamCong = findNhanvienByMaNhanVien(PAGE);
                loadGridview(_ChamCong._ChamCongs);
                showLabelInfo(_ChamCong.sKeeptime);
            }
            createPaginationButton();
        }
        private TotalChamCong findNhanvienByMaNhanVien(int MaNhanVien)
        {
            TotalChamCong _TotalChamCong = new TotalChamCong();

            foreach (TotalChamCong _ChamCong in _TOTAL_CHAMCONGS)
            {
                if (_ChamCong.MaNV == MaNhanVien)
                    _TotalChamCong = _ChamCong;
            }
            return _TotalChamCong;
        }
        private static DataTable findAllNhanVien()
        {
            string query = "select distinct(manv), Tennhanvien from nhanvien";
            DataTable NhanViens = ConnectionUtils.findAll(query);
            return NhanViens;
        }
        private void showLabelInfo(Keeptime Keeptimes)
        {
            lblManv.Text = Keeptimes.MaNV.ToString();
            lblTotal.Text = Keeptimes.NumberOfOvertime.ToString();
            lblLate.Text = Keeptimes.Late.ToString();
            lblLeave.Text = Keeptimes.Absent.ToString();
            lblTennhanvien.Text = Keeptimes.TenNV;
        }
        private void ChangeStyleDataGridView(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                DateTime dateInRow = DateTime.Parse(row.Cells[0].Value.ToString());

                String InMorning = row.Cells[1].Value.ToString();
                String OutMorning = row.Cells[2].Value.ToString();
                String InAfternoon = row.Cells[3].Value.ToString();
                String OutAfternoon = row.Cells[4].Value.ToString();
                String InOvertime = row.Cells[5].Value.ToString();
                String OutOvertime = row.Cells[6].Value.ToString();
                String NumberOvertime = row.Cells[7].Value.ToString();

                if (InMorning.Trim() == "00:00:00")
                {
                    row.Cells[1].Style.ForeColor = Color.Transparent;
                    row.Cells[1].Style.SelectionForeColor = Color.Transparent;
                }
                if (OutMorning.Trim() == "00:00:00")
                {
                    row.Cells[2].Style.ForeColor = Color.Transparent;
                    row.Cells[2].Style.SelectionForeColor = Color.Transparent;
                }
                if (InAfternoon.Trim() == "00:00:00")
                {
                    row.Cells[3].Style.ForeColor = Color.Transparent;
                    row.Cells[3].Style.SelectionForeColor = Color.Transparent;
                }
                if (OutAfternoon.Trim() == "00:00:00")
                {
                    row.Cells[4].Style.ForeColor = Color.Transparent;
                    row.Cells[4].Style.SelectionForeColor = Color.Transparent;
                }
                if (InOvertime.Trim() == "00:00:00")
                {
                    row.Cells[5].Style.ForeColor = Color.Transparent;
                    row.Cells[5].Style.SelectionForeColor = Color.Transparent;
                }
                if (OutOvertime.Trim() == "00:00:00")
                {
                    row.Cells[6].Style.ForeColor = Color.Transparent;
                    row.Cells[6].Style.SelectionForeColor = Color.Transparent;
                }
                if (NumberOvertime.Trim() == "00:00:00")
                {
                    row.Cells[7].Style.ForeColor = Color.Transparent;
                    row.Cells[7].Style.SelectionForeColor = Color.Transparent;
                }

                if (dateInRow.DayOfWeek == DayOfWeek.Sunday)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void loadGridview(List<ChamCong> _ChamCongs)
        {
            dataGridChamcong.AutoGenerateColumns = false;
            dataGridChamcong.DataSource = null;
            dataGridChamcong.DataSource = _ChamCongs;
            ChangeStyleDataGridView(dataGridChamcong);
            foreach (Control btn in grpPagination.Controls)
            {
                if (btn.Text.Trim() == PAGE.ToString())
                    btn.BackColor = Color.Red;
                else
                    btn.BackColor = Color.Transparent;
            }
        }


        #endregion

        #region //==================== Code in form củ ====================//
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(strConnect);
        //    sqlConnection.Open();
        //    string queryCount = "SELECT Count(manv) FROM nhanvien";
        //    SqlCommand cmdCount = new SqlCommand(queryCount, sqlConnection);
        //    Int32 count = (Int32)cmdCount.ExecuteScalar();
        //    sqlConnection.Close();

        //    for (int i = 0; i < count; i++)
        //    {
        //        TotalChamCong _TotalChamCong = _TOTAL_CHAMCONGS[i];
        //        loadGridview(_TotalChamCong._ChamCongs);
        //        showLabelInfo(_TotalChamCong.sKeeptime);

        //        string title = ("BẢNG CHẤM CÔNG");
        //        string thang = ("Tháng " + MONTH + " năm " + YEAR);
        //        string ma = ("Mã nhân viên : " + _TotalChamCong.sKeeptime.MaNV.ToString());
        //        string ten = ("Tên nhân viên : " + _TotalChamCong.sKeeptime.TenNV.ToString());
        //        string vang = ("Vắng mặt : " + _TotalChamCong.sKeeptime.Absent.ToString());
        //        string tre = ("Đi trể : " + _TotalChamCong.sKeeptime.Late.ToString());
        //        string tangca = ("Tăng ca : " + _TotalChamCong.sKeeptime.NumberOfOvertime.ToString());

        //        StringBuilder sb = new StringBuilder();
        //        sb.AppendLine(thang);
        //        sb.AppendLine(ma);
        //        sb.AppendLine(ten);
        //        sb.AppendLine(vang.PadLeft(195 + vang.Length));
        //        sb.AppendLine(tre.PadLeft(195 + tre.Length));
        //        sb.AppendLine(tangca.PadLeft(195 + tangca.Length));

        //        StringBuilder sb1 = new StringBuilder();
        //        sb1.AppendLine(title);

        //        DGVPrinterHelper.DGVPrinter printer = new DGVPrinterHelper.DGVPrinter();
        //        printer.Title = sb1.ToString();

        //        printer.SubTitle = sb.ToString();

        //        printer.SubTitleFont = new System.Drawing.Font("Myriad Pro", 10.3F,//
        //                                    System.Drawing.FontStyle.Bold, //
        //                                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        printer.SubTitleAlignment = StringAlignment.Near;

        //        printer.PageNumbers = true;
        //        printer.PageNumberInHeader = false;
        //        printer.PorportionalColumns = true; ;
        //        printer.HeaderCellAlignment = StringAlignment.Center;
        //        printer.FooterAlignment = StringAlignment.Near;
        //        printer.FooterSpacing = 15;

        //        try
        //        {
        //            printer.PrintNoDisplay(dataGridChamcong);
        //        }
        //        catch
        //        {
        //            MessageBox.Show("file dang mo");
        //            return;
        //        }
        //    }
        //}
        #endregion


    }
}