namespace ChuyenDe
{
    partial class frmReportSPDaBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.thongKeSanPhamDaBanCuaCuaHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bachHoaXanhDataSet = new ChuyenDe.BachHoaXanhDataSet();
            this.rpvSanPhamDaBan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.thongKeSanPhamDaBanCuaCuaHangTableAdapter = new ChuyenDe.BachHoaXanhDataSetTableAdapters.ThongKeSanPhamDaBanCuaCuaHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.thongKeSanPhamDaBanCuaCuaHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // thongKeSanPhamDaBanCuaCuaHangBindingSource
            // 
            this.thongKeSanPhamDaBanCuaCuaHangBindingSource.DataMember = "ThongKeSanPhamDaBanCuaCuaHang";
            this.thongKeSanPhamDaBanCuaCuaHangBindingSource.DataSource = this.bachHoaXanhDataSet;
            // 
            // bachHoaXanhDataSet
            // 
            this.bachHoaXanhDataSet.DataSetName = "BachHoaXanhDataSet";
            this.bachHoaXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpvSanPhamDaBan
            // 
            this.rpvSanPhamDaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.thongKeSanPhamDaBanCuaCuaHangBindingSource;
            this.rpvSanPhamDaBan.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSanPhamDaBan.LocalReport.ReportEmbeddedResource = "ChuyenDe.SanPhamDaBan.rdlc";
            this.rpvSanPhamDaBan.Location = new System.Drawing.Point(0, 0);
            this.rpvSanPhamDaBan.Name = "rpvSanPhamDaBan";
            this.rpvSanPhamDaBan.ServerReport.BearerToken = null;
            this.rpvSanPhamDaBan.Size = new System.Drawing.Size(800, 450);
            this.rpvSanPhamDaBan.TabIndex = 0;
            this.rpvSanPhamDaBan.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // thongKeSanPhamDaBanCuaCuaHangTableAdapter
            // 
            this.thongKeSanPhamDaBanCuaCuaHangTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportSPDaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvSanPhamDaBan);
            this.Name = "frmReportSPDaBan";
            this.Text = "frmReportSPDaBan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportSPDaBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thongKeSanPhamDaBanCuaCuaHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvSanPhamDaBan;
        private System.Windows.Forms.BindingSource thongKeSanPhamDaBanCuaCuaHangBindingSource;
        private BachHoaXanhDataSet bachHoaXanhDataSet;
        private BachHoaXanhDataSetTableAdapters.ThongKeSanPhamDaBanCuaCuaHangTableAdapter thongKeSanPhamDaBanCuaCuaHangTableAdapter;
    }
}