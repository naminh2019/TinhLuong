namespace TinhLuong
{
    partial class DSnhanvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridNhanvien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.lblRemove = new System.Windows.Forms.Label();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDcard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namsinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.More = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNhanvien)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridNhanvien
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridNhanvien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridNhanvien.ColumnHeadersHeight = 35;
            this.dataGridNhanvien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.Column1,
            this.Column2,
            this.dienthoai,
            this.IDcard,
            this.Namsinh,
            this.DateAt,
            this.More});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridNhanvien.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridNhanvien.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridNhanvien.EnableHeadersVisualStyles = false;
            this.dataGridNhanvien.Location = new System.Drawing.Point(21, 123);
            this.dataGridNhanvien.Name = "dataGridNhanvien";
            this.dataGridNhanvien.RowHeadersVisible = false;
            this.dataGridNhanvien.RowTemplate.Height = 30;
            this.dataGridNhanvien.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridNhanvien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridNhanvien.Size = new System.Drawing.Size(1442, 640);
            this.dataGridNhanvien.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myriad Pro Light", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(558, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 42);
            this.label1.TabIndex = 15;
            this.label1.Text = "DANH SÁCH NHÂN VIÊN";
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.DarkGray;
            this.lblExit.Location = new System.Drawing.Point(1364, 812);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(62, 30);
            this.lblExit.TabIndex = 16;
            this.lblExit.Text = "Close";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNew.ForeColor = System.Drawing.Color.DarkGray;
            this.lblNew.Location = new System.Drawing.Point(1044, 812);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(50, 30);
            this.lblNew.TabIndex = 18;
            this.lblNew.Text = "New";
            this.lblNew.Click += new System.EventHandler(this.lblNew_Click);

            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdit.ForeColor = System.Drawing.Color.DarkGray;
            this.lblEdit.Location = new System.Drawing.Point(1150, 812);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(47, 30);
            this.lblEdit.TabIndex = 19;
            this.lblEdit.Text = "Edit";
            this.lblEdit.Click += new System.EventHandler(this.lblEdit_Click);

            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemove.ForeColor = System.Drawing.Color.DarkGray;
            this.lblRemove.Location = new System.Drawing.Point(1240, 812);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(85, 30);
            this.lblRemove.TabIndex = 20;
            this.lblRemove.Text = "Remove";
            this.lblRemove.Click += new System.EventHandler(this.lblRemove_Click);

            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaNV.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaNV.Frozen = true;
            this.MaNV.HeaderText = "MaNV";
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "tennhanvien";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Tên nhân vien";
            this.Column1.Name = "Column1";
            this.Column1.Width = 180;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "diachi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Địa chỉ";
            this.Column2.Name = "Column2";
            this.Column2.Width = 350;
            // 
            // dienthoai
            // 
            this.dienthoai.DataPropertyName = "PhoneNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dienthoai.DefaultCellStyle = dataGridViewCellStyle5;
            this.dienthoai.Frozen = true;
            this.dienthoai.HeaderText = "Điện Thoại";
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Width = 120;
            // 
            // IDcard
            // 
            this.IDcard.DataPropertyName = "IDcardNo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IDcard.DefaultCellStyle = dataGridViewCellStyle6;
            this.IDcard.Frozen = true;
            this.IDcard.HeaderText = "Số CMND";
            this.IDcard.Name = "IDcard";
            this.IDcard.Width = 140;
            // 
            // Namsinh
            // 
            this.Namsinh.DataPropertyName = "namsinh";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Namsinh.DefaultCellStyle = dataGridViewCellStyle7;
            this.Namsinh.Frozen = true;
            this.Namsinh.HeaderText = "Năm sinh";
            this.Namsinh.Name = "Namsinh";
            this.Namsinh.Width = 80;
            // 
            // DateAt
            // 
            this.DateAt.DataPropertyName = "YearAtWork";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DateAt.DefaultCellStyle = dataGridViewCellStyle8;
            this.DateAt.Frozen = true;
            this.DateAt.HeaderText = "Năm vào làm";
            this.DateAt.Name = "DateAt";
            this.DateAt.Width = 90;
            // 
            // More
            // 
            this.More.Frozen = true;
            this.More.HeaderText = "More";
            this.More.Name = "More";
            this.More.Text = "More";
            this.More.UseColumnTextForButtonValue = true;
            this.More.Width = 50;
            // 
            // DSnhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1486, 886);
            this.ControlBox = false;
            this.Controls.Add(this.lblRemove);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridNhanvien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DSnhanvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nhân viên";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNhanvien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridNhanvien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dienthoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDcard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namsinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAt;
        private System.Windows.Forms.DataGridViewButtonColumn More;
    }
}

