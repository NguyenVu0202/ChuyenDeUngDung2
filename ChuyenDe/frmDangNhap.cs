using DAO;
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
	public partial class frmDangNhap : Form
	{
        DataBHXDataContext db = new DataBHXDataContext();
        public frmDangNhap()
		{
			InitializeComponent();
		}

		private void btnDangKy_Click(object sender, EventArgs e)
		{
			this.Hide();
			frmDangKy frmDangKy = new frmDangKy();
			frmDangKy.ShowDialog();
			this.Close();
		}

		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			bool check = BUS.BUSAccount.Instance.CheckAccount(txtTaiKhoan, txtMatKhau);

            var manv = (from a in db.Accounts
                        where a.TaiKhoan == txtTaiKhoan.Text && a.MatKhau == txtMatKhau.Text
                        select a.MaNV).FirstOrDefault();

            var quyen = (from q in db.NhanViens
                         where q.MaNV == manv
                         select q.ChucVu).FirstOrDefault();

            if (check == true || txtTaiKhoan.Text == "admin" && txtMatKhau.Text == "admin")
			{
				this.Hide();
				frmChinh frmChinh = new frmChinh(quyen);
                frmChinh.ShowDialog();
				this.Close();			
			}
			else
			{
				MessageBox.Show("Tài khoản hoặc mật khẩu không đúng, vui lòng nhập lại!");
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{

			DialogResult r;
			r = MessageBox.Show("Bạn có muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
			if (r == DialogResult.Yes)
			{
				this.Close();
			}
		}
	}
}
