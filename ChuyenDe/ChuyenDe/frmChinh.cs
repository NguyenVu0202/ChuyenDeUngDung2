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
	}
}
