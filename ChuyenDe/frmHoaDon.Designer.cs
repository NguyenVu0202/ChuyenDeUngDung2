namespace ChuyenDe
{
	partial class frmHoaDon
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
			this.btnIn = new System.Windows.Forms.Button();
			this.txtSDTKH = new System.Windows.Forms.TextBox();
			this.txtDiaChiKH = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTenKH = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dgvDanhSachHoaDon = new System.Windows.Forms.DataGridView();
			this.label9 = new System.Windows.Forms.Label();
			this.btnXoa = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtMaCH = new System.Windows.Forms.TextBox();
			this.txtTenNV = new System.Windows.Forms.TextBox();
			this.txtLamMoi = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboCamera = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtMaSP = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtGiamGia = new System.Windows.Forms.TextBox();
			this.txtMaNV = new System.Windows.Forms.TextBox();
			this.txtMaKH = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnXacNhan = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.picCamera = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHoaDon)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
			this.SuspendLayout();
			// 
			// btnIn
			// 
			this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnIn.Location = new System.Drawing.Point(1267, 832);
			this.btnIn.Name = "btnIn";
			this.btnIn.Size = new System.Drawing.Size(135, 50);
			this.btnIn.TabIndex = 55;
			this.btnIn.Text = "IN";
			this.btnIn.UseVisualStyleBackColor = true;
			// 
			// txtSDTKH
			// 
			this.txtSDTKH.Location = new System.Drawing.Point(733, 197);
			this.txtSDTKH.Name = "txtSDTKH";
			this.txtSDTKH.ReadOnly = true;
			this.txtSDTKH.Size = new System.Drawing.Size(272, 27);
			this.txtSDTKH.TabIndex = 15;
			// 
			// txtDiaChiKH
			// 
			this.txtDiaChiKH.Location = new System.Drawing.Point(733, 153);
			this.txtDiaChiKH.Name = "txtDiaChiKH";
			this.txtDiaChiKH.ReadOnly = true;
			this.txtDiaChiKH.Size = new System.Drawing.Size(272, 27);
			this.txtDiaChiKH.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(509, 149);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(98, 20);
			this.label7.TabIndex = 12;
			this.label7.Text = "Địa Chỉ KH:";
			// 
			// txtTenKH
			// 
			this.txtTenKH.Location = new System.Drawing.Point(733, 105);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.ReadOnly = true;
			this.txtTenKH.Size = new System.Drawing.Size(272, 27);
			this.txtTenKH.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(509, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(139, 20);
			this.label6.TabIndex = 4;
			this.label6.Text = "Tên Khách Hàng:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(509, 59);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 20);
			this.label5.TabIndex = 3;
			this.label5.Text = "Mã Khách Hàng:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "Mã NV:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.dgvDanhSachHoaDon);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(0, 517);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(1498, 280);
			this.groupBox3.TabIndex = 50;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Hóa Đơn";
			// 
			// dgvDanhSachHoaDon
			// 
			this.dgvDanhSachHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDanhSachHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDanhSachHoaDon.Location = new System.Drawing.Point(1, 26);
			this.dgvDanhSachHoaDon.Name = "dgvDanhSachHoaDon";
			this.dgvDanhSachHoaDon.RowHeadersWidth = 51;
			this.dgvDanhSachHoaDon.RowTemplate.Height = 24;
			this.dgvDanhSachHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDanhSachHoaDon.Size = new System.Drawing.Size(1497, 248);
			this.dgvDanhSachHoaDon.TabIndex = 0;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 149);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(70, 20);
			this.label9.TabIndex = 16;
			this.label9.Text = "Tên NV:";
			// 
			// btnXoa
			// 
			this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(345, 832);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(135, 50);
			this.btnXoa.TabIndex = 52;
			this.btnXoa.Text = "XÓA";
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(1, -2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1492, 50);
			this.label1.TabIndex = 48;
			this.label1.Text = "HÓA ĐƠN BÁN HÀNG";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(16, 194);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(67, 20);
			this.label15.TabIndex = 20;
			this.label15.Text = "Mã CH:";
			// 
			// txtMaCH
			// 
			this.txtMaCH.Location = new System.Drawing.Point(157, 194);
			this.txtMaCH.Name = "txtMaCH";
			this.txtMaCH.ReadOnly = true;
			this.txtMaCH.Size = new System.Drawing.Size(300, 27);
			this.txtMaCH.TabIndex = 19;
			// 
			// txtTenNV
			// 
			this.txtTenNV.Location = new System.Drawing.Point(157, 149);
			this.txtTenNV.Name = "txtTenNV";
			this.txtTenNV.ReadOnly = true;
			this.txtTenNV.Size = new System.Drawing.Size(300, 27);
			this.txtTenNV.TabIndex = 17;
			// 
			// txtLamMoi
			// 
			this.txtLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.txtLamMoi.Location = new System.Drawing.Point(662, 832);
			this.txtLamMoi.Name = "txtLamMoi";
			this.txtLamMoi.Size = new System.Drawing.Size(135, 50);
			this.txtLamMoi.TabIndex = 53;
			this.txtLamMoi.Text = "LÀM MỚI";
			this.txtLamMoi.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboCamera);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.txtMaSP);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtGiamGia);
			this.groupBox1.Controls.Add(this.txtMaNV);
			this.groupBox1.Controls.Add(this.txtMaKH);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.txtMaCH);
			this.groupBox1.Controls.Add(this.txtTenNV);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtSDTKH);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtDiaChiKH);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtTenKH);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 75);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1036, 415);
			this.groupBox1.TabIndex = 49;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông Tin Chung";
			// 
			// cboCamera
			// 
			this.cboCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCamera.FormattingEnabled = true;
			this.cboCamera.Location = new System.Drawing.Point(733, 289);
			this.cboCamera.Name = "cboCamera";
			this.cboCamera.Size = new System.Drawing.Size(272, 28);
			this.cboCamera.TabIndex = 35;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(509, 292);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(73, 20);
			this.label12.TabIndex = 34;
			this.label12.Text = "Camera:";
			// 
			// txtMaSP
			// 
			this.txtMaSP.Location = new System.Drawing.Point(157, 63);
			this.txtMaSP.Name = "txtMaSP";
			this.txtMaSP.Size = new System.Drawing.Size(300, 27);
			this.txtMaSP.TabIndex = 32;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(16, 63);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 20);
			this.label11.TabIndex = 31;
			this.label11.Text = "Mã SP:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(509, 245);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(196, 20);
			this.label10.TabIndex = 30;
			this.label10.Text = "Tổng Tiền Sau Khi Giảm:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(733, 241);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(272, 27);
			this.textBox2.TabIndex = 29;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 289);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 20);
			this.label3.TabIndex = 28;
			this.label3.Text = "Tổng Tiền:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(157, 289);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(300, 27);
			this.textBox1.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 241);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 20);
			this.label2.TabIndex = 26;
			this.label2.Text = "Giảm Giá:";
			// 
			// txtGiamGia
			// 
			this.txtGiamGia.Location = new System.Drawing.Point(157, 238);
			this.txtGiamGia.Name = "txtGiamGia";
			this.txtGiamGia.Size = new System.Drawing.Size(300, 27);
			this.txtGiamGia.TabIndex = 25;
			// 
			// txtMaNV
			// 
			this.txtMaNV.Location = new System.Drawing.Point(157, 104);
			this.txtMaNV.Name = "txtMaNV";
			this.txtMaNV.Size = new System.Drawing.Size(300, 27);
			this.txtMaNV.TabIndex = 24;
			// 
			// txtMaKH
			// 
			this.txtMaKH.Location = new System.Drawing.Point(733, 63);
			this.txtMaKH.Name = "txtMaKH";
			this.txtMaKH.Size = new System.Drawing.Size(272, 27);
			this.txtMaKH.TabIndex = 23;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(509, 200);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "SĐT KH:";
			// 
			// btnXacNhan
			// 
			this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnXacNhan.Location = new System.Drawing.Point(56, 832);
			this.btnXacNhan.Name = "btnXacNhan";
			this.btnXacNhan.Size = new System.Drawing.Size(135, 50);
			this.btnXacNhan.TabIndex = 51;
			this.btnXacNhan.Text = "XÁC NHẬN";
			this.btnXacNhan.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.picCamera);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(1073, 75);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(411, 415);
			this.groupBox2.TabIndex = 56;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Camera";
			// 
			// picCamera
			// 
			this.picCamera.Location = new System.Drawing.Point(6, 21);
			this.picCamera.Name = "picCamera";
			this.picCamera.Size = new System.Drawing.Size(399, 388);
			this.picCamera.TabIndex = 0;
			this.picCamera.TabStop = false;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(978, 832);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(135, 50);
			this.button1.TabIndex = 57;
			this.button1.Text = "QUÉT MÃ";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// frmHoaDon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1496, 899);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnIn);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtLamMoi);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnXacNhan);
			this.Name = "frmHoaDon";
			this.Text = "HoaDon";
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHoaDon)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnIn;
		private System.Windows.Forms.TextBox txtSDTKH;
		private System.Windows.Forms.TextBox txtDiaChiKH;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtTenKH;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.DataGridView dgvDanhSachHoaDon;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtMaCH;
		private System.Windows.Forms.TextBox txtTenNV;
		private System.Windows.Forms.Button txtLamMoi;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnXacNhan;
		private System.Windows.Forms.TextBox txtMaKH;
		private System.Windows.Forms.TextBox txtMaNV;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtGiamGia;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtMaSP;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox picCamera;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cboCamera;
		private System.Windows.Forms.Button button1;
	}
}