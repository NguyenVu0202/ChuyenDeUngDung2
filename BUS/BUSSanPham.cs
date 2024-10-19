using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace BUS
{
	public class BUSSanPham
	{
		private static BUSSanPham instance;

		public static BUSSanPham Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BUSSanPham();
				}
				return instance;
			}


		}
		private BUSSanPham() { }
		public void Xem(DataGridView data)
		{
			var dt = DAOSanPham.Instance.Xem().Select(t =>
			{
				var HinhAnh = Image.FromFile(t.HinhAnh);

				return new
				{
					t.MaSP,
					t.TenSP,
					t.MaLoai,
					t.MaNCC,
					t.GiaBan,
					HinhAnh,
					t.GhiChu

				};
			}).ToList();
			data.DataSource = dt;
			DataGridViewImageColumn pic = new DataGridViewImageColumn();
			pic = (DataGridViewImageColumn)data.Columns[5];
			pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
		}
		public void Them(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenhang, TextBox giaban, TextBox hinhanh, TextBox ghichu)
		{
			DAOSanPham.Instance.Them(masp, tensp, tenloai, tenhang, giaban, hinhanh, ghichu);
		}
		public void LoadTenLoai(ComboBox cb)
		{
			DAOSanPham.Instance.LoadComBoBoxTenLoai(cb);
		}
		public void LoadTenNCC(ComboBox cb)
		{
			DAOSanPham.Instance.LoadComBoxTenNCC(cb);
		}
		public void Sua(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenhang, TextBox giaban, TextBox hinhanh, TextBox ghichu)
		{
			if (!string.IsNullOrEmpty(hinhanh.Text))
			{
				string[] cattenanh = hinhanh.Text.Split('\\');
				int lastIndex = cattenanh.Length - 1;
				string tenanh = cattenanh[lastIndex];
				string duongdan = Path.Combine(Application.StartupPath, "Image");
				string duongdanmoi = duongdan + "\\" + tenanh;
				SanPham sp = new SanPham
				{
					MaSP = masp.Text,
					TenSP = tensp.Text,
					MaLoai = tenloai.SelectedValue.ToString(),
					MaNCC = tenhang.SelectedValue.ToString(),
					GiaBan = int.Parse(giaban.Text),
					HinhAnh = duongdanmoi,
					GhiChu = ghichu.Text,

				};
				DAOSanPham.Instance.Sua(sp);
			}
			else
			{
				SanPham sp = new SanPham
				{
					MaSP = masp.Text,
					TenSP = tensp.Text,
					MaLoai = tenloai.SelectedValue.ToString(),
					MaNCC = tenhang.SelectedValue.ToString(),
					GiaBan = int.Parse(giaban.Text),
					HinhAnh = LayHinhAnhBangMaSP(masp),
					GhiChu = ghichu.Text,

				};
				DAOSanPham.Instance.Sua(sp);
			}
		}
		public string LayHinhAnhBangMaSP(TextBox masp)
		{
			return DAOSanPham.Instance.LayHinhAnhBangMaSP(masp);
		}
		public void Xoa(TextBox masp)
		{
			DAOSanPham.Instance.Xoa(masp.Text);
		}

		public void LoadDgvLenForm(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenhang, TextBox giaban, PictureBox picHinhAnh, TextBox ghichu, DataGridView data)
		{
			DAOSanPham.Instance.LoadDgvLenForm(masp, tensp, tenloai, tenhang, giaban, picHinhAnh, ghichu, data);
		}
	}
}
