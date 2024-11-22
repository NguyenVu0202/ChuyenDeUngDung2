using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
	public class BUS_LuongNhanVien
	{
		private static BUS_LuongNhanVien instance;

		public static BUS_LuongNhanVien Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BUS_LuongNhanVien();
				}
				return instance;
			}
		}

		// Lấy thông tin nhân viên theo mã
		public NhanVien GetNhanVienByMaNV(string maNV)
		{
			return DAO_LuongNhanVien.Instance.GetNhanVienByMaNV(maNV);
		}

		// Lấy danh sách mã nhân viên
		public List<string> GetAllMaNV()
		{
			return DAO_LuongNhanVien.Instance.GetAllMaNV();
		}

		//Load Combobox Cua Hang
		public List<dynamic> LayDanhSachMaVaDiaChiCuaHang()
		{
			return DAO_LuongNhanVien.Instance.LayDanhSachMaVaDiaChiCuaHang();
		}

		public void TimKiemMaCH(string maCH, DataGridView data)
		{
			if (string.IsNullOrEmpty(maCH))
			{
				MessageBox.Show("Vui lòng chọn mã cửa hàng!");
				return;
			}

			DataTable result = DAO_LuongNhanVien.Instance.TimKiemMaCH(maCH);
			if (result.Rows.Count > 0)
			{
				data.DataSource = result;
			}
			else
			{
				MessageBox.Show("Không tìm thấy dữ liệu!");
				data.DataSource = null;
			}
		}

		//Load Nhân Viên
		public void LoadBangTinhLuong(DataGridView data)
		{
			var dt = DAO_LuongNhanVien.Instance.LoadLuongNV().Select(s =>
			{
				return new
				{
					s.MaTinhLuong,
					s.MaNV,
					s.MaCH,
					s.LuongCoBan,
					s.PhuCap,
					s.Thuong,
					s.NgayNghiPhep,
					s.NgayNghiKhongPhep,
					s.NgayNghiConLai,
					s.LuongThucLinh,
					s.NgayTinhLuong
				};
			}).ToList();
			data.DataSource = dt;
		}

		public void LoadDgvLenForm(TextBox matinhluong, ComboBox manv, ComboBox mach, TextBox luongcoban, TextBox phucap, TextBox thuong, TextBox nghiPhep, TextBox nghiKhongPhep, TextBox ngayNghiConLai, TextBox luongThucLinh, DateTimePicker ngayTinhLuong, DataGridView data)
		{
			try
			{
				DAO.DAO_LuongNhanVien.Instance.LoadDgvLenForm(matinhluong, manv, mach, luongcoban, phucap, thuong, nghiPhep, ngayNghiConLai, luongThucLinh, nghiKhongPhep, ngayTinhLuong, data);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		public void ThemBangLuong(BangTinhLuong bangLuong)
		{
			// Gọi DAO để thêm bảng lương vào cơ sở dữ liệu
			DAO_LuongNhanVien.Instance.ThemaLuongNV(bangLuong);
		}

		// Hàm này có thể lấy dữ liệu từ DB hoặc tính toán trực tiếp
		public decimal TinhLuongThucLinh(decimal luongCoBan, decimal? phuCap, decimal? thuong, int? ngayNghiPhep, int? ngayNghiKhongPhep, int ngayNghiPhepConLai)
		{
			// Gọi logic tính lương từ BUS hoặc trực tiếp như trong hàm trước
			DAO_LuongNhanVien tinhLuong = new DAO_LuongNhanVien();
			return tinhLuong.TinhLuongThucLinh(luongCoBan, phuCap, thuong, ngayNghiPhep, ngayNghiKhongPhep, ngayNghiPhepConLai);
		}

		public bool SuaLuongNV(BangTinhLuong tinhLuong)
		{
			return DAO_LuongNhanVien.Instance.SuaLuongNV(tinhLuong);
		}

		//Xóa lương
		public void XoaLuong(TextBox manv)
		{
			DAO_LuongNhanVien.Instance.XoaLuong(int.Parse(manv.Text));
		}

	}

}

