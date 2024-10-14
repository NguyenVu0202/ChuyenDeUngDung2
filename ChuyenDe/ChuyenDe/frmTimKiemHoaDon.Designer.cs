namespace ChuyenDe
{
	partial class frmTimKiemHoaDon
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgvTimKiemHoaDon = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnThoat = new System.Windows.Forms.Button();
			this.dtpNgay = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.btnIn = new System.Windows.Forms.Button();
			this.btnLamMoi = new System.Windows.Forms.Button();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.txtMaKH = new System.Windows.Forms.TextBox();
			this.txtMaHD = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHoaDon)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgvTimKiemHoaDon);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(0, 424);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1145, 350);
			this.groupBox2.TabIndex = 39;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh Sách Tìm Kiếm";
			// 
			// dgvTimKiemHoaDon
			// 
			this.dgvTimKiemHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvTimKiemHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTimKiemHoaDon.Location = new System.Drawing.Point(6, 26);
			this.dgvTimKiemHoaDon.Name = "dgvTimKiemHoaDon";
			this.dgvTimKiemHoaDon.RowHeadersWidth = 51;
			this.dgvTimKiemHoaDon.RowTemplate.Height = 24;
			this.dgvTimKiemHoaDon.Size = new System.Drawing.Size(1139, 324);
			this.dgvTimKiemHoaDon.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnThoat);
			this.groupBox1.Controls.Add(this.dtpNgay);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnIn);
			this.groupBox1.Controls.Add(this.btnLamMoi);
			this.groupBox1.Controls.Add(this.btnTimKiem);
			this.groupBox1.Controls.Add(this.txtMaKH);
			this.groupBox1.Controls.Add(this.txtMaHD);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(112, 91);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(939, 279);
			this.groupBox1.TabIndex = 40;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông Tin Hóa Đơn";
			// 
			// btnThoat
			// 
			this.btnThoat.Location = new System.Drawing.Point(716, 209);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(102, 41);
			this.btnThoat.TabIndex = 30;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = true;
			// 
			// dtpNgay
			// 
			this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpNgay.Location = new System.Drawing.Point(357, 145);
			this.dtpNgay.Name = "dtpNgay";
			this.dtpNgay.Size = new System.Drawing.Size(230, 27);
			this.dtpNgay.TabIndex = 29;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(275, 145);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 20);
			this.label3.TabIndex = 28;
			this.label3.Text = "Ngày:";
			// 
			// btnIn
			// 
			this.btnIn.Location = new System.Drawing.Point(537, 209);
			this.btnIn.Name = "btnIn";
			this.btnIn.Size = new System.Drawing.Size(102, 41);
			this.btnIn.TabIndex = 27;
			this.btnIn.Text = "In";
			this.btnIn.UseVisualStyleBackColor = true;
			// 
			// btnLamMoi
			// 
			this.btnLamMoi.Location = new System.Drawing.Point(357, 209);
			this.btnLamMoi.Name = "btnLamMoi";
			this.btnLamMoi.Size = new System.Drawing.Size(102, 41);
			this.btnLamMoi.TabIndex = 26;
			this.btnLamMoi.Text = "Làm Mới";
			this.btnLamMoi.UseVisualStyleBackColor = true;
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Location = new System.Drawing.Point(179, 209);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(102, 41);
			this.btnTimKiem.TabIndex = 25;
			this.btnTimKiem.Text = "Tìm Kiếm";
			this.btnTimKiem.UseVisualStyleBackColor = true;
			// 
			// txtMaKH
			// 
			this.txtMaKH.Location = new System.Drawing.Point(357, 90);
			this.txtMaKH.Name = "txtMaKH";
			this.txtMaKH.Size = new System.Drawing.Size(230, 27);
			this.txtMaKH.TabIndex = 11;
			// 
			// txtMaHD
			// 
			this.txtMaHD.Location = new System.Drawing.Point(357, 35);
			this.txtMaHD.Name = "txtMaHD";
			this.txtMaHD.Size = new System.Drawing.Size(230, 27);
			this.txtMaHD.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(275, 90);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 20);
			this.label7.TabIndex = 5;
			this.label7.Text = "Mã KH:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(275, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã HĐ:";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1142, 55);
			this.label1.TabIndex = 38;
			this.label1.Text = "TÌM KIẾM HÓA ĐƠN";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmTimKiemHoaDon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1144, 775);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Name = "frmTimKiemHoaDon";
			this.Text = "frmTimKiemHoaDon";
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHoaDon)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView dgvTimKiemHoaDon;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.DateTimePicker dtpNgay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnIn;
		private System.Windows.Forms.Button btnLamMoi;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.TextBox txtMaKH;
		private System.Windows.Forms.TextBox txtMaHD;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}