using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
	public class BUSAccount
	{
		private static BUSAccount instance;
		public static BUSAccount Instance
		{
			get
			{
				if (instance == null)
					instance = new BUSAccount();
				return instance;
			}
		}
		private BUSAccount() { }
		public void Register(TextBox taikhoan, TextBox matkhau, TextBox manv)
		{
			Account sanPham = new Account
			{
				TaiKhoan = taikhoan.Text,
				MatKhau = matkhau.Text,
				MaNV = manv.Text
			};

			DAOAccount.Instance.Register(sanPham);
		}
		public bool CheckAccount(TextBox taikhoan, TextBox matkhau)
		{
			bool check = DAOAccount.Instance.CheckAccount(taikhoan.Text, matkhau.Text);
			if (check == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public string quyen(TextBox taikhoan)
		{
			return DAOAccount.Instance.quyen(taikhoan.Text);
		}
        public string manv(TextBox taikhoan)
        {
            return DAOAccount.Instance.manv(taikhoan.Text);
        }
    }
}
