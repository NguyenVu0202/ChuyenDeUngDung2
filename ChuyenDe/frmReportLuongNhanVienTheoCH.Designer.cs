namespace ChuyenDe
{
	partial class frmReportLuongNhanVienTheoCH
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
			this.thongkeLuongNhanVienTheoCuaHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.bachHoaXanhDataSet = new ChuyenDe.BachHoaXanhDataSet();
			this.rptLuongNVCH = new Microsoft.Reporting.WinForms.ReportViewer();
			this.thongkeLuongNhanVienTheoCuaHangTableAdapter = new ChuyenDe.BachHoaXanhDataSetTableAdapters.ThongkeLuongNhanVienTheoCuaHangTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.thongkeLuongNhanVienTheoCuaHangBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// thongkeLuongNhanVienTheoCuaHangBindingSource
			// 
			this.thongkeLuongNhanVienTheoCuaHangBindingSource.DataMember = "ThongkeLuongNhanVienTheoCuaHang";
			this.thongkeLuongNhanVienTheoCuaHangBindingSource.DataSource = this.bachHoaXanhDataSet;
			// 
			// bachHoaXanhDataSet
			// 
			this.bachHoaXanhDataSet.DataSetName = "BachHoaXanhDataSet";
			this.bachHoaXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// rptLuongNVCH
			// 
			this.rptLuongNVCH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.thongkeLuongNhanVienTheoCuaHangBindingSource;
			this.rptLuongNVCH.LocalReport.DataSources.Add(reportDataSource1);
			this.rptLuongNVCH.LocalReport.ReportEmbeddedResource = "ChuyenDe.rptLuongNhanVienCuaHang.rdlc";
			this.rptLuongNVCH.Location = new System.Drawing.Point(1, 3);
			this.rptLuongNVCH.Name = "rptLuongNVCH";
			this.rptLuongNVCH.ServerReport.BearerToken = null;
			this.rptLuongNVCH.Size = new System.Drawing.Size(1416, 568);
			this.rptLuongNVCH.TabIndex = 0;
			// 
			// thongkeLuongNhanVienTheoCuaHangTableAdapter
			// 
			this.thongkeLuongNhanVienTheoCuaHangTableAdapter.ClearBeforeFill = true;
			// 
			// frmReportLuongNhanVienTheoCH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1421, 575);
			this.Controls.Add(this.rptLuongNVCH);
			this.Name = "frmReportLuongNhanVienTheoCH";
			this.Text = "frmReportLuongNhanVienTheoCH";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmReportLuongNhanVienTheoCH_Load);
			((System.ComponentModel.ISupportInitialize)(this.thongkeLuongNhanVienTheoCuaHangBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer rptLuongNVCH;
		private System.Windows.Forms.BindingSource thongkeLuongNhanVienTheoCuaHangBindingSource;
		private BachHoaXanhDataSet bachHoaXanhDataSet;
		private BachHoaXanhDataSetTableAdapters.ThongkeLuongNhanVienTheoCuaHangTableAdapter thongkeLuongNhanVienTheoCuaHangTableAdapter;
	}
}