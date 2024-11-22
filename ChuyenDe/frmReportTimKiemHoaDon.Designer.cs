namespace ChuyenDe
{
    partial class frmReportTimKiemHoaDon
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.rptvTimKiemHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bachHoaXanhDataSet = new ChuyenDe.BachHoaXanhDataSet();
            this.reportTimKiemHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportTimKiemHoaDonTableAdapter = new ChuyenDe.BachHoaXanhDataSetTableAdapters.ReportTimKiemHoaDonTableAdapter();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportTimKiemHoaDonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hóa Đơn:";
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(671, 25);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(172, 27);
            this.txtMaHoaDon.TabIndex = 1;
            // 
            // rptvTimKiemHoaDon
            // 
            this.rptvTimKiemHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.reportTimKiemHoaDonBindingSource;
            this.rptvTimKiemHoaDon.LocalReport.DataSources.Add(reportDataSource2);
            this.rptvTimKiemHoaDon.LocalReport.ReportEmbeddedResource = "ChuyenDe.RptTimKiemHoaDon.rdlc";
            this.rptvTimKiemHoaDon.Location = new System.Drawing.Point(12, 72);
            this.rptvTimKiemHoaDon.Name = "rptvTimKiemHoaDon";
            this.rptvTimKiemHoaDon.ServerReport.BearerToken = null;
            this.rptvTimKiemHoaDon.Size = new System.Drawing.Size(1667, 814);
            this.rptvTimKiemHoaDon.TabIndex = 2;
            // 
            // bachHoaXanhDataSet
            // 
            this.bachHoaXanhDataSet.DataSetName = "BachHoaXanhDataSet";
            this.bachHoaXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportTimKiemHoaDonBindingSource
            // 
            this.reportTimKiemHoaDonBindingSource.DataMember = "ReportTimKiemHoaDon";
            this.reportTimKiemHoaDonBindingSource.DataSource = this.bachHoaXanhDataSet;
            // 
            // reportTimKiemHoaDonTableAdapter
            // 
            this.reportTimKiemHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(882, 25);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(74, 27);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmReportTimKiemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1691, 898);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.rptvTimKiemHoaDon);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.label1);
            this.Name = "frmReportTimKiemHoaDon";
            this.Text = "frmReportTimKiemHoaDon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportTimKiemHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportTimKiemHoaDonBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private Microsoft.Reporting.WinForms.ReportViewer rptvTimKiemHoaDon;
        private BachHoaXanhDataSet bachHoaXanhDataSet;
        private System.Windows.Forms.BindingSource reportTimKiemHoaDonBindingSource;
        private BachHoaXanhDataSetTableAdapters.ReportTimKiemHoaDonTableAdapter reportTimKiemHoaDonTableAdapter;
        private System.Windows.Forms.Button btnIn;
    }
}