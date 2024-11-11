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
    public partial class frmReportTimKiemHoaDon : Form
    {
        public frmReportTimKiemHoaDon()
        {
            InitializeComponent();
        }

        private void frmReportTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            BachHoaXanhDataSetTableAdapters.ReportTimKiemHoaDonTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ReportTimKiemHoaDonTableAdapter();
            tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
            tableAdapter.Fill(bachHoaXanhDataSet.ReportTimKiemHoaDon, int.Parse(txtMaHoaDon.Text.ToString()));
            this.rptvTimKiemHoaDon.RefreshReport();
        }
    }
}
