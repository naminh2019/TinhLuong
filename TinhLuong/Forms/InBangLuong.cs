using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
//using System.Collections.Generic;

namespace TinhLuong.Forms
{
    public partial class InBangLuong : Form
    {
        public InBangLuong()
        {
            InitializeComponent();
        }
        private List<Salary.Allowance> sThunhap;
        private List<Salary.Deduct> sKhautru;
        string sMonth = null;
        string sName = null;
        string sLate = null;
        string sLeave = null;
        string sOvertime = null;
        int tongTN = 0;
        int tongKT = 0;
        int giocong = 0;
        int MaNV = 0;
        string sRank = null;
        public InBangLuong(List<Salary.Allowance> emThunhap, List<Salary.Deduct> emKhautru,
                           string sMonth, string sName, string sLate, string sLeave, string sOvertime, int tongTN, int tongKT, int MaNV, String sRank, int giocong)
        {
            InitializeComponent();
            this.sThunhap = emThunhap;
            this.sKhautru = emKhautru;
            this.sLeave = sLeave;
            this.sLate = sLate;
            this.sOvertime = sOvertime;
            this.sMonth = sMonth;
            this.sName = sName;
            this.tongTN = tongTN;
            this.tongKT = tongKT;
            this.MaNV = MaNV;
            this.sRank = sRank;
            this.giocong = giocong;
        }



        private void tinhluong_Load(object sender, EventArgs e)
        {
            Size = new Size(380, 800);
            int scrWidth = Screen.PrimaryScreen.Bounds.Width;
            int scrHeight = Screen.PrimaryScreen.Bounds.Height;
            Location = new Point((scrWidth - Width) / 2,
                                     (scrHeight - Height) / 2 - 30);


            dgvThunhap.AutoGenerateColumns = false;
            dgvThunhap.DataSource = null;
            dgvThunhap.DataSource = sThunhap.OrderBy(r => r.AllowanceName).ToList(); ;
            dgvThunhap.ClearSelection();
            // dgvThunhap.Columns["money"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvKhautru.AutoGenerateColumns = false;
            dgvKhautru.DataSource = null;
            dgvKhautru.DataSource = sKhautru.OrderBy(r => r.DeductName).ToList(); ;
            dgvKhautru.ClearSelection();
            //dgvKhautru.Columns["tienkhautru"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvThunhap.Height = dgvThunhap.Rows.Cast<DataGridViewRow>().Sum(x => x.Height);// (dgvThunhap.ColumnHeadersHeight);
            dgvThunhap.Columns["AllowanceMoney"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            int locationText = int.Parse(dgvThunhap.Location.Y.ToString()) + int.Parse(dgvThunhap.Height.ToString());

            int locationDGV = locationText + int.Parse(label2.Height.ToString());
            dgvKhautru.Location = new Point(8, locationDGV + 25);
            dgvKhautru.Height = dgvKhautru.Rows.Cast<DataGridViewRow>().Sum(x => x.Height);// (dgvKhautru.ColumnHeadersHeight);
            dgvKhautru.Columns["DeductMoney"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            int locationSUM = int.Parse(dgvKhautru.Location.Y.ToString()) + int.Parse(dgvKhautru.Height.ToString());
            label7.Location = new Point(8, locationSUM + 20);
            lblThuclanh.Location = new Point(199, locationSUM + 20);
            label8.Location = new Point(-4, locationSUM + 15);
            label2.Location = new Point(8, locationText + 20);
            label12.Location = new Point(-4, locationText + 15);
            lblKhautru.Location = new Point(199, locationText + 20);
            string[] datetime = sMonth.Split('-');

            lblMonthYear.Text = ("Tháng " + datetime[0].ToString() + " năm " + datetime[1].ToString());
            lbltennhanvien.Text = sName;
            lblmanhanvien.Text = ("Mã NV : " + MaNV.ToString());
            lblgiocong.Text = ("Giờ công : " + giocong.ToString("###,###"));
            lblnghiphep.Text = ("Nghỉ phép : " + sLeave);
            lblditre.Text = ("Đi trể : " + sLate);
            lbltangca.Text = ("Tăng ca : " + sOvertime);
            lbldanhgia.Text = ("Xếp hạng : " + sRank);
            lblThunhap.Text = tongTN.ToString("###,###,###");
            lblKhautru.Text = tongKT.ToString("###,###,###");
            int thuclanh = tongTN - tongKT;
            lblThuclanh.Text = thuclanh.ToString("###,###,###");

        }
        private static Bitmap DrawControlToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width * 125 / 100, control.Height * 125 / 100);
            // Bitmap bitmap = new Bitmap(1024, 768);
            Graphics graphic = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            rect.Size = new Size(rect.Width * 125 / 100, rect.Height * 125 / 100);
            graphic.CopyFromScreen(rect.Location.X * 125 / 100, rect.Location.Y * 125 / 100, 0, 0, rect.Size);
            return bitmap;
        }
        public Image Resizebitmap(Image img, float percentage)
        {
            int originalW = img.Width;
            int originalH = img.Height;
            int resizedW = (int)(originalW * percentage / 100);
            int resizedH = (int)(originalH * percentage / 100);
            Bitmap bmp = new Bitmap(resizedW, resizedH);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);
            graphic.Dispose();
            return (Image)bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = DrawControlToBitmap(panel1);
            Resizebitmap(bitmap, 50);
            bitmap.Save(@"d:\abc.jpg");
            System.Diagnostics.Process.Start(@"d:\abc.jpg");
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            memoryImage = new Bitmap(panel1.Width * 125 / 100, panel1.Height * 125 / 100);
            // Bitmap bitmap = new Bitmap(1024, 768);
            Graphics graphic = Graphics.FromImage(memoryImage);
            Rectangle rect = panel1.RectangleToScreen(panel1.ClientRectangle);
            rect.Size = new Size(rect.Width * 125 / 100, rect.Height * 125 / 100);
            graphic.CopyFromScreen(rect.Location.X * 125 / 100, rect.Location.Y * 125 / 100, 0, 0, rect.Size);

            // printDocument1.PrinterSettings.PrinterName = "Microsoft Print To PDF";
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            //Do not show the network in the printer dialog.
            pageSetupDialog1.ShowNetwork = false;

            //Show the dialog storing the result.
            DialogResult result = pageSetupDialog1.ShowDialog();

            // If the result is OK, display selected settings in
            // ListBox1. These values can be used when printing the
            // document.
            if (result == DialogResult.OK)
            {
                // printDocument1.PrinterSettings.PrinterName = "Xprinter XP -350BM";
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.Print();
            }



        }
        Bitmap memoryImage;
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(Resizebitmap(memoryImage, 65), 0, 0);

        }

    }
}

