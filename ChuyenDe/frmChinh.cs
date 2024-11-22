using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuyenDe
{
	public partial class frmChinh : Form
	{
		string quyen = "";
        string manv = "";
		public frmChinh()
		{
			InitializeComponent();
		}

        public frmChinh(string quyen, string manv)
        {
            InitializeComponent();
			this.quyen = quyen;
            this.manv = manv;
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            if(quyen == "1")
            {
                mnuSanPham.Enabled = false;
                mnuDanhMucHang.Enabled = false;
                mnuDanhMucLoai.Enabled = false;
                mnuCuaHang.Enabled = false;
                mnuKho.Enabled = false;
                mnuNhanVien.Enabled = false;
            }
            else
            {
                mnuSanPham.Enabled = true;
                mnuDanhMucHang.Enabled = true;
                mnuDanhMucLoai.Enabled = true;
                mnuCuaHang.Enabled = true;
                mnuKho.Enabled = true;
                mnuNhanVien.Enabled = true;
            }    
        }

        private void frmChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            BUSHoaDon.Instance.XoaHoaDon();
        }

        private void mnuTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            frmTimKiemHoaDon frm = new frmTimKiemHoaDon(manv);
            frm.MdiParent = this;
            frm.Show();
        }
        private void mnuThongKeDanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuThongKeLuongNV_Click(object sender, EventArgs e)
        {
            frmThongKeLuongNhanVien frm = new frmThongKeLuongNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTimKiemSanPham_Click(object sender, EventArgs e)
        {
            frmTimKiemSanPham frm = new frmTimKiemSanPham();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuThongKeSanPham_Click(object sender, EventArgs e)
        {
            frmThongKeSanPhamDaBan frm = new frmThongKeSanPhamDaBan();
            frm.MdiParent = this;
            frm.Show();
        }

		private void mnuThongKeDanhThu_Click_1(object sender, EventArgs e)
		{
			frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuKhachHang_Click_1(object sender, EventArgs e)
		{
			frmKhachHang frm = new frmKhachHang();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuThongKeSanPham_Click_1(object sender, EventArgs e)
		{
			frmThongKeSanPhamDaBan frm = new frmThongKeSanPhamDaBan();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuThongKeLuongNV_Click_1(object sender, EventArgs e)
		{
			frmThongKeLuongNhanVien frm = new frmThongKeLuongNhanVien();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuDangXuat_Click_1(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				this.Hide();
				frmDangNhap frmDangNhap = new frmDangNhap();
				frmDangNhap.ShowDialog();
				this.Close();
			}
		}

		private void mnuThoat_Click_1(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn muốn thoát ứng dụng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void mnuSanPham_Click_1(object sender, EventArgs e)
		{
			frmSanPham fr = new frmSanPham();
			fr.MdiParent = this;
			fr.Show();
		}

		private void mnuDanhMucHang_Click_1(object sender, EventArgs e)
		{
			frmNhaCungCap frm = new frmNhaCungCap();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuDanhMucLoai_Click_1(object sender, EventArgs e)
		{
			frmLoai frm = new frmLoai();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuCuaHang_Click_1(object sender, EventArgs e)
		{
			frmCuaHang frm = new frmCuaHang();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuKho_Click_1(object sender, EventArgs e)
		{
			frmKho frm = new frmKho();
			frm.MdiParent = this;
			frm.Show();
		}

		private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmNhanVien frm = new frmNhanVien();
			frm.MdiParent = this;
			frm.Show();
		}

		private void lươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLuongNhanVien frm = new frmLuongNhanVien();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuHoaDon_Click_1(object sender, EventArgs e)
		{
			frmHoaDon frm = new frmHoaDon(manv);
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuTimKiemSanPham_Click_1(object sender, EventArgs e)
		{
			frmTimKiemSanPham frm = new frmTimKiemSanPham();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuTimKiemHoaDon_Click_1(object sender, EventArgs e)
		{
			frmTimKiemHoaDon frm = new frmTimKiemHoaDon(manv);
			frm.MdiParent = this;
			frm.Show();
		}
	}
}
