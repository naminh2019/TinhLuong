using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhLuong
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void lấyDữLiệuTừExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExcel ImportExcel = new TinhLuong.ImportExcel();
            ImportExcel.MdiParent = this;
            if (!CheckOpened(ImportExcel.Name))
                ImportExcel.Show();
        }
        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSnhanvien DSnhanvien = new DSnhanvien();
            DSnhanvien.MdiParent = this;
            if (!CheckOpened(DSnhanvien.Name))
                DSnhanvien.Show();
        }
        private void danhSáchNhómViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void tínhPhụCấpVàKhấuTrừToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FixedAllowance FixedAllowance = new Forms.FixedAllowance();
            FixedAllowance.MdiParent = this;
            if (!CheckOpened(FixedAllowance.Name))
                FixedAllowance.Show();
        }

        private void đánhGiáThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Classification Classification = new Forms.Classification();
            Classification.MdiParent = this;
            if (!CheckOpened(Classification.Name))
                Classification.Show();
        }

        private void inTínhLươngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.Tinhluong Tinhluong = new Forms.Tinhluong();
            Tinhluong.MdiParent = this;
            if (!CheckOpened(Tinhluong.Name))
                Tinhluong.Show();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bảngChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selectmonth Selectmonth = new Selectmonth();
            Selectmonth.MdiParent = this;
            if (!CheckOpened(Selectmonth.Name))
                Selectmonth.Show();
        }

        private void cậpNhậtTăngCaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Forms.ExtraOvertime ExtraOvertime = new Forms.ExtraOvertime();
            ExtraOvertime.MdiParent = this;
            if (!CheckOpened(ExtraOvertime.Name))
                ExtraOvertime.Show();
        }

        private void tiềnĐóngGópTừThiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharityMoney CharityMoney = new CharityMoney();
            CharityMoney.MdiParent = this;
            if (!CheckOpened(CharityMoney.Name))
                CharityMoney.Show();
        }

         }
}
