using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;

namespace ChuyenDe
{
    public partial class frmTimKiemSanPham : Form
    {
        public frmTimKiemSanPham()
        {
            InitializeComponent();
            dgvTimKiemSP.DataError += dgvTimKiemSP_DataError;
            dgvTimKiemSP.CellPainting += dgvTimKiemSP_CellPainting;
            dgvTimKiemSP.RowTemplate.Height = 100;
        }

        private void Reset()
        {
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            listBox1.Visible = false;
            listBox2.Visible = false;
            dgvTimKiemSP.DataSource = null;
        }



        private void dgvTimKiemSP_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvTimKiemSP.Columns["HinhAnh"].Index && e.RowIndex >= 0)
            {
                e.Handled = true; // Ngăn chặn việc vẽ mặc định

                // Lấy hình ảnh từ ô
                Image img = e.Value as Image;

                if (img != null)
                {
                    // Đặt kích thước cho hình ảnh
                    int width = 200; // Chiều rộng
                    int height = 100; // Chiều cao

                    // Vẽ hình ảnh vào ô
                    e.Graphics.DrawImage(img, e.CellBounds.X, e.CellBounds.Y, width, height);
                }

                // Vẽ viền cho ô
                e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string maSP = selectedItem.Split('-')[0].Trim();

                var sp = BUSTimSanPham.Instance.TimKiemSanPhamByMa(maSP).FirstOrDefault();
                if (sp != null)
                {
                    txtMaSP.Text = sp.MaSP;
                }

                listBox1.Visible = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim(); // Lấy mã sản phẩm từ TextBox
            string tenSP = txtTenSP.Text.Trim(); // Lấy tên sản phẩm từ TextBox

            // Kiểm tra ít nhất một trong hai trường không rỗng
            if (!string.IsNullOrWhiteSpace(maSP) || !string.IsNullOrWhiteSpace(tenSP))
            {
                var results = DAOTimSanPham.Instance.TimSanPham(maSP, tenSP); // Gọi phương thức tìm kiếm theo mã và tên sản phẩm

                // Kiểm tra xem có sản phẩm nào được tìm thấy không
                if (results.Count == 0)
                {
                    // Thông báo không tìm thấy sản phẩm
                    MessageBox.Show("Không tìm thấy sản phẩm nào. Vui lòng thử lại với mã hoặc tên khác.", "Thông báo");
                    txtMaSP.Text = string.Empty;
                    listBox1.Visible = false;
                }
                else
                {
                    // Tạo danh sách sản phẩm với hình ảnh
                    var productList = results.Select(sp => new
                    {
                        sp.MaSP,
                        sp.TenSP,
                        sp.MaLoai,
                        sp.MaNCC,
                        sp.GiaBan,
                        HinhAnh = File.Exists(sp.HinhAnh) ? Image.FromFile(sp.HinhAnh) : null, // Gán hình ảnh
                        sp.GhiChu
                    }).ToList();

                    // Hiển thị kết quả trong DataGridView
                    dgvTimKiemSP.DataSource = productList;
                    listBox2.Visible = false;
                    listBox1.Visible = false;

                    // Đảm bảo cột HinhAnh là kiểu DataGridViewImageColumn
                    if (dgvTimKiemSP.Columns["HinhAnh"] is DataGridViewImageColumn)
                    {
                        dgvTimKiemSP.Columns["HinhAnh"].Width = 200; // Đặt chiều rộng cho cột hình ảnh
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm hoặc tên sản phẩm để tìm kiếm.", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                string tenSP = selectedItem.Split('-')[0].Trim();

                var sp = BUSTimSanPham.Instance.TimKiemSanPhamByTen(tenSP).FirstOrDefault();
                if (sp != null)
                {
                    txtTenSP.Text = sp.TenSP;
                }

                listBox2.Visible = false;
            }
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtMaSP.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var suggestions = BUSTimSanPham.Instance.TimKiemSanPhamByMa(searchTerm);
                listBox1.Items.Clear();
                foreach (var sp in suggestions)
                {
                    listBox1.Items.Add(sp.MaSP + " - " + sp.TenSP);
                }
                listBox1.Visible = listBox1.Items.Count > 0;
            }
            else
            {
                listBox1.Visible = false;
            }
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTenSP.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var suggestions = BUSTimSanPham.Instance.TimKiemSanPhamByTen(searchTerm);
                listBox2.Items.Clear();
                foreach (var sp in suggestions)
                {
                    listBox2.Items.Add(sp.TenSP);
                }
                listBox2.Visible = listBox2.Items.Count > 0;
            }
            else
            {
                listBox2.Visible = false;
            }
        }

        private void dgvTimKiemSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTimKiemSP.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value is Image)
            {
                e.Value = (Image)e.Value; // Đảm bảo rằng giá trị là hình ảnh
                e.FormattingApplied = true; // Đánh dấu rằng định dạng đã được áp dụng
            }
        }

        private void dgvTimKiemSP_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Data error: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false; // Prevent the exception from being thrown
        }
    }
}
