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
            BUS_Kho.Instance.LoadCuaHang(cbMaCH);
        }

        //Hiển Thị dữ liệu
        public void LoadNhanVien()
        {
            BUS_NhanVien.Instance.LoadNV(dgvThongTinNhanVien);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {

        }

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

                // Kiểm tra các trường không được bỏ trống
                if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(tenNV) ||
                    (!rdNam.Checked && !rdNu.Checked) || string.IsNullOrWhiteSpace(diaChi) ||
                    string.IsNullOrWhiteSpace(sDT) || string.IsNullOrWhiteSpace(luong))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin các trường MaNV, TenNV, Giới Tính, SĐT, Lương, Địa Chỉ.");
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

                if (!decimal.TryParse(luong, out decimal luongDecimal))
                {
                    MessageBox.Show("Lương phải là số hợp lệ.");
                    return;
                }

                if (!long.TryParse(sDT, out long soDienThoai))
                {
                    MessageBox.Show("Số điện thoại phải là số hợp lệ.");
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
                    MaCH = maCH
                };

                // Thêm nhân viên vào cơ sở dữ liệu
                BUS_NhanVien.Instance.ThemNhanVien(txtMaNV, txtTenNV, rdNam, rdNu, dtpNgaySinh, txtSĐT, txtDiaChi, txtLuong, cbMaCH);

                // Tải lại dữ liệu sau khi thêm
                LoadNhanVien();

                // Xóa các trường
                txtMaNV.Text = string.Empty;
                cbMaCH.SelectedIndex = -1; // Đặt lại lựa chọn
                rdNam.Checked = false;
                rdNu.Checked = false;
                txtTenNV.Text = string.Empty;
                txtSĐT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtLuong.Text = string.Empty;

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

                // Kiểm tra các trường không được bỏ trống
                if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(tenNV) ||
                    (!rdNam.Checked && !rdNu.Checked) || string.IsNullOrWhiteSpace(diaChi) ||
                    string.IsNullOrWhiteSpace(sDT) || string.IsNullOrWhiteSpace(luong))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin các trường MaNV, TenNV, Giới Tính, SĐT, Lương, Địa Chỉ.");
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

                if (!decimal.TryParse(luong, out decimal luongDecimal))
                {
                    MessageBox.Show("Lương phải là số hợp lệ.");
                    return;
                }

                if (!long.TryParse(sDT, out long soDienThoai))
                {
                    MessageBox.Show("Số điện thoại phải là số hợp lệ.");
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
                    MaCH = maCH
                };

                // Thêm nhân viên vào cơ sở dữ liệu
                BUS_NhanVien.Instance.SuaNV(txtMaNV, txtTenNV, rdNam, rdNu, dtpNgaySinh, txtSĐT, txtDiaChi, txtLuong, cbMaCH);

                // Tải lại dữ liệu sau khi thêm
                LoadNhanVien();

                // Xóa các trường
                txtMaNV.Text = string.Empty;
                cbMaCH.SelectedIndex = -1; // Đặt lại lựa chọn
                rdNam.Checked = false;
                rdNu.Checked = false;
                txtTenNV.Text = string.Empty;
                txtSĐT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtLuong.Text = string.Empty;

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không???", "Thông Báo",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                BUS_NhanVien.Instance.XoaNV(txtMaNV);
               
                txtMaNV.Text = string.Empty;
                cbMaCH.SelectedIndex = -1; // Đặt lại lựa chọn
                rdNam.Checked = false;
                rdNu.Checked = false;
                txtTenNV.Text = string.Empty;
                txtSĐT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtLuong.Text = string.Empty;

                txtMaNV.Focus();
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Không thể xóa!!!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Reset chế độ chỉ đọc trước khi kiểm tra
            txtTenNV.ReadOnly = false;
            txtMaNV.ReadOnly = false;

            // Kiểm tra điều kiện tìm kiếm
            if (txtMaNV.Text.Length > 0)
            {
                // Kiểm tra xem có nhân viên với mã này không
                if (!DAO_NhanVien.Instance.KiemTraMaNV(txtMaNV.Text))
                {
                    MessageBox.Show("Không có mã nhân viên này. Vui lòng nhập tên nhân viên để tìm kiếm.");
                    txtMaNV.Text = string.Empty;
                    txtTenNV.Focus(); // Đặt con trỏ vào trường Tên nhân viên
                    return;
                }

                // Nếu có mã nhân viên, tìm kiếm theo mã nhân viên
                BUS_NhanVien.Instance.TimKiemNVTheoMaNV(txtMaNV, dgvThongTinNhanVien); 
                txtTenNV.ReadOnly = false; // Mở khóa trường Tên nhân viên
                txtMaNV.ReadOnly = false;   // Khóa trường Mã nhân viên
            }
            else if (txtTenNV.Text.Length > 0)
            {
                // Kiểm tra xem có nhân viên với tên này không
                if (!DAO_NhanVien.Instance.KiemTraTenNV(txtTenNV.Text))
                {
                    MessageBox.Show("Không có tên nhân viên này. Vui lòng nhập mã nhân viên để tìm kiếm.");
                    txtMaNV.Focus(); // Đặt con trỏ vào trường Mã nhân viên
                    return;
                }

                // Nếu có tên nhân viên, tìm kiếm theo tên nhân viên
                BUS_NhanVien.Instance.TimKiemNVTheoTenNV(txtTenNV, dgvThongTinNhanVien);
                txtTenNV.Text = string.Empty;
                txtMaNV.ReadOnly = false; // Mở khóa trường Mã nhân viên
                txtTenNV.ReadOnly = false; // Khóa trường Tên nhân viên
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã nhân viên hoặc Tên nhân viên để tìm kiếm.");
            }

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

        private void dgvThongTinNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_NhanVien.Instance.LoadDgvLenForm(txtMaNV, txtTenNV, rdNam, rdNu, dtpNgaySinh, txtSĐT, txtDiaChi, txtLuong, cbMaCH, dgvThongTinNhanVien);
        }
    }
}
