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
            string makh = cboMaKH.Text;
            mach = BUSTimKiemHoaDon.Instance.MaCuaHang(manv);
            if (txtMaHD.Text.Length > 0)
            {
                // Kiểm tra khoảng trắng đầu và cuối trong MaKH
                if (mahd != mahd.Trim())
                {
                    MessageBox.Show("Mã khách hàng không được có khoảng trắng ở đầu hoặc cuối.");
                    return;
                }
                // Kiểm tra khoảng trắng liên tiếp trong MaKH
                if (Regex.IsMatch(mahd, @"\s{2,}"))
                {
                    MessageBox.Show("Mã khách hàng không được có hai khoảng trắng liên tiếp.");
                    return;
                }
                BUSTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaHD(txtMaHD, dgvTimKiemHoaDon, mach);
            }
            else if (cboMaKH.Text != "")
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
                BUSTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaKH(makh, dgvTimKiemHoaDon, mach);
            }
            else
            {
                BUSTimKiemHoaDon.Instance.TimKiemHoaDonTheoNgayBan(dtpNgay, dgvTimKiemHoaDon, mach);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            cboMaKH.SelectedIndex = -1;
            txtMaHD.ReadOnly = false;
            dtpNgay.Text = DateTime.Now.ToString();
            dgvTimKiemHoaDon.DataSource = null;
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportTimKiemHoaDon frm = new frmReportTimKiemHoaDon();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
        private void cboMaKH_KeyUp(object sender, KeyEventArgs e)
        {
            BUSTimKiemHoaDon.Instance.AutoTimKiemMaKH(cboMaKH);
        }

        private void cboMaKH_TextChanged(object sender, EventArgs e)
        {
            if (cboMaKH.Text.Length > 0)
            {
                txtMaHD.ReadOnly = true;
            }
        }
    }
}
