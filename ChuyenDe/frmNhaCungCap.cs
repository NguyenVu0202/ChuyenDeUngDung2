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
            if (string.IsNullOrWhiteSpace(txtMaHang.Text) ||
                string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            BUSNhaCungCap.Instance.Them(txtMaHang, txtTenHang);
            txtMaHang.Text = string.Empty;
            txtTenHang.Text = string.Empty;
            txtMaHang.Focus();
            Load();
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
            BUSNhaCungCap.Instance.Load(txtMaHang, txtTenHang,dgvHang);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text != "" && txtTenHang.Text != "")
            {
                BUSNhaCungCap.Instance.Sua(txtMaHang, txtTenHang);
                Load();
                txtMaHang.Text = string.Empty;
                txtTenHang.Text = string.Empty;
                txtMaHang.Focus();
            }
            else MessageBox.Show("Vui lòng chọn dữ liệu để sửa!");    
        }
    }
}
