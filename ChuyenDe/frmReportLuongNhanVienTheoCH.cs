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
	public partial class frmReportLuongNhanVienTheoCH : Form
	{
		string maCH = "";
		public frmReportLuongNhanVienTheoCH()
		{
			InitializeComponent();
		}
		public frmReportLuongNhanVienTheoCH(string maCH)
		{
			InitializeComponent();
			this.maCH = maCH;
		}
		private void frmReportLuongNhanVienTheoCH_Load(object sender, EventArgs e)
		{
			BachHoaXanhDataSetTableAdapters.ThongkeLuongNhanVienTheoCuaHangTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ThongkeLuongNhanVienTheoCuaHangTableAdapter();
			tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
			tableAdapter.Fill(bachHoaXanhDataSet.ThongkeLuongNhanVienTheoCuaHang, maCH);
			this.rptLuongNVCH.RefreshReport();
		}
    }
}
