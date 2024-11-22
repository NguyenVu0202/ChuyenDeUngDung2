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
    public partial class frmReportThongKeDoanhThu : Form
    {
        private string ma;
        private DateTime tu;
        private DateTime toi;
        public frmReportThongKeDoanhThu(string ma, DateTime tu, DateTime toi)
        {
            InitializeComponent();
            this.ma = ma;
            this.tu = tu;
            this.toi = toi;
        }

        private void frmReportThongKeDoanhThu_Load(object sender, EventArgs e)
        { // TODO: This line of code loads data into the 'bachHoaXanhDataSet.ThongKeSanPhamDaBanCuaCuaHang' table. You can move, or remove it, as needed.
            BachHoaXanhDataSetTableAdapters.ThongKeDoanhThuTheoCHTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ThongKeDoanhThuTheoCHTableAdapter();
            tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
            tableAdapter.Fill(bachHoaXanhDataSet.ThongKeDoanhThuTheoCH, ma, tu, toi);
            this.reportViewer1.RefreshReport();
        }
    }
}
