using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;

namespace ChuyenDe
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            View();
            Check();
        }

        public void View()
        {
            BUSKhachHang.Instance.View(dgvDanhSachKH);
        }
        private void dgvDanhSachKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUSKhachHang.Instance.Load(txtMaKH, txtTenKH, radNam, radNu, txtSDT, txtDiaChi, dgvDanhSachKH);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                (!radNam.Checked && !radNu.Checked) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Viết hoa khi thêm
                txtMaKH.Text = txtMaKH.Text.ToUpper();
                txtTenKH.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtTenKH.Text.ToLower());
                txtDiaChi.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDiaChi.Text.ToLower());
                if (txtSDT.Text.Length != 10 || !txtSDT.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 số và chỉ chứa chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BUSKhachHang.Instance.Them(txtMaKH, txtTenKH, radNam, radNu, txtSDT, txtDiaChi);
                txtMaKH.Text = string.Empty;
                txtTenKH.Text = string.Empty;
                radNam.Checked = false;
                radNu.Checked = false;
                txtSDT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtMaKH.Focus();
                View();
            }
            catch (Exception)
            {
                MessageBox.Show("Không được trùng mã!!!");
            }
        }
        private void CheckInput(TextBox textBox)
        {
            // Reset ErrorProvider cho TextBox hiện tại
            errorProvider1.SetError(textBox, string.Empty);

            // Lấy giá trị từ TextBox
            string input = textBox.Text;

            // Kiểm tra khoảng trắng đầu/cuối
            if (input != input.Trim())
            {
                errorProvider1.SetError(textBox, "Không được chứa khoảng trắng đầu/cuối.");
                return;
            }

            // Kiểm tra hai khoảng trắng liên tiếp
            if (input.Contains("  "))
            {
                errorProvider1.SetError(textBox, "Không được có hai khoảng trắng liên tiếp.");
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra điều kiện nhập liệu
                if (!string.IsNullOrWhiteSpace(txtMaKH.Text) &&
                    !string.IsNullOrWhiteSpace(txtTenKH.Text) &&
                    (radNam.Checked || radNu.Checked) &&
                    !string.IsNullOrWhiteSpace(txtSDT.Text) &&
                    !string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    // Kiểm tra số điện thoại
                    if (txtSDT.Text.Length != 10 || !txtSDT.Text.All(char.IsDigit))
                    {
                        MessageBox.Show("Số điện thoại phải đủ 10 số và chỉ chứa chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo đối tượng khách hàng và gán giá trị
                    KhachHang khachHang = new KhachHang
                    {
                        MaKH = txtMaKH.Text.ToUpper(), // Chuyển mã khách hàng thành chữ hoa
                        TenKH = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtTenKH.Text.ToLower()), // Viết hoa chữ cái đầu
                        GioiTinh = radNam.Checked ? "Nam" : "Nữ",
                        DiaChi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDiaChi.Text.ToLower()), // Viết hoa chữ cái đầu địa chỉ
                        SDT = txtSDT.Text
                    };

                    // Gọi phương thức sửa thông tin khách hàng
                    if (BUSKhachHang.Instance.Sua(khachHang))
                    {
                        MessageBox.Show("Bạn đã sửa thành công!");
                        // Xóa các TextBox và lấy lại focus
                        txtMaKH.Text = string.Empty;
                        txtTenKH.Text = string.Empty;
                        radNam.Checked = false;
                        radNu.Checked = false;
                        txtSDT.Text = string.Empty;
                        txtDiaChi.Text = string.Empty;
                        txtMaKH.Focus();
                        View();
                    }
                    else
                    {
                        MessageBox.Show("Sửa khách hàng không thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không được sửa mã");             
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "" && txtTenKH.Text != "" && (radNam.Checked == true || radNu.Checked == true) && txtSDT.Text != "" && txtDiaChi.Text != "")
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    BUSKhachHang.Instance.Xoa(txtMaKH);
                    MessageBox.Show("Bạn đã xóa thành công!");
                    txtMaKH.Text = string.Empty;
                    txtTenKH.Text = string.Empty;
                    if (radNam.Checked == true)
                        radNam.Checked = false;
                    else radNu.Checked = false;
                    txtSDT.Text = string.Empty;
                    txtDiaChi.Text = string.Empty;
                    txtMaKH.Focus();
                    View();
                }
                else MessageBox.Show("Xóa không thành công!");
            }
            else MessageBox.Show("Vui lòng chọn dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMaKH.Text) || !string.IsNullOrWhiteSpace(txtTenKH.Text) || !string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                txtMaKH.Text = txtMaKH.Text.ToUpper();
                txtTenKH.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtTenKH.Text.ToLower());
                txtSDT.Text = txtSDT.Text.Replace(" ","");
                if (!string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoMa(txtMaKH, dgvDanhSachKH);
                }
                if (!string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoTen(txtTenKH, dgvDanhSachKH);
                }
                if (!string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoSDT(txtSDT, dgvDanhSachKH);
                }
            }
            else MessageBox.Show("Vui lòng nhập dữ liệu cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void Check()
        {
            btnTimKiem.Enabled = radMa.Checked || radTen.Checked || radSDT.Checked;
        }
        private void radMa_CheckedChanged(object sender, EventArgs e)
        {
            if (radMa.Checked)
            {
                txtTenKH.Enabled = false;
                txtSDT.Enabled = false;
                txtDiaChi.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = true;
                txtTenKH.Text = string.Empty;
                txtMaKH.Text = string.Empty;
                if (radNam.Checked == true)
                    radNam.Checked = false;
                else radNu.Checked = false;
                txtSDT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtMaKH.Focus();
            }
            else
            {
                txtTenKH.Enabled = true;
                txtSDT.Enabled = true;
                txtDiaChi.Enabled = true;
                radNam.Enabled = true;
                radNu.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTimKiem.Enabled = false;
            }
        }

        private void radTen_CheckedChanged(object sender, EventArgs e)
        {
            if (radTen.Checked)
            {
                txtMaKH.Enabled = false;
                txtSDT.Enabled = false;
                txtDiaChi.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = true;
                txtSDT.Text = string.Empty;
                txtTenKH.Text = string.Empty;
                if (radNam.Checked == true)
                    radNam.Checked = false;
                else radNu.Checked = false;
                txtMaKH.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtTenKH.Focus();
            }
            else
            {
                txtMaKH.Enabled = true;
                txtSDT.Enabled = true;
                txtDiaChi.Enabled = true;
                radNam.Enabled = true;
                radNu.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTimKiem.Enabled = false;
            }
        }

        private void radSDT_CheckedChanged(object sender, EventArgs e)
        {
            if (radSDT.Checked)
            {
                txtTenKH.Enabled = false;
                txtMaKH.Enabled = false;
                txtDiaChi.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = true;
                txtTenKH.Text = string.Empty;
                txtSDT.Text = string.Empty;
                if (radNam.Checked == true)
                    radNam.Checked = false;
                else radNu.Checked = false;
                txtMaKH.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtSDT.Focus();
            }
            else
            {
                txtTenKH.Enabled = true;
                txtMaKH.Enabled = true;
                txtDiaChi.Enabled = true;
                radNam.Enabled = true;
                radNu.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTimKiem.Enabled = false;
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtMaKH);
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtSDT);
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtTenKH);
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtDiaChi);
        }
    }
}
