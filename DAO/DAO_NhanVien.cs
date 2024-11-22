using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
	public class DAO_NhanVien
	{
		private static DAO_NhanVien instance;

		public static DAO_NhanVien Instance
		{
			get
			{
				if (instance == null)
					instance = new DAO_NhanVien();
				return instance;
			}
		}
		public DAO_NhanVien() { }

		//Load Combobox MaCH
		public List<string> LayDanhSachMaVaDiaChiCuaHang()
		{
			try
			{
				using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
				{
					return (from k in db.CuaHangs
							select $"{k.MaCH} - {k.DiaChi}").ToList();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Lỗi truy vấn dữ liệu: {ex.Message}");
			}
		}

		public string LayMaCHTuChuoi(string maVaDiaChi)
		{
			if (string.IsNullOrEmpty(maVaDiaChi))
				throw new ArgumentException("Dữ liệu không hợp lệ");

			// Tách chuỗi trước dấu "-" và loại bỏ khoảng trắng
			return maVaDiaChi.Split('-')[0].Trim();
		}


		//Thêm nhân viên
		public void ThemNhanVien(NhanVien nhanVien, string maVaDiaChi)
		{
			try
			{
				using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
				{
					// Lấy MaCH từ chuỗi MaCH - DiaChi
					nhanVien.MaCH = LayMaCHTuChuoi(maVaDiaChi);

					// Kiểm tra số điện thoại đã tồn tại
					bool isPhoneNumberExists = db.NhanViens.Any(nv => nv.SDT == nhanVien.SDT);
					if (isPhoneNumberExists)
					{
						MessageBox.Show("Số điện thoại đã tồn tại. Mỗi nhân viên chỉ được có một số điện thoại duy nhất.");
						return;
					}

					// Kiểm tra và gán chức vụ (Chỉ cho phép 1 hoặc 0)
					if (int.TryParse(nhanVien.ChucVu, out int chucVu))
					{
						if (chucVu == 1 || chucVu == 0)
						{
							nhanVien.ChucVu = chucVu.ToString();
						}
						else
						{
							MessageBox.Show("Chức vụ không hợp lệ. Chỉ có thể là 0 hoặc 1.");
							return;
						}
					}
					else
					{
						MessageBox.Show("Chức vụ không hợp lệ. Vui lòng nhập giá trị đúng.");
						return;
					}

					// Tạo MaNV mới theo định dạng NV00_<MaCH><number>
					int employeeCount = db.NhanViens.Count(nv => nv.MaCH == nhanVien.MaCH);
					nhanVien.MaNV = $"NV00{employeeCount + 1}_{nhanVien.MaCH}";

					// Thêm nhân viên mới vào cơ sở dữ liệu
					db.NhanViens.InsertOnSubmit(nhanVien);
					db.SubmitChanges();

					MessageBox.Show("Thêm Thành Công");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Thêm Thất Bại: " + ex.Message);
			}
		}

		//Hiển thị danh sách nhân viên
		public List<NhanVien> LoadNV()
		{
			List<NhanVien> listnv = new List<NhanVien>();
			DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());
			var nv = (from s in db.NhanViens
					  select new
					  {
						  s.MaNV,
						  s.TenNV,
						  s.GioiTinh,
						  s.NgaySinh,
						  s.SDT,
						  s.DiaChi,
						  s.Luong,
						  s.MaCH,
						  s.ChucVu

					  }).ToList();

			foreach (var item in nv)
			{
				NhanVien nhanVien = new NhanVien();
				nhanVien.MaNV = item.MaNV;
				nhanVien.TenNV = item.TenNV;
				nhanVien.GioiTinh = item.GioiTinh;
				nhanVien.NgaySinh = item.NgaySinh;
				nhanVien.SDT = item.SDT;
				nhanVien.DiaChi = item.DiaChi;
				nhanVien.Luong = item.Luong;
				nhanVien.MaCH = item.MaCH;
				nhanVien.ChucVu = item.ChucVu;
				listnv.Add(nhanVien);
			}
			return listnv;
		}

		//Hiển thị dữ liệu xuống dgv
		public void LoadDgvLenForm(TextBox manv, TextBox tennv, RadioButton gtnam, RadioButton gtnu, DateTimePicker ngaysinh, TextBox sdt, TextBox diachi, TextBox luong, ComboBox mach, TextBox chucvu, DataGridView data)
		{
			var rowIndex = data.SelectedCells[0].RowIndex;
			var row = data.Rows[rowIndex];
			manv.Text = row.Cells["MaNV"].Value?.ToString().Trim();
			tennv.Text = row.Cells["TenNV"].Value?.ToString().Trim();
			if (row.Cells["GioiTinh"].Value?.ToString().Trim() == "Nam")
			{
				gtnam.Checked = true;
			}
			else
			{
				gtnu.Checked = true;
			}
			ngaysinh.Text = row.Cells["NgaySinh"].Value != null
				? ((DateTime)row.Cells["NgaySinh"].Value).ToString("yyyy-MM-dd")
				: "";
			sdt.Text = row.Cells["SDT"].Value?.ToString().Trim();
			luong.Text = row.Cells["Luong"].Value?.ToString().Trim();
			diachi.Text = row.Cells["DiaChi"].Value?.ToString().Trim();
			mach.Text = row.Cells["MaCH"].Value?.ToString().Trim();
			chucvu.Text = row.Cells["ChucVu"].Value?.ToString().Trim();

		}

		//Sửa nhân viên
		public void SuaNV(NhanVien nhanVien, string maVaDiaChi)
		{
			try
			{
				// Sử dụng khối using để quản lý đối tượng db
				using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
				{
					// Tìm nhân viên dựa trên mã nhân viên (MaNV)
					NhanVien nv = db.NhanViens.SingleOrDefault(p => p.MaNV == nhanVien.MaNV);

					if (nv != null)
					{
						// Lấy MaCH từ chuỗi MaCH - DiaChi
						nhanVien.MaCH = LayMaCHTuChuoi(maVaDiaChi);

						// Kiểm tra số điện thoại có trùng với nhân viên khác (trừ nhân viên hiện tại)
						bool isPhoneNumberExists = db.NhanViens
							.Any(p => p.SDT == nhanVien.SDT && p.MaNV != nhanVien.MaNV);

						if (isPhoneNumberExists)
						{
							MessageBox.Show("Số điện thoại đã tồn tại. Mỗi nhân viên chỉ được có một số điện thoại duy nhất.");
							return;
						}

						// Cập nhật thông tin nhân viên
						bool isUpdated = false;

						// Chỉ cập nhật các thuộc tính nếu có sự thay đổi
						if (nv.TenNV != nhanVien.TenNV)
						{
							nv.TenNV = nhanVien.TenNV;
							isUpdated = true;
						}

						if (nv.GioiTinh != nhanVien.GioiTinh)
						{
							nv.GioiTinh = nhanVien.GioiTinh;
							isUpdated = true;
						}

						if (nv.NgaySinh != nhanVien.NgaySinh)
						{
							nv.NgaySinh = nhanVien.NgaySinh;
							isUpdated = true;
						}

						if (nv.SDT != nhanVien.SDT)
						{
							nv.SDT = nhanVien.SDT;
							isUpdated = true;
						}

						if (nv.Luong != nhanVien.Luong)
						{
							nv.Luong = nhanVien.Luong;
							isUpdated = true;
						}

						if (nv.DiaChi != nhanVien.DiaChi)
						{
							nv.DiaChi = nhanVien.DiaChi;
							isUpdated = true;
						}

						if (nv.MaCH != nhanVien.MaCH)
						{
							nv.MaCH = nhanVien.MaCH;
							isUpdated = true;
						}

						// Kiểm tra và cập nhật chức vụ (Chỉ cho phép 1 hoặc 0)
						if (nv.ChucVu != nhanVien.ChucVu && (int.Parse(nhanVien.ChucVu) == 1 || int.Parse(nhanVien.ChucVu) == 0))
						{
							nv.ChucVu = nhanVien.ChucVu;
							isUpdated = true;
						}

						// Nếu có sự thay đổi, lưu vào cơ sở dữ liệu
						if (isUpdated)
						{
							db.SubmitChanges();
							MessageBox.Show("Sửa nhân viên thành công! (Mã nhân viên không được phép thay đổi)");
						}
						else
						{
							MessageBox.Show("Không có thay đổi nào để cập nhật.");
						}
					}
					else
					{
						MessageBox.Show("Không tìm thấy nhân viên để sửa.");
					}
				}
			}
			catch (Exception ex)
			{
				// Hiển thị thông báo thất bại và lỗi
				MessageBox.Show("Sửa thất bại: " + ex.Message);
			}
		}



		//Xóa nhân viên
		public void XoaNV(string maNV)
		{
			try
			{
				DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());
				var nv = db.NhanViens.FirstOrDefault(p => p.MaNV == maNV);
				db.NhanViens.DeleteOnSubmit(nv);
				db.SubmitChanges();
				MessageBox.Show("Xóa Thành Công");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Xóa thất bại: " + ex.Message);
			}
		}

		//Tìm kiếm nhân viên theo Mã Nhân Viên
		public List<NhanVien> TimKiemNVTheoMaNV(string MaNV)
		{
			List<NhanVien> list = new List<NhanVien>();
			DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());
			var nv = db.NhanViens.SingleOrDefault(p => p.MaNV == MaNV);
			if (nv != null)
			{
				NhanVien nhanvien = new NhanVien
				{
					MaNV = nv.MaNV,
					TenNV = nv.TenNV,
					GioiTinh = nv.GioiTinh,
					DiaChi = nv.DiaChi,
					SDT = nv.SDT,
					NgaySinh = nv.NgaySinh,
					Luong = nv.Luong,
					MaCH = nv.MaCH,
					ChucVu = nv.ChucVu,
				};
				list.Add(nhanvien);
			}
			else
			{
				MessageBox.Show("Không Có Mã Nhân Viên");
			}
			return list;
		}

		//Tìm kiếm Nhân Viên theo tên nhân viên
		public List<NhanVien> TimKiemNVTheoSĐTNV(string MaNV)
		{
			List<NhanVien> list = new List<NhanVien>();
			DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());

			// Tìm tất cả nhân viên có cùng số điện thoại
			var duplicateEmployees = db.NhanViens.Where(p => p.SDT == MaNV).ToList();

			if (duplicateEmployees.Count > 1)
			{
				MessageBox.Show("Số điện thoại trùng lặp với nhiều nhân viên khác. Vui lòng kiểm tra lại!");
			}
			else if (duplicateEmployees.Count == 1)
			{
				var nv = duplicateEmployees.First();
				NhanVien nhanvien = new NhanVien
				{
					MaNV = nv.MaNV,
					TenNV = nv.TenNV,
					GioiTinh = nv.GioiTinh,
					DiaChi = nv.DiaChi,
					SDT = nv.SDT,
					NgaySinh = nv.NgaySinh,
					Luong = nv.Luong,
					MaCH = nv.MaCH,
					ChucVu = nv.ChucVu,
				};
				list.Add(nhanvien);
			}
			else
			{
				MessageBox.Show("Không có nhân viên với số điện thoại cần tìm.");
			}

			return list;

		}

		public bool KiemTraMaNV(string maNV)
		{
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				return db.NhanViens.Any(nv => nv.MaNV == maNV);
			}
		}


		//Load Mã Nhân Viên
		public List<string> LoadMaNV()
		{
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				// Lấy danh sách MaNV từ bảng NhanVien và chuyển thành List<string>
				return db.NhanViens
							  .Select(nv => nv.MaNV)
							  .ToList();
			}
		}

		//Load Tên Nhân Viên
		public List<string> LoadSDTNV()
		{
			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				// Lấy danh sách số điện thoại từ bảng NhanVien và chuyển thành List<string>
				return db.NhanViens
						 .Select(nv => nv.SDT)
						 .ToList();
			}
		}



	}
}
