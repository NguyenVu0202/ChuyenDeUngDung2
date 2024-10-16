﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
	public class DAOAccount
	{
		private static DAOAccount instance;
		DataBHXDataContext db = new DataBHXDataContext();
		public static DAOAccount Instance
		{
			get
			{
				if (instance == null)
					instance = new DAOAccount();
				return instance;
			}
		}

		private DAOAccount() { }
		public void Register(Account account)
		{
			try
			{			
				db.Accounts.InsertOnSubmit(account);
				db.SubmitChanges();
				MessageBox.Show("Đăng Ký Thành Công");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Đăng Ký Thất Bại" + ex.Message);
			}
		}

		public bool CheckAccount(string taikhoan, string matkhau)
		{
			bool ketqua = false;
			var account = (from ac in db.Accounts
						   where ac.TaiKhoan == taikhoan && ac.MatKhau == matkhau
						   select ac).FirstOrDefault();
			if (account != null)
			{
				ketqua = true;
			}
			return ketqua;
		}
	}
}
