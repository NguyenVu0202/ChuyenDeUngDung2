using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Drawing.Imaging;
using BUS;
using System.IO;

namespace ChuyenDe
{
	public partial class frmSanPham : Form
	{
		private void frmSanPham_Load(object sender, EventArgs e)
		{
			LoadSanPham();
			LoadTenLoai();
			LoadTenNCC();
		}

		bool isGenerate = false;
		public frmSanPham()
		{
			InitializeComponent();
		}

		private void btnTaoMa_Click(object sender, EventArgs e)
		{
			isGenerate = true;
			picBarcode.SizeMode = PictureBoxSizeMode.AutoSize;
			Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

			picBarcode.Image = barcode.Draw(txtMaSP.Text, 200);
		}

		private void btnLuuMa_Click(object sender, EventArgs e)
		{
			if (isGenerate)
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				picBarcode.Image.Save(path + "\\" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() +
					".jpg", ImageFormat.Jpeg);
			}
		}

		public void LoadTenLoai()
		{
			BUSSanPham.Instance.LoadTenLoai(cboTenLoai);
		}
		public void LoadTenNCC()
		{
			BUSSanPham.Instance.LoadTenNCC(cboTenHang);
		}
		private void LoadSanPham()
		{
			BUSSanPham.Instance.Xem(dgvSanPham);
		}
		public void LayHinhAnhBangMaSP()
		{
			BUSSanPham.Instance.LayHinhAnhBangMaSP(txtMaSP);
		}
		private void ofdOpenFile_FileOk(object sender, CancelEventArgs e)
		{
			ofdOpenFile.ShowDialog();
			string file = ofdOpenFile.FileName;
			if (string.IsNullOrEmpty(file))
			{
				return;
			}
			Image spImage = Image.FromFile(file);
			picHinhAnh.Image = spImage;
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			DialogResult kq = MessageBox.Show("Ban co muon Thoat ko???", "Thong Bao",
							MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (kq == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void btnChonAnh_Click_1(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// Set the image location and display it in PictureBox
				picHinhAnh.ImageLocation = openFileDialog.FileName;
				txtHinhAnh.Text = openFileDialog.FileName;

                string selectedFileName = Path.GetFileName(openFileDialog.FileName);
                string destinationPath = Path.Combine(Application.StartupPath, "Image", selectedFileName);

                try
				{
					// Copy the selected file to the "Image" folder
					File.Copy(openFileDialog.FileName, destinationPath, true);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã xảy ra lỗi khi sao chép hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnXoa_Click_1(object sender, EventArgs e)
		{
			DialogResult kq = MessageBox.Show("Ban co muon xoa ko???", "Thong Bao",
										   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (kq == DialogResult.Yes)
			{
				BUSSanPham.Instance.Xoa(txtMaSP);
				LoadSanPham();
			}
			else
			{
				MessageBox.Show("Lỗi!");
			}
		}

		private void btnSua_Click_1(object sender, EventArgs e)
		{
			LayHinhAnhBangMaSP();
			BUSSanPham.Instance.Sua(txtMaSP, txtTenSP, cboTenLoai, cboTenHang, txtGiaBan, txtHinhAnh, txtGhiChu);
			LoadSanPham();
		}

		private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			BUSSanPham.Instance.LoadDgvLenForm(txtMaSP, txtTenSP, cboTenLoai, cboTenHang, txtGiaBan, picHinhAnh, txtGhiChu, dgvSanPham);
		}

		private void btnThem_Click_1(object sender, EventArgs e)
		{

			BUSSanPham.Instance.Them(txtMaSP, txtTenSP, cboTenLoai, cboTenHang, txtGiaBan, txtHinhAnh, txtGhiChu);
			LoadSanPham();
		}
	}
}
