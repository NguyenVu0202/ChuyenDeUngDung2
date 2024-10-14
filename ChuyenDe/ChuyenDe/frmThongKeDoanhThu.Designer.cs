namespace ChuyenDe
{
	partial class frmThongKeDoanhThu
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
			this.btnThoat = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnIn = new System.Windows.Forms.Button();
			this.dtpToiNgay = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
			this.btnLamMoi = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnThongKe = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnThoat
			// 
			this.btnThoat.Location = new System.Drawing.Point(664, 228);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(116, 41);
			this.btnThoat.TabIndex = 32;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(171, 87);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 20);
			this.label5.TabIndex = 25;
			this.label5.Text = "Mã CH:";
			// 
			// dgvDoanhThu
			// 
			this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDoanhThu.Location = new System.Drawing.Point(0, 26);
			this.dgvDoanhThu.Name = "dgvDoanhThu";
			this.dgvDoanhThu.RowHeadersWidth = 51;
			this.dgvDoanhThu.RowTemplate.Height = 24;
			this.dgvDoanhThu.Size = new System.Drawing.Size(992, 221);
			this.dgvDoanhThu.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgvDoanhThu);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(-1, 406);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(992, 247);
			this.groupBox2.TabIndex = 41;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh Sách Danh Thu";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.btnThoat);
			this.groupBox1.Controls.Add(this.btnIn);
			this.groupBox1.Controls.Add(this.dtpToiNgay);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.dtpTuNgay);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.btnLamMoi);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnThongKe);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(92, 107);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(802, 293);
			this.groupBox1.TabIndex = 42;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông Tin Thống Kê";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(244, 84);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(283, 27);
			this.textBox1.TabIndex = 33;
			// 
			// btnIn
			// 
			this.btnIn.Location = new System.Drawing.Point(664, 156);
			this.btnIn.Name = "btnIn";
			this.btnIn.Size = new System.Drawing.Size(116, 41);
			this.btnIn.TabIndex = 30;
			this.btnIn.Text = "In";
			this.btnIn.UseVisualStyleBackColor = true;
			// 
			// dtpToiNgay
			// 
			this.dtpToiNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpToiNgay.Location = new System.Drawing.Point(406, 167);
			this.dtpToiNgay.Name = "dtpToiNgay";
			this.dtpToiNgay.Size = new System.Drawing.Size(200, 27);
			this.dtpToiNgay.TabIndex = 29;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(348, 167);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 20);
			this.label4.TabIndex = 28;
			this.label4.Text = "Tới:";
			// 
			// dtpTuNgay
			// 
			this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTuNgay.Location = new System.Drawing.Point(78, 167);
			this.dtpTuNgay.Name = "dtpTuNgay";
			this.dtpTuNgay.Size = new System.Drawing.Size(200, 27);
			this.dtpTuNgay.TabIndex = 27;
			// 
			// btnLamMoi
			// 
			this.btnLamMoi.Location = new System.Drawing.Point(664, 90);
			this.btnLamMoi.Name = "btnLamMoi";
			this.btnLamMoi.Size = new System.Drawing.Size(116, 41);
			this.btnLamMoi.TabIndex = 24;
			this.btnLamMoi.Text = "Làm Mới";
			this.btnLamMoi.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(25, 167);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Từ:";
			// 
			// btnThongKe
			// 
			this.btnThongKe.Location = new System.Drawing.Point(664, 25);
			this.btnThongKe.Name = "btnThongKe";
			this.btnThongKe.Size = new System.Drawing.Size(116, 41);
			this.btnThongKe.TabIndex = 23;
			this.btnThongKe.Text = "Thống Kê";
			this.btnThongKe.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(989, 55);
			this.label1.TabIndex = 40;
			this.label1.Text = "THỐNG KÊ DANH THU";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmThongKeDoanhThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 654);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Name = "frmThongKeDoanhThu";
			this.Text = "frmThongKeDoanhThu";
			((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridView dgvDoanhThu;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnIn;
		private System.Windows.Forms.DateTimePicker dtpToiNgay;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpTuNgay;
		private System.Windows.Forms.Button btnLamMoi;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnThongKe;
		private System.Windows.Forms.Label label1;
	}
}