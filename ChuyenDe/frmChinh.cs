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
		public frmChinh()
		{
			InitializeComponent();
		}

		private void mnuSanPham_Click(object sender, EventArgs e)
		{
			frmSanPham fr = new frmSanPham();
			fr.MdiParent = this;
			fr.Show();
		}

        private void mnuDanhMucHang_Click(object sender, EventArgs e)
        {
			frmNhaCungCap frm = new frmNhaCungCap();
			frm.MdiParent = this;
			frm.Show();
        }

        private void mnuDanhMucLoai_Click(object sender, EventArgs e)
        {
			frmLoai frm = new frmLoai();
			frm.MdiParent = this;
			frm.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuKho_Click(object sender, EventArgs e)
        {
			frmKho frm = new frmKho();
			frm.MdiParent = this;
			frm.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
			frmNhanVien frm = new frmNhanVien();
			frm.MdiParent = this;
			frm.Show();
        }

        private void mnuCuaHang_Click(object sender, EventArgs e)
        {
			frmCuaHang frm = new frmCuaHang();
			frm.MdiParent = this;
			frm.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
			DialogResult result = MessageBox.Show("Bạn muốn thoát ứng dụng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Application.Exit();
			}
        }
    }
}
