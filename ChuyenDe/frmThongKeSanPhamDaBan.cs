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
            LoadMaCH();
            bus = new BUSThongKeSanPhamDaBan();
        }
        private void LoadMaCH()
        {
            BUS_ThongKeDoanhThu.Instance.LoadMaCH(txtMa);
        }
        private void dgvBanSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBanSP.Columns["GiaSP"].Visible = false;

            dgvBanSP.Columns["GiamGia"].Visible = false;
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

                // Ẩn cột GiaSP và GiamGia nếu chúng tồn tại
                if (dgvBanSP.Columns["GiaSP"] != null)
                {
                    dgvBanSP.Columns["GiaSP"].Visible = false;
                }
                if (dgvBanSP.Columns["GiamGia"] != null)
                {
                    dgvBanSP.Columns["GiamGia"].Visible = false;
                }
            }
            else
            {
                // Thông báo không có dữ liệu
                MessageBox.Show("Không có dữ liệu thống kê cho mã cửa hàng này trong khoảng thời gian đã chọn.");
                dgvBanSP.DataSource = null; // Xóa dữ liệu trong DataGridView nếu không có kết quả
            }
        }

     
       
        private void Reset()
        {
            txtMa.SelectedIndex = -1;
            dtpTuNgay.Text = DateTime.Now.ToString();
            dtpToiNgay.Text = DateTime.Now.ToString();
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            DateTime tu = dtpTuNgay.Value;
            DateTime toi = dtpToiNgay.Value;

            frmReportSPDaBan reportForm = new frmReportSPDaBan(ma, tu, toi);
            reportForm.Show();
        }

        private void frmThongKeSanPhamDaBan_Load(object sender, EventArgs e)
        {
            LoadMaCH();
            txtMa.SelectedIndex = -1;
        }
    }
}
