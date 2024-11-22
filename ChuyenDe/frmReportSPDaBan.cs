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
    public partial class frmReportSPDaBan : Form
    {
        private string ma;
        private DateTime tu;
        private DateTime toi;
        public frmReportSPDaBan(string ma, DateTime tu, DateTime toi)
        {
            InitializeComponent();
            this.ma = ma;
            this.tu = tu;
            this.toi = toi;
        }

        private void frmReportSPDaBan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bachHoaXanhDataSet.ThongKeSanPhamDaBanCuaCuaHang' table. You can move, or remove it, as needed.
            BachHoaXanhDataSetTableAdapters.ThongKeSanPhamDaBanCuaCuaHangTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ThongKeSanPhamDaBanCuaCuaHangTableAdapter();
            tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
            tableAdapter.Fill(bachHoaXanhDataSet.ThongKeSanPhamDaBanCuaCuaHang, ma, tu, toi);
            this.rpvSanPhamDaBan.RefreshReport();
        }
    }
}
