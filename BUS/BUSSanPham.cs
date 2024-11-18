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
                Image HinhAnh = null;
                try
                {
                    // Check if the image path is not null or empty
                    if (!string.IsNullOrWhiteSpace(t.HinhAnh))
                    {
                        // Attempt to load the image
                        HinhAnh = Image.FromFile(t.HinhAnh);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., file not found, invalid path)
                    Console.WriteLine($"Error loading image for product {t.MaSP}: {ex.Message}");
                    // You might want to set a default image or leave it as null
                    // HinhAnh = Properties.Resources.DefaultImage; // Example of setting a default image
                }

                return new
                {
                    t.MaSP,
                    t.TenSP,
                    t.MaLoai,
                    t.MaNCC,
                    t.GiaBan,
					t.GiamGia,
                    HinhAnh, // HinhAnh can be null if loading failed
                    t.GhiChu
                };
            }).ToList();

            data.DataSource = dt;

            // Ensure the image column is set up correctly
            if (data.Columns.Count > 6 && data.Columns[6] is DataGridViewImageColumn pic)
            {
                pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
        }

        public void Them(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenhang, TextBox giaban, TextBox hinhanh, TextBox ghichu, TextBox giamGia)
		{
			DAOSanPham.Instance.Them(masp, tensp, tenloai, tenhang, giaban, hinhanh, ghichu, giamGia);
		}
		public void LoadTenLoai(ComboBox cb)
		{
			DAOSanPham.Instance.LoadComBoBoxTenLoai(cb);
		}
		public void LoadTenNCC(ComboBox cb)
		{
			DAOSanPham.Instance.LoadComBoxTenNCC(cb);
		}
		public void Sua(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenhang, TextBox giaban, TextBox hinhanh, TextBox ghichu, TextBox giamGia)
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
					GiamGia = int.Parse(giamGia.Text)
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
                    GiamGia = int.Parse(giamGia.Text)
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

		public void LoadDgvLenForm(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenhang, TextBox giaban, PictureBox picHinhAnh, TextBox ghichu, DataGridView data, TextBox giamGia)
		{
			DAOSanPham.Instance.LoadDgvLenForm(masp, tensp, tenloai, tenhang, giaban, picHinhAnh, ghichu, data, giamGia);
		}
		public void AutoTimKiemTenNCC(ComboBox cb)
		{
			DAOSanPham.Instance.AutoTimKiemTenNCC(cb);
		}
        public void AutoTimKiemTenLoai(ComboBox cb)
        {
            DAOSanPham.Instance.AutoTimKiemTenLoai(cb);
        }
    }
}
