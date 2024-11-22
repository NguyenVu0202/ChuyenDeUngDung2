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
using BUS;
using DAO;

namespace ChuyenDe
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            BUSNhaCungCap.Instance.View(dgvHang);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra khoảng trắng và ký tự đặc biệt trước khi thêm
            if (!CheckInput(txtMaHang) || !CheckInput(txtTenHang))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Viết hoa chữ cái đầu tiên khi thêm
            txtMaHang.Text = txtMaHang.Text.ToUpper();
            txtTenHang.Text = char.ToUpper(txtTenHang.Text[0]) + txtTenHang.Text.Substring(1).ToLower();

            // Thêm nhà cung cấp
            BUSNhaCungCap.Instance.Them(txtMaHang, txtTenHang); // Chuyển giá trị thành chuỗi
            txtMaHang.Text = string.Empty;
            txtTenHang.Text = string.Empty;
            txtMaHang.Focus();
            Load();
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
            string specialCharactersPattern = @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\,']";
            if (Regex.IsMatch(input, specialCharactersPattern))
            {
                errorProvider1.SetError(textBox, "Đầu vào không được chứa ký tự đặc biệt!");
                return false; // Trả về false nếu không hợp lệ
            }

            return true; // Trả về true nếu tất cả các kiểm tra đều hợp lệ
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text != "" && txtTenHang.Text != "")
            {
                DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    BUSNhaCungCap.Instance.Xoa(txtMaHang);
                    Load();
                    txtMaHang.Text = string.Empty;
                    txtTenHang.Text = string.Empty;
                    txtMaHang.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }
            }
            else MessageBox.Show("Vui lòng chọn dữ liệu để xóa!");
        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUSNhaCungCap.Instance.Load(txtMaHang, txtTenHang, dgvHang);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra khoảng trắng và ký tự đặc biệt trước khi sửa
            if (!CheckInput(txtMaHang) || !CheckInput(txtTenHang))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtMaHang.Text) && !string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                // Viết hoa toàn bộ mã hàng
                txtMaHang.Text = txtMaHang.Text.ToUpper();

                // Viết hoa chữ cái đầu tiên của tên hàng và chuyển các chữ cái còn lại thành chữ thường
                txtTenHang.Text = char.ToUpper(txtTenHang.Text[0]) + txtTenHang.Text.Substring(1).ToLower();

                // Gọi phương thức sửa thông tin nhà cung cấp
                BUSNhaCungCap.Instance.Sua(txtMaHang, txtTenHang); // Chuyển giá trị thành chuỗi
                Load();
                txtMaHang.Text = string.Empty;
                txtTenHang.Text = string.Empty;
                txtMaHang.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtMaHang);
            // Kiểm tra ký tự đặc biệt
            if (Regex.IsMatch(txtMaHang.Text, @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\]"))
            {
                errorProvider1.SetError(txtMaHang, "Đầu vào không được chứa ký tự đặc biệt!");
            }
        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtTenHang);
            // Kiểm tra ký tự đặc biệt
            if (Regex.IsMatch(txtTenHang.Text, @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\]"))
            {
                errorProvider1.SetError(txtTenHang, "Đầu vào không được chứa ký tự đặc biệt!");
            }
        }
    }
}
