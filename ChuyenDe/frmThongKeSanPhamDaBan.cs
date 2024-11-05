using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using static DAO.DAOHoaDon;

namespace ChuyenDe
{
	public partial class frmThongKeSanPhamDaBan : Form
	{
        private BUSThongKeSanPhamDaBan bus;
        public frmThongKeSanPhamDaBan()
        {
            InitializeComponent();
            bus = new BUSThongKeSanPhamDaBan();
        }
      
        private void dgvBanSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnThongKeTheoSP_Click(object sender, EventArgs e)
        {
            string maCH = txtMa.Text.Trim();
            DateTime startDate = dtpTuNgay.Value;
            DateTime endDate = dtpToiNgay.Value;

            // Kiểm tra xem mã cửa hàng có hợp lệ không
            if (string.IsNullOrWhiteSpace(maCH))
            {
                MessageBox.Show("Vui lòng nhập mã cửa hàng.");
                return;
            }

            // Gọi phương thức thống kê
            var thongKeService = new BUSThongKeSanPhamDaBan(); // Giả sử bạn có một lớp dịch vụ để thực hiện thống kê
            List<ChiTietHoaDonDTO> thongKeResult = thongKeService.ThongKe(maCH, startDate, endDate);

            // Kiểm tra kết quả thống kê
            if (thongKeResult != null && thongKeResult.Count > 0)
            {
                // Hiển thị kết quả trong DataGridView
                dgvBanSP.DataSource = thongKeResult;
                listBox1.Visible = false;
            }
            else
            {
                // Thông báo không có dữ liệu
                MessageBox.Show("Không có dữ liệu thống kê cho mã cửa hàng này trong khoảng thời gian đã chọn.");
                dgvBanSP.DataSource = null; // Xóa dữ liệu trong DataGridView nếu không có kết quả
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtMa.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var suggestions = BUSThongKeSanPhamDaBan.Instance.CuaHangByMa(searchTerm);
                listBox1.Items.Clear();
                foreach (var sp in suggestions)
                {
                    listBox1.Items.Add(sp.MaCH);
                }
                listBox1.Visible = listBox1.Items.Count > 0;
            }
            else
            {
                listBox1.Visible = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string maSP = selectedItem.Split('-')[0].Trim();

                var sp = BUSThongKeSanPhamDaBan.Instance.CuaHangByMa(maSP).FirstOrDefault();
                if (sp != null)
                {
                    txtMa.Text = sp.MaCH;
                }

                listBox1.Visible = false;
            }
        }

        private void Reset()
        {
            txtMa.Text = string.Empty;
            dtpTuNgay.Text = DateTime.Now.ToString();
            dtpToiNgay.Text = DateTime.Now.ToString();
            listBox1.Visible = false;
            dgvBanSP.DataSource = null;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắ chắn muốn thoát?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
