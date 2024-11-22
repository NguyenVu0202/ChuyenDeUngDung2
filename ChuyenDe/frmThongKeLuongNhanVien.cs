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

namespace ChuyenDe
{
	public partial class frmThongKeLuongNhanVien : Form
	{
		public frmThongKeLuongNhanVien()
		{
			InitializeComponent();
		}

        private void LoadMaCH()
        {
            BUS_ThongKeLuongNhanVienTheoCH.Instance.LoadMaCH(cbMaCH);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
			// Giả sử cbMaCH là ComboBox để chọn mã cửa hàng
			string maCH = cbMaCH.SelectedValue?.ToString(); // hoặc .Text nếu muốn lấy nội dung hiển thị

			if (!string.IsNullOrEmpty(maCH))
			{
				// Lấy danh sách kết quả từ phương thức ThongKeLuongNVTheoCH
				var result = BUS_ThongKeLuongNhanVienTheoCH.Instance.ThongKeLuongNVTheoCH(maCH);

				if (result != null && result.Any())
				{
					// Gán danh sách vào DataGridView (dgvThongKe)
					dgvLuongNhanVien.DataSource = null; // Xóa dữ liệu cũ
					dgvLuongNhanVien.DataSource = result;
				}
				else
				{
					MessageBox.Show("Không có dữ liệu để hiển thị.");
					dgvLuongNhanVien.DataSource = null; // Xóa dữ liệu cũ nếu có
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một cửa hàng hợp lệ.");
			}
		}


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbMaCH.SelectedIndex = -1;
            dgvLuongNhanVien.DataSource = null;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
			frmReportLuongNhanVienTheoCH frm = new frmReportLuongNhanVienTheoCH(cbMaCH.Text);
			this.Hide();
			frm.ShowDialog();
			this.Close();
		}

        private void btnThoat_Click(object sender, EventArgs e)
        {
			DialogResult result = MessageBox.Show("Bạn có chắ chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				this.Close();
			}
		}

        private void frmThongKeLuongNhanVien_Load(object sender, EventArgs e)
        {
            // Cấu hình AutoComplete cho TextBox txtMaNV
            cbMaCH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaCH.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Tạo AutoCompleteStringCollection để chứa dữ liệu
            AutoCompleteStringCollection dataMaNV = new AutoCompleteStringCollection();
            dataMaNV.AddRange(LayDanhSachMaCH()); // Lấy danh sách mã nhân viên và thêm vào AutoComplete
            cbMaCH.AutoCompleteCustomSource = dataMaNV;
            LoadMaCH();
            cbMaCH.SelectedIndex = -1;
        }

        private string[] LayDanhSachMaCH()
        {
            // Giả sử phương thức LoadMaNV() trả về danh sách mã nhân viên từ cơ sở dữ liệu
            List<string> danhSachMaNV = DAO_ThongKeLuongNhanVienTheoCH.Instance.LoadMaCH();
            return danhSachMaNV.ToArray();
        }
    }
}
