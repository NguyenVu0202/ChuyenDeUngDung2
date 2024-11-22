namespace ChuyenDe
{
    partial class frmReportHoaDon
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
            this.rptvHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bachHoaXanhDataSet = new ChuyenDe.BachHoaXanhDataSet();
            this.bachHoaXanhDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportHoaDonTableAdapter = new ChuyenDe.BachHoaXanhDataSetTableAdapters.ReportHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportHoaDonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptvHoaDon
            // 
            this.rptvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reportHoaDonBindingSource;
            this.rptvHoaDon.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvHoaDon.LocalReport.ReportEmbeddedResource = "ChuyenDe.rptHoaDon.rdlc";
            this.rptvHoaDon.Location = new System.Drawing.Point(12, 12);
            this.rptvHoaDon.Name = "rptvHoaDon";
            this.rptvHoaDon.ServerReport.BearerToken = null;
            this.rptvHoaDon.Size = new System.Drawing.Size(1667, 874);
            this.rptvHoaDon.TabIndex = 0;
            // 
            // bachHoaXanhDataSet
            // 
            this.bachHoaXanhDataSet.DataSetName = "BachHoaXanhDataSet";
            this.bachHoaXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bachHoaXanhDataSetBindingSource
            // 
            this.bachHoaXanhDataSetBindingSource.DataSource = this.bachHoaXanhDataSet;
            this.bachHoaXanhDataSetBindingSource.Position = 0;
            // 
            // reportHoaDonBindingSource
            // 
            this.reportHoaDonBindingSource.DataMember = "ReportHoaDon";
            this.reportHoaDonBindingSource.DataSource = this.bachHoaXanhDataSetBindingSource;
            // 
            // reportHoaDonTableAdapter
            // 
            this.reportHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1691, 898);
            this.Controls.Add(this.rptvHoaDon);
            this.Name = "frmReportHoaDon";
            this.Text = "RpHoaDon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RpHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportHoaDonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer rptvHoaDon;
        private BachHoaXanhDataSet bachHoaXanhDataSet;
        private System.Windows.Forms.BindingSource bachHoaXanhDataSetBindingSource;
        private System.Windows.Forms.BindingSource reportHoaDonBindingSource;
        private BachHoaXanhDataSetTableAdapters.ReportHoaDonTableAdapter reportHoaDonTableAdapter;
    }
}