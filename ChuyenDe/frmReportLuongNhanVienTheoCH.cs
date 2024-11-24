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
		string tungay = "";
		string denngay = "";
		public frmReportLuongNhanVienTheoCH()
		{
			InitializeComponent();
		}
		public frmReportLuongNhanVienTheoCH(string maCH, string tungay, string denngay)
		{
			InitializeComponent();
			this.maCH = maCH;
			this.tungay = tungay;
			this.denngay = denngay;
		}
		private void frmReportLuongNhanVienTheoCH_Load(object sender, EventArgs e)
		{
			BachHoaXanhDataSetTableAdapters.ThongkeLuongNhanVienTheoCuaHangTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ThongkeLuongNhanVienTheoCuaHangTableAdapter();
			tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
			tableAdapter.Fill(bachHoaXanhDataSet.ThongkeLuongNhanVienTheoCuaHang, maCH, DateTime.Parse(tungay), DateTime.Parse(denngay));
			this.rptLuongNVCH.RefreshReport();
		}
    }
}
