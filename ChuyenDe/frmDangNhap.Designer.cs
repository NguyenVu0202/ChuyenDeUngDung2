namespace ChuyenDe
{
	partial class frmDangNhap
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
			this.btnDangKy = new System.Windows.Forms.Button();
			this.btnDangNhap = new System.Windows.Forms.Button();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.txtTaiKhoan = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnThoat
			// 
			this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.Location = new System.Drawing.Point(380, 394);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(114, 31);
			this.btnThoat.TabIndex = 24;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = true;
			// 
			// btnDangKy
			// 
			this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDangKy.Location = new System.Drawing.Point(476, 320);
			this.btnDangKy.Name = "btnDangKy";
			this.btnDangKy.Size = new System.Drawing.Size(114, 31);
			this.btnDangKy.TabIndex = 23;
			this.btnDangKy.Text = "Đăng ký";
			this.btnDangKy.UseVisualStyleBackColor = true;
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDangNhap.Location = new System.Drawing.Point(290, 320);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(114, 31);
			this.btnDangNhap.TabIndex = 22;
			this.btnDangNhap.Text = "Đăng nhập";
			this.btnDangNhap.UseVisualStyleBackColor = true;
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMatKhau.Location = new System.Drawing.Point(253, 232);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.PasswordChar = '*';
			this.txtMatKhau.Size = new System.Drawing.Size(372, 30);
			this.txtMatKhau.TabIndex = 21;
			// 
			// txtTaiKhoan
			// 
			this.txtTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTaiKhoan.Location = new System.Drawing.Point(253, 127);
			this.txtTaiKhoan.Name = "txtTaiKhoan";
			this.txtTaiKhoan.Size = new System.Drawing.Size(372, 30);
			this.txtTaiKhoan.TabIndex = 20;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(86, 232);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 25);
			this.label3.TabIndex = 19;
			this.label3.Text = "Mật khẩu:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(86, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 25);
			this.label2.TabIndex = 18;
			this.label2.Text = "Tài khoản:";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(859, 57);
			this.label1.TabIndex = 17;
			this.label1.Text = "ĐĂNG NHẬP";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmDangNhap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::ChuyenDe.Properties.Resources.sharefb_v201908071702_637008562618462479;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(859, 457);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnDangKy);
			this.Controls.Add(this.btnDangNhap);
			this.Controls.Add(this.txtMatKhau);
			this.Controls.Add(this.txtTaiKhoan);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmDangNhap";
			this.Text = "frmDangNhap";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnDangKy;
		private System.Windows.Forms.Button btnDangNhap;
		private System.Windows.Forms.TextBox txtMatKhau;
		private System.Windows.Forms.TextBox txtTaiKhoan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}