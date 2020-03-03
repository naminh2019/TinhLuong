namespace TinhLuong
{
    partial class CharityMoney
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCharity = new System.Windows.Forms.DataGridView();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tennhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfLate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblPrint = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblTextTC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharity)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMonth.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(400, 93);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(79, 31);
            this.cboMonth.TabIndex = 0;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(571, 93);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(102, 31);
            this.cboYear.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(505, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Năm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(320, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tháng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myriad Pro Light", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(381, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 42);
            this.label3.TabIndex = 16;
            this.label3.Text = "TIỀN TỪ THIỆN";
            // 
            // dgvCharity
            // 
            this.dgvCharity.BackgroundColor = System.Drawing.Color.Maroon;
            this.dgvCharity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCharity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCharity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.Tennhanvien,
            this.NumberOfLate,
            this.Money});
            this.dgvCharity.Location = new System.Drawing.Point(128, 210);
            this.dgvCharity.Name = "dgvCharity";
            this.dgvCharity.RowHeadersVisible = false;
            this.dgvCharity.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCharity.RowTemplate.Height = 30;
            this.dgvCharity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCharity.Size = new System.Drawing.Size(736, 307);
            this.dgvCharity.TabIndex = 17;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaNV.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaNV.HeaderText = "Mã NNV";
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 80;
            // 
            // Tennhanvien
            // 
            this.Tennhanvien.DataPropertyName = "Tennhanvien";
            this.Tennhanvien.HeaderText = "Tên nhân viên";
            this.Tennhanvien.Name = "Tennhanvien";
            this.Tennhanvien.Width = 200;
            // 
            // NumberOfLate
            // 
            this.NumberOfLate.DataPropertyName = "NumberOfLate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NumberOfLate.DefaultCellStyle = dataGridViewCellStyle3;
            this.NumberOfLate.HeaderText = "Số ngày trể";
            this.NumberOfLate.Name = "NumberOfLate";
            this.NumberOfLate.Width = 120;
            // 
            // Money
            // 
            this.Money.DataPropertyName = "Money";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Money.DefaultCellStyle = dataGridViewCellStyle4;
            this.Money.HeaderText = "Tiền phạt";
            this.Money.Name = "Money";
            this.Money.Width = 150;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.DarkGray;
            this.lblClose.Location = new System.Drawing.Point(774, 685);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(62, 30);
            this.lblClose.TabIndex = 28;
            this.lblClose.Text = "Close";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblPrint
            // 
            this.lblPrint.AutoSize = true;
            this.lblPrint.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrint.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPrint.Location = new System.Drawing.Point(665, 685);
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.Size = new System.Drawing.Size(55, 30);
            this.lblPrint.TabIndex = 27;
            this.lblPrint.Text = "Print";
            this.lblPrint.Click += new System.EventHandler(this.lblPrint_Click);
            // 
            // lblSum
            // 
            this.lblSum.BackColor = System.Drawing.Color.White;
            this.lblSum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSum.Location = new System.Drawing.Point(666, 520);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(199, 35);
            this.lblSum.TabIndex = 29;
            this.lblSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextTC
            // 
            this.lblTextTC.BackColor = System.Drawing.Color.White;
            this.lblTextTC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTextTC.Location = new System.Drawing.Point(129, 520);
            this.lblTextTC.Name = "lblTextTC";
            this.lblTextTC.Size = new System.Drawing.Size(533, 35);
            this.lblTextTC.TabIndex = 30;
            this.lblTextTC.Text = "TỔNG CỘNG";
            this.lblTextTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CharityMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(992, 749);
            this.Controls.Add(this.lblTextTC);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblPrint);
            this.Controls.Add(this.dgvCharity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboMonth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CharityMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CharityMoney";
            this.Load += new System.EventHandler(this.CharityMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCharity;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblPrint;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblTextTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tennhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfLate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
    }
}