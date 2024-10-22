namespace ChuyenDe
{
	partial class frmSanPham
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
			this.btnChonAnh = new System.Windows.Forms.Button();
			this.txtHinhAnh = new System.Windows.Forms.TextBox();
			this.cboTenLoai = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.cboTenHang = new System.Windows.Forms.ComboBox();
			this.txtGhiChu = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtGiaBan = new System.Windows.Forms.TextBox();
			this.txtTenSP = new System.Windows.Forms.TextBox();
			this.txtMaSP = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.picHinhAnh = new System.Windows.Forms.PictureBox();
			this.grpHinhAnh = new System.Windows.Forms.GroupBox();
			this.dgvSanPham = new System.Windows.Forms.DataGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.grpThongTinSP = new System.Windows.Forms.GroupBox();
			this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.btnLuuMa = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.picBarcode = new System.Windows.Forms.PictureBox();
			this.btnTaoMa = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
			this.grpHinhAnh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.grpThongTinSP.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
			this.SuspendLayout();
			// 
			// btnChonAnh
			// 
			this.btnChonAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChonAnh.Location = new System.Drawing.Point(841, 42);
			this.btnChonAnh.Name = "btnChonAnh";
			this.btnChonAnh.Size = new System.Drawing.Size(40, 28);
			this.btnChonAnh.TabIndex = 27;
			this.btnChonAnh.Text = "...";
			this.btnChonAnh.UseVisualStyleBackColor = true;
			this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click_1);
			// 
			// txtHinhAnh
			// 
			this.txtHinhAnh.Location = new System.Drawing.Point(586, 42);
			this.txtHinhAnh.Name = "txtHinhAnh";
			this.txtHinhAnh.Size = new System.Drawing.Size(241, 27);
			this.txtHinhAnh.TabIndex = 26;
			// 
			// cboTenLoai
			// 
			this.cboTenLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTenLoai.FormattingEnabled = true;
			this.cboTenLoai.Location = new System.Drawing.Point(172, 142);
			this.cboTenLoai.Name = "cboTenLoai";
			this.cboTenLoai.Size = new System.Drawing.Size(250, 28);
			this.cboTenLoai.TabIndex = 25;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1330, 58);
			this.label1.TabIndex = 33;
			this.label1.Text = "THÔNG TIN SẢN PHẨM";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnSua
			// 
			this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSua.Location = new System.Drawing.Point(243, 860);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(135, 50);
			this.btnSua.TabIndex = 37;
			this.btnSua.Text = "SỬA";
			this.btnSua.UseVisualStyleBackColor = true;
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
			// 
			// btnThem
			// 
			this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnThem.Location = new System.Drawing.Point(23, 860);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(135, 50);
			this.btnThem.TabIndex = 36;
			this.btnThem.Text = "THÊM";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
			// 
			// btnThoat
			// 
			this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.Location = new System.Drawing.Point(1171, 860);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(135, 50);
			this.btnThoat.TabIndex = 39;
			this.btnThoat.Text = "THOÁT";
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(478, 860);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(135, 50);
			this.btnXoa.TabIndex = 38;
			this.btnXoa.Text = "XÓA";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
			// 
			// cboTenHang
			// 
			this.cboTenHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTenHang.FormattingEnabled = true;
			this.cboTenHang.Location = new System.Drawing.Point(172, 195);
			this.cboTenHang.Name = "cboTenHang";
			this.cboTenHang.Size = new System.Drawing.Size(250, 28);
			this.cboTenHang.TabIndex = 24;
			// 
			// txtGhiChu
			// 
			this.txtGhiChu.Location = new System.Drawing.Point(547, 113);
			this.txtGhiChu.Multiline = true;
			this.txtGhiChu.Name = "txtGhiChu";
			this.txtGhiChu.Size = new System.Drawing.Size(317, 165);
			this.txtGhiChu.TabIndex = 20;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(505, 90);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 20);
			this.label11.TabIndex = 19;
			this.label11.Text = "Ghi Chú:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(497, 45);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(83, 20);
			this.label10.TabIndex = 17;
			this.label10.Text = "Hình Ảnh:";
			// 
			// txtGiaBan
			// 
			this.txtGiaBan.Location = new System.Drawing.Point(172, 245);
			this.txtGiaBan.Name = "txtGiaBan";
			this.txtGiaBan.Size = new System.Drawing.Size(250, 27);
			this.txtGiaBan.TabIndex = 15;
			// 
			// txtTenSP
			// 
			this.txtTenSP.Location = new System.Drawing.Point(172, 95);
			this.txtTenSP.Name = "txtTenSP";
			this.txtTenSP.Size = new System.Drawing.Size(250, 27);
			this.txtTenSP.TabIndex = 11;
			// 
			// txtMaSP
			// 
			this.txtMaSP.Location = new System.Drawing.Point(172, 45);
			this.txtMaSP.Name = "txtMaSP";
			this.txtMaSP.Size = new System.Drawing.Size(250, 27);
			this.txtMaSP.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(19, 245);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 20);
			this.label9.TabIndex = 7;
			this.label9.Text = "Giá Bán:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(19, 195);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 20);
			this.label7.TabIndex = 5;
			this.label7.Text = "Tên NCC:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(19, 145);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 20);
			this.label6.TabIndex = 4;
			this.label6.Text = "Tên Loại:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(19, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 20);
			this.label5.TabIndex = 3;
			this.label5.Text = "Tên SP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mã SP:";
			// 
			// picHinhAnh
			// 
			this.picHinhAnh.Location = new System.Drawing.Point(27, 45);
			this.picHinhAnh.Name = "picHinhAnh";
			this.picHinhAnh.Size = new System.Drawing.Size(358, 252);
			this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picHinhAnh.TabIndex = 0;
			this.picHinhAnh.TabStop = false;
			// 
			// grpHinhAnh
			// 
			this.grpHinhAnh.Controls.Add(this.picHinhAnh);
			this.grpHinhAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpHinhAnh.Location = new System.Drawing.Point(921, 95);
			this.grpHinhAnh.Name = "grpHinhAnh";
			this.grpHinhAnh.Size = new System.Drawing.Size(400, 304);
			this.grpHinhAnh.TabIndex = 35;
			this.grpHinhAnh.TabStop = false;
			this.grpHinhAnh.Text = "Hinh Ảnh";
			// 
			// dgvSanPham
			// 
			this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSanPham.Location = new System.Drawing.Point(0, 26);
			this.dgvSanPham.Name = "dgvSanPham";
			this.dgvSanPham.RowHeadersWidth = 51;
			this.dgvSanPham.RowTemplate.Height = 50;
			this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSanPham.Size = new System.Drawing.Size(1325, 222);
			this.dgvSanPham.TabIndex = 0;
			this.dgvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellContentClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgvSanPham);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(5, 569);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1331, 266);
			this.groupBox2.TabIndex = 40;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh Sách Sản Phẩm";
			// 
			// grpThongTinSP
			// 
			this.grpThongTinSP.Controls.Add(this.btnChonAnh);
			this.grpThongTinSP.Controls.Add(this.txtHinhAnh);
			this.grpThongTinSP.Controls.Add(this.cboTenLoai);
			this.grpThongTinSP.Controls.Add(this.cboTenHang);
			this.grpThongTinSP.Controls.Add(this.txtGhiChu);
			this.grpThongTinSP.Controls.Add(this.label11);
			this.grpThongTinSP.Controls.Add(this.label10);
			this.grpThongTinSP.Controls.Add(this.txtGiaBan);
			this.grpThongTinSP.Controls.Add(this.txtTenSP);
			this.grpThongTinSP.Controls.Add(this.txtMaSP);
			this.grpThongTinSP.Controls.Add(this.label9);
			this.grpThongTinSP.Controls.Add(this.label7);
			this.grpThongTinSP.Controls.Add(this.label6);
			this.grpThongTinSP.Controls.Add(this.label5);
			this.grpThongTinSP.Controls.Add(this.label2);
			this.grpThongTinSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpThongTinSP.Location = new System.Drawing.Point(12, 95);
			this.grpThongTinSP.Name = "grpThongTinSP";
			this.grpThongTinSP.Size = new System.Drawing.Size(887, 304);
			this.grpThongTinSP.TabIndex = 34;
			this.grpThongTinSP.TabStop = false;
			this.grpThongTinSP.Text = "Thông Tin Sản Phẩm";
			// 
			// ofdOpenFile
			// 
			this.ofdOpenFile.FileName = "openFileDialog1";
			// 
			// btnLuuMa
			// 
			this.btnLuuMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLuuMa.Location = new System.Drawing.Point(939, 861);
			this.btnLuuMa.Name = "btnLuuMa";
			this.btnLuuMa.Size = new System.Drawing.Size(135, 50);
			this.btnLuuMa.TabIndex = 42;
			this.btnLuuMa.Text = "LƯU MÃ";
			this.btnLuuMa.UseVisualStyleBackColor = true;
			this.btnLuuMa.Click += new System.EventHandler(this.btnLuuMa_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.picBarcode);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(330, 409);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(617, 148);
			this.groupBox1.TabIndex = 43;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Barcode";
			// 
			// picBarcode
			// 
			this.picBarcode.Location = new System.Drawing.Point(6, 26);
			this.picBarcode.Name = "picBarcode";
			this.picBarcode.Size = new System.Drawing.Size(611, 116);
			this.picBarcode.TabIndex = 0;
			this.picBarcode.TabStop = false;
			// 
			// btnTaoMa
			// 
			this.btnTaoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTaoMa.Location = new System.Drawing.Point(704, 860);
			this.btnTaoMa.Name = "btnTaoMa";
			this.btnTaoMa.Size = new System.Drawing.Size(135, 50);
			this.btnTaoMa.TabIndex = 44;
			this.btnTaoMa.Text = "TẠO MÃ";
			this.btnTaoMa.UseVisualStyleBackColor = true;
			this.btnTaoMa.Click += new System.EventHandler(this.btnTaoMa_Click);
			// 
			// frmSanPham
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1333, 927);
			this.Controls.Add(this.btnTaoMa);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnLuuMa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSua);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.grpHinhAnh);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.grpThongTinSP);
			this.Name = "frmSanPham";
			this.Text = "SanPham";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmSanPham_Load);
			((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
			this.grpHinhAnh.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.grpThongTinSP.ResumeLayout(false);
			this.grpThongTinSP.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnChonAnh;
		private System.Windows.Forms.TextBox txtHinhAnh;
		private System.Windows.Forms.ComboBox cboTenLoai;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.ComboBox cboTenHang;
		private System.Windows.Forms.TextBox txtGhiChu;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtGiaBan;
		private System.Windows.Forms.TextBox txtTenSP;
		private System.Windows.Forms.TextBox txtMaSP;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox picHinhAnh;
		private System.Windows.Forms.GroupBox grpHinhAnh;
		private System.Windows.Forms.DataGridView dgvSanPham;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox grpThongTinSP;
		private System.Windows.Forms.OpenFileDialog ofdOpenFile;
		private System.Windows.Forms.Button btnLuuMa;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox picBarcode;
		private System.Windows.Forms.Button btnTaoMa;
	}
}