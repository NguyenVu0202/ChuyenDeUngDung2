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

        private void mnuCuaHang_Click(object sender, EventArgs e)
        {
			frmCuaHang frm = new frmCuaHang();
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
    }
}
