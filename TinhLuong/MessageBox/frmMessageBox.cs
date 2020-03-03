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
    public partial class frmMessageBox : Form
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }

        public frmMessageBox(String message)
        {
            InitializeComponent();
            this.message = message;
        }

        private String message;

        public String name { get; set; }

    
        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            this.lblMessage.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.name = button1.Name.ToString();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.name = button2.Name.ToString();
            this.Close();
        }
    }
}
