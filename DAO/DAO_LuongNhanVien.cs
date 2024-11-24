using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
	public class DAO_LuongNhanVien
	{
		private static DAO_LuongNhanVien instance;

		public static DAO_LuongNhanVien Instance
		{
			get
			{
				if (instance == null)
					instance = new DAO_LuongNhanVien();
				return instance;
			}
		}
		public DAO_LuongNhanVien() { }

		public NhanVien GetNhanVienByMaNV(string maNV)
		{
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				return db.NhanViens.FirstOrDefault(nv => nv.MaNV == maNV);
			}

		}


		//Load Combobox MaCH
		public List<dynamic> LayDanhSachMaVaDiaChiCuaHang()
		{
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				return (from k in db.CuaHangs
						select new
						{
							MaCH = k.MaCH,
							DisplayText = $"{k.MaCH} - {k.DiaChi}"
						}).ToList<dynamic>();
			}
		}


		public string LayMaCHTuChuoi(string maVaDiaChi)
		{
			if (string.IsNullOrEmpty(maVaDiaChi))
				throw new ArgumentException("Dữ liệu không hợp lệ");

			// Tách chuỗi trước dấu "-" và loại bỏ khoảng trắng
			return maVaDiaChi.Split('-')[0].Trim();
		}


		// Lấy danh sách mã nhân viên (nếu cần để đổ vào combobox)
		public List<string> GetAllMaNV()
		{
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				return db.NhanViens.Select(nv => nv.MaNV).ToList();
			}
		}

		//Tìm kiếm MaCH
		public DataTable TimKiemMaCH(string maCH)
		{
			DataTable table = new DataTable();

			// Định nghĩa các cột của DataTable
			table.Columns.Add("MaTinhLuong", typeof(int));
			table.Columns.Add("MaNV", typeof(string));
			table.Columns.Add("MaCH", typeof(string));
			table.Columns.Add("LuongCoBan", typeof(decimal));
			table.Columns.Add("PhuCap", typeof(decimal));
			table.Columns.Add("Thuong", typeof(decimal));
			table.Columns.Add("NgayNghiPhep", typeof(int));
			table.Columns.Add("NgayNghiKhongPhep", typeof(int));
			table.Columns.Add("LuongThucLinh", typeof(decimal));
			table.Columns.Add("NgayNghiConLai", typeof(int));
			table.Columns.Add("NgayTinhLuong", typeof(DateTime));

			
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				// Truy vấn dữ liệu
				var result = (from s in db.BangTinhLuongs
							  join ch in db.CuaHangs on s.MaCH equals ch.MaCH
							  where ch.MaCH == maCH
							  select new
							  {
								  s.MaTinhLuong,
								  s.MaNV,
								  ch.MaCH,
								  s.LuongCoBan,
								  s.PhuCap,
								  s.Thuong,
								  s.NgayNghiPhep,
								  s.NgayNghiKhongPhep,
								  s.LuongThucLinh,
								  s.NgayNghiConLai,
								  s.NgayTinhLuong

							  }).ToList();


				// Đổ dữ liệu vào DataTable
				if (result.Any())
				{
					foreach (var item in result)
					{
						DataRow row = table.NewRow();
						row["MaTinhLuong"] = item.MaTinhLuong;
						row["MaNV"] = item.MaNV;
						row["MaCH"] = item.MaCH;
						row["LuongCoBan"] = item.LuongCoBan;
						row["PhuCap"] = item.PhuCap;
						row["Thuong"] = item.Thuong;
						row["NgayNghiPhep"] = item.NgayNghiPhep;
						row["NgayNghiKhongPhep"] = item.NgayNghiKhongPhep;
						row["LuongThucLinh"] = item.LuongThucLinh;
						row["NgayNghiConLai"] = item.NgayNghiConLai;
						row["NgayTinhLuong"] = item.NgayTinhLuong;
						table.Rows.Add(row);
					}
				}
			}

			return table;
		}

		//Hiển thị dữ liệu xuống dgv
		public List<BangTinhLuong> LoadLuongNV()
		{
			List<BangTinhLuong> listBangLuong = new List<BangTinhLuong>();
			DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());

			// Lấy dữ liệu từ bảng BangTinhLuong
			var bangLuong = (from s in db.BangTinhLuongs
							 select new
							 {
								 s.MaTinhLuong,
								 s.MaNV,
								 s.MaCH,
								 s.LuongCoBan,
								 s.PhuCap,
								 s.Thuong,
								 s.NgayNghiPhep,
								 s.NgayNghiKhongPhep,
								 s.LuongThucLinh,
								 s.NgayNghiConLai,
								 s.NgayTinhLuong
							 }).ToList();

			// Chuyển dữ liệu sang danh sách đối tượng BangTinhLuong
			foreach (var item in bangLuong)
			{
				BangTinhLuong tinhLuong = new BangTinhLuong();

				tinhLuong.MaTinhLuong = item.MaTinhLuong;
				tinhLuong.MaNV = item.MaNV;
				tinhLuong.MaCH = item.MaCH;
				tinhLuong.LuongCoBan = item.LuongCoBan;
				tinhLuong.PhuCap = item.PhuCap;
				tinhLuong.Thuong = item.Thuong;
				tinhLuong.NgayNghiPhep = item.NgayNghiPhep;
				tinhLuong.NgayNghiKhongPhep = item.NgayNghiKhongPhep;
				tinhLuong.NgayNghiConLai = item.NgayNghiConLai;
				tinhLuong.LuongThucLinh = item.LuongThucLinh;
				tinhLuong.NgayTinhLuong = item.NgayTinhLuong;
				listBangLuong.Add(tinhLuong);
			}

			return listBangLuong;
		}

		//Dgv lên form
		public void LoadDgvLenForm(TextBox matinhluong, ComboBox manv, ComboBox mach, TextBox luongcoban, TextBox phucap, TextBox thuong, TextBox nghiPhep, TextBox nghiKhongPhep, TextBox luongThucLinh, TextBox ngayNghiConLai, DateTimePicker ngayTinhLuong, DataGridView data)
		{
			// Ensure a row is selected
			if (data.SelectedCells.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một hàng dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Get the selected row
			var rowIndex = data.SelectedCells[0].RowIndex;
			var row = data.Rows[rowIndex];

			// Safely populate controls
			matinhluong.Text = row.Cells["MaTinhLuong"]?.Value?.ToString()?.Trim() ?? string.Empty;
			manv.Text = row.Cells["MaNV"]?.Value?.ToString()?.Trim() ?? string.Empty;
			mach.Text = row.Cells["MaCH"]?.Value?.ToString()?.Trim() ?? string.Empty;
			luongcoban.Text = row.Cells["LuongCoBan"]?.Value?.ToString()?.Trim() ?? "0";
			phucap.Text = row.Cells["PhuCap"]?.Value?.ToString()?.Trim() ?? "0";
			thuong.Text = row.Cells["Thuong"]?.Value?.ToString()?.Trim() ?? "0";
			nghiPhep.Text = row.Cells["NgayNghiPhep"]?.Value?.ToString()?.Trim() ?? "0";
			nghiKhongPhep.Text = row.Cells["NgayNghiKhongPhep"]?.Value?.ToString()?.Trim() ?? "0";
			ngayNghiConLai.Text = row.Cells["NgayNghiConLai"]?.Value?.ToString()?.Trim() ?? "0";
			luongThucLinh.Text = row.Cells["LuongThucLinh"]?.Value?.ToString()?.Trim() ?? "0";

			// Parse and set date
			if (row.Cells["NgayTinhLuong"]?.Value != null &&
				DateTime.TryParse(row.Cells["NgayTinhLuong"].Value.ToString(), out DateTime ngay))
			{
				ngayTinhLuong.Value = ngay;
			}
			else
			{
				ngayTinhLuong.Value = DateTime.Now; // Set to current date if invalid
			}
		}

		public void ThemaLuongNV(BangTinhLuong cuaHang)
		{
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				db.BangTinhLuongs.InsertOnSubmit(cuaHang);
				db.SubmitChanges();

			}
		}

		public decimal TinhLuongThucLinh(decimal luongCoBan, decimal? phuCap, decimal? thuong, int? soNgayNghiPhep, int? soNgayNghiKhongPhep, int soNgayNghiPhepConLai)
		{
			// Giả định số ngày làm việc tiêu chuẩn trong tháng
			int soNgayLamViecTieuChuan = 26;

			// Tính lương mỗi ngày
			decimal luongMotNgay = luongCoBan / soNgayLamViecTieuChuan;

			// Xử lý các giá trị null, gán giá trị mặc định là 0 nếu null
			decimal phuCapValue = phuCap ?? 0;
			decimal thuongValue = thuong ?? 0;
			int soNgayNghiPhepValue = soNgayNghiPhep ?? 0;
			int soNgayNghiKhongPhepValue = soNgayNghiKhongPhep ?? 0;

			// Tính số ngày nghỉ phép vượt quá
			int soNgayNghiPhepVuot = Math.Max(0, soNgayNghiPhepValue - soNgayNghiPhepConLai);

			// Cập nhật số ngày nghỉ phép còn lại
			soNgayNghiPhepConLai = Math.Max(0, soNgayNghiPhepConLai - soNgayNghiPhepValue);

			// Thêm số ngày nghỉ phép vượt quá vào ngày nghỉ không phép
			soNgayNghiKhongPhepValue += soNgayNghiPhepVuot;

			// Tính phần trừ cho ngày nghỉ có phép
			decimal truNghiPhep = (soNgayNghiPhepValue - soNgayNghiPhepVuot) * luongMotNgay;

			// Tính phần trừ cho ngày nghỉ không phép
			decimal truNghiKhongPhep = soNgayNghiKhongPhepValue * luongMotNgay;

			// Tính lương thực lãnh
			decimal luongThucLinh = luongCoBan + phuCapValue + thuongValue - truNghiPhep - truNghiKhongPhep;

			// Làm tròn lương thực lãnh đến 0 chữ số sau dấu thập phân
			luongThucLinh = Math.Round(luongThucLinh, 0, MidpointRounding.AwayFromZero);

			return luongThucLinh;
		}

		//Sửa bảng lương 
		public bool SuaLuongNV(BangTinhLuong tinhLuong)
		{
			try
			{
				using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
				{
					var existingRecord = db.BangTinhLuongs.SingleOrDefault(btl => btl.MaTinhLuong == tinhLuong.MaTinhLuong);
					if (existingRecord == null)
						return false;

					// Kiểm tra số ngày nghỉ phép
					if (tinhLuong.NgayNghiPhep > 12)
					{
						// Hiển thị thông báo và yêu cầu nhập ngày nghỉ không phép
						MessageBox.Show("Ngày nghỉ phép không được quá 12 ngày. Vui lòng nhập số ngày nghỉ vượt quá vào trường 'Ngày nghỉ không phép'.",
										"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}

					// Cập nhật dữ liệu
					existingRecord.MaNV = tinhLuong.MaNV;
					existingRecord.MaCH = tinhLuong.MaCH;
					existingRecord.LuongCoBan = tinhLuong.LuongCoBan;
					existingRecord.PhuCap = tinhLuong.PhuCap;
					existingRecord.Thuong = tinhLuong.Thuong;
					existingRecord.NgayNghiPhep = tinhLuong.NgayNghiPhep;
					existingRecord.NgayNghiKhongPhep = tinhLuong.NgayNghiKhongPhep;
					existingRecord.NgayNghiConLai = tinhLuong.NgayNghiConLai;
					existingRecord.LuongThucLinh = tinhLuong.LuongThucLinh;
					existingRecord.NgayTinhLuong = tinhLuong.NgayTinhLuong;

					db.SubmitChanges();
					return true;
				}
			}
			catch (Exception ex)
			{
				// Hiển thị thông báo lỗi
				MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

		}

		//Xóa bảng lương
		public void XoaLuong(int maNV)
		{
			try
			{
				DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());
				var nv = db.BangTinhLuongs.FirstOrDefault(p => p.MaTinhLuong == maNV);
				db.BangTinhLuongs.DeleteOnSubmit(nv);
				db.SubmitChanges();
				MessageBox.Show("Xóa Thành Công");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Xóa thất bại: " + ex.Message);
			}
		}

	}
}
