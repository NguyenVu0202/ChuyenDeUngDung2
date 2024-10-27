using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin để đăng ký!");
                return; // Dừng lại nếu có trường bị bỏ trống
            }

            // Kiểm tra khoảng trắng đầu và cuối
            if (txtTaiKhoan.Text != txtTaiKhoan.Text.Trim() || txtMatKhau.Text != txtMatKhau.Text.Trim() ||
                txtMaNV.Text != txtMaNV.Text.Trim())
            {
                MessageBox.Show("Không được có khoảng trắng ở đầu hoặc cuối.");
                return; // Dừng lại nếu có khoảng trắng đầu hoặc cuối
            }

            // Kiểm tra khoảng trắng liên tiếp trong chuỗi
            if (Regex.IsMatch(txtTaiKhoan.Text, @"\s{2,}") || Regex.IsMatch(txtMatKhau.Text, @"\s{2,}") ||
                Regex.IsMatch(txtMaNV.Text, @"\s{2,}"))
            {
                MessageBox.Show("Không được có hai khoảng trắng liên tiếp.");
                return; // Dừng lại nếu có hai khoảng trắng liên tiếp
            }

            BUSAccount.Instance.Register(txtTaiKhoan, txtMatKhau, txtMaNV);
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
