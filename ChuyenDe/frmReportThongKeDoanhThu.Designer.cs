namespace ChuyenDe
{
    partial class frmReportThongKeDoanhThu
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bachHoaXanhDataSet = new ChuyenDe.BachHoaXanhDataSet();
            this.thongKeDoanhThuTheoCHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thongKeDoanhThuTheoCHTableAdapter = new ChuyenDe.BachHoaXanhDataSetTableAdapters.ThongKeDoanhThuTheoCHTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongKeDoanhThuTheoCHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.thongKeDoanhThuTheoCHBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ChuyenDe.DoanhThuCuaHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // bachHoaXanhDataSet
            // 
            this.bachHoaXanhDataSet.DataSetName = "BachHoaXanhDataSet";
            this.bachHoaXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // thongKeDoanhThuTheoCHBindingSource
            // 
            this.thongKeDoanhThuTheoCHBindingSource.DataMember = "ThongKeDoanhThuTheoCH";
            this.thongKeDoanhThuTheoCHBindingSource.DataSource = this.bachHoaXanhDataSet;
            // 
            // thongKeDoanhThuTheoCHTableAdapter
            // 
            this.thongKeDoanhThuTheoCHTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportThongKeDoanhThu";
            this.Text = "frmReportThongKeDoanhThu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportThongKeDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongKeDoanhThuTheoCHBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource thongKeDoanhThuTheoCHBindingSource;
        private BachHoaXanhDataSet bachHoaXanhDataSet;
        private BachHoaXanhDataSetTableAdapters.ThongKeDoanhThuTheoCHTableAdapter thongKeDoanhThuTheoCHTableAdapter;
    }
}