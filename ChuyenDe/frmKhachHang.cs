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

namespace ChuyenDe
{
	public partial class frmKhachHang : Form
	{
		public frmKhachHang()
		{
			InitializeComponent();
		}

        private void dgvDanhSachKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			BUSKhachHang.Instance.Load(txtMaKH,txtTenKH,r);
        }
    }
}
