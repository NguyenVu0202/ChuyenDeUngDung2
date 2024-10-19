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
    }
}
