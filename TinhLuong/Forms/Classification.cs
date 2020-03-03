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

namespace TinhLuong.Forms
{
    public partial class Classification : Form
    {
        public Classification()
        {
            InitializeComponent();
        }
        #region//===================== Declare variable ====================//
        List<TinhLuong.Entities.Classification> sClassification = null;
        string Date = null;
        DataTable sRank = null;
        Boolean check = false;
        #endregion

        #region //==================== Form Open & Close ====================// 
        private void Classification_Load(object sender, EventArgs e)
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
            fillDadagrid();
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
            label1.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblSave.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblClose.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            label1.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblSave.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblClose.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);

            base.OnMouseLeave(e);
        }
        #endregion

        #region //==================== DataContainer Process ====================// 

        private void dgvRank_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnKeyPress);
            if (dgvRank.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnKeyPress);
                }
            }
        }
        private void dgvRank_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRank.Rows)
            {
                row.Cells[3].Value = row.Cells[3].Value.ToString().ToUpper();
                if (row.Cells[3].Value.ToString().Length > 1)
                {
                    row.Cells[3].Value = row.Cells[3].Value.ToString().Substring(0, 1);
                }
            }
        }
        #endregion();

        #region //==================== FormDisplay Process ====================// 
        private void label1_Click(object sender, EventArgs e)
        {
            fillDadagrid();
        }
        #endregion

        #region //==================== CURD Click ====================// 
        private void lblSave_Click(object sender, EventArgs e)
        {
            if (sRank.Rows.Count > 0)
            {
                if (check == false)
                {
                    DialogResult result = MessageBox.Show("Du lieu trung, ban muon xoa?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        check = true;
                        string queryDeleteCLS = String.Format("delete from Classification where  Date = '{0}'", Date);
                        SqlCommand DeleteCLS = new SqlCommand(queryDeleteCLS);
                        ConnectionUtils.ExeCuteNonquery(DeleteCLS);
                    }
                    else return;
                }
            }
            foreach (DataGridViewRow row in dgvRank.Rows)
            {
                if (row.Cells[3].Value.ToString().Trim() != "")
                {
                    int sMaNV = int.Parse(row.Cells[1].Value.ToString());
                    string sRank = row.Cells[3].Value.ToString();

                    string queryInsertCls = String.Format("INSERT INTO Classification(Date, MaNV, Rank)" +
                                                          " VALUES('{0}', {1}, '{2}')", Date, sMaNV, sRank);
                    SqlCommand insertCls = new SqlCommand(queryInsertCls);
                    ConnectionUtils.ExeCuteNonquery(insertCls);
                }
            }
            MessageBox.Show("Lưu thành công!");
            check = false;
        }
        #endregion

        #region //==================== Procedure ====================// 
        private void fillDadagrid()
        {
            sClassification = new List<Entities.Classification>();
            Date = cboMonth.Text + "-" + cboYear.Text;

            string query = string.Format("select * from Classification where Date = '{0}'", Date);
            sRank = ConnectionUtils.findAll(query);

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = null;
                sqlConnection = ConnectionUtils.getConnection();
                string queryNhanvien = string.Format("select * from nhanvien");

                SqlCommand cmdNhanvien = new SqlCommand(queryNhanvien, sqlConnection);
                SqlDataReader exeNhanvien = cmdNhanvien.ExecuteReader();
                while (exeNhanvien.Read())
                {
                    sClassification.Add(new TinhLuong.Entities.Classification()
                    {
                        Date = Date.ToString(),
                        MaNV = (int)exeNhanvien["MaNV"],
                        TenNV = exeNhanvien["Tennhanvien"].ToString(),
                        Rank = "",
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
            foreach (TinhLuong.Entities.Classification Infication in sClassification)
            {
                int sMaNV = int.Parse(Infication.MaNV.ToString());
                foreach (DataRow Ranks in sRank.Rows)
                {
                    if (Ranks["MaNV"].ToString() == sMaNV.ToString())
                    {
                        Infication.Rank = Ranks["Rank"].ToString();
                    }
                }
            }
            if (sClassification.Count > 0)
            {
                dgvRank.AutoGenerateColumns = false;
                dgvRank.DataSource = null;
                dgvRank.DataSource = sClassification;
            }
        }
        private void ColumnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 'a' && e.KeyChar != 'b' && e.KeyChar != 'c' && e.KeyChar != 'd' && e.KeyChar != 'A' && e.KeyChar != 'B' && e.KeyChar != 'C' && e.KeyChar != 'D')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ đánh giá A,B,C,D");
            }
        }
        #endregion
    }
}


