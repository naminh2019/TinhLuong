namespace TinhLuong.Forms
{
    partial class InBangLuong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InBangLuong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvThunhap = new System.Windows.Forms.DataGridView();
            this.AllowanceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowanceMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblThuclanh = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblThunhap = new System.Windows.Forms.Label();
            this.lblKhautru = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltangca = new System.Windows.Forms.Label();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.lblnghiphep = new System.Windows.Forms.Label();
            this.dgvKhautru = new System.Windows.Forms.DataGridView();
            this.DeductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeductMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblditre = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblmanhanvien = new System.Windows.Forms.Label();
            this.lbltennhanvien = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.lbldanhgia = new System.Windows.Forms.Label();
            this.lblgiocong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThunhap)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhautru)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.CausesValidation = false;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Myriad Pro Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(15, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "CÁC KHOẢN THU NHẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvThunhap
            // 
            this.dgvThunhap.AllowUserToAddRows = false;
            this.dgvThunhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvThunhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThunhap.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvThunhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThunhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvThunhap.ColumnHeadersHeight = 30;
            this.dgvThunhap.ColumnHeadersVisible = false;
            this.dgvThunhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AllowanceName,
            this.AllowanceMoney});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Myriad Pro", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThunhap.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvThunhap.Location = new System.Drawing.Point(15, 331);
            this.dgvThunhap.Name = "dgvThunhap";
            this.dgvThunhap.ReadOnly = true;
            this.dgvThunhap.RowHeadersVisible = false;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle28.Format = "N0";
            dataGridViewCellStyle28.NullValue = null;
            this.dgvThunhap.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvThunhap.RowTemplate.Height = 30;
            this.dgvThunhap.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThunhap.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvThunhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThunhap.Size = new System.Drawing.Size(454, 50);
            this.dgvThunhap.TabIndex = 3;
            // 
            // AllowanceName
            // 
            this.AllowanceName.DataPropertyName = "AllowanceName";
            this.AllowanceName.HeaderText = "Khoản thu nhập";
            this.AllowanceName.Name = "AllowanceName";
            this.AllowanceName.ReadOnly = true;
            this.AllowanceName.Width = 215;
            // 
            // AllowanceMoney
            // 
            this.AllowanceMoney.DataPropertyName = "AllowanceMoney";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "N0";
            dataGridViewCellStyle26.NullValue = null;
            this.AllowanceMoney.DefaultCellStyle = dataGridViewCellStyle26;
            this.AllowanceMoney.HeaderText = "Số tiền";
            this.AllowanceMoney.Name = "AllowanceMoney";
            this.AllowanceMoney.ReadOnly = true;
            this.AllowanceMoney.Width = 120;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.CausesValidation = false;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Myriad Pro Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(15, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "CÁC KHOẢN KHẤU TRỪ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.CausesValidation = false;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(15, 726);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "THỰC LÃNH";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThuclanh
            // 
            this.lblThuclanh.BackColor = System.Drawing.Color.White;
            this.lblThuclanh.CausesValidation = false;
            this.lblThuclanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblThuclanh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThuclanh.Location = new System.Drawing.Point(263, 726);
            this.lblThuclanh.Margin = new System.Windows.Forms.Padding(3);
            this.lblThuclanh.Name = "lblThuclanh";
            this.lblThuclanh.Size = new System.Drawing.Size(200, 29);
            this.lblThuclanh.TabIndex = 6;
            this.lblThuclanh.Text = "0";
            this.lblThuclanh.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 863);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblThunhap);
            this.panel1.Controls.Add(this.lblKhautru);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbltangca);
            this.panel1.Controls.Add(this.lblMonthYear);
            this.panel1.Controls.Add(this.lbldanhgia);
            this.panel1.Controls.Add(this.lblnghiphep);
            this.panel1.Controls.Add(this.dgvKhautru);
            this.panel1.Controls.Add(this.lblditre);
            this.panel1.Controls.Add(this.dgvThunhap);
            this.panel1.Controls.Add(this.lblThuclanh);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblgiocong);
            this.panel1.Controls.Add(this.lblmanhanvien);
            this.panel1.Controls.Add(this.lbltennhanvien);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(4, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 832);
            this.panel1.TabIndex = 8;
            // 
            // lblThunhap
            // 
            this.lblThunhap.BackColor = System.Drawing.Color.White;
            this.lblThunhap.CausesValidation = false;
            this.lblThunhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblThunhap.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThunhap.Location = new System.Drawing.Point(263, 294);
            this.lblThunhap.Name = "lblThunhap";
            this.lblThunhap.Size = new System.Drawing.Size(200, 29);
            this.lblThunhap.TabIndex = 4;
            this.lblThunhap.Text = "Thunhap";
            this.lblThunhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKhautru
            // 
            this.lblKhautru.BackColor = System.Drawing.Color.White;
            this.lblKhautru.CausesValidation = false;
            this.lblKhautru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKhautru.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblKhautru.Location = new System.Drawing.Point(263, 395);
            this.lblKhautru.Name = "lblKhautru";
            this.lblKhautru.Size = new System.Drawing.Size(200, 29);
            this.lblKhautru.TabIndex = 6;
            this.lblKhautru.Text = "Khautru";
            this.lblKhautru.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.CausesValidation = false;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(438, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "CTY TNHH IN - THIẾT KẾ - QUẢNG CÁO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltangca
            // 
            this.lbltangca.BackColor = System.Drawing.Color.White;
            this.lbltangca.CausesValidation = false;
            this.lbltangca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbltangca.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltangca.Location = new System.Drawing.Point(15, 221);
            this.lbltangca.Name = "lbltangca";
            this.lbltangca.Size = new System.Drawing.Size(200, 24);
            this.lbltangca.TabIndex = 57;
            this.lbltangca.Text = "tangca";
            this.lbltangca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYear.Location = new System.Drawing.Point(103, 131);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(255, 25);
            this.lblMonthYear.TabIndex = 56;
            this.lblMonthYear.Text = "Month - Year";
            this.lblMonthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblnghiphep
            // 
            this.lblnghiphep.BackColor = System.Drawing.Color.White;
            this.lblnghiphep.CausesValidation = false;
            this.lblnghiphep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblnghiphep.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnghiphep.Location = new System.Drawing.Point(263, 251);
            this.lblnghiphep.Name = "lblnghiphep";
            this.lblnghiphep.Size = new System.Drawing.Size(200, 24);
            this.lblnghiphep.TabIndex = 57;
            this.lblnghiphep.Text = "nghiphep";
            this.lblnghiphep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvKhautru
            // 
            this.dgvKhautru.AllowUserToAddRows = false;
            this.dgvKhautru.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhautru.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhautru.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvKhautru.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhautru.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dgvKhautru.ColumnHeadersHeight = 30;
            this.dgvKhautru.ColumnHeadersVisible = false;
            this.dgvKhautru.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeductName,
            this.DeductMoney});
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Myriad Pro", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhautru.DefaultCellStyle = dataGridViewCellStyle31;
            this.dgvKhautru.Location = new System.Drawing.Point(15, 432);
            this.dgvKhautru.Name = "dgvKhautru";
            this.dgvKhautru.ReadOnly = true;
            this.dgvKhautru.RowHeadersVisible = false;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle32.Format = "N0";
            dataGridViewCellStyle32.NullValue = null;
            this.dgvKhautru.RowsDefaultCellStyle = dataGridViewCellStyle32;
            this.dgvKhautru.RowTemplate.Height = 30;
            this.dgvKhautru.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhautru.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvKhautru.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhautru.Size = new System.Drawing.Size(454, 50);
            this.dgvKhautru.TabIndex = 3;
            // 
            // DeductName
            // 
            this.DeductName.DataPropertyName = "DeductName";
            this.DeductName.HeaderText = "Khoản khấu trừ";
            this.DeductName.Name = "DeductName";
            this.DeductName.ReadOnly = true;
            this.DeductName.Width = 218;
            // 
            // DeductMoney
            // 
            this.DeductMoney.DataPropertyName = "DeductMoney";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "N0";
            dataGridViewCellStyle30.NullValue = null;
            this.DeductMoney.DefaultCellStyle = dataGridViewCellStyle30;
            this.DeductMoney.HeaderText = "Số tiền";
            this.DeductMoney.Name = "DeductMoney";
            this.DeductMoney.ReadOnly = true;
            this.DeductMoney.Width = 120;
            // 
            // lblditre
            // 
            this.lblditre.BackColor = System.Drawing.Color.White;
            this.lblditre.CausesValidation = false;
            this.lblditre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblditre.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblditre.Location = new System.Drawing.Point(254, 221);
            this.lblditre.Name = "lblditre";
            this.lblditre.Size = new System.Drawing.Size(209, 24);
            this.lblditre.TabIndex = 4;
            this.lblditre.Text = "ditre";
            this.lblditre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.CausesValidation = false;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(11, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(438, 29);
            this.label6.TabIndex = 4;
            this.label6.Text = "PHIẾU TÍNH LƯƠNG";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmanhanvien
            // 
            this.lblmanhanvien.BackColor = System.Drawing.Color.White;
            this.lblmanhanvien.CausesValidation = false;
            this.lblmanhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblmanhanvien.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmanhanvien.Location = new System.Drawing.Point(15, 191);
            this.lblmanhanvien.Name = "lblmanhanvien";
            this.lblmanhanvien.Size = new System.Drawing.Size(206, 24);
            this.lblmanhanvien.TabIndex = 4;
            this.lblmanhanvien.Text = "manhanvien";
            this.lblmanhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbltennhanvien
            // 
            this.lbltennhanvien.BackColor = System.Drawing.Color.White;
            this.lbltennhanvien.CausesValidation = false;
            this.lbltennhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbltennhanvien.Font = new System.Drawing.Font("Myriad Pro Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltennhanvien.Location = new System.Drawing.Point(213, 161);
            this.lbltennhanvien.Name = "lbltennhanvien";
            this.lbltennhanvien.Size = new System.Drawing.Size(250, 24);
            this.lbltennhanvien.TabIndex = 4;
            this.lbltennhanvien.Text = "tennhanvien";
            this.lbltennhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.CausesValidation = false;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 24);
            this.label13.TabIndex = 4;
            this.label13.Text = "Nhân viên :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.CausesValidation = false;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("VNI-Helve", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "MINH HOAØNG";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.CausesValidation = false;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(11, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(438, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "----------------------------------------";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(-17, 718);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(499, 41);
            this.label8.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(-17, 388);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(499, 41);
            this.label12.TabIndex = 58;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(-12, 288);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(499, 41);
            this.label11.TabIndex = 58;
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Location = new System.Drawing.Point(330, 863);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(75, 34);
            this.btnPrintAll.TabIndex = 7;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // lbldanhgia
            // 
            this.lbldanhgia.BackColor = System.Drawing.Color.White;
            this.lbldanhgia.CausesValidation = false;
            this.lbldanhgia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbldanhgia.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldanhgia.Location = new System.Drawing.Point(15, 251);
            this.lbldanhgia.Name = "lbldanhgia";
            this.lbldanhgia.Size = new System.Drawing.Size(206, 24);
            this.lbldanhgia.TabIndex = 57;
            this.lbldanhgia.Text = "danhgia";
            // 
            // lblgiocong
            // 
            this.lblgiocong.BackColor = System.Drawing.Color.White;
            this.lblgiocong.CausesValidation = false;
            this.lblgiocong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblgiocong.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgiocong.Location = new System.Drawing.Point(227, 191);
            this.lblgiocong.Name = "lblgiocong";
            this.lblgiocong.Size = new System.Drawing.Size(236, 24);
            this.lblgiocong.TabIndex = 4;
            this.lblgiocong.Text = "giocong";
            this.lblgiocong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InBangLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(486, 909);
            this.Controls.Add(this.btnPrintAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "InBangLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tinhluong";
            this.Load += new System.EventHandler(this.tinhluong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThunhap)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhautru)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvThunhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblThuclanh;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.DataGridView dgvKhautru;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbltangca;
        private System.Windows.Forms.Label lblnghiphep;
        private System.Windows.Forms.Label lblditre;
        private System.Windows.Forms.Label lbltennhanvien;
        private System.Windows.Forms.Label lblmanhanvien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThunhap;
        private System.Windows.Forms.Label lblKhautru;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowanceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowanceMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeductMoney;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbldanhgia;
        private System.Windows.Forms.Label lblgiocong;
    }
}