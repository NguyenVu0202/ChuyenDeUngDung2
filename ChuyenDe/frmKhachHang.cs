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
                // Kiểm tra điều kiện nhập liệu
                if (!CheckInput(txtMaKH) || !CheckInput(txtTenKH) || !CheckInput(txtSDT) || !CheckInput(txtDiaChi) ||
                    (!radNam.Checked && !radNu.Checked))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Viết hoa khi thêm
                txtMaKH.Text = txtMaKH.Text.ToUpper();
                txtTenKH.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtTenKH.Text.ToLower());
                txtDiaChi.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDiaChi.Text.ToLower());

                // Kiểm tra số điện thoại
                if (txtSDT.Text.Length != 10 || !txtSDT.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 số và chỉ chứa chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi phương thức thêm khách hàng
                BUSKhachHang.Instance.Them(txtMaKH, txtTenKH, radNam, radNu, txtSDT, txtDiaChi);

                // Xóa các TextBox và lấy lại focus
                ResetForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Không được trùng mã!!!");
            }
        }
        private bool CheckInput(TextBox textBox)
        {
            // Reset ErrorProvider cho TextBox hiện tại
            errorProvider1.SetError(textBox, string.Empty);

            // Lấy giá trị từ TextBox
            string input = textBox.Text;

            // Kiểm tra khoảng trắng đầu/cuối
            if (input != input.Trim())
            {
                errorProvider1.SetError(textBox, "Không được chứa khoảng trắng đầu/cuối.");
                return false; // Trả về false nếu không hợp lệ
            }

            // Kiểm tra hai khoảng trắng liên tiếp
            if (input.Contains("  "))
            {
                errorProvider1.SetError(textBox, "Không được có hai khoảng trắng liên tiếp.");
                return false; // Trả về false nếu không hợp lệ
            }

            // Kiểm tra ký tự đặc biệt
            string chars = @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\,']";
            if (Regex.IsMatch(input, chars))
            {
                errorProvider1.SetError(textBox, "Đầu vào không được chứa ký tự đặc biệt!");
                return false; // Trả về false nếu không hợp lệ
            }

            return true; // Trả về true nếu tất cả các kiểm tra đều hợp lệ
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra điều kiện nhập liệu
                if (!CheckInput(txtMaKH) || !CheckInput(txtTenKH) || !CheckInput(txtSDT) || !CheckInput(txtDiaChi) ||
                    (!radNam.Checked && !radNu.Checked))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                    MessageBox.Show("Bạn đã sửa khách hàng thành công!");
                    // Xóa các TextBox và lấy lại focus
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Sửa khách hàng không thành công!");
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
                    ResetForm();
                }
                else MessageBox.Show("Xóa không thành công!");
            }
            else MessageBox.Show("Vui lòng chọn dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                txtSDT.Text = txtSDT.Text.Replace(" ", "");
                if (!string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoMa(txtMaKH, dgvDanhSachKH);
                    txtMaKH.Text = string.Empty;
                    listBox1.Visible = false;
                }
                if (!string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoSDT(txtSDT, dgvDanhSachKH);
                    txtSDT.Text = string.Empty;
                    listBox2.Visible = false;
                }
            }
            else MessageBox.Show("Vui lòng nhập dữ liệu cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void Check()
        {
            btnTimKiem.Enabled = radMa.Checked || radSDT.Checked;
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
                listBox2.Visible = false;
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
                listBox1.Visible = false;
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
            // Kiểm tra ký tự đặc biệt
            if (Regex.IsMatch(txtMaKH.Text, @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\]"))
            {
                errorProvider1.SetError(txtMaKH, "Đầu vào không được chứa ký tự đặc biệt!");
            }
            if (radMa.Checked == true)
            {
                string searchTerm = txtMaKH.Text.Trim();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var suggestions = BUSKhachHang.Instance.TimKhachHangMa(searchTerm);
                    listBox1.Items.Clear();
                    foreach (var kh in suggestions)
                    {
                        listBox1.Items.Add(kh.MaKH + " - " + kh.TenKH);
                    }
                    listBox1.Visible = listBox1.Items.Count > 0;
                }
                else
                {
                    listBox1.Visible = false;
                }
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtSDT);
            if (radSDT.Checked == true)
            {
                string searchTerm = txtSDT.Text.Trim();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var suggestions = BUSKhachHang.Instance.TimKhachHangSDT(searchTerm);
                    listBox2.Items.Clear();
                    foreach (var kh in suggestions)
                    {
                        listBox2.Items.Add(kh.SDT + " - " + kh.TenKH);
                    }
                    listBox2.Visible = listBox2.Items.Count > 0;
                }
                else
                {
                    listBox2.Visible = false;
                }
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra ký tự đặc biệt
            if (Regex.IsMatch(txtTenKH.Text, @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\]"))
            {
                errorProvider1.SetError(txtTenKH, "Đầu vào không được chứa ký tự đặc biệt!");
            }
            CheckInput(txtTenKH);
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtDiaChi);
            // Kiểm tra ký tự đặc biệt
            if (Regex.IsMatch(txtDiaChi.Text, @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\]"))
            {
                errorProvider1.SetError(txtDiaChi, "Đầu vào không được chứa ký tự đặc biệt!");
            }
        }

        private void ResetForm()
        {
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            radNam.Checked = false;
            radNu.Checked = false;
            radSDT.Checked = false;
            radMa.Checked = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            dgvDanhSachKH.DataSource = null;
            View();
        }
       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string maKH = selectedItem.Split('-')[0].Trim();

                var kh = BUSKhachHang.Instance.TimKhachHangMa(maKH).FirstOrDefault();
                if (kh != null)
                {
                    txtMaKH.Text = kh.MaKH;
                }

                listBox1.Visible = false;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                string maKH = selectedItem.Split('-')[0].Trim();

                var kh = BUSKhachHang.Instance.TimKhachHangSDT(maKH).FirstOrDefault();
                if (kh != null)
                {
                    txtSDT.Text = kh.SDT;
                }

                listBox2.Visible = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
