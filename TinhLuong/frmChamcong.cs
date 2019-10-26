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


namespace TinhLuong
{
    public partial class frmChamcong : Form
    {
        public int year;
        public int month;
        public frmChamcong()
        {
            InitializeComponent();
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
        private void ChangeStyleDataGridView(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                DateTime dateInRow = DateTime.Parse(row.Cells[1].Value.ToString());

                String InMorning = row.Cells[2].Value.ToString();
                String OutMorning = row.Cells[3].Value.ToString();
                String InAfternoon = row.Cells[4].Value.ToString();
                String OutAfternoon = row.Cells[5].Value.ToString();
                String InOvertime = row.Cells[6].Value.ToString();
                String OutOvertime = row.Cells[7].Value.ToString();
                String NumberOvertime = row.Cells[8].Value.ToString();

                if (InMorning.Trim() == "00:00:00")
                {
                    row.Cells[2].Style.ForeColor = Color.Transparent;
                    row.Cells[2].Style.SelectionForeColor = Color.Transparent;
                }
                if (OutMorning.Trim() == "00:00:00")
                {
                    row.Cells[3].Style.ForeColor = Color.Transparent;
                    row.Cells[3].Style.SelectionForeColor = Color.Transparent;
                }
                if (InAfternoon.Trim() == "00:00:00")
                {
                    row.Cells[4].Style.ForeColor = Color.Transparent;
                    row.Cells[4].Style.SelectionForeColor = Color.Transparent;
                }
                if (OutAfternoon.Trim() == "00:00:00")
                {
                    row.Cells[5].Style.ForeColor = Color.Transparent;
                    row.Cells[5].Style.SelectionForeColor = Color.Transparent;
                }
                if (InOvertime.Trim() == "00:00:00")
                {
                    row.Cells[6].Style.ForeColor = Color.Transparent;
                    row.Cells[6].Style.SelectionForeColor = Color.Transparent;
                }
                if (OutOvertime.Trim() == "00:00:00")
                {
                    row.Cells[7].Style.ForeColor = Color.Transparent;
                    row.Cells[7].Style.SelectionForeColor = Color.Transparent;
                }
                if (NumberOvertime.Trim() == "00:00:00")
                {
                    row.Cells[8].Style.ForeColor = Color.Transparent;
                    row.Cells[8].Style.SelectionForeColor = Color.Transparent;
                }

                if (dateInRow.DayOfWeek == DayOfWeek.Sunday)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private List<clsChamCong> loadRecord(int page, int recordNumber)
        {

            List<clsChamCong> loadPage = new List<clsChamCong>();

            loadPage = _ChamCongAlls.Skip((page - 1) * recordNumber).Take(numberRecord).ToList();
            return loadPage;
        }
        public frmChamcong(int month, int year)
        {
            InitializeComponent();
            this.month = month;
            this.year = year;
        }
        private List<clsChamCong> createDefaultDataByMonth(int month, int year, int MaNhanVien)
        {
            List<clsChamCong> chamCongs = new List<clsChamCong>();

            int firstDayOfMonth = 1;
            int lastDayOfMonth = DateTime.DaysInMonth(year, month);
            int i = firstDayOfMonth;

            clsChamCong _clsChamCong = null;
            while (i <= lastDayOfMonth)
            {
                _clsChamCong = new clsChamCong();
                DateTime date = new DateTime(year, month, i);

                _clsChamCong.MaNhanVien = MaNhanVien;
                _clsChamCong.Date = date;

                chamCongs.Add(_clsChamCong);

                i++;
            }

            return chamCongs;
        }
        private void loadData()
        {
            //NhanVienHistory _NhanVienHistory = _NhanVienHistories[1];
            //lblTotal.Text = _NhanVienHistory.NumberOfOvertime.ToString();
            //lblManv.Text = _NhanVienHistory.MaNV.ToString();
            //lblLate.Text = _NhanVienHistory.Late.ToString();
            //lblLeave.Text = _NhanVienHistory.Absent.ToString();


            TimeSpan lateTime = new TimeSpan(8, 10, 0);
            int late = 0;
            int leave = 0;
            TimeSpan total = new TimeSpan();



            //if (page < 1) page = 1;
            //btn1.Text = page.ToString();
            //if (page > _ChamCongAlls.Count() / numberRecord - 9) page = _ChamCongAlls.Count() / numberRecord - 9;
            //btn1.Text = page.ToString();

            //btn2.Text = (int.Parse(btn1.Text) + 1).ToString();
            //btn3.Text = (int.Parse(btn2.Text) + 1).ToString();
            //btn4.Text = (int.Parse(btn3.Text) + 1).ToString();
            //btn5.Text = (int.Parse(btn4.Text) + 1).ToString();
            //btn6.Text = (int.Parse(btn5.Text) + 1).ToString();
            //btn7.Text = (int.Parse(btn6.Text) + 1).ToString();
            //btn8.Text = (int.Parse(btn7.Text) + 1).ToString();
            //btn9.Text = (int.Parse(btn8.Text) + 1).ToString();
            //btn10.Text = (int.Parse(btn9.Text) + 1).ToString();

            //if (int.Parse(btn1.Text) == pageNumber) btn1.BackColor = Color.GreenYellow;
            //else btn1.BackColor = Color.Transparent;
            //if (int.Parse(btn2.Text) == pageNumber) btn2.BackColor = Color.GreenYellow;
            //else btn2.BackColor = Color.Transparent;
            //if (int.Parse(btn3.Text) == pageNumber) btn3.BackColor = Color.GreenYellow;
            //else btn3.BackColor = Color.Transparent;
            //if (int.Parse(btn4.Text) == pageNumber) btn4.BackColor = Color.GreenYellow;
            //else btn4.BackColor = Color.Transparent;
            //if (int.Parse(btn5.Text) == pageNumber) btn5.BackColor = Color.GreenYellow;
            //else btn5.BackColor = Color.Transparent;
            //if (int.Parse(btn6.Text) == pageNumber) btn6.BackColor = Color.GreenYellow;
            //else btn6.BackColor = Color.Transparent;
            //if (int.Parse(btn7.Text) == pageNumber) btn7.BackColor = Color.GreenYellow;
            //else btn7.BackColor = Color.Transparent;
            //if (int.Parse(btn8.Text) == pageNumber) btn8.BackColor = Color.GreenYellow;
            //else btn8.BackColor = Color.Transparent;
            //if (int.Parse(btn9.Text) == pageNumber) btn9.BackColor = Color.GreenYellow;
            //else btn9.BackColor = Color.Transparent;
            //if (int.Parse(btn10.Text) == pageNumber) btn10.BackColor = Color.GreenYellow;
            //else btn10.BackColor = Color.Transparent;

            foreach (DataGridViewRow Addrow in dataGridChamcong.Rows)
            {
                if (TimeSpan.Parse(Addrow.Cells["Inmorning"].Value.ToString()).CompareTo(lateTime) > 0)
                {
                    late = late + 1;
                }
                if (DateTime.Parse(Addrow.Cells["Date"].Value.ToString()).DayOfWeek != DayOfWeek.Sunday && Addrow.Cells["Inmorning"].Value.ToString().Trim() == "00:00:00" && Addrow.Cells["InAfternoon"].Value.ToString().Trim() == "00:00:00")
                    leave = leave + 1;

                //============================================================================
                int mNhanvien = int.Parse(Addrow.Cells["manhanvien"].Value.ToString());
                total = total.Add(TimeSpan.Parse(Addrow.Cells["NumberOvertime"].Value.ToString()));
                StringBuilder sb = FormatNumberOvertime(total);

                String queryIDSelect = string.Format("SELECT * FROM nhanvien where MaNV = {0}", mNhanvien);
                DataTable IDselect = ClassConnect.findAll(queryIDSelect);
                foreach (DataRow TenNV in IDselect.Rows)
                {
                    lblTennhanvien.Text = (TenNV["tennhanvien"].ToString());
                }

                lblTotal.Text = sb.ToString();
                lblManv.Text = Addrow.Cells["manhanvien"].Value.ToString();
                lblLate.Text = late.ToString();
                lblLeave.Text = leave.ToString();

                #region viewpagenumber



                if (page < 1) page = 1;
                btn1.Text = page.ToString();
                if (page > _ChamCongAlls.Count() / numberRecord - 9) page = _ChamCongAlls.Count() / numberRecord - 9;
                btn1.Text = page.ToString();

                btn2.Text = (int.Parse(btn1.Text) + 1).ToString();
                btn3.Text = (int.Parse(btn2.Text) + 1).ToString();
                btn4.Text = (int.Parse(btn3.Text) + 1).ToString();
                btn5.Text = (int.Parse(btn4.Text) + 1).ToString();
                btn6.Text = (int.Parse(btn5.Text) + 1).ToString();
                btn7.Text = (int.Parse(btn6.Text) + 1).ToString();
                btn8.Text = (int.Parse(btn7.Text) + 1).ToString();
                btn9.Text = (int.Parse(btn8.Text) + 1).ToString();
                btn10.Text = (int.Parse(btn9.Text) + 1).ToString();

                if (int.Parse(btn1.Text) == pageNumber) btn1.BackColor = Color.GreenYellow;
                else btn1.BackColor = Color.Transparent;
                if (int.Parse(btn2.Text) == pageNumber) btn2.BackColor = Color.GreenYellow;
                else btn2.BackColor = Color.Transparent;
                if (int.Parse(btn3.Text) == pageNumber) btn3.BackColor = Color.GreenYellow;
                else btn3.BackColor = Color.Transparent;
                if (int.Parse(btn4.Text) == pageNumber) btn4.BackColor = Color.GreenYellow;
                else btn4.BackColor = Color.Transparent;
                if (int.Parse(btn5.Text) == pageNumber) btn5.BackColor = Color.GreenYellow;
                else btn5.BackColor = Color.Transparent;
                if (int.Parse(btn6.Text) == pageNumber) btn6.BackColor = Color.GreenYellow;
                else btn6.BackColor = Color.Transparent;
                if (int.Parse(btn7.Text) == pageNumber) btn7.BackColor = Color.GreenYellow;
                else btn7.BackColor = Color.Transparent;
                if (int.Parse(btn8.Text) == pageNumber) btn8.BackColor = Color.GreenYellow;
                else btn8.BackColor = Color.Transparent;
                if (int.Parse(btn9.Text) == pageNumber) btn9.BackColor = Color.GreenYellow;
                else btn9.BackColor = Color.Transparent;
                if (int.Parse(btn10.Text) == pageNumber) btn10.BackColor = Color.GreenYellow;
                else btn10.BackColor = Color.Transparent;
                #endregion
            }
        }

        private NhanVienHistory calculateNhanVienHistory(List<clsChamCong> _ChamCongs)
        {

            TimeSpan lateTime = new TimeSpan(8, 10, 0);
            int totalLate = 0;
            int totalLeave = 0;
            TimeSpan total = new TimeSpan();
            int MaNhanVien = 0;

            foreach (clsChamCong _NhanVien in _ChamCongs)
            {
                MaNhanVien = _NhanVien.MaNhanVien;

                if (TimeSpan.Parse(_NhanVien.InMorning.ToString()).CompareTo(lateTime) > 0)
                {
                    totalLate = totalLate + 1;
                }
                if (DateTime.Parse(_NhanVien.Date.ToString()).DayOfWeek != DayOfWeek.Sunday //
                    && _NhanVien.InMorning.ToString().Trim() == "00:00:00" //
                    && _NhanVien.InAfternoon.ToString().Trim() == "00:00:00")
                    totalLeave = totalLeave + 1;

                int mNhanvien = _NhanVien.MaNhanVien;
                total = total.Add(TimeSpan.Parse(_NhanVien.NumberOvertime.ToString()));
                StringBuilder sb = FormatNumberOvertime(total);

                String queryIDSelect = string.Format("SELECT * FROM nhanvien where MaNV = {0}", mNhanvien);
                DataTable IDselect = ClassConnect.findAll(queryIDSelect);
                foreach (DataRow TenNV in IDselect.Rows)
                {
                    lblTennhanvien.Text = (TenNV["tennhanvien"].ToString());
                }
            }

            StringBuilder buider = FormatNumberOvertime(total);
            NhanVienHistory _NhanVienHistory = new NhanVienHistory();
            _NhanVienHistory.MaNV = MaNhanVien;
            _NhanVienHistory.Date = month;
            _NhanVienHistory.NumberOfOvertime = buider.ToString();
            _NhanVienHistory.Absent = totalLeave;
            _NhanVienHistory.Late = totalLate;

            return _NhanVienHistory;
        }

        private void getTotalNumberOvertime(List<clsChamCong> _ChamCongs)
        {
            TimeSpan lateTime = new TimeSpan(8, 10, 0);
            int totalLate = 0;
            int totalLeave = 0;
            TimeSpan total = new TimeSpan();
            int MaNhanVien = 0;

            foreach (clsChamCong _NhanVien in _ChamCongs)
            {
                MaNhanVien = _NhanVien.MaNhanVien;

                if (TimeSpan.Parse(_NhanVien.InMorning.ToString()).CompareTo(lateTime) > 0)
                {
                    totalLate = totalLate + 1;
                }
                if (DateTime.Parse(_NhanVien.Date.ToString()).DayOfWeek != DayOfWeek.Sunday //
                    && _NhanVien.InMorning.ToString().Trim() == "00:00:00" //
                    && _NhanVien.InAfternoon.ToString().Trim() == "00:00:00")
                    totalLeave = totalLeave + 1;

                int mNhanvien = _NhanVien.MaNhanVien;
                total = total.Add(TimeSpan.Parse(_NhanVien.NumberOvertime.ToString()));
                StringBuilder sb = FormatNumberOvertime(total);

                String queryIDSelect = string.Format("SELECT * FROM nhanvien where MaNV = {0}", mNhanvien);
                DataTable IDselect = ClassConnect.findAll(queryIDSelect);
                foreach (DataRow TenNV in IDselect.Rows)
                {
                    lblTennhanvien.Text = (TenNV["tennhanvien"].ToString());
                }
            }

            StringBuilder buider = FormatNumberOvertime(total);
            NhanVienHistory _NhanVienHistory = new NhanVienHistory();
            _NhanVienHistory.MaNV = MaNhanVien;
            _NhanVienHistory.Date = month;
            _NhanVienHistory.NumberOfOvertime = buider.ToString();
            _NhanVienHistory.Absent = totalLeave;
            _NhanVienHistory.Late = totalLate;
            _NhanVienHistories.Add(_NhanVienHistory);

        }
        private void loadGridview()
        {
            dataGridChamcong.AutoGenerateColumns = true;
            dataGridChamcong.DataSource = null;
            dataGridChamcong.DataSource = loadRecord(pageNumber, numberRecord);
            ChangeStyleDataGridView(dataGridChamcong);
        }
        //==================================================================================================================================
        List<TotalChamCong> _totalChamCongs = new List<TotalChamCong>();

        List<clsChamCong> _ChamCongAlls = new List<clsChamCong>();
        List<NhanVienHistory> _NhanVienHistories = new List<NhanVienHistory>();
        int page = 1;
        private void Chamcong_Load(object sender, EventArgs e)
        {
            

            lblHead.Text = string.Format("Tháng {0} năm {1}", month, year);

            numberRecord = DateTime.DaysInMonth(year, month);

            string query = "select distinct(manv) from nhanvien";
            DataTable maNhanvien = ClassConnect.findAll(query);

            //List<clsChamCong> _ChamCongAlls = new List<clsChamCong>();
            foreach (DataRow IDnhanvien in maNhanvien.Rows)
            {
                int MaNhanVien = int.Parse(IDnhanvien["MaNV"].ToString());
                if (MaNhanVien <= 0)
                {
                    return;
                }

                string query2 = string.Format("select * from dulieu where month(f2) = {0} and f1 = {1}", month, MaNhanVien);
                DataTable tChamcong = ClassConnect.findAll(query2);


                List<clsChamCong> ChamCongs = createDefaultDataByMonth(month, year, MaNhanVien);

                foreach (DataRow rows in tChamcong.Rows)
                {
                    DateTime date = DateTime.Parse(rows[1].ToString());

                    DateTime dateOnly = date.Date;
                    TimeSpan timeOnly = date.TimeOfDay;

                    String queryIDSelect = string.Format("SELECT * FROM nhanvien where MaNV = {0}", MaNhanVien);

                    DataTable IDselect = ClassConnect.findAll(queryIDSelect);

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

                        int macongviec = int.Parse(DefaultTime["MaCV"].ToString());

                        TimeSpan InMorning = new TimeSpan();
                        TimeSpan OutMorning = new TimeSpan();
                        TimeSpan InAfternoon = new TimeSpan();
                        TimeSpan OutAfternoon = new TimeSpan();
                        TimeSpan InOvertime = new TimeSpan();
                        TimeSpan OutOvertime = new TimeSpan();
                        TimeSpan NumberOvertime = new TimeSpan();

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
                                //InOvertime = new TimeSpan(17, 0, 0);
                                InOvertime = DefaultInOvertime;
                                OutOvertime = timeOnly;
                            }
                        }
                        //List<clsChamCong> tChamCongs = new List < clsChamCong >
                        // tChamCongs.Add(ChamCongs);

                        #region inserttime 
                        //=================================================================================================================

                        foreach (clsChamCong objInList in ChamCongs)
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
                                #endregion
                                #region NumberOvertime
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
                getTotalNumberOvertime(ChamCongs);
                Console.WriteLine("size = " + _NhanVienHistories.Count());
                _ChamCongAlls.AddRange(ChamCongs);

                TotalChamCong _TotalChamCong = new TotalChamCong();
                _TotalChamCong.MaNV = MaNhanVien;
                _TotalChamCong._NhanVienHistory = calculateNhanVienHistory(ChamCongs);
                _TotalChamCong._ChamCongs = ChamCongs;
                _totalChamCongs.Add(_TotalChamCong);


               


                loadGridview();
                loadData();


                #endregion
            }

            totalPage = _ChamCongAlls.Count() / numberRecord;
        }

        int totalPage = -1;
        int pageNumber = 1;
        int numberRecord = -1;
        private void btnBack_Click(object sender, EventArgs e)
        {

            if (pageNumber - 1 > 0)
            {
                page--;
                pageNumber--;
                loadGridview();
                loadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (pageNumber < _ChamCongAlls.Count() / numberRecord)
            {
                page++;
                pageNumber++;
                loadGridview();
                loadData();
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            int find = 0;
            foreach (clsChamCong timkiem in _ChamCongAlls)
            {
                if (timkiem.MaNhanVien != int.Parse(txtFind.Text.Trim().ToString()))
                {
                    find++;
                    continue;
                }
                page = find / numberRecord + 1;
                pageNumber = find / numberRecord + 1;
                loadGridview();
                loadData();
            }
        }
        #region page view
        private void btn1_Click(object sender, EventArgs e)
        {
            //page--;
            //pageNumber = int.Parse(btn1.Text);
            //loadGridview();
            //loadData();

            pageNumber = int.Parse(btn1.Text);

            TotalChamCong _TotalChamCong = _totalChamCongs[pageNumber - 1];

            dataGridChamcong.AutoGenerateColumns = true;
            dataGridChamcong.DataSource = null;
            dataGridChamcong.DataSource = _TotalChamCong._ChamCongs;
            ChangeStyleDataGridView(dataGridChamcong);

            lblTotal.Text = _TotalChamCong._NhanVienHistory.NumberOfOvertime.ToString();
            lblManv.Text = _TotalChamCong._NhanVienHistory.MaNV.ToString();
            lblLate.Text = _TotalChamCong._NhanVienHistory.Late.ToString();
            lblLeave.Text = _TotalChamCong._NhanVienHistory.Absent.ToString();


        }

        private void btn2_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn2.Text);
            loadGridview();
            loadData();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn3.Text);
            loadGridview();
            loadData();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn4.Text);
            loadGridview();
            loadData();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn5.Text);
            loadGridview();
            loadData();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn6.Text);
            loadGridview();
            loadData();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn7.Text);
            loadGridview();
            loadData();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn8.Text);
            loadGridview();
            loadData();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(btn9.Text);
            loadGridview();
            loadData();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            page++;
            pageNumber = int.Parse(btn10.Text);
            loadGridview();
            loadData();
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_NhanVienHistories == null || _NhanVienHistories.Count == 0)
            {
                MessageBox.Show("No data");
                return;
            }

            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);

            try
            {
                sqlConnection.Open();
                foreach (NhanVienHistory _NhanVienHistory in _NhanVienHistories)
                {
                    int MaNV = _NhanVienHistory.MaNV;
                    int Date = _NhanVienHistory.Date;
                    string NumberOfOvertime = _NhanVienHistory.NumberOfOvertime;
                    int Absent = _NhanVienHistory.Absent;
                    int Late = _NhanVienHistory.Late;

                    String historyQuery = String.Format("select * from NhanVienHistory where Date = {0} and MaNV = {1}", Date, MaNV);
                    DataTable historyTable = ClassConnect.findAll(historyQuery);
                    if (historyTable.Rows.Count > 0)
                    {
                        // update command
                    }
                    else
                    {
                        string query = String.Format(" INSERT INTO NhanVienHistory(MaNV, Date, NumberOfOvertime, Absent, Late) VALUES({0}, {1}, '{2}', {3}, {4}) ",
                        MaNV, Date, NumberOfOvertime, Absent, Late);

                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        Int32 kq = sqlCommand.ExecuteNonQuery();
                    }
                }

                //for (int i = 1; i <= totalPage; i++)
                //{
                //    pageNumber = i;
                //    loadGridview();
                //    loadData();
                //    int MaNV = int.Parse(lblManv.Text.ToString());
                //    int Date = int.Parse(month.ToString());
                //    string NumberOfOvertime = lblTotal.Text;
                //    int Absent = int.Parse(lblLeave.Text.ToString());
                //    int Late = Int16.Parse(lblLate.Text.ToString());

                //    string query = String.Format(" INSERT INTO SaveData(MaNV, Date, NumberOfOvertime, Absent, Late) VALUES({0}, {1}, '{2}', {3}, {4}) ",
                //        MaNV, Date, NumberOfOvertime, Absent, Late);

                //    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //    Int32 kq = sqlCommand.ExecuteNonQuery();
                //}

                // Console.WriteLine("OK");
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Loi" + ex.Message);
                MessageBox.Show("Loi" + ex.Message);
            }


            
        }
    }
}
