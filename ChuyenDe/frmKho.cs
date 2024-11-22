using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuyenDe
{
    public partial class frmKho : Form
    {
       
        public frmKho()
        {
            InitializeComponent();
            LoadCbMaSP();
            LoadCbCuaHang();
            LoadKho();
        }

        //public void LoadKho()
        //{
        //    BUS_Kho.Instance.Xem(dgvKhoa);
        //}

        private void LoadKho()
        {
            BUS_Kho khoBUS = new BUS_Kho();
            dgvKhoa.DataSource = khoBUS.GetKhoWithProductName();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
			btnThem.Enabled = false; // Vô hiệu hóa nút thêm
			try
			{
				// Lấy giá trị từ các trường nhập
				string maKho = txtMaKho.Text;
				string maCH = cbMaCH.SelectedValue?.ToString() ?? "";
				string maSP = cbSP.SelectedValue?.ToString() ?? "";
				string soLuong = txtSoLuong.Text;

				// Kiểm tra rằng tất cả các trường bắt buộc đã được điền
				if (string.IsNullOrWhiteSpace(maKho) || string.IsNullOrWhiteSpace(soLuong))
				{
					ShowMessage("Vui lòng điền đầy đủ thông tin cho cả bốn trường MaKho, MaCH, MaSP và Số Lượng");
					return;
				}

				// Kiểm tra khoảng trắng đầu và cuối
				if (maKho != maKho.Trim() || soLuong != soLuong.Trim())
				{
					ShowMessage("Không được có khoảng trắng ở đầu hoặc cuối.");
					return;
				}

				// Kiểm tra khoảng trắng liên tiếp
				if (Regex.IsMatch(maKho, @"\s{2,}") || Regex.IsMatch(soLuong, @"\s{2,}"))
				{
					ShowMessage("Không được có hai khoảng trắng liên tiếp.");
					return;
				}

				// Xác thực số lượng là một số nguyên không âm
				if (!int.TryParse(soLuong, out int soLuongInt) || soLuongInt < 0)
				{
					ShowMessage("Số lượng phải là số nguyên hợp lệ và không được âm");
					return;
				}


				BUS_Kho.Instance.Them(maCH, maKho, maSP, soLuongInt);

				// Tải lại dữ liệu và đặt lại các trường nhập
				LoadKho();
				txtMaKho.Text = string.Empty;
				cbMaCH.SelectedIndex = -1;
				cbSP.SelectedIndex = -1;
				txtSoLuong.Text = "";
				txtMaKho.Focus();
			}
			catch (Exception ex)
			{
				ShowMessage("Thêm không thành công.Cửa hàng đã có kho! ");
			}
			finally
			{
				btnThem.Enabled = true; // Bật lại nút thêm
			}
		}

        // Phương thức trợ giúp để hiển thị thông báo
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Ban co muon xoa ko???", "Thong Bao",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                BUS_Kho.Instance.XoaKho(txtMaKho);
                LoadKho();
                txtMaKho.Text = string.Empty;
                cbMaCH.SelectedIndex = -1; // Đặt lại lựa chọn
                cbSP.SelectedIndex = -1;   // Đặt lại lựa chọn
                txtSoLuong.Text = "";
                txtMaKho.Focus();
            }
            else
            {
                MessageBox.Show("Lỗi");
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

        private void frmKho_Load(object sender, EventArgs e)
        {
			// Cấu hình AutoComplete cho TextBox txtMaNV
			txtMaKho.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtMaKho.AutoCompleteSource = AutoCompleteSource.CustomSource;

			//Tạo AutoCompleteStringCollection để chứa dữ liệu
			AutoCompleteStringCollection dataMaKho = new AutoCompleteStringCollection();
			dataMaKho.AddRange(LayDanhSachMaKho()); // Lấy danh sách mã nhân viên và thêm vào AutoComplete
			txtMaKho.AutoCompleteCustomSource = dataMaKho;


		}

		//Tim kiem kho
		private string[] LayDanhSachMaKho()
        {
            // Giả sử phương thức LoadMaNV() trả về danh sách mã nhân viên từ cơ sở dữ liệu
            List<string> danhSachMaNV = DAO_Kho.Instance.LoadMaKho();
            return danhSachMaNV.ToArray();
        }

        public void LoadCbMaSP()
        {
            BUS_Kho.Instance.LoadSanPham(cbSP);
        }

        public void LoadCbCuaHang()
        {
            BUS_Kho.Instance.LoadCuaHang(cbMaCH);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BUS_Kho.Instance.TimKiemMaKho(txtMaKho, dgvKhoa);
        }

        private void dgvKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_Kho.Instance.LoadDgvLenForm(txtMaKho, cbMaCH, cbSP, txtSoLuong, dgvKhoa);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa nội dung của các trường nhập liệu
            txtMaKho.Text = string.Empty;
            txtSoLuong.Text = string.Empty;

            // Đặt lại lựa chọn cho các combo box
            cbMaCH.SelectedIndex = -1; // Không chọn mục nào
            cbSP.SelectedIndex = -1;   // Không chọn mục nào

            // Tải lại danh sách kho
            LoadKho();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadKho();
        }

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			// Lấy thông tin từ giao diện người dùng
			string maCH = cbMaCH.Text;         // Mã cửa hàng
			string maSP = cbSP.SelectedValue.ToString();           // Mã sản phẩm
			string maKho = txtMaKho.Text;      // Mã kho
			decimal soLuongCapNhat;

			// Kiểm tra và chuyển đổi số lượng cập nhật sang kiểu decimal
			if (!decimal.TryParse(txtSoLuong.Text, out soLuongCapNhat))
			{
				MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return; // Dừng lại nếu nhập liệu không hợp lệ
			}

			// Khởi tạo đối tượng BUS để xử lý nghiệp vụ
			BUS_Kho khoBUS = new BUS_Kho();

			try
			{
				// Gọi phương thức cập nhật kho trong BUS
				khoBUS.SuaKho(maKho, maCH, maSP, soLuongCapNhat);

				// Hiển thị thông báo thành công
				MessageBox.Show("Cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadKho();
			}
			catch (Exception ex)
			{
				// Xử lý nếu có lỗi xảy ra
				MessageBox.Show("Lỗi khi cập nhật kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
    
}
