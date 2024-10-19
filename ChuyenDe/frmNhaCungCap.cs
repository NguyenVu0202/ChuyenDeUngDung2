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
            DialogResult kq = MessageBox.Show("Ban co muon Thoat ko???", "Thong Bao",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BUSNhaCungCap.Instance.Them(txtMaHang,txtTenHang);
            Load();
            txtMaHang.Text = string.Empty;
            txtTenHang.Text = string.Empty;
            txtMaHang.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Ban co muon xoa ko???", "Thong Bao",
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

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUSNhaCungCap.Instance.Load(txtMaHang, txtTenHang,dgvHang);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BUSNhaCungCap.Instance.Sua(txtMaHang, txtTenHang);
            Load();
            txtMaHang.Text = string.Empty;
            txtTenHang.Text = string.Empty;
            txtMaHang.Focus();
        }
    }
}
