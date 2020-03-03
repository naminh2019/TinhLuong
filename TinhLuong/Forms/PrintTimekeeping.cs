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

namespace TinhLuong
{
    public partial class PrintTimekeeping : Form
    {
        List<TinhLuong.Entities.ChamCong> sChamcong = new List<Entities.ChamCong>();
        string thang = null;
        string ma = null;
        string ten = null;
        string vang = null;
        string tre = null;
        string tangca = null;
        Boolean PrintAll;

        public PrintTimekeeping(List<TinhLuong.Entities.ChamCong> sChamcong, string thang, string ma, string ten, string vang, string tre, string tangca, Boolean PrintAll )
        {
            InitializeComponent();
            this.sChamcong  = sChamcong;
            this.thang = thang;
            this.ma = ma;
            this.ten = ten;
            this.vang = vang;
            this.tre = tre;
            this.tangca = tangca;
            this.PrintAll = PrintAll;
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rptTimekeeping1.SetDataSource(sChamcong);
            rptTimekeeping1.SetParameterValue("pNgaythang", thang);
            rptTimekeeping1.SetParameterValue("pMaNV",ma);
            rptTimekeeping1.SetParameterValue("pTennhanvien", ten);
            rptTimekeeping1.SetParameterValue("pVangmat", vang);
            rptTimekeeping1.SetParameterValue("pDitre", tre);
            rptTimekeeping1.SetParameterValue("pTangca", tangca);
            crystalReportViewer1.ReportSource = rptTimekeeping1;
            crystalReportViewer1.Refresh();

            if (PrintAll == true)
            {
                PrinterSettings getprinterName = new PrinterSettings();
                rptTimekeeping1.PrintOptions.PrinterName = "Gestetner MP 301 PCL 6";
                rptTimekeeping1.PrintToPrinter(1, true, 1, 1);

                rptTimekeeping1.Close();
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Refresh();
                this.Close();
                GC.Collect();
            }
        }
    }
}
