﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace ChuyenDe
{
    public partial class frmLoai : Form
    {
        public frmLoai()
        {
            InitializeComponent();
            View();
            txtMaLoai.TextChanged += txtMaLoai_TextChanged;
            txtTenLoai.TextChanged += txtTenLoai_TextChanged;
        }
        private void View()
        {
            BUSLoai.Instance.View(dgvLoai);
        }

        private void dgvLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUSLoai.Instance.Load(txtMaLoai, txtTenLoai, dgvLoai);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào cho txtMaLoai và txtTenLoai
            if (!CheckInput(txtMaLoai) || !CheckInput(txtTenLoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Viết hoa chữ cái đầu tiên khi thêm
            txtMaLoai.Text = txtMaLoai.Text.ToUpper();
            txtTenLoai.Text = char.ToUpper(txtTenLoai.Text[0]) + txtTenLoai.Text.Substring(1).ToLower();

            // Gọi phương thức thêm loại
            BUSLoai.Instance.Them(txtMaLoai, txtTenLoai); // Chuyển giá trị thành chuỗi

            // Xóa các TextBox và lấy lại focus
            txtMaLoai.Text = string.Empty;
            txtTenLoai.Text = string.Empty;
            txtMaLoai.Focus();
            View();
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
            // Kiểm tra đầu vào cho txtMaLoai và txtTenLoai
            if (!CheckInput(txtMaLoai) || !CheckInput(txtTenLoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtMaLoai.Text) && !string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                // Viết hoa toàn bộ mã loại
                txtMaLoai.Text = txtMaLoai.Text.ToUpper();

                // Viết hoa chữ cái đầu tiên của tên loại và chuyển các chữ cái còn lại thành chữ thường
                txtTenLoai.Text = char.ToUpper(txtTenLoai.Text[0]) + txtTenLoai.Text.Substring(1).ToLower();

                // Gọi phương thức sửa thông tin loại
                BUSLoai.Instance.Sua(txtMaLoai, txtTenLoai); // Chuyển giá trị thành chuỗi

                // Cập nhật giao diện
                View();

                // Xóa các TextBox và lấy lại focus
                txtMaLoai.Text = string.Empty;
                txtTenLoai.Text = string.Empty;
                txtMaLoai.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "" && txtTenLoai.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BUSLoai.Instance.Xoa(txtMaLoai);
                    View();
                    txtMaLoai.Text = string.Empty;
                    txtTenLoai.Text = string.Empty;
                    txtMaLoai.Focus();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }
            }
            else MessageBox.Show("Vui lòng chọn dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtMaLoai_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtMaLoai);
            // Kiểm tra ký tự đặc biệt
            if (Regex.IsMatch(txtMaLoai.Text, @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\]"))
            {
                errorProvider1.SetError(txtMaLoai, "Đầu vào không được chứa ký tự đặc biệt!");
            }
        }

        private void txtTenLoai_TextChanged(object sender, EventArgs e)
        {
            CheckInput(txtTenLoai);
            // Kiểm tra ký tự đặc biệt
            if (Regex.IsMatch(txtTenLoai.Text, @"[!@#$%^&*()_\-+=;""'.>\/?|\{\}\[\]\\]"))
            {
                errorProvider1.SetError(txtTenLoai, "Đầu vào không được chứa ký tự đặc biệt!");
            }
        }
    }
}
