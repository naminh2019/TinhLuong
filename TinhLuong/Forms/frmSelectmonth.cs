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
    public partial class Selectmonth : Form
    {
        public Selectmonth()
        {
            InitializeComponent();
        }
        #region //==================== Form Layout ====================//

        protected override void OnMouseEnter(System.EventArgs e)
        {
            lblOK.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblCancel.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblOK.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblCancel.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
    
            base.OnMouseLeave(e);
        }

        #endregion

        private void Selectmonth_Load(object sender, EventArgs e)
        {
            lblYear.Text = DateTime.Now.Year.ToString();
            txtHoliday.Text = "0";
            OnMouseEnter(e);
            OnMouseLeave(e);
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);

            int year = int.Parse(lblYear.Text.ToString());
            int month = getMonth();
            int holiday = int.Parse(txtHoliday.Text.ToString());

            if (month == 0)
            {
                MessageBox.Show("Chua chon thang");
                return;
            }
            sqlConnection.Open();
            String query = String.Format("select count(*) from dulieu where month(Timekeep) = {0} and year(Timekeep) = {1}", month, year);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Int32 err = (Int32)sqlCommand.ExecuteScalar();

            if (err == 0)
            {
                MessageBox.Show("No data");
                return;
            }

            frmChamcong frChamcong = new frmChamcong(month, year, holiday);
            frChamcong.ShowDialog();
            this.Close();
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
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            lblYear.Text = (int.Parse(lblYear.Text.ToString()) + 1).ToString();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            lblYear.Text = (int.Parse(lblYear.Text.ToString()) - 1).ToString();
        }
        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHoliday_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
