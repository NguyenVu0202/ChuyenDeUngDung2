using BUS;
using DAO;
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
	public partial class frmLuongNhanVien : Form
	{
		public frmLuongNhanVien()
		{
			InitializeComponent();
			LoadMaCH();
			LoadMaNVCombobox();
			LoadBangTinhLuong();
		}
		private void LoadMaNVCombobox()
		{
			var maNVList = BUS_LuongNhanVien.Instance.GetAllMaNV();
			cbMaNV.DataSource = maNVList;
		}

		private void LoadBangTinhLuong()
		{
			BUS_LuongNhanVien.Instance.LoadBangTinhLuong(dgvLuongNV);
		}

		private void frmLuongNhanVien_Load(object sender, EventArgs e)
		{
			// Cấu hình AutoComplete cho TextBox txtMaNV
			cbMaNV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbMaNV.AutoCompleteSource = AutoCompleteSource.CustomSource;

			// Tạo AutoCompleteStringCollection để chứa dữ liệu
			AutoCompleteStringCollection dataMaNV = new AutoCompleteStringCollection();
			dataMaNV.AddRange(LayDanhSachMaNV()); // Lấy danh sách mã nhân viên và thêm vào AutoComplete
			cbMaNV.AutoCompleteCustomSource = dataMaNV;
		}
		private string[] LayDanhSachMaNV()
		{
			// Giả sử phương thức LoadMaNV() trả về danh sách mã nhân viên từ cơ sở dữ liệu
			List<string> danhSachMaNV = DAO_NhanVien.Instance.LoadMaNV();
			return danhSachMaNV.ToArray();
		}

		private void LoadMaCH()
		{
			try
			{
				// Lấy danh sách mã và địa chỉ cửa hàng từ BUS
				var danhSachMaCH = BUS_LuongNhanVien.Instance.LayDanhSachMaVaDiaChiCuaHang();

				// Gán dữ liệu cho ComboBox
				cbMaCH.DataSource = danhSachMaCH;
				cbMaCH.DisplayMember = "DisplayText"; // Hiển thị mã và địa chỉ
				cbMaCH.ValueMember = "MaCH";         // Giá trị thực tế là mã cửa hàng
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi tải danh sách mã cửa hàng: {ex.Message}");
			}
		}

		private void ClearTextBoxes()
		{
			txtTenNV.Text = string.Empty;
			txtSĐT.Text = string.Empty;
			txtLuongCB.Text = string.Empty;
			cbMaCH.Text = string.Empty; // Xóa giá trị trong combobox MaCH
		}

		private void cbMaNV_Leave(object sender, EventArgs e)
		{
			try
			{
				string selectedMaNV = cbMaNV.SelectedItem?.ToString();
				if (!string.IsNullOrWhiteSpace(selectedMaNV))
				{
					var nhanVien = BUS_LuongNhanVien.Instance.GetNhanVienByMaNV(selectedMaNV);

					if (nhanVien != null)
					{
						txtTenNV.Text = nhanVien.TenNV;
						txtSĐT.Text = nhanVien.SDT;
						txtLuongCB.Text = nhanVien.Luong?.ToString("N0") ?? "0";
						cbMaCH.Text = nhanVien.MaCH;

					}
					else
					{
						MessageBox.Show("Không tìm thấy nhân viên với mã đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						ClearTextBoxes();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			string maCH = cbMaCH.SelectedValue?.ToString();
			if (!string.IsNullOrEmpty(maCH))
			{
				BUS_LuongNhanVien.Instance.TimKiemMaCH(maCH, dgvLuongNV);
			}
			else
			{
				MessageBox.Show("Vui lòng chọn mã cửa hàng!");
			}
		}

		private void dgvLuongNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			BUS_LuongNhanVien.Instance.LoadDgvLenForm(txtMaTinhLuong, cbMaNV, cbMaCH, txtLuongCB, txtPhuCap, txtThuong, txtNghiPhep, txtNgayNghiConLai, txtNghiKhongPhep, txtLuongThucLinh, dtpNgayTinhLuong, dgvLuongNV);
		}

		private void btnThem_Click(object sender, EventArgs e)
		{

			btnThem.Enabled = false;
			try
			{
				// Lấy giá trị từ các trường

				string maNV = cbMaNV.SelectedValue?.ToString() ?? "";
				string maCH = cbMaCH.Text ?? "";
				string luong = txtLuongCB.Text;
				string phuCap = txtPhuCap.Text;
				string thuong = txtThuong.Text;
				string ngayNghiPhep = txtNghiPhep.Text;
				string ngayNghiKhongPhep = txtNghiKhongPhep.Text;
				string luongThucLinh = txtLuongThucLinh.Text;
				string ngayNghiConLai = txtNgayNghiConLai.Text;
				string maVaDiaChi = cbMaCH.SelectedItem?.ToString(); // Sử dụng ?. để tránh NullReferenceException
				string ngayTinhLuong = dtpNgayTinhLuong.Text;

				// Kiểm tra các trường không được bỏ trống
				if (string.IsNullOrWhiteSpace(luong) || string.IsNullOrWhiteSpace(phuCap) ||
					string.IsNullOrWhiteSpace(thuong) || string.IsNullOrWhiteSpace(ngayNghiPhep) ||
					string.IsNullOrWhiteSpace(ngayNghiKhongPhep) || string.IsNullOrWhiteSpace(ngayNghiConLai))
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin các trường Tên NV, Địa chỉ, SĐT, Lương, Phụ cấp, Thưởng, Ngày nghỉ phép, Ngày nghỉ không phép.");
					return; // Dừng lại nếu có trường bị bỏ trống
				}

				if (luong != luong.Trim())
				{
					MessageBox.Show("Lương không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				if (phuCap != phuCap.Trim())
				{
					MessageBox.Show("Phụ cấp không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				if (thuong != thuong.Trim())
				{
					MessageBox.Show("Thưởng không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				if (ngayNghiConLai != ngayNghiConLai.Trim())
				{
					MessageBox.Show("Thưởng không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong các trường
				if (Regex.IsMatch(maNV, @"\s{2,}"))
				{
					MessageBox.Show("Mã nhân viên không được có hai khoảng trắng liên tiếp.");
					return;
				}

				if (Regex.IsMatch(luong, @"\s{2,}"))
				{
					MessageBox.Show("Lương không được có hai khoảng trắng liên tiếp.");
					return;
				}

				if (Regex.IsMatch(phuCap, @"\s{2,}"))
				{
					MessageBox.Show("Phụ cấp không được có hai khoảng trắng liên tiếp.");
					return;
				}

				if (Regex.IsMatch(thuong, @"\s{2,}"))
				{
					MessageBox.Show("Thưởng không được có hai khoảng trắng liên tiếp.");
					return;
				}

				if (!decimal.TryParse(luong, out decimal luongDecimal))
				{
					MessageBox.Show("Lương phải là số hợp lệ.");
					return;
				}

				if (!decimal.TryParse(phuCap, out decimal phuCapDecimal))
				{
					MessageBox.Show("Phụ cấp phải là số hợp lệ.");
					return;
				}

				if (!decimal.TryParse(thuong, out decimal thuongDecimal))
				{
					MessageBox.Show("Thưởng phải là số hợp lệ.");
					return;
				}

				if (!int.TryParse(ngayNghiPhep, out int ngayNghiPhepInt))
				{
					MessageBox.Show("Ngày nghỉ phép phải là số hợp lệ.");
					return;
				}

				if (!int.TryParse(ngayNghiKhongPhep, out int ngayNghiKhongPhepInt))
				{
					MessageBox.Show("Ngày nghỉ không phép phải là số hợp lệ.");
					return;
				}

				if (!int.TryParse(ngayNghiConLai, out int ngayNghiConLaiInt))
				{
					MessageBox.Show("Ngày nghỉ còn lại phải là số hợp lệ.");
					return;
				}
				// Kiểm tra số ngày nghỉ phép từ giao diện


				if (!DateTime.TryParse(ngayTinhLuong, out DateTime ngayTinhLuongDate))
				{
					MessageBox.Show("Ngày tính lương không hợp lệ.");
					return;
				}

				// Kiểm tra số ngày nghỉ phép không vượt quá 12
				if (ngayNghiPhepInt > 12)
				{
					MessageBox.Show("Số ngày nghỉ có phép không được vượt quá 12 ngày.");
					return;
				}

				// Tạo đối tượng nhân viên
				BangTinhLuong nhanVien = new BangTinhLuong
				{

					MaNV = maNV,
					MaCH = maCH,
					LuongCoBan = decimal.Parse(luong),
					PhuCap = decimal.Parse(phuCap),
					Thuong = decimal.Parse(thuong),
					NgayNghiPhep = int.Parse(ngayNghiPhep),
					NgayNghiKhongPhep = int.Parse(ngayNghiKhongPhep),
					NgayNghiConLai = int.Parse(ngayNghiConLai),
					LuongThucLinh = decimal.Parse(luongThucLinh),
					NgayTinhLuong = DateTime.Parse(ngayTinhLuong),

				};

				// Thêm nhân viên vào cơ sở dữ liệu
				BUS_LuongNhanVien.Instance.ThemBangLuong(nhanVien);
				MessageBox.Show("Thêm thành công");
				// Tải lại dữ liệu sau khi thêm
				LoadBangTinhLuong();

				// Xóa các trường
				txtMaTinhLuong.Text = string.Empty;
				cbMaNV.SelectedIndex = -1; // Reset selection
				cbMaCH.SelectedIndex = -1; // Reset selection
				txtTenNV.Text = string.Empty;
				txtSĐT.Text = string.Empty;
				txtLuongCB.Text = string.Empty;
				txtPhuCap.Text = string.Empty;
				txtThuong.Text = string.Empty;
				txtNghiPhep.Text = string.Empty;
				txtNghiKhongPhep.Text = string.Empty;
				txtNgayNghiConLai.Text = string.Empty;
				txtLuongThucLinh.Text = string.Empty;
				dtpNgayTinhLuong.Value = DateTime.Now; // Set to current date or desired default date

				cbMaNV.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Thêm không thành công: {ex.Message}");
			}
			finally
			{
				btnThem.Enabled = true;
			}
		}

		private void txtLuongThucLinh_Leave(object sender, EventArgs e)
		{
			try
			{
				// Lấy các giá trị từ giao diện
				decimal luongCoBan = decimal.Parse(txtLuongCB.Text);
				decimal? phuCap = string.IsNullOrEmpty(txtPhuCap.Text) ? (decimal?)null : decimal.Parse(txtPhuCap.Text);
				decimal? thuong = string.IsNullOrEmpty(txtThuong.Text) ? (decimal?)null : decimal.Parse(txtThuong.Text);

				// Xử lý ngày nghỉ phép và không phép
				int? ngayNghiPhep = string.IsNullOrEmpty(txtNghiPhep.Text) ? (int?)null : int.Parse(txtNghiPhep.Text);
				int? ngayNghiKhongPhep = string.IsNullOrEmpty(txtNghiKhongPhep.Text) ? (int?)null : int.Parse(txtNghiKhongPhep.Text);

				// Lấy giá trị ngày nghỉ phép còn lại từ giao diện (hoặc từ dữ liệu ban đầu)
				// Lấy số ngày nghỉ phép còn lại (12 nếu không có giá trị nhập vào)
				int ngayNghiPhepConLai = string.IsNullOrEmpty(txtNgayNghiConLai.Text) ? 12 : int.Parse(txtNgayNghiConLai.Text);

				// Lấy số ngày nghỉ phép đã nhập
				int ngayNghiPhepDaNhap = string.IsNullOrEmpty(txtNghiPhep.Text) ? 0 : int.Parse(txtNghiPhep.Text);

				// Trừ số ngày nghỉ phép đã nhập từ số ngày nghỉ phép còn lại
				int ngayNghiPhepConLaiSauKhiTru = ngayNghiPhepConLai - ngayNghiPhepDaNhap;

				// Kiểm tra nếu ngày nghỉ phép còn lại sau khi trừ là âm, thì gán về 0
				ngayNghiPhepConLaiSauKhiTru = Math.Max(0, ngayNghiPhepConLaiSauKhiTru);

				// Hiển thị hoặc sử dụng giá trị đã trừ
				Console.WriteLine("Ngày nghỉ phép còn lại: " + ngayNghiPhepConLaiSauKhiTru);


				// Gọi phương thức tính lương thực lãnh và nhận giá trị ngày nghỉ phép còn lại từ phương thức trả về
				decimal luongThucLinh = BUS_LuongNhanVien.Instance.TinhLuongThucLinh(
					luongCoBan,
					phuCap,
					thuong,
					ngayNghiPhep,
					ngayNghiKhongPhep,
					ngayNghiPhepConLai  // Không sử dụng ref
				);

				// Cập nhật ngày nghỉ phép còn lại sau khi tính toán
				txtNgayNghiConLai.Text = ngayNghiPhepConLaiSauKhiTru.ToString();

				// Hiển thị kết quả lương thực lãnh dưới dạng VND
				txtLuongThucLinh.Text = luongThucLinh.ToString();
			}
			catch (Exception ex)
			{
				// Xử lý lỗi và hiển thị thông báo nếu có lỗi
				MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			try
			{
				// Kiểm tra và lấy giá trị Ngày nghỉ phép
				int ngayNghiPhep = int.Parse(txtNghiPhep.Text.Trim());
				// Kiểm tra và lấy giá trị Ngày nghỉ không phép (chỉ khai báo một lần)
				int ngayNghiKhongPhep = int.Parse(txtNghiKhongPhep.Text.Trim());

				// Kiểm tra Phụ cấp
				if (!decimal.TryParse(txtPhuCap.Text.Trim(), out decimal phuCap) || phuCap < 0)
				{
					MessageBox.Show("Phụ cấp phải là số hợp lệ và không được âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Kiểm tra Thưởng
				if (!decimal.TryParse(txtThuong.Text.Trim(), out decimal thuong) || thuong < 0)
				{
					MessageBox.Show("Thưởng phải là số hợp lệ và không được âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Kiểm tra Ngày nghỉ phép
				if (ngayNghiPhep < 0)
				{
					MessageBox.Show("Ngày nghỉ phép phải là số nguyên hợp lệ và không được âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Kiểm tra Ngày nghỉ không phép
				if (ngayNghiKhongPhep < 0)
				{
					MessageBox.Show("Ngày nghỉ không phép phải là số nguyên hợp lệ và không được âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Kiểm tra số ngày nghỉ phép từ giao diện
				if (ngayNghiPhep > 12 && ngayNghiKhongPhep == 0)
				{
					MessageBox.Show("Ngày nghỉ phép không được quá 12 ngày. Vui lòng nhập số ngày vượt quá vào trường 'Ngày nghỉ không phép'.",
									"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Tiếp tục với logic cập nhật
				BangTinhLuong tinhLuong = new BangTinhLuong
				{
					MaTinhLuong = int.Parse(txtMaTinhLuong.Text),
					MaNV = cbMaNV.SelectedValue.ToString(),
					MaCH = cbMaCH.SelectedValue.ToString(),
					LuongCoBan = decimal.Parse(txtLuongCB.Text.Trim()),
					PhuCap = decimal.Parse(txtPhuCap.Text.Trim()),
					Thuong = decimal.Parse(txtThuong.Text.Trim()),
					NgayNghiPhep = ngayNghiPhep,
					NgayNghiConLai = int.Parse(txtNgayNghiConLai.Text),
					NgayNghiKhongPhep = ngayNghiKhongPhep,
					LuongThucLinh = decimal.Parse(txtLuongThucLinh.Text.Trim()),
					NgayTinhLuong = dtpNgayTinhLuong.Value
				};

				if (BUS_LuongNhanVien.Instance.SuaLuongNV(tinhLuong))
				{
					MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadBangTinhLuong();
				}
				else
				{
					MessageBox.Show("Không tìm thấy bản ghi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			DialogResult kq = MessageBox.Show("Bạn có muốn xóa không???", "Thông Báo",
										MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (kq == DialogResult.Yes)
			{
				BUS_LuongNhanVien.Instance.XoaLuong(txtMaTinhLuong);

				// Clear fields
				txtMaTinhLuong.Text = string.Empty;
				cbMaNV.SelectedIndex = -1; // Reset selection
				cbMaCH.SelectedIndex = -1; // Reset selection
				txtTenNV.Text = string.Empty;
				txtSĐT.Text = string.Empty;
				txtLuongCB.Text = string.Empty;
				txtPhuCap.Text = string.Empty;
				txtThuong.Text = string.Empty;
				txtNghiPhep.Text = string.Empty;
				txtNghiKhongPhep.Text = string.Empty;
				txtLuongThucLinh.Text = string.Empty;
				dtpNgayTinhLuong.Value = DateTime.Now; // Set to current date or desired default date

				LoadBangTinhLuong();
			}
			else
			{
				MessageBox.Show("Không thể xóa!!!");
			}
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			// Clear fields
			txtMaTinhLuong.Text = string.Empty;
			cbMaNV.SelectedIndex = -1; // Reset selection
			cbMaCH.SelectedIndex = -1; // Reset selection
			txtTenNV.Text = string.Empty;
			txtSĐT.Text = string.Empty;
			txtLuongCB.Text = string.Empty;
			txtPhuCap.Text = string.Empty;
			txtThuong.Text = string.Empty;
			txtNghiPhep.Text = string.Empty;
			txtNghiKhongPhep.Text = string.Empty;
			txtNgayNghiConLai.Text = string.Empty;
			txtLuongThucLinh.Text = string.Empty;
			dtpNgayTinhLuong.Value = DateTime.Now; // Set to current date or desired default date
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			DialogResult kq = MessageBox.Show("Bạn muốn thoát không????", "Thong Bao",
				  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (kq == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void btnIn_Click(object sender, EventArgs e)
		{
			frmInLuongNhanVien frm = new frmInLuongNhanVien(int.Parse(txtMaTinhLuong.Text));
			this.Hide();
			frm.ShowDialog();
			this.Close();
		}
	}
}
