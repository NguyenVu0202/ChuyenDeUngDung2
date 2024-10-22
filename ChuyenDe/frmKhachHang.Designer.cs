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
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radSDT = new System.Windows.Forms.RadioButton();
            this.radTen = new System.Windows.Forms.RadioButton();
            this.radMa = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(830, 770);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(152, 62);
            this.btnTimKiem.TabIndex = 32;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1290, 68);
            this.label1.TabIndex = 27;
            this.label1.Text = "THÔNG TIN KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(56, 770);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(152, 62);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDanhSachKH);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 439);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1285, 298);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Khách Hàng";
            // 
            // dgvDanhSachKH
            // 
            this.dgvDanhSachKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachKH.Location = new System.Drawing.Point(0, 32);
            this.dgvDanhSachKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDanhSachKH.Name = "dgvDanhSachKH";
            this.dgvDanhSachKH.RowHeadersWidth = 51;
            this.dgvDanhSachKH.RowTemplate.Height = 24;
            this.dgvDanhSachKH.Size = new System.Drawing.Size(1278, 260);
            this.dgvDanhSachKH.TabIndex = 0;
            this.dgvDanhSachKH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachKH_CellContentClick);
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(338, 112);
            this.radNu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(64, 29);
            this.radNu.TabIndex = 11;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Location = new System.Drawing.Point(180, 112);
            this.radNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(81, 29);
            this.radNam.TabIndex = 10;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(753, 112);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(306, 31);
            this.txtDiaChi.TabIndex = 9;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(753, 58);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(306, 31);
            this.txtTenKH.TabIndex = 8;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(180, 169);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(337, 31);
            this.txtSDT.TabIndex = 7;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(180, 58);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(337, 31);
            this.txtMaKH.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(573, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Địa Chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(573, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tên Khách Hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số Điện Thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giới Tính:";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(578, 770);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(152, 62);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(310, 770);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(152, 62);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radSDT);
            this.groupBox1.Controls.Add(this.radTen);
            this.groupBox1.Controls.Add(this.radMa);
            this.groupBox1.Controls.Add(this.label7);
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
            this.groupBox1.Location = new System.Drawing.Point(68, 174);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1133, 239);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // radSDT
            // 
            this.radSDT.AutoSize = true;
            this.radSDT.Location = new System.Drawing.Point(974, 181);
            this.radSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radSDT.Name = "radSDT";
            this.radSDT.Size = new System.Drawing.Size(79, 29);
            this.radSDT.TabIndex = 15;
            this.radSDT.TabStop = true;
            this.radSDT.Text = "SDT";
            this.radSDT.UseVisualStyleBackColor = true;
            this.radSDT.CheckedChanged += new System.EventHandler(this.radSDT_CheckedChanged);
            // 
            // radTen
            // 
            this.radTen.AutoSize = true;
            this.radTen.Location = new System.Drawing.Point(887, 181);
            this.radTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radTen.Name = "radTen";
            this.radTen.Size = new System.Drawing.Size(74, 29);
            this.radTen.TabIndex = 14;
            this.radTen.TabStop = true;
            this.radTen.Text = "Tên";
            this.radTen.UseVisualStyleBackColor = true;
            this.radTen.CheckedChanged += new System.EventHandler(this.radTen_CheckedChanged);
            // 
            // radMa
            // 
            this.radMa.AutoSize = true;
            this.radMa.Location = new System.Drawing.Point(796, 181);
            this.radMa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radMa.Name = "radMa";
            this.radMa.Size = new System.Drawing.Size(67, 29);
            this.radMa.TabIndex = 13;
            this.radMa.TabStop = true;
            this.radMa.Text = "Mã";
            this.radMa.UseVisualStyleBackColor = true;
            this.radMa.CheckedChanged += new System.EventHandler(this.radMa_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(636, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tìm kiếm theo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã KH:";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(1084, 770);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(152, 62);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 841);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
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
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton radSDT;
        private System.Windows.Forms.RadioButton radTen;
        private System.Windows.Forms.RadioButton radMa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
    }
}