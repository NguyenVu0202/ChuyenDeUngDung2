using BUS;
using DevExpress.XtraEditors.Mask.Design;
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
	public partial class frmTimKiemHoaDon : Form
	{
        string manv = "";
        string mach = "";
		public frmTimKiemHoaDon()
		{
			InitializeComponent();
		}
        public frmTimKiemHoaDon(string manv)
        {
            InitializeComponent();
            this.manv = manv;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHD.Text;
            string makh = txtMaKH.Text;
            mach = BUSTimKiemHoaDon.Instance.MaCuaHang(manv);

            if (txtMaKH.ReadOnly == true)
            {
                // Kiểm tra khoảng trắng đầu và cuối trong MaHD
                if (mahd != mahd.Trim())
                {
                    MessageBox.Show("Mã hóa đơn không được có khoảng trắng ở đầu hoặc cuối.");
                    return;
                }
                // Kiểm tra khoảng trắng liên tiếp trong MaHD
                if (Regex.IsMatch(mahd, @"\s{2,}"))
                {
                    MessageBox.Show("Mã hóa đơn không được có hai khoảng trắng liên tiếp.");
                    return;
                }
                // Kiểm tra maHD chỉ được là số
                if (!int.TryParse(mahd, out _))
                {
                    MessageBox.Show("Mã hóa đơn chỉ được là số.");
                    return;
                }
                BUSTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaHD(txtMaHD, dgvTimKiemHoaDon, mach);
            }
            else if (txtMaHD.ReadOnly == true)
            {
                // Kiểm tra khoảng trắng đầu và cuối trong MaKH
                if (makh != makh.Trim())
                {
                    MessageBox.Show("Mã khách hàng không được có khoảng trắng ở đầu hoặc cuối.");
                    return;
                }
                // Kiểm tra khoảng trắng liên tiếp trong MaKH
                if (Regex.IsMatch(makh, @"\s{2,}"))
                {
                    MessageBox.Show("Mã khách hàng không được có hai khoảng trắng liên tiếp.");
                    return;
                }
                BUSTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaKH(txtMaKH, dgvTimKiemHoaDon, mach);
            }
            else
            {
                BUSTimKiemHoaDon.Instance.TimKiemHoaDonTheoNgayBan(dtpNgay, dgvTimKiemHoaDon, mach);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txtMaKH.Text = "";
            txtMaHD.ReadOnly = false;
            txtMaKH.ReadOnly = false;
            dtpNgay.Text = DateTime.Now.ToString();
            dgvTimKiemHoaDon.DataSource = null;
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Length > 0)
            {
                txtMaKH.ReadOnly = true;
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length > 0)
            {
                txtMaHD.ReadOnly = true;
            }
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
    }
}
