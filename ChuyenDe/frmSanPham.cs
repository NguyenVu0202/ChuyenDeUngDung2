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
using System.Text.RegularExpressions;

namespace ChuyenDe
{
	public partial class frmSanPham : Form
	{
		private void frmSanPham_Load(object sender, EventArgs e)
		{
			LoadSanPham();
			LoadTenLoai();
			LoadTenNCC();
            cboTenHang.SelectedIndex = -1;
            cboTenLoai.SelectedIndex = -1;
		}

		bool isGenerate = false;
		public frmSanPham()
		{
			InitializeComponent();
		}

        private void TaoMa()
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm để tạo mã barcode!");
            }
            else
            {
                isGenerate = true;
                picBarcode.SizeMode = PictureBoxSizeMode.AutoSize;
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                picBarcode.Image = barcode.Draw(txtMaSP.Text, 200);
            }
        }

		private void btnTaoMa_Click(object sender, EventArgs e)
		{
            TaoMa();
        }

		private void btnLuuMa_Click(object sender, EventArgs e)
		{
            if (isGenerate)
            {
                if (picBarcode.Image == null)
                {
                    MessageBox.Show("Không có hình barcode để lưu mã!");
                }
                else
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string fileName = $"{DateTime.Now.Second}_{DateTime.Now.Millisecond}.jpg";
                    string fullPath = System.IO.Path.Combine(path, fileName);

                    picBarcode.Image.Save(fullPath, ImageFormat.Jpeg);
                    MessageBox.Show($"Mã barcode đã được lưu tại: {fullPath}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng tạo mã barcode trước khi lưu!");
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
                txtMaSP.Text = null;
                txtTenSP.Text = null;
                cboTenLoai.SelectedIndex = -1;
                cboTenHang.SelectedIndex = -1;
                txtGiaBan.Text = null;
                txtGiamGia.Text = null;
                txtHinhAnh.Text = null;
                txtGhiChu.Text = null;
                picHinhAnh.Image = null;
                picBarcode.Image = null;
            }
		}

		private void btnSua_Click_1(object sender, EventArgs e)
		{
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtGhiChu.Text) ||
                string.IsNullOrWhiteSpace(txtGiaBan.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return; // Dừng lại nếu có trường bị bỏ trống
            }

            if (txtMaSP.Text != txtMaSP.Text.Trim() || txtGhiChu.Text != txtGhiChu.Text.Trim() ||
                txtGiaBan.Text != txtGiaBan.Text.Trim() || txtTenSP.Text != txtTenSP.Text.Trim() ||
                txtHinhAnh.Text != txtHinhAnh.Text.Trim())
            {
                MessageBox.Show("Không được có khoảng trắng ở đầu hoặc cuối.");
                return; // Dừng lại nếu có khoảng trắng đầu hoặc cuối
            }

            if (Regex.IsMatch(txtMaSP.Text, @"\s{2,}") || Regex.IsMatch(txtGhiChu.Text, @"\s{2,}") ||
                Regex.IsMatch(txtGiaBan.Text, @"\s{2,}") || Regex.IsMatch(txtTenSP.Text, @"\s{2,}") ||
                Regex.IsMatch(txtHinhAnh.Text, @"\s{2,}"))
            {
                MessageBox.Show("Không được có hai khoảng trắng liên tiếp.");
                return; // Dừng lại nếu có hai khoảng trắng liên tiếp
            }

            if (!decimal.TryParse(txtGiaBan.Text, out _))
            {
                MessageBox.Show("Giá bán chỉ được là số.");
                return; // Dừng lại nếu giá bán không phải là số
            }

            LayHinhAnhBangMaSP();
			BUSSanPham.Instance.Sua(txtMaSP, txtTenSP, cboTenLoai, cboTenHang, txtGiaBan, txtHinhAnh, txtGhiChu, txtGiamGia);
			LoadSanPham();
            txtMaSP.Text = null;
            txtTenSP.Text = null;
            cboTenLoai.SelectedIndex = -1;
            cboTenHang.SelectedIndex = -1;
            txtGiaBan.Text = null;
            txtGiamGia.Text = null;
            txtHinhAnh.Text = null;
            txtGhiChu.Text = null;
            picHinhAnh.Image = null;
            picBarcode.Image = null;
        }

		private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			BUSSanPham.Instance.LoadDgvLenForm(txtMaSP, txtTenSP, cboTenLoai, cboTenHang, txtGiaBan, picHinhAnh, txtGhiChu, dgvSanPham, txtGiamGia);
            TaoMa();
		}

		private void btnThem_Click_1(object sender, EventArgs e)
		{
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtGhiChu.Text) ||
				string.IsNullOrWhiteSpace(txtGiaBan.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text) ||
				string.IsNullOrWhiteSpace(txtHinhAnh.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return; // Dừng lại nếu có trường bị bỏ trống
            }

            if (txtMaSP.Text != txtMaSP.Text.Trim() || txtGhiChu.Text != txtGhiChu.Text.Trim() ||
                txtGiaBan.Text != txtGiaBan.Text.Trim() || txtTenSP.Text != txtTenSP.Text.Trim() ||
                txtHinhAnh.Text != txtHinhAnh.Text.Trim())
            {
                MessageBox.Show("Không được có khoảng trắng ở đầu hoặc cuối.");
                return; // Dừng lại nếu có khoảng trắng đầu hoặc cuối
            }

            if (Regex.IsMatch(txtMaSP.Text, @"\s{2,}") || Regex.IsMatch(txtGhiChu.Text, @"\s{2,}") ||
                Regex.IsMatch(txtGiaBan.Text, @"\s{2,}") || Regex.IsMatch(txtTenSP.Text, @"\s{2,}") ||
                Regex.IsMatch(txtHinhAnh.Text, @"\s{2,}"))
            {
                MessageBox.Show("Không được có hai khoảng trắng liên tiếp.");
                return; // Dừng lại nếu có hai khoảng trắng liên tiếp
            }

            if (!decimal.TryParse(txtGiaBan.Text, out _))
            {
                MessageBox.Show("Giá bán chỉ được là số.");
                return; // Dừng lại nếu giá bán không phải là số
            }

            // Lưu hình ảnh vào thư mục khi thêm sản phẩm
            string selectedFileName = Path.GetFileName(txtHinhAnh.Text);
            string destinationPath = Path.Combine(Application.StartupPath, "Image", selectedFileName);

            // Kiểm tra xem hình ảnh đã tồn tại trong thư mục không
            if (File.Exists(destinationPath))
            {
                MessageBox.Show("Hình ảnh đã tồn tại. Vui lòng chọn hình ảnh khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Ngừng thực hiện nếu hình ảnh đã tồn tại
            }			

            try
            {
                // Copy the selected file to the "Image" folder
                File.Copy(txtHinhAnh.Text, destinationPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi sao chép hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngừng thực hiện nếu có lỗi
            }

            // Thêm sản phẩm
            BUSSanPham.Instance.Them(txtMaSP, txtTenSP, cboTenLoai, cboTenHang, txtGiaBan, txtHinhAnh, txtGhiChu, txtGiamGia);
            LoadSanPham();
            txtMaSP.Text = null;
            txtTenSP.Text = null;
            cboTenLoai.SelectedIndex = -1;
            cboTenHang.SelectedIndex = -1;
            txtGiaBan.Text = null;
            txtHinhAnh.Text = null;
            txtGhiChu.Text = null;
            picHinhAnh.Image = null;
            picBarcode.Image = null;
        }

        private void cboTenHang_KeyUp(object sender, KeyEventArgs e)
        {
            BUSSanPham.Instance.AutoTimKiemTenNCC(cboTenHang);
        }

        private void cboTenLoai_KeyUp(object sender, KeyEventArgs e)
        {
            BUSSanPham.Instance.AutoTimKiemTenLoai(cboTenLoai);
        }
    }
}
