using BUS;
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
	public partial class frmThongKeDoanhThu : Form
	{
		public frmThongKeDoanhThu()
		{
			InitializeComponent();
		}

        private void LoadMaCH()
        {
            BUS_ThongKeDoanhThu.Instance.LoadMaCH(cbMaCH);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BUS_ThongKeDoanhThu.Instance.ThongKeDoanhThu(cbMaCH, dtpTuNgay, dtpToiNgay, dgvDoanhThu);
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            LoadMaCH();
            cbMaCH.SelectedIndex = -1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbMaCH.SelectedIndex = -1;
            dtpTuNgay.Text = DateTime.Now.ToString();
            dtpToiNgay.Text = DateTime.Now.ToString();
            dgvDoanhThu.DataSource = null;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

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
    }
}
