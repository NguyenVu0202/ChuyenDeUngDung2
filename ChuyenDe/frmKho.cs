using BUS;
using DAO;
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

        public void LoadKho()
        {
            BUS_Kho.Instance.Xem(dgvKhoa);
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            try
            {
                // Lấy giá trị từ các trường
                string maKho = txtMaKho.Text;
                string maCH = cbMaCH.SelectedValue?.ToString() ?? "";
                string maSP = cbSP.SelectedValue?.ToString() ?? "";
                string soLuong = txtSoLuong.Text;

                // Kiểm tra các trường không được bỏ trống
                if (string.IsNullOrWhiteSpace(maKho) || string.IsNullOrWhiteSpace(soLuong))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cho cả bốn trường MaKho, MaCH, MaSP và Số Lượng");
                    return; // Dừng lại nếu có trường bị bỏ trống
                }

                // Kiểm tra khoảng trắng đầu và cuối
                if (maKho != maKho.Trim() || soLuong != soLuong.Trim())
                {
                    MessageBox.Show("Không được có khoảng trắng ở đầu hoặc cuối.");
                    return; // Dừng lại nếu có khoảng trắng đầu hoặc cuối
                }

                // Kiểm tra khoảng trắng liên tiếp trong chuỗi
                if (Regex.IsMatch(maKho, @"\s{2,}") || Regex.IsMatch(soLuong, @"\s{2,}"))
                {
                    MessageBox.Show("Không được có hai khoảng trắng liên tiếp.");
                    return; // Dừng lại nếu có hai khoảng trắng liên tiếp
                }

                if (!int.TryParse(soLuong, out int soLuongInt))
                {
                    MessageBox.Show("Số lượng phải là số nguyên hợp lệ.");
                    return;
                }

                // Nếu tất cả điều kiện đều thỏa mãn, tiến hành thêm thông tin vào cơ sở dữ liệu
                Kho ch = new Kho
                {
                    MaKho = maKho,
                    MaCH = maCH,
                    MaSP = maSP,
                    SoLuong = int.Parse(soLuong),

                };

                BUS_Kho.Instance.ThemKho(txtMaKho, cbMaCH, cbSP, txtSoLuong);
              

                // Tải lại dữ liệu sau khi thêm
                LoadKho();
                txtMaKho.Text = string.Empty;
                cbMaCH.SelectedIndex = -1; // Đặt lại lựa chọn
                cbSP.SelectedIndex = -1;   // Đặt lại lựa chọn
                txtSoLuong.Text = "";
                txtMaKho.Focus();
                // Mã thêm kho vào cơ sở dữ liệu
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công!!!");
            }
            finally
            {
                btnThem.Enabled = true;
            }

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
            txtMaKho.Text = "";
            LoadKho();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadKho();
        }
    }
    
}
