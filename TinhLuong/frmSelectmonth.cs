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
    public partial class frmSelectmonth : Form
    {
        public frmSelectmonth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboNam.SelectedIndex < 0)
            {
                MessageBox.Show("Chua chon nam");
                return;
            }
                
            int year = int.Parse(cboNam.Text.ToString());
            int month = getMonth();

            if (month == 0)
            {
                MessageBox.Show("Chua chon thang");
                return;
            }

            frmChamcong frChamcong = new frmChamcong(month, year);
            frChamcong.ShowDialog();
        }

        private void frmSelectmonth_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;

            cboNam.Items.Add(year - 1);
            cboNam.Items.Add(year);
        }

        private int getMonth()
        {
            if (radioButton1.Checked == true)
                return 1;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            MessageBox.Show("true");
        }
    }
}
