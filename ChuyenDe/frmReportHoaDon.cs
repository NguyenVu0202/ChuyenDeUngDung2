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
    public partial class frmReportHoaDon : Form
    {
        public frmReportHoaDon()
        {
            InitializeComponent();
        }

        private void RpHoaDon_Load(object sender, EventArgs e)
        {
            BachHoaXanhDataSetTableAdapters.ReportHoaDonTableAdapter tableAdapter = new BachHoaXanhDataSetTableAdapters.ReportHoaDonTableAdapter();
            tableAdapter.Connection.ConnectionString = BUSDoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
            tableAdapter.Fill(bachHoaXanhDataSet.ReportHoaDon);
            this.rptvHoaDon.RefreshReport();
        }
    }
}
