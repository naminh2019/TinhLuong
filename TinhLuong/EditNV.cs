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
    public partial class EditNV : Form
    {
        public EditNV()
        {
            InitializeComponent();
        }

        #region Khoi tao bien
        int MaNV;
        #endregion



        public EditNV(int MaNV)
        {
            InitializeComponent();
            this.MaNV = MaNV;
        }

        private void EditNV_Load(object sender, EventArgs e)
        {
            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);

            DataSet dataSet = new DataSet();

            SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT  *  FROM Nhomviec;", sqlConnection);
            adapter1.Fill(dataSet, "Nhomviec");
            DataTable dataTableNhomviec = dataSet.Tables["Nhomviec"];

            cboNhomviec.DataSource = null;
            cboNhomviec.DataSource = dataTableNhomviec;
            cboNhomviec.DisplayMember = "Nhomviec";
            cboNhomviec.ValueMember = "MaCV";

            txtMaNV.ReadOnly = true;
            txtMaNV.BackColor = Color.White;
            txtMaNV.ForeColor = Color.Red;


            if (MaNV == 0)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT  max(maNV)  FROM Nhanvien;", sqlConnection);

                adapter.Fill(dataSet, "MaxMaNhanVien");

                DataTable dataTableNhanvien = dataSet.Tables["MaxMaNhanVien"];

                int MaxMaNhanVien = int.Parse(dataTableNhanvien.Rows[0][0].ToString());

                MaxMaNhanVien = MaxMaNhanVien + 1;
                txtMaNV.Text = MaxMaNhanVien.ToString();

                cboNhomviec.Text = "";
            }
            else
            {
                string query = String.Format("SELECT * FROM Nhanvien where MaNV = {0};", MaNV);
                SqlDataAdapter adapter2 = new SqlDataAdapter(query, sqlConnection);
                adapter2.Fill(dataSet, "NhanVien");
                DataTable dataTableNhanvien = dataSet.Tables["NhanVien"];

                txtMaNV.Text = MaNV.ToString();
                txtTennhanvien.Text = dataTableNhanvien.Rows[0][1].ToString();
                txtDiachi.Text = dataTableNhanvien.Rows[0][2].ToString();
                txtDienthoai.Text = dataTableNhanvien.Rows[0][3].ToString();
                txtLuongcanban.Text = dataTableNhanvien.Rows[0][5].ToString();
                cboBaohiem.Text = dataTableNhanvien.Rows[0][6].ToString();

                int mMacv = int.Parse(dataTableNhanvien.Rows[0][4].ToString());
                cboNhomviec.SelectedValue = mMacv;

               }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboNhomviec_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = true;
        }

        private void cboBaohiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            String strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnect);

            try
            {
                sqlConnection.Open();

                int mMaNV = int.Parse(txtMaNV.Text.Trim());
                string mTenNV = txtTennhanvien.Text.Trim();
                string mDiachi = txtDiachi.Text.Trim();
                string mSDT = txtDienthoai.Text.Trim();
                int mMacv = int.Parse(cboNhomviec.SelectedValue.ToString());
                int mLCB = int.Parse(txtLuongcanban.Text.Trim());
                bool mBH = Boolean.Parse(cboBaohiem.Text.Trim());

                if (MaNV == 0)
                {
                    string query = String.Format(" INSERT INTO Nhanvien(MaNV, Tennhanvien, Diachi, Dienthoai, MaCV, Luongcanban, ChedoBH) VALUES({0},'{1}','{2}', '{3}', {4}, {5}, 1) ",
                        mMaNV, mTenNV, mDiachi, mSDT, mMacv, mLCB);

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    Int32 kq = sqlCommand.ExecuteNonQuery();

                    // Console.WriteLine("OK");
                    MessageBox.Show("OK");
                }
                else
                { }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Loi" + ex.Message);
                MessageBox.Show("Loi" + ex.Message);
            }

        }

    }
}