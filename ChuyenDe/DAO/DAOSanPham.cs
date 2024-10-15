using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace DAO
{
	public class DAOSanPham
	{
		private static DAOSanPham instance;
		DataBHXDataContext db = new DataBHXDataContext();

		public static DAOSanPham Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DAOSanPham();
				}
				return instance;
			}


		}
		public DAOSanPham() { }
		public List<SanPham> Xem()
		{
			List<SanPham> sp = new List<SanPham>();
			
				var sanPhamsFromDB = (from sp1 in db.SanPhams
									  select new
									  {
										  sp1.MaSP,
										  sp1.TenSP,
										  sp1.MaLoai,
										  sp1.MaNCC,
										  sp1.GiaBan,
										  sp1.HinhAnh, // Assuming HinhAnh is of type Binary in the database
										  sp1.GhiChu
									  }).ToList();

				foreach (var item in sanPhamsFromDB)
				{
					SanPham sanPham = new SanPham();
					sanPham.MaSP = item.MaSP;
					sanPham.MaLoai = item.MaLoai;
					sanPham.MaNCC = item.MaNCC;
					sanPham.TenSP = item.TenSP;
					sanPham.GiaBan = item.GiaBan;
					sanPham.GhiChu = item.GhiChu;
					sanPham.HinhAnh = item.HinhAnh;

					sp.Add(sanPham);
				}

			return sp;
		}
		public void LoadComBoBoxTenLoai(ComboBox cb)
		{
			Dictionary<string, string> lst = new Dictionary<string, string>();

				var tenloai = from loai in db.Loais
							  select new { loai.MaLoai, loai.TenLoai };
				foreach (var item in tenloai)
				{
					lst.Add(item.MaLoai, item.TenLoai);
				}
				cb.DataSource = new BindingSource(lst, null);
				cb.DisplayMember = "Value";
				cb.ValueMember = "Key";

		}
		public void LoadComBoxTenNCC(ComboBox cb)
		{
			Dictionary<string, string> lst = new Dictionary<string, string>();

				var tenHang = from sp in db.NCCs
							  select new { sp.MaNCC, sp.TenNCC };
				foreach (var item in tenHang)
				{
					lst.Add(item.MaNCC, item.TenNCC);
				}
				cb.DataSource = new BindingSource(lst, null);
				cb.DisplayMember = "Value";
				cb.ValueMember = "Key";

		}
		public void Them(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenncc, TextBox giaban, TextBox hinhanh, TextBox ghichu)
		{
			try
			{
					string[] cattenanh = hinhanh.Text.Split('\\');
					int lastIndex = cattenanh.Length - 1;
					string tenanh = cattenanh[lastIndex];
					string duongdan = Path.Combine(Application.StartupPath, "Image");
					string duongdanmoi = duongdan + "\\" + tenanh;
					SanPham sp = new SanPham();
					sp.MaSP = masp.Text;
					sp.TenSP = tensp.Text;
					sp.MaLoai = tenloai.SelectedValue.ToString().Trim();
					sp.MaNCC = tenncc.SelectedValue.ToString().Trim();
					sp.GiaBan = int.Parse(giaban.Text);
					sp.HinhAnh = duongdanmoi;
					sp.GhiChu = ghichu.Text;
					db.SanPhams.InsertOnSubmit(sp);
					db.SubmitChanges();
					MessageBox.Show("Thêm Sản Phẩm Thành Công");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi " + ex);
			}
		}
		public void Xoa(string masp)
		{
				var spdelete = db.SanPhams.FirstOrDefault(a => a.MaSP == masp);
				if (spdelete != null)
				{
					db.SanPhams.DeleteOnSubmit(spdelete);
					db.SubmitChanges();
				}
		}
		public bool Sua(SanPham sp)
		{
				var spupdate = db.SanPhams.SingleOrDefault(a => a.MaSP == sp.MaSP);
				if (spupdate != null)
				{
					spupdate.MaLoai = sp.MaLoai;
					spupdate.MaNCC = sp.MaNCC;
					spupdate.TenSP = sp.TenSP;
					spupdate.GiaBan = sp.GiaBan;
					spupdate.HinhAnh = sp.HinhAnh;
					spupdate.GhiChu = sp.GhiChu;
					db.SubmitChanges();
					MessageBox.Show("Sửa Sản Phẩm Thành Công");
					return true;
				}
				else
				{
					MessageBox.Show("Sửa Sản Phẩm Thất Bại");
				}	
				return false;
		}
		public string LayHinhAnhBangMaSP(TextBox masp)
		{
				var sanpham = db.SanPhams.SingleOrDefault(sp => sp.MaSP == masp.Text);
				if (sanpham != null)
				{
					return sanpham.HinhAnh;
				}	
				else
				{
					return "";
				}
		}
		public void LoadDgvLenForm(TextBox masp, TextBox tensp, ComboBox tenloai, ComboBox tenhang, TextBox giaban, PictureBox picHinhAnh, TextBox ghichu, DataGridView data)
		{
				var rowIndex = data.SelectedCells[0].RowIndex;
				var row = data.Rows[rowIndex];
				masp.Text = row.Cells[0].Value.ToString().Trim();
				tensp.Text = row.Cells[1].Value.ToString().Trim();
				var loai = (from l in db.Loais
							where l.MaLoai == row.Cells[2].Value.ToString().Trim()
							select l.TenLoai).FirstOrDefault();
				tenloai.Text = loai.ToString();
				var hang = (from h in db.NCCs
							where h.MaNCC == row.Cells[3].Value.ToString().Trim()
							select h.TenNCC).FirstOrDefault();
				tenhang.Text = hang.ToString();
				giaban.Text = row.Cells[4].Value.ToString().Trim();
				var anh = row.Cells[5].Value as Image;
				picHinhAnh.Image = anh;
				ghichu.Text = row.Cells[6].Value.ToString().Trim();
		}
	}
}
