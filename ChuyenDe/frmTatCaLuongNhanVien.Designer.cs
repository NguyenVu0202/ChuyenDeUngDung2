namespace ChuyenDe
{
    partial class frmTatCaLuongNhanVien
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
			this.rptTatCaLuongNhanVien = new Microsoft.Reporting.WinForms.ReportViewer();
			this.bachHoaXanhDataSet = new ChuyenDe.BachHoaXanhDataSet();
			this.reportThongKeLuongNhanVienTheoMaNVBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.reportThongKeLuongNhanVienTheoMaNVTableAdapter = new ChuyenDe.BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTheoMaNVTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reportThongKeLuongNhanVienTheoMaNVBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// rptTatCaLuongNhanVien
			// 
			this.rptTatCaLuongNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.reportThongKeLuongNhanVienTheoMaNVBindingSource;
			this.rptTatCaLuongNhanVien.LocalReport.DataSources.Add(reportDataSource1);
			this.rptTatCaLuongNhanVien.LocalReport.ReportEmbeddedResource = "ChuyenDe.rptTatCaLuongNhanVien.rdlc";
			this.rptTatCaLuongNhanVien.Location = new System.Drawing.Point(2, 3);
			this.rptTatCaLuongNhanVien.Name = "rptTatCaLuongNhanVien";
			this.rptTatCaLuongNhanVien.ServerReport.BearerToken = null;
			this.rptTatCaLuongNhanVien.Size = new System.Drawing.Size(1499, 560);
			this.rptTatCaLuongNhanVien.TabIndex = 0;
			// 
			// bachHoaXanhDataSet
			// 
			this.bachHoaXanhDataSet.DataSetName = "BachHoaXanhDataSet";
			this.bachHoaXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// reportThongKeLuongNhanVienTheoMaNVBindingSource
			// 
			this.reportThongKeLuongNhanVienTheoMaNVBindingSource.DataMember = "ReportThongKeLuongNhanVienTheoMaNV";
			this.reportThongKeLuongNhanVienTheoMaNVBindingSource.DataSource = this.bachHoaXanhDataSet;
			// 
			// reportThongKeLuongNhanVienTheoMaNVTableAdapter
			// 
			this.reportThongKeLuongNhanVienTheoMaNVTableAdapter.ClearBeforeFill = true;
			// 
			// frmTatCaLuongNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1500, 564);
			this.Controls.Add(this.rptTatCaLuongNhanVien);
			this.Name = "frmTatCaLuongNhanVien";
			this.Text = "frmTatCaLuongNhanVien";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmTatCaLuongNhanVien_Load);
			((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reportThongKeLuongNhanVienTheoMaNVBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer rptTatCaLuongNhanVien;
		private System.Windows.Forms.BindingSource reportThongKeLuongNhanVienTheoMaNVBindingSource;
		private BachHoaXanhDataSet bachHoaXanhDataSet;
		private BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTheoMaNVTableAdapter reportThongKeLuongNhanVienTheoMaNVTableAdapter;
	}
}