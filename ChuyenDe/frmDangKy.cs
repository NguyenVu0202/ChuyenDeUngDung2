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
	public partial class frmDangKy : Form
	{
		public frmDangKy()
		{
			InitializeComponent();
		}

		private void btnDangKy_Click(object sender, EventArgs e)
		{
			if (txtTaiKhoan.Text.Length > 0 && txtMatKhau.Text.Length > 0 && txtMaNV.Text.Length > 0)
			{
				BUSAccount.Instance.Register(txtTaiKhoan, txtMatKhau, txtMaNV);
			}
			else if (txtMaNV.Text.Length == 0)
			{
				MessageBox.Show("Không được để trống thông tin");
			}
			else if (txtMatKhau.Text.Length == 0)
			{
				MessageBox.Show("Không được để trống thông tin");
			}
			else if (txtTaiKhoan.Text.Length == 0)
			{
				MessageBox.Show("Không được để trống thông tin");
			}
		}
		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			this.Hide();
			frmDangNhap frmLogin = new frmDangNhap();
			frmLogin.ShowDialog();
			this.Close();
		}
	}
}
