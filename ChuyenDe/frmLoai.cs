using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace ChuyenDe
{
    public partial class frmLoai : Form
    {
        public frmLoai()
        {
            InitializeComponent();
            View();
        }
        private void View()
        {
            BUSLoai.Instance.View(dgvLoai);
        }

        private void dgvLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUSLoai.Instance.Load(txtMaLoai, txtTenLoai, dgvLoai);
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
            BUSLoai.Instance.Them(txtMaLoai, txtTenLoai);
            View();
            txtMaLoai.Text = string.Empty;
            txtTenLoai.Text = string.Empty;
            txtMaLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BUSLoai.Instance.Sua(txtMaLoai,txtTenLoai);
            View();
            txtMaLoai.Text = string.Empty;
            txtTenLoai.Text= string.Empty;
            txtMaLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BUSLoai.Instance.Xoa(txtMaLoai);
                View();
                txtMaLoai.Text = string.Empty;
                txtTenLoai.Text = string.Empty;
                txtMaLoai.Focus();
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
            }
        }
    }
}
