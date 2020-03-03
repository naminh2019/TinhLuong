using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TinhLuong.Forms
{
    public partial class PrintSalary : Form
    {
        private List<Salary.Allowance> sThunhap;
        private List<Salary.Deduct> sKhautru;
        string sMonth = null;
        string sName = null;
        string sLate = null;
        string sLeave = null;
        string sOvertime = null;
        int tongTN = 0;
        int tongKT = 0;
        int giocong = 0;
        int MaNV = 0;
        string sRank = null;
        public PrintSalary(List<Salary.Allowance> emThunhap, List<Salary.Deduct> emKhautru,
                           string sMonth, string sName, string sLate, string sLeave, string sOvertime, int tongTN, int tongKT, int MaNV, String sRank, int giocong)
        {
            InitializeComponent();
            this.sThunhap = emThunhap;
            this.sKhautru = emKhautru;
            this.sLeave = sLeave;
            this.sLate = sLate;
            this.sOvertime = sOvertime;
            this.sMonth = sMonth;
            this.sName = sName;
            this.tongTN = tongTN;
            this.tongKT = tongKT;
            this.MaNV = MaNV;
            this.sRank = sRank;
            this.giocong = giocong;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            Report.rptTinhluong crystalRpt = new Report.rptTinhluong();
            crystalRpt.Load("D:/TinhLuong/TinhLuong/TinhLuong/Report/rptTinhluong.rpt");
            crystalRpt.DataSourceConnections.Clear();
            crystalRpt.Subreports[0].SetDataSource(sThunhap);
            crystalRpt.Subreports[1].SetDataSource(sKhautru);
            crystalRpt.SetParameterValue("pTotalTN", tongTN.ToString("###,###,###"));
            crystalRpt.SetParameterValue("pTotalKT", tongKT.ToString("###,###,###"));
            crystalRpt.SetParameterValue("pThuclanh", (tongTN - tongKT).ToString("###,###,###"));
            crystalRpt.SetParameterValue("pNgaythang", sMonth);
            crystalRpt.SetParameterValue("pTennhanvien", sName);
            crystalRpt.SetParameterValue("pMaNV", "Mã NV :" + MaNV);
            crystalRpt.SetParameterValue("pGiocong", "Giờ công : " + giocong.ToString("###,###"));
            crystalRpt.SetParameterValue("pTangca", "Tăng ca : " + sOvertime);
            crystalRpt.SetParameterValue("pDitre", "Đi trể : " + sLate);
            crystalRpt.SetParameterValue("pXephang", "Xếp hạng : " + sRank);
            crystalRpt.SetParameterValue("pNghiphep", "Nghỉ phép : " + sLeave);
            crystalReportViewer1.ReportSource = crystalRpt;
            crystalReportViewer1.Refresh();

            PrinterSettings getprinterName = new PrinterSettings();
            crystalRpt.PrintOptions.PrinterName = "Xprinter XP-350BM";
            crystalRpt.PrintToPrinter(1, true, 1, 1);

            crystalRpt.Close();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.Refresh();
            this.Close();
            GC.Collect();

        }
    }
}
