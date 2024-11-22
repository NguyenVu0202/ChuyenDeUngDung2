namespace ChuyenDe
{
	partial class frmChinh
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSanPham = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDanhMucHang = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDanhMucLoai = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCuaHang = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuKho = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
			this.lươngNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thôngTinNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTimKiemSanPham = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTimKiemHoaDon = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuThongKeDanhThu = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuThongKeSanPham = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuThongKeLuongNV = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuDanhMuc,
            this.mnuKhachHang,
            this.mnuNhanVien,
            this.mnuHoaDon,
            this.mnuTimKiem,
            this.mnuThongKe});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1257, 36);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuThoat});
			this.mnuFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(108, 32);
			this.mnuFile.Text = "Hệ thống";
			// 
			// mnuDangXuat
			// 
			this.mnuDangXuat.Name = "mnuDangXuat";
			this.mnuDangXuat.Size = new System.Drawing.Size(224, 32);
			this.mnuDangXuat.Text = "Đăng Xuất";
			this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click_1);
			// 
			// mnuThoat
			// 
			this.mnuThoat.Name = "mnuThoat";
			this.mnuThoat.Size = new System.Drawing.Size(224, 32);
			this.mnuThoat.Text = "Thoát";
			this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click_1);
			// 
			// mnuDanhMuc
			// 
			this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSanPham,
            this.mnuDanhMucHang,
            this.mnuDanhMucLoai,
            this.mnuCuaHang,
            this.mnuKho});
			this.mnuDanhMuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuDanhMuc.Name = "mnuDanhMuc";
			this.mnuDanhMuc.Size = new System.Drawing.Size(115, 32);
			this.mnuDanhMuc.Text = "Danh Mục";
			// 
			// mnuSanPham
			// 
			this.mnuSanPham.Name = "mnuSanPham";
			this.mnuSanPham.Size = new System.Drawing.Size(224, 32);
			this.mnuSanPham.Text = "Sản Phẩm";
			this.mnuSanPham.Click += new System.EventHandler(this.mnuSanPham_Click_1);
			// 
			// mnuDanhMucHang
			// 
			this.mnuDanhMucHang.Name = "mnuDanhMucHang";
			this.mnuDanhMucHang.Size = new System.Drawing.Size(224, 32);
			this.mnuDanhMucHang.Text = "Hãng";
			this.mnuDanhMucHang.Click += new System.EventHandler(this.mnuDanhMucHang_Click_1);
			// 
			// mnuDanhMucLoai
			// 
			this.mnuDanhMucLoai.Name = "mnuDanhMucLoai";
			this.mnuDanhMucLoai.Size = new System.Drawing.Size(224, 32);
			this.mnuDanhMucLoai.Text = "Loại";
			this.mnuDanhMucLoai.Click += new System.EventHandler(this.mnuDanhMucLoai_Click_1);
			// 
			// mnuCuaHang
			// 
			this.mnuCuaHang.Name = "mnuCuaHang";
			this.mnuCuaHang.Size = new System.Drawing.Size(224, 32);
			this.mnuCuaHang.Text = "Cửa Hàng";
			this.mnuCuaHang.Click += new System.EventHandler(this.mnuCuaHang_Click_1);
			// 
			// mnuKho
			// 
			this.mnuKho.Name = "mnuKho";
			this.mnuKho.Size = new System.Drawing.Size(224, 32);
			this.mnuKho.Text = "Kho";
			this.mnuKho.Click += new System.EventHandler(this.mnuKho_Click_1);
			// 
			// mnuKhachHang
			// 
			this.mnuKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuKhachHang.Name = "mnuKhachHang";
			this.mnuKhachHang.Size = new System.Drawing.Size(131, 32);
			this.mnuKhachHang.Text = "Khách Hàng";
			this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click_1);
			// 
			// mnuNhanVien
			// 
			this.mnuNhanVien.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lươngNhânViênToolStripMenuItem,
            this.thôngTinNhânViênToolStripMenuItem});
			this.mnuNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuNhanVien.Name = "mnuNhanVien";
			this.mnuNhanVien.Size = new System.Drawing.Size(116, 32);
			this.mnuNhanVien.Text = "Nhân Viên";
			// 
			// lươngNhânViênToolStripMenuItem
			// 
			this.lươngNhânViênToolStripMenuItem.Name = "lươngNhânViênToolStripMenuItem";
			this.lươngNhânViênToolStripMenuItem.Size = new System.Drawing.Size(280, 32);
			this.lươngNhânViênToolStripMenuItem.Text = "Lương Nhân Viên";
			this.lươngNhânViênToolStripMenuItem.Click += new System.EventHandler(this.lươngNhânViênToolStripMenuItem_Click);
			// 
			// thôngTinNhânViênToolStripMenuItem
			// 
			this.thôngTinNhânViênToolStripMenuItem.Name = "thôngTinNhânViênToolStripMenuItem";
			this.thôngTinNhânViênToolStripMenuItem.Size = new System.Drawing.Size(280, 32);
			this.thôngTinNhânViênToolStripMenuItem.Text = "Thông Tin Nhân Viên";
			this.thôngTinNhânViênToolStripMenuItem.Click += new System.EventHandler(this.thôngTinNhânViênToolStripMenuItem_Click);
			// 
			// mnuHoaDon
			// 
			this.mnuHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuHoaDon.Name = "mnuHoaDon";
			this.mnuHoaDon.Size = new System.Drawing.Size(104, 32);
			this.mnuHoaDon.Text = "Hóa Đơn";
			this.mnuHoaDon.Click += new System.EventHandler(this.mnuHoaDon_Click_1);
			// 
			// mnuTimKiem
			// 
			this.mnuTimKiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimKiemSanPham,
            this.mnuTimKiemHoaDon});
			this.mnuTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuTimKiem.Name = "mnuTimKiem";
			this.mnuTimKiem.Size = new System.Drawing.Size(107, 32);
			this.mnuTimKiem.Text = "Tìm Kiếm";
			// 
			// mnuTimKiemSanPham
			// 
			this.mnuTimKiemSanPham.Name = "mnuTimKiemSanPham";
			this.mnuTimKiemSanPham.Size = new System.Drawing.Size(270, 32);
			this.mnuTimKiemSanPham.Text = "Tìm Kiếm Sản Phẩm";
			this.mnuTimKiemSanPham.Click += new System.EventHandler(this.mnuTimKiemSanPham_Click_1);
			// 
			// mnuTimKiemHoaDon
			// 
			this.mnuTimKiemHoaDon.Name = "mnuTimKiemHoaDon";
			this.mnuTimKiemHoaDon.Size = new System.Drawing.Size(270, 32);
			this.mnuTimKiemHoaDon.Text = "Tìm Kiếm Hóa Đơn";
			this.mnuTimKiemHoaDon.Click += new System.EventHandler(this.mnuTimKiemHoaDon_Click_1);
			// 
			// mnuThongKe
			// 
			this.mnuThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThongKeDanhThu,
            this.mnuThongKeSanPham,
            this.mnuThongKeLuongNV});
			this.mnuThongKe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuThongKe.Name = "mnuThongKe";
			this.mnuThongKe.Size = new System.Drawing.Size(109, 32);
			this.mnuThongKe.Text = "Thống Kê";
			// 
			// mnuThongKeDanhThu
			// 
			this.mnuThongKeDanhThu.Name = "mnuThongKeDanhThu";
			this.mnuThongKeDanhThu.Size = new System.Drawing.Size(249, 32);
			this.mnuThongKeDanhThu.Text = "Danh Thu";
			this.mnuThongKeDanhThu.Click += new System.EventHandler(this.mnuThongKeDanhThu_Click_1);
			// 
			// mnuThongKeSanPham
			// 
			this.mnuThongKeSanPham.Name = "mnuThongKeSanPham";
			this.mnuThongKeSanPham.Size = new System.Drawing.Size(249, 32);
			this.mnuThongKeSanPham.Text = "Sản Phẩm";
			this.mnuThongKeSanPham.Click += new System.EventHandler(this.mnuThongKeSanPham_Click_1);
			// 
			// mnuThongKeLuongNV
			// 
			this.mnuThongKeLuongNV.Name = "mnuThongKeLuongNV";
			this.mnuThongKeLuongNV.Size = new System.Drawing.Size(249, 32);
			this.mnuThongKeLuongNV.Text = "Lương Nhân Viên";
			this.mnuThongKeLuongNV.Click += new System.EventHandler(this.mnuThongKeLuongNV_Click_1);
			// 
			// frmChinh
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::ChuyenDe.Properties.Resources.sharefb_v201908071702_637008562618462479;
			this.ClientSize = new System.Drawing.Size(1257, 840);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "frmChinh";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChinh_FormClosing);
			this.Load += new System.EventHandler(this.frmChinh_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
		private System.Windows.Forms.ToolStripMenuItem mnuThoat;
		private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
		private System.Windows.Forms.ToolStripMenuItem mnuSanPham;
		private System.Windows.Forms.ToolStripMenuItem mnuDanhMucHang;
		private System.Windows.Forms.ToolStripMenuItem mnuDanhMucLoai;
		private System.Windows.Forms.ToolStripMenuItem mnuCuaHang;
		private System.Windows.Forms.ToolStripMenuItem mnuKho;
		private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
		private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
		private System.Windows.Forms.ToolStripMenuItem lươngNhânViênToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thôngTinNhânViênToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuHoaDon;
		private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
		private System.Windows.Forms.ToolStripMenuItem mnuTimKiemSanPham;
		private System.Windows.Forms.ToolStripMenuItem mnuTimKiemHoaDon;
		private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
		private System.Windows.Forms.ToolStripMenuItem mnuThongKeDanhThu;
		private System.Windows.Forms.ToolStripMenuItem mnuThongKeSanPham;
		private System.Windows.Forms.ToolStripMenuItem mnuThongKeLuongNV;
	}
}

