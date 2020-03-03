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
    public partial class CharityMoney : Form
    {
        public CharityMoney()
        {
            InitializeComponent();
        }
        #region //==================== Form Open & Close ====================// 
        string sMonth = null;
        string textMonth = null;
        List<Salary.Charity> penaltyMoney = new List<Salary.Charity>();

        private void CharityMoney_Load(object sender, EventArgs e)
        {
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
            sMonth = cboMonth.Text.ToString() + "-" + cboYear.Text.ToString();
            textMonth = ("Tháng " + cboMonth.Text.ToString() + " Năm " + cboYear.Text.ToString());

            string queryCharity = string.Format("select NV.MaNV,Tennhanvien, Money from Nhanvien NV inner join SalaryHistory SH" +
                                             " on NV.MaNV = SH.MaNV and SH.DeductID = 6 and sh.date = '{0}'", sMonth);
            SqlCommand cmdCharity = new SqlCommand(queryCharity, ConnectionUtils.getConnection());
            SqlDataReader exeCharity = cmdCharity.ExecuteReader();

            while (exeCharity.Read())
            {
                penaltyMoney.Add(new Salary.Charity()
                {
                    MaNV = (int)exeCharity["MaNV"],
                    Tennhanvien = exeCharity["tennhanvien"].ToString(),
                    NumberOfLate = (int)exeCharity["Money"] / 50000,
                    Money = (int)exeCharity["Money"]
                });
            }

            int TotalMoney = penaltyMoney.Sum(x => x.Money);
            lblSum.Text = TotalMoney.ToString("###,###,###");

            dgvCharity.AutoGenerateColumns = false;
            dgvCharity.DataSource = null;
            dgvCharity.DataSource = penaltyMoney;

            dgvCharity.Height = dgvCharity.Rows.Cast<DataGridViewRow>().Sum(x => x.Height * 123 / 100);
            int locationText = int.Parse(dgvCharity.Location.Y.ToString()) + int.Parse(dgvCharity.Height.ToString());
            lblSum.Location = new Point(498, locationText);
            lblTextTC.Location = new Point(96, locationText);
            OnMouseEnter(e);
            OnMouseLeave(e);
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion;

        #region //==================== Control Process ====================// 
        protected override void OnMouseEnter(System.EventArgs e)
        {
            lblPrint.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblPrint.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);

            base.OnMouseLeave(e);
        }
        #endregion

        private void lblPrint_Click(object sender, EventArgs e)
        {
            using (PrintCharity PrintCharity = new PrintCharity(textMonth, penaltyMoney))
            {
                PrintCharity.ShowDialog();
            }
        }
    }
}
