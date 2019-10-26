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
    public partial class DSnhanvien : Form
    {
        public DSnhanvien()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)

        {
            ClassConnect.getConnection();

            String query = "SELECT * FROM nhanvien dsnv INNER JOIN nhomviec nv on dsnv.maCV = nv.maCV";

            DataTable dtNhanVien = ClassConnect.findAll(query);

            dataGridNhanvien.AutoGenerateColumns = true;
            dataGridNhanvien.DataSource = null;
            dataGridNhanvien.DataSource = dtNhanVien;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EditNV feditNV = new EditNV(0);
            feditNV.ShowDialog();

            // FillDataGirdView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridNhanvien.CurrentRow.Index;

            int MaNV = int.Parse(dataGridNhanvien.Rows[currentIndex].Cells["MaNV"].Value.ToString());

            EditNV feditNV = new EditNV(MaNV);
            feditNV.ShowDialog();

            // FillDataGirdView();
        }
        private void FillDataGirdView()
        {

        }

        private void dataGridNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
