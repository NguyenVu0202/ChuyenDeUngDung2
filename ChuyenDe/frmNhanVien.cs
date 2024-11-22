using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuyenDe
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            LoadCbCuaHang();
            LoadNhanVien();
        }

        //Load combobox Cua Hang
        public void LoadCbCuaHang()
        {
			try
			{
				List<string> danhSach = BUS_NhanVien.Instance.LayDanhSachCuaHang();
				cbMaCH.DataSource = danhSach; // Gắn dữ liệu trực tiếp
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi tải ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        //Hiển Thị dữ liệu
        public void LoadNhanVien()
        {
            BUS_NhanVien.Instance.LoadNV(dgvThongTinNhanVien);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // Cấu hình AutoComplete cho TextBox txtMaNV
            txtMaNV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaNV.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Tạo AutoCompleteStringCollection để chứa dữ liệu
            AutoCompleteStringCollection dataMaNV = new AutoCompleteStringCollection();
            dataMaNV.AddRange(LayDanhSachMaNV()); // Lấy danh sách mã nhân viên và thêm vào AutoComplete
            txtMaNV.AutoCompleteCustomSource = dataMaNV;

            // Cấu hình AutoComplete cho TextBox txtTenNV
            txtSĐT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSĐT.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Tạo AutoCompleteStringCollection cho tên nhân viên
            AutoCompleteStringCollection dataTenNV = new AutoCompleteStringCollection();
            dataTenNV.AddRange(LayDanhSachSĐTNV()); // Lấy danh sách tên nhân viên và thêm vào AutoComplete
            txtSĐT.AutoCompleteCustomSource = dataTenNV;
        }

        //Btn Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
			btnThem.Enabled = false;
			try
			{
				// Lấy giá trị từ các trường
				string maNV = txtMaNV.Text;
				string tenNV = txtTenNV.Text;
				string ngaySinh = dtpNgaySinh.Text;
				string sDT = txtSĐT.Text;
				string diaChi = txtDiaChi.Text;
				string luong = txtLuong.Text;
				string maCH = cbMaCH.SelectedValue?.ToString() ?? "";
				string chucvu = txtChucVu.Text;
				string maVaDiaChi = cbMaCH.SelectedItem.ToString();

				// Kiểm tra các trường không được bỏ trống
				if (string.IsNullOrWhiteSpace(tenNV) ||
					(!rdNam.Checked && !rdNu.Checked) || string.IsNullOrWhiteSpace(diaChi) ||
					string.IsNullOrWhiteSpace(sDT) || string.IsNullOrWhiteSpace(luong) || string.IsNullOrWhiteSpace(chucvu))
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin các trường TenNV, Giới Tính, SĐT, Lương, Địa Chỉ, Chức vụ");
					return; // Dừng lại nếu có trường bị bỏ trống
				}

				// Kiểm tra khoảng trắng đầu và cuối trong TenNV
				if (tenNV != tenNV.Trim())
				{
					MessageBox.Show("Tên nhân viên không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong SDT
				if (sDT != sDT.Trim())
				{
					MessageBox.Show("Số điện thoại không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong DiaChi
				if (diaChi != diaChi.Trim())
				{
					MessageBox.Show("Địa chỉ không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong Luong
				if (luong != luong.Trim())
				{
					MessageBox.Show("Lương không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong Chuc Vu
				if (chucvu != chucvu.Trim())
				{
					MessageBox.Show("Chức Vụ không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong MaNV
				if (Regex.IsMatch(maNV, @"\s{2,}"))
				{
					MessageBox.Show("Mã nhân viên không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong TenNV
				if (Regex.IsMatch(tenNV, @"\s{2,}"))
				{
					MessageBox.Show("Tên nhân viên không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong SDT
				if (Regex.IsMatch(sDT, @"\s{2,}"))
				{
					MessageBox.Show("Số điện thoại không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong DiaChi
				if (Regex.IsMatch(diaChi, @"\s{2,}"))
				{
					MessageBox.Show("Địa chỉ không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong Luong
				if (Regex.IsMatch(luong, @"\s{2,}"))
				{
					MessageBox.Show("Lương không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong ChucVu
				if (Regex.IsMatch(chucvu, @"\s{2,}"))
				{
					MessageBox.Show("Chức Vụ không được có hai khoảng trắng liên tiếp.");
					return;
				}

				if (!decimal.TryParse(luong, out decimal luongDecimal) || luongDecimal < 0)
				{
					MessageBox.Show("Lương phải là số hợp lệ và không được âm");
					return;
				}

				if (!long.TryParse(sDT, out long soDienThoai))
				{
					MessageBox.Show("Số điện thoại phải là số hợp lệ.");
					return;
				}

				// Kiểm tra tuổi
				if (!DateTime.TryParse(ngaySinh, out DateTime dateOfBirth))
				{
					MessageBox.Show("Ngày sinh không hợp lệ.");
					return;
				}

				int age = DateTime.Now.Year - dateOfBirth.Year;
				if (dateOfBirth > DateTime.Now.AddYears(-age)) age--; // Điều chỉnh nếu chưa qua sinh nhật trong năm

				if (age < 18)
				{
					MessageBox.Show("Nhân viên phải đủ 18 tuổi.");
					return;
				}

				//Sdt phải đúng 10 chữ số 
				if (sDT.Length != 10)
				{
					MessageBox.Show("Số điện thoại phải có đúng 10 chữ số.");
					return;
				}

				// Kiểm tra tên nhân viên không chứa ký tự đặc biệt
				if (!Regex.IsMatch(tenNV, @"^[a-zA-ZÀ-ỹ\s]+$"))
				{
					MessageBox.Show("Tên nhân viên không được chứa ký tự đặc biệt.");
					return;
				}

				// Kiểm tra giới tính
				string gioitinh = rdNam.Checked ? "Nam" : "Nữ";

				// Tạo đối tượng nhân viên
				NhanVien nhanVien = new NhanVien
				{
					MaNV = maNV,
					TenNV = tenNV,
					GioiTinh = gioitinh,
					NgaySinh = Convert.ToDateTime(ngaySinh),
					SDT = sDT,
					DiaChi = diaChi,
					Luong = int.Parse(luong),
					MaCH = maCH,
					ChucVu = chucvu
				};

				// Thêm nhân viên vào cơ sở dữ liệu
				BUS_NhanVien.Instance.ThemNhanVien(txtMaNV, txtTenNV, rdNam, rdNu, dtpNgaySinh, txtSĐT, txtDiaChi, txtLuong, cbMaCH, txtChucVu, maVaDiaChi);

				// Tải lại dữ liệu sau khi thêm
				LoadNhanVien();

				// Xóa các trường
				txtMaNV.Text = string.Empty;
				cbMaCH.SelectedIndex = -1; // Reset selection
				rdNam.Checked = false;
				rdNu.Checked = false;
				txtTenNV.Text = string.Empty;
				txtSĐT.Text = string.Empty;
				txtDiaChi.Text = string.Empty;
				txtLuong.Text = string.Empty;
				txtChucVu.Text = string.Empty;
				dtpNgaySinh.Value = DateTime.Now; // Set to current date or desired default date

				txtMaNV.Focus();
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

		//Btn Sửa
		
        //Btn Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không???", "Thông Báo",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                BUS_NhanVien.Instance.XoaNV(txtMaNV);

                // Clear fields
                txtMaNV.Text = string.Empty;
                cbMaCH.SelectedIndex = -1; // Reset selection
                rdNam.Checked = false;
                rdNu.Checked = false;
                txtTenNV.Text = string.Empty;
                txtSĐT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtLuong.Text = string.Empty;
                txtChucVu.Text = string.Empty;
                dtpNgaySinh.Value = DateTime.Now; // Set to current date or desired default date


                txtMaNV.Focus();
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Không thể xóa!!!");
            }
        }

        //Btn Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMaNV.Text) || !string.IsNullOrWhiteSpace(txtSĐT.Text) )
            {
                txtMaNV.Text = txtMaNV.Text.ToUpper();
                txtSĐT.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtSĐT.Text.ToLower());
             
                if (!string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUS_NhanVien.Instance.TimKiemNVTheoMaNV(txtMaNV, dgvThongTinNhanVien);
                   
                }
                if (!string.IsNullOrWhiteSpace(txtSĐT.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUS_NhanVien.Instance.TimKiemNVTheoSDTNV(txtSĐT, dgvThongTinNhanVien);
                    
                }
               
            }
            else MessageBox.Show("Vui lòng nhập dữ liệu cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private string[] LayDanhSachMaNV()
        {
            // Giả sử phương thức LoadMaNV() trả về danh sách mã nhân viên từ cơ sở dữ liệu
            List<string> danhSachMaNV = DAO_NhanVien.Instance.LoadMaNV();
            return danhSachMaNV.ToArray();
        }

        private string[] LayDanhSachSĐTNV()
        {
            // Giả sử phương thức LoadTenNV() trả về danh sách tên nhân viên từ cơ sở dữ liệu
            List<string> danhSachTenNV = DAO_NhanVien.Instance.LoadSDTNV();
            return danhSachTenNV.ToArray();
        }

        //Btn Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát không????", "Thong Bao",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //dgv load lên form
        private void dgvThongTinNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            BUS_NhanVien.Instance.LoadDgvLenForm(txtMaNV, txtTenNV, rdNam, rdNu, dtpNgaySinh, txtSĐT, txtDiaChi, txtLuong, cbMaCH, txtChucVu, dgvThongTinNhanVien);

        }

        private void rdMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaNV.Checked)
            {
                // Thiết lập các trường không thể chỉnh sửa
                txtTenNV.Enabled = false;
                rdNam.Enabled = false;
                rdNu.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                dtpNgaySinh.Enabled = false;
                txtSĐT.Enabled = false;
                txtDiaChi.Enabled = false;
                txtLuong.Enabled = false;
                cbMaCH.Enabled = false;
                txtChucVu.Enabled = false;

                // Đảm bảo chỉ một trong hai radio button được chọn
                if (rdNam.Checked)
                    rdNu.Checked = false;

                txtMaNV.Focus();
            }
            else if (rdSĐT.Checked) // Nếu radio button cho số điện thoại được chọn
            {
                // Xóa nội dung txtMaNV
                txtMaNV.Text = string.Empty;

                // Thiết lập các trường có thể chỉnh sửa
                txtTenNV.Enabled = true;
                rdNam.Enabled = true;
                rdNu.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                dtpNgaySinh.Enabled = true;
                txtSĐT.Enabled = true;
                txtDiaChi.Enabled = true;
                txtLuong.Enabled = true;
                cbMaCH.Enabled = true;
                txtChucVu.Enabled = true;

                txtTenNV.Focus(); // Đặt con trỏ vào txtTenNV
            }
            else if (rdSĐT.Checked) // Nếu radio button cho tên nhân viên được chọn
            {
                // Mở khóa các trường nhập liệu
                txtMaNV.Enabled = true; // Nếu bạn cần mở khóa mã nhân viên để chỉnh sửa
                txtTenNV.Enabled = true;
                rdNam.Enabled = true;
                rdNu.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                dtpNgaySinh.Enabled = true;
                txtSĐT.Enabled = true;
                txtDiaChi.Enabled = true;
                txtLuong.Enabled = true;
                cbMaCH.Enabled = true;
                txtChucVu.Enabled = true;

                // Đặt con trỏ vào txtTenNV hoặc trường khác bạn muốn
                txtTenNV.Focus();
            }
        }


        private void rdTenNV_CheckedChanged(object sender, EventArgs e)
        {
            // Thiết lập trạng thái ban đầu cho tất cả các trường
            bool isReadOnly = false;

            if (rdSĐT.Checked)
            {
                // Khi chọn tìm kiếm theo số điện thoại
                isReadOnly = true; // Thiết lập chế độ chỉ đọc

                txtSĐT.Focus(); // Đặt con trỏ vào txtSĐT
            }
            else if (rdMaNV.Checked)
            {
                // Khi chọn tìm kiếm theo mã nhân viên
                txtSĐT.Text = string.Empty; // Xóa nội dung txtSĐT
                txtMaNV.Focus(); // Đặt con trỏ vào txtMaNV
            }
            else if (rdSĐT.Checked)
            {
                // Khi chọn tìm kiếm theo tên nhân viên
                txtSĐT.Text = string.Empty; // Xóa nội dung txtSĐT
                txtMaNV.Text = string.Empty; // Xóa nội dung txtMaNV
                txtTenNV.Focus(); // Đặt con trỏ vào txtTenNV
            }

            // Thiết lập các trường dựa trên chế độ chỉ đọc
            txtMaNV.Enabled = !isReadOnly;
            txtTenNV.Enabled = !isReadOnly;
            rdNam.Enabled = !isReadOnly;
            rdNu.Enabled = !isReadOnly;
            btnThem.Enabled = !isReadOnly;
            btnSua.Enabled = !isReadOnly;
            btnXoa.Enabled = !isReadOnly;
            dtpNgaySinh.Enabled = !isReadOnly;
            txtDiaChi.Enabled = !isReadOnly;
            txtLuong.Enabled = !isReadOnly;
            cbMaCH.Enabled = !isReadOnly;
            txtChucVu.Enabled = !isReadOnly;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các ô nhập liệu
            txtMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            txtSĐT.Text = string.Empty;
            txtLuong.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtChucVu.Text = string.Empty;

            // Đặt lại các lựa chọn cho ComboBox
            cbMaCH.SelectedIndex = -1; // Không chọn mục nào

            // Bỏ chọn các radio button
            rdNam.Checked = false;
            rdNu.Checked = false;
            rdMaNV.Checked = false;
            rdSĐT.Checked = false;

            // Đặt lại ngày sinh
            dtpNgaySinh.Value = DateTime.Now; // Hoặc đặt thành giá trị mặc định khác

            // Mở khóa tất cả các trường nhập liệu
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            txtSĐT.Enabled = true;
            txtLuong.Enabled = true;
            txtDiaChi.Enabled = true;
            txtChucVu.Enabled = true;
            cbMaCH.Enabled = true;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            dtpNgaySinh.Enabled = true;

            // Tải lại danh sách nhân viên
            LoadNhanVien();

            // Đặt con trỏ vào ô mã nhân viên hoặc ô khác bạn muốn
            txtMaNV.Focus();
        }

		private void btnSua_Click(object sender, EventArgs e)
		{
			btnThem.Enabled = false;
			try
			{
				// Lấy giá trị từ các trường
				string maNV = txtMaNV.Text;
				string tenNV = txtTenNV.Text;
				string ngaySinh = dtpNgaySinh.Text;
				string sDT = txtSĐT.Text;
				string diaChi = txtDiaChi.Text;
				string luong = txtLuong.Text;
				string maCH = cbMaCH.SelectedValue?.ToString() ?? "";
				string chucvu = txtChucVu.Text;
				string maVaDiaChi = cbMaCH.SelectedItem.ToString();
				// Kiểm tra các trường không được bỏ trống
				if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(tenNV) ||
					(!rdNam.Checked && !rdNu.Checked) || string.IsNullOrWhiteSpace(diaChi) ||
					string.IsNullOrWhiteSpace(sDT) || string.IsNullOrWhiteSpace(luong) || string.IsNullOrWhiteSpace(chucvu))
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin các trường MaNV, TenNV, Giới Tính, SĐT, Lương, Địa Chỉ, Chức vụ");
					return; // Dừng lại nếu có trường bị bỏ trống
				}

				// Kiểm tra khoảng trắng đầu và cuối trong MaNV
				if (maNV != maNV.Trim())
				{
					MessageBox.Show("Mã nhân viên không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong TenNV
				if (tenNV != tenNV.Trim())
				{
					MessageBox.Show("Tên nhân viên không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong SDT
				if (sDT != sDT.Trim())
				{
					MessageBox.Show("Số điện thoại không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong DiaChi
				if (diaChi != diaChi.Trim())
				{
					MessageBox.Show("Địa chỉ không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong Luong
				if (luong != luong.Trim())
				{
					MessageBox.Show("Lương không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối trong Chuc Vu
				if (chucvu != chucvu.Trim())
				{
					MessageBox.Show("Chức Vụ không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong MaNV
				if (Regex.IsMatch(maNV, @"\s{2,}"))
				{
					MessageBox.Show("Mã nhân viên không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong TenNV
				if (Regex.IsMatch(tenNV, @"\s{2,}"))
				{
					MessageBox.Show("Tên nhân viên không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong SDT
				if (Regex.IsMatch(sDT, @"\s{2,}"))
				{
					MessageBox.Show("Số điện thoại không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong DiaChi
				if (Regex.IsMatch(diaChi, @"\s{2,}"))
				{
					MessageBox.Show("Địa chỉ không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong Luong
				if (Regex.IsMatch(luong, @"\s{2,}"))
				{
					MessageBox.Show("Lương không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp trong ChucVu
				if (Regex.IsMatch(chucvu, @"\s{2,}"))
				{
					MessageBox.Show("Chức Vụ không được có hai khoảng trắng liên tiếp.");
					return;
				}

				if (!decimal.TryParse(luong, out decimal luongDecimal) || luongDecimal < 0)
				{
					MessageBox.Show("Lương phải là số hợp lệ và không được âm");
					return;
				}

				if (!long.TryParse(sDT, out long soDienThoai) || soDienThoai < 10)
				{
					MessageBox.Show("Số điện thoại phải là số hợp lệ và phải đủ 10 số");
					return;
				}

				//Sđt phải đúng 10 chữ số 
				if (sDT.Length != 10)
				{
					MessageBox.Show("Số điện thoại phải có đúng 10 chữ số.");
					return;
				}

				// Kiểm tra tên nhân viên không chứa ký tự đặc biệt
				if (!Regex.IsMatch(tenNV, @"^[a-zA-ZÀ-ỹ\s]+$"))
				{
					MessageBox.Show("Tên nhân viên không được chứa ký tự đặc biệt.");
					return;
				}

				// Kiểm tra giới tính
				string gioitinh = rdNam.Checked ? "Nam" : "Nữ";

				// Tạo đối tượng nhân viên
				NhanVien nhanVien = new NhanVien
				{
					MaNV = maNV,
					TenNV = tenNV,
					GioiTinh = gioitinh,
					NgaySinh = Convert.ToDateTime(ngaySinh),
					SDT = sDT,
					DiaChi = diaChi,
					Luong = int.Parse(luong),
					MaCH = maCH,
					ChucVu = chucvu
				};

				// Thêm nhân viên vào cơ sở dữ liệu
				BUS_NhanVien.Instance.SuaNV(txtMaNV, txtTenNV, rdNam, rdNu, dtpNgaySinh, txtSĐT, txtDiaChi, txtLuong, cbMaCH, txtChucVu, maVaDiaChi);

				// Tải lại dữ liệu sau khi thêm
				LoadNhanVien();
				// Clear fields
				txtMaNV.Text = string.Empty;
				cbMaCH.SelectedIndex = -1; // Reset selection
				rdNam.Checked = false;
				rdNu.Checked = false;
				txtTenNV.Text = string.Empty;
				txtSĐT.Text = string.Empty;
				txtDiaChi.Text = string.Empty;
				txtLuong.Text = string.Empty;
				txtChucVu.Text = string.Empty;
				dtpNgaySinh.Value = DateTime.Now; // Set to current date or desired default date

				txtMaNV.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Sửa không thành công: {ex.Message}");
			}
			finally
			{
				btnThem.Enabled = true;
			}

		}
	}
}
