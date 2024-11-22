namespace ChuyenDe
{
	partial class frmInLuongNhanVien
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
			this.reportThongKeLuongNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.bachHoaXanhDataSet = new ChuyenDe.BachHoaXanhDataSet();
			this.rptLuongNV = new Microsoft.Reporting.WinForms.ReportViewer();
			this.reportThongKeLuongNhanVienTableAdapter = new ChuyenDe.BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.reportThongKeLuongNhanVienBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// reportThongKeLuongNhanVienBindingSource
			// 
			this.reportThongKeLuongNhanVienBindingSource.DataMember = "ReportThongKeLuongNhanVien";
			this.reportThongKeLuongNhanVienBindingSource.DataSource = this.bachHoaXanhDataSet;
			// 
			// bachHoaXanhDataSet
			// 
			this.bachHoaXanhDataSet.DataSetName = "BachHoaXanhDataSet";
			this.bachHoaXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// rptLuongNV
			// 
			this.rptLuongNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.reportThongKeLuongNhanVienBindingSource;
			this.rptLuongNV.LocalReport.DataSources.Add(reportDataSource1);
			this.rptLuongNV.LocalReport.ReportEmbeddedResource = "ChuyenDe.rptLuongNhanVien.rdlc";
			this.rptLuongNV.Location = new System.Drawing.Point(-2, 8);
			this.rptLuongNV.Name = "rptLuongNV";
			this.rptLuongNV.ServerReport.BearerToken = null;
			this.rptLuongNV.Size = new System.Drawing.Size(1504, 549);
			this.rptLuongNV.TabIndex = 1;
			// 
			// reportThongKeLuongNhanVienTableAdapter
			// 
			this.reportThongKeLuongNhanVienTableAdapter.ClearBeforeFill = true;
			// 
			// frmInLuongNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1500, 564);
			this.Controls.Add(this.rptLuongNV);
			this.Name = "frmInLuongNhanVien";
			this.Text = "frmInLuongNhanVien";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmInLuongNhanVien_Load);
			((System.ComponentModel.ISupportInitialize)(this.reportThongKeLuongNhanVienBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bachHoaXanhDataSet)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer rptLuongNV;
		private System.Windows.Forms.BindingSource reportThongKeLuongNhanVienBindingSource;
		private BachHoaXanhDataSet bachHoaXanhDataSet;
		private BachHoaXanhDataSetTableAdapters.ReportThongKeLuongNhanVienTableAdapter reportThongKeLuongNhanVienTableAdapter;
	}
}