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
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                (!radNam.Checked && !radNu.Checked) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BUSKhachHang.Instance.Them(txtMaKH, txtTenKH, radNam, radNu, txtSDT, txtDiaChi);
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            radNam.Checked = false;
            radNu.Checked = false;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMaKH.Focus();
            View();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "" && txtTenKH.Text != "" && (radNam.Checked == true || radNu.Checked == true) && txtSDT.Text != "" && txtDiaChi.Text != "")
            {
                KhachHang khachHang = new KhachHang();
                khachHang.MaKH = txtMaKH.Text;
                khachHang.TenKH = txtTenKH.Text;
                khachHang.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                khachHang.DiaChi = txtDiaChi.Text;
                khachHang.SDT = txtSDT.Text;

                if (BUSKhachHang.Instance.Sua(khachHang))
                {
                    MessageBox.Show("Sửa khách hàng thành công!");
                    txtMaKH.Text = string.Empty;
                    txtTenKH.Text = string.Empty;
                    if (radNam.Checked == true)
                        radNam.Checked = false;
                    else radNu.Checked = false;
                    txtSDT.Text = string.Empty;
                    txtDiaChi.Text = string.Empty;
                    txtMaKH.Focus();
                    View();
                }
                else
                {
                    MessageBox.Show("Sửa khách hàng không thành công!");
                }
            }
            else MessageBox.Show("Vui lòng chọn dữ liệu để sửa!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "" && txtTenKH.Text != "" && (radNam.Checked == true || radNu.Checked == true) && txtSDT.Text != "" && txtDiaChi.Text != "")
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    BUSKhachHang.Instance.Xoa(txtMaKH);
                    MessageBox.Show("Xóa thành công!");
                    txtMaKH.Text = string.Empty;
                    txtTenKH.Text = string.Empty;
                    if (radNam.Checked == true)
                        radNam.Checked = false;
                    else radNu.Checked = false;
                    txtSDT.Text = string.Empty;
                    txtDiaChi.Text = string.Empty;
                    txtMaKH.Focus();
                    View();
                }
                else MessageBox.Show("Xóa không thành công!");
            }
            else MessageBox.Show("Vui lòng chọn dữ liệu để xóa!");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMaKH.Text) || !string.IsNullOrWhiteSpace(txtTenKH.Text) || !string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoMa(txtMaKH, dgvDanhSachKH);
                }
                if (!string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoTen(txtTenKH, dgvDanhSachKH);
                }
                if (!string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    btnTimKiem.Enabled = true;
                    BUSKhachHang.Instance.TimKhachHangTheoSDT(txtSDT, dgvDanhSachKH);
                }
            }
            else MessageBox.Show("Vui lòng nhập dữ liệu cần tìm kiếm!");
        }
        private void Check()
        {
            btnTimKiem.Enabled = radMa.Checked || radTen.Checked || radSDT.Checked;
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

        private void radTen_CheckedChanged(object sender, EventArgs e)
        {
            if (radTen.Checked)
            {
                txtMaKH.Enabled = false;
                txtSDT.Enabled = false;
                txtDiaChi.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = true;
                txtSDT.Text = string.Empty;
                txtTenKH.Text = string.Empty;
                if (radNam.Checked == true)
                    radNam.Checked = false;
                else radNu.Checked = false;
                txtMaKH.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtTenKH.Focus();
            }
            else
            {
                txtMaKH.Enabled = true;
                txtSDT.Enabled = true;
                txtDiaChi.Enabled = true;
                radNam.Enabled = true;
                radNu.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
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
    }
}
