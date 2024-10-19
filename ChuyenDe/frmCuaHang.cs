using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ChuyenDe
{
    public partial class frmCuaHang : Form
    {
        public frmCuaHang()
        {
            InitializeComponent();
            LoadForm();
        }

        public void LoadForm()
        {
            BUS_CuaHang.Instance.Xem(dgvCuaHang);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các trường
                string maCH = txtCH.Text;
                string diaChi = txtDC.Text;

                // Kiểm tra các trường không được bỏ trống
                if (string.IsNullOrWhiteSpace(maCH) || string.IsNullOrWhiteSpace(diaChi))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cho cả hai trường MaCH và DiaChi.");
                    return; // Dừng lại nếu có trường bị bỏ trống
                }

                // Kiểm tra khoảng trắng đầu và cuối
                if (maCH != maCH.Trim() || diaChi != diaChi.Trim())
                {
                    MessageBox.Show("Không được có khoảng trắng ở đầu hoặc cuối.");
                    return; // Dừng lại nếu có khoảng trắng đầu hoặc cuối
                }

                // Kiểm tra khoảng trắng liên tiếp trong chuỗi
                if (Regex.IsMatch(maCH, @"\s{2,}") || Regex.IsMatch(diaChi, @"\s{2,}"))
                {
                    MessageBox.Show("Không được có hai khoảng trắng liên tiếp.");
                    return; // Dừng lại nếu có hai khoảng trắng liên tiếp
                }

                // Nếu tất cả điều kiện đều thỏa mãn, tiến hành thêm thông tin vào cơ sở dữ liệu
                CuaHang ch = new CuaHang
                {
                    MaCH = maCH,
                    DiaChi = diaChi,
                };

                BUS_CuaHang.Instance.Them(ch);
                MessageBox.Show("Thêm thành công!!!");

                // Tải lại dữ liệu sau khi thêm
                LoadForm();
                txtCH.Text = string.Empty;
                txtDC.Text = string.Empty;
                txtCH.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công!!!");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Ban co muon xoa ko???", "Thong Bao",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                BUS_CuaHang.Instance.Xoa(txtCH);
                LoadForm();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            // Lấy giá trị từ các trường
            string maCH = txtCH.Text;
            string diaChi = txtDC.Text;

            // Kiểm tra các trường không được bỏ trống
            if (string.IsNullOrWhiteSpace(maCH) || string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cho cả hai trường MaCH và DiaChi.");
                return; // Dừng lại nếu có trường bị bỏ trống
            }

            // Kiểm tra khoảng trắng đầu và cuối
            if (maCH != maCH.Trim() || diaChi != diaChi.Trim())
            {
                MessageBox.Show("Không được có khoảng trắng ở đầu hoặc cuối.");
                return; // Dừng lại nếu có khoảng trắng đầu hoặc cuối
            }

            // Kiểm tra khoảng trắng liên tiếp trong chuỗi
            if (Regex.IsMatch(maCH, @"\s{2,}") || Regex.IsMatch(diaChi, @"\s{2,}"))
            {
                MessageBox.Show("Không được có hai khoảng trắng liên tiếp.");
                return; // Dừng lại nếu có hai khoảng trắng liên tiếp
            }

            CuaHang ch = new CuaHang
            {
                MaCH = txtCH.Text,
                DiaChi = txtDC.Text,
            };

            BUS_CuaHang bus = new BUS_CuaHang();
            bool result = bus.Sua(txtCH.Text, ch);

            if (result)
            {

                MessageBox.Show("Sửa thông tin thành công!");
                LoadForm();
                txtCH.Text = string.Empty;
                txtDC.Text = string.Empty;
                txtCH.Focus();
            }
            else
            {
                MessageBox.Show("Không thể sửa MÃ hoặc có lỗi xảy ra khi sửa thông tin!");
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

        private void dgvCuaHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvCuaHang.Rows[dgvCuaHang.CurrentCell.RowIndex];
            txtCH.Text = row.Cells["MaCH"].Value.ToString();
            txtDC.Text = row.Cells["DiaChi"].Value.ToString();
        }
    }
}
