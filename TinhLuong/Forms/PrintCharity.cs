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
    public partial class PrintCharity : Form
    {
        string textMonth = null;
        List<Salary.Charity> penaltyMoney = new List<Salary.Charity>();
        public PrintCharity(string textMonth, List<Salary.Charity> penaltyMoney)
        {
            InitializeComponent();
            this.textMonth = textMonth;
            this.penaltyMoney = penaltyMoney;
        }

        private void PrintCharity_Load(object sender, EventArgs e)
        {
            rptLatePenalty1.SetDataSource(penaltyMoney);
            rptLatePenalty1.SetParameterValue("pMonth", textMonth);
            crystalReportViewer1.ReportSource = rptLatePenalty1;
            crystalReportViewer1.Refresh();

            PrinterSettings getprinterName = new PrinterSettings();
            rptLatePenalty1.PrintOptions.PrinterName = "Xprinter XP-350BM";
            rptLatePenalty1.PrintToPrinter(1, true, 1, 1);

            rptLatePenalty1.Close();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.Refresh();
            this.Close();
            GC.Collect();
        }
    }
}
