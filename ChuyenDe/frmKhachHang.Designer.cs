namespace ChuyenDe
{
	partial class frmKhachHang
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
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnThem = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgvDanhSachKH = new System.Windows.Forms.DataGridView();
			this.radNu = new System.Windows.Forms.RadioButton();
			this.radNam = new System.Windows.Forms.RadioButton();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.txtTenKH = new System.Windows.Forms.TextBox();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.txtMaKH = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnThoat = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKH)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTimKiem.Location = new System.Drawing.Point(738, 616);
			this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(135, 50);
			this.btnTimKiem.TabIndex = 32;
			this.btnTimKiem.Text = "TÌM KIẾM";
			this.btnTimKiem.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1147, 54);
			this.label1.TabIndex = 27;
			this.label1.Text = "THÔNG TIN KHÁCH HÀNG";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnThem
			// 
			this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(50, 616);
			this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(135, 50);
			this.btnThem.TabIndex = 30;
			this.btnThem.Text = "THÊM";
			this.btnThem.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgvDanhSachKH);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(5, 351);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(1142, 238);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh Sách Khách Hàng";
			// 
			// dgvDanhSachKH
			// 
			this.dgvDanhSachKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDanhSachKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDanhSachKH.Location = new System.Drawing.Point(0, 26);
			this.dgvDanhSachKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvDanhSachKH.Name = "dgvDanhSachKH";
			this.dgvDanhSachKH.RowHeadersWidth = 51;
			this.dgvDanhSachKH.RowTemplate.Height = 24;
			this.dgvDanhSachKH.Size = new System.Drawing.Size(1136, 208);
			this.dgvDanhSachKH.TabIndex = 0;
			// 
			// radNu
			// 
			this.radNu.AutoSize = true;
			this.radNu.Location = new System.Drawing.Point(300, 90);
			this.radNu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.radNu.Name = "radNu";
			this.radNu.Size = new System.Drawing.Size(51, 24);
			this.radNu.TabIndex = 11;
			this.radNu.TabStop = true;
			this.radNu.Text = "Nữ";
			this.radNu.UseVisualStyleBackColor = true;
			// 
			// radNam
			// 
			this.radNam.AutoSize = true;
			this.radNam.Location = new System.Drawing.Point(160, 90);
			this.radNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.radNam.Name = "radNam";
			this.radNam.Size = new System.Drawing.Size(65, 24);
			this.radNam.TabIndex = 10;
			this.radNam.TabStop = true;
			this.radNam.Text = "Nam";
			this.radNam.UseVisualStyleBackColor = true;
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Location = new System.Drawing.Point(669, 90);
			this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(272, 27);
			this.txtDiaChi.TabIndex = 9;
			// 
			// txtTenKH
			// 
			this.txtTenKH.Location = new System.Drawing.Point(669, 46);
			this.txtTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.Size = new System.Drawing.Size(272, 27);
			this.txtTenKH.TabIndex = 8;
			// 
			// txtSDT
			// 
			this.txtSDT.Location = new System.Drawing.Point(160, 135);
			this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(300, 27);
			this.txtSDT.TabIndex = 7;
			// 
			// txtMaKH
			// 
			this.txtMaKH.Location = new System.Drawing.Point(160, 46);
			this.txtMaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtMaKH.Name = "txtMaKH";
			this.txtMaKH.Size = new System.Drawing.Size(300, 27);
			this.txtMaKH.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(509, 90);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 20);
			this.label6.TabIndex = 4;
			this.label6.Text = "Địa Chỉ:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(509, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(139, 20);
			this.label5.TabIndex = 3;
			this.label5.Text = "Tên Khách Hàng:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(119, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "Số Điện Thoại:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Giới Tính:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã KH:";
			// 
			// btnXoa
			// 
			this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(514, 616);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(135, 50);
			this.btnXoa.TabIndex = 33;
			this.btnXoa.Text = "XÓA";
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// btnSua
			// 
			this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSua.Location = new System.Drawing.Point(276, 616);
			this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(135, 50);
			this.btnSua.TabIndex = 31;
			this.btnSua.Text = "SỬA";
			this.btnSua.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radNu);
			this.groupBox1.Controls.Add(this.radNam);
			this.groupBox1.Controls.Add(this.txtDiaChi);
			this.groupBox1.Controls.Add(this.txtTenKH);
			this.groupBox1.Controls.Add(this.txtSDT);
			this.groupBox1.Controls.Add(this.txtMaKH);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(60, 139);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(1007, 191);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông Tin Khách Hàng";
			// 
			// btnThoat
			// 
			this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.Location = new System.Drawing.Point(964, 616);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(135, 50);
			this.btnThoat.TabIndex = 34;
			this.btnThoat.Text = "THOÁT";
			this.btnThoat.UseVisualStyleBackColor = true;
			// 
			// frmKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1147, 673);
			this.Controls.Add(this.btnTimKiem);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnSua);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnThoat);
			this.Name = "frmKhachHang";
			this.Text = "frmKhachHang";
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKH)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView dgvDanhSachKH;
		private System.Windows.Forms.RadioButton radNu;
		private System.Windows.Forms.RadioButton radNam;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.TextBox txtTenKH;
		private System.Windows.Forms.TextBox txtSDT;
		private System.Windows.Forms.TextBox txtMaKH;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnThoat;
	}
}