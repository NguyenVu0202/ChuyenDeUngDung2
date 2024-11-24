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
	public partial class frmTatCaLuongNhanVien : Form
	{
		string MaNV = "";
		public frmTatCaLuongNhanVien()
		{
			InitializeComponent();
		}
		public frmTatCaLuongNhanVien(string maNV)
		{
			InitializeComponent();
			this.MaNV = maNV;
		}

		private void frmTatCaLuongNhanVien_Load(object sender, EventArgs e)
		{

			BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTheoMaNVTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTheoMaNVTableAdapter();
			tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
			tableAdapter.Fill(bachHoaXanhDataSet.ReportThongKeLuongNhanVienTheoMaNV, MaNV);

			this.rptTatCaLuongNhanVien.RefreshReport();
		}
	}
}
