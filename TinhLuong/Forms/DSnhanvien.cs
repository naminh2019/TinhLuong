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
        #region //==================== Declare variable ====================//
        string sEdit = null;
        #endregion

        #region //==================== Form Open & Close ====================//
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridNhanvien.Size = new Size(1080, 515);
            ConnectionUtils.getConnection();

            String query = "SELECT *,LTRIM(RTRIM([Dienthoai])) as PhoneNo, LTRIM(RTRIM([SoCMND])) as IDcardNo FROM nhanvien dsnv INNER JOIN nhomviec nv on dsnv.maCV = nv.maCV";

            DataTable dtNhanVien = ConnectionUtils.findAll(query);

            dataGridNhanvien.AutoGenerateColumns = false;
            dataGridNhanvien.DataSource = null;
            dataGridNhanvien.DataSource = dtNhanVien;
            OnMouseEnter(e);
            OnMouseLeave(e);
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region //==================== Control Process ====================//
        protected override void OnMouseEnter(System.EventArgs e)
        {
            lblNew.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblEdit.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblRemove.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
            lblExit.MouseEnter += new EventHandler(Utils.MouseEvent.MouseOnEnter);
   
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            lblNew.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblEdit.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblRemove.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
            lblExit.MouseLeave += new EventHandler(Utils.MouseEvent.MouseOnLeave);
        
            base.OnMouseLeave(e);
        }
        #endregion

        #region //==================== CURD Buttom Click ====================//
        private void lblNew_Click(object sender, EventArgs e)
        {
            sEdit = "NEW";
            EditNV feditNV = new EditNV(sEdit, 0);
            feditNV.Show();
        }
        private void lblEdit_Click(object sender, EventArgs e)
        {
            sEdit = "EDIT";
            int currentIndex = dataGridNhanvien.CurrentRow.Index;
            int MaNV = int.Parse(dataGridNhanvien.Rows[currentIndex].Cells["MaNV"].Value.ToString());
            EditNV feditNV = new EditNV(sEdit, MaNV);
            feditNV.Show();
        }
        private void lblRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có code delete nhân viên");
        }
        #endregion
    }
}
