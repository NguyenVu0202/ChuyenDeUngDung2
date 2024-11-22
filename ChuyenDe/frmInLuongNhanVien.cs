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
	public partial class frmInLuongNhanVien : Form
	{
		int matinhluong = 0;
		public frmInLuongNhanVien()
		{
			InitializeComponent();
		}

		public frmInLuongNhanVien(int matinhluong)
		{
			InitializeComponent();
			this.matinhluong = matinhluong;
		}

		private void frmInLuongNhanVien_Load(object sender, EventArgs e)
		{

			BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTableAdapter();
			tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
			tableAdapter.Fill(bachHoaXanhDataSet.ReportThongKeLuongNhanVien, matinhluong);

			this.rptLuongNV.RefreshReport();
		}
    }
}
