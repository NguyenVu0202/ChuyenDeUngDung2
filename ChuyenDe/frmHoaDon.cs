using AForge.Video;
using AForge.Video.DirectShow;
using BUS;
using DAO;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace ChuyenDe
{
	public partial class frmHoaDon : Form
	{
		private string manv = "";
        private string masp = "";
        private string soluong = "";
        private string makh = "";
        private string mabarcode;
        private FilterInfoCollection FilterInfoCollection; //bien luu thong tin cac thiet bi video
        private VideoCaptureDevice VideoCaptureDevice; //bien tuong tac voi cac thiet bi video
        public frmHoaDon()
		{
			InitializeComponent();
		}
        public frmHoaDon(string manv)
        {
            InitializeComponent();
			this.manv = manv;
        }
		public void LoadKH()
		{
			List<string> list = new List<string>();
			list = BUSHoaDon.Instance.LoadKhachHang(txtMaKH);
			if (list != null && list.Count >= 2)
			{
                txtTenKH.Text = list[0].ToString();
                txtSDTKH.Text = list[1].ToString();
            }
            else
            {
                txtError.Text = "Khách Hàng Không Tồn Tại, Vui Lòng Nhập Lại!";
                txtMaKH.Text = "";
            }
        }
        public void LoadSP()
        {
            List<string> list = new List<string>();
            list = BUSHoaDon.Instance.LoadSanPham(txtMaSP);
            if (list != null && list.Count >= 3)
            {
                txtTenSP.Text = list[0].ToString();
                txtGiaSP.Text = list[1].ToString();
                txtGiamGia.Text = list[2].ToString();
            }
            else
            {
                txtError.Text = "Sản Phẩm Không Tồn Tại, Vui Lòng Nhập Lại!";
                txtMaKH.Text = "";
            }
        }
        public void TongTienSauKhiGiam()
        {
            if (decimal.TryParse(txtGiaSP.Text, out decimal giasp) &&
                decimal.TryParse(txtSoLuong.Text, out decimal soluong) &&
                decimal.TryParse(txtGiamGia.Text, out decimal giamgia) &&
                giamgia <= 100)
            {
                decimal tienTruocGiamGia = giasp * soluong;
                decimal giamGia = (tienTruocGiamGia * giamgia) / 100;
                decimal tongtien = tienTruocGiamGia - giamGia;
                decimal tongtienNguyen = Math.Floor(tongtien);

                txtTienSauKhiGiam.Text = tongtienNguyen.ToString();
            }
            else
            {
                decimal tienTruocGiamGia = giasp * decimal.Parse(txtSoLuong.Text);
                decimal giamGia = 0;
                decimal tongtien = tienTruocGiamGia - giamGia;
                decimal tongtienNguyen = Math.Floor(tongtien);

                txtTienSauKhiGiam.Text = tongtienNguyen.ToString();
            }
        }
        public void TaoHoaDon()
        {
            BUSHoaDon.Instance.TaoHoaDon(manv);
        }

        private void txtMaKH_Leave(object sender, EventArgs e)
        {
			LoadKH();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            TaoHoaDon();
            LoadChiTietHoaDon();
            TinhTongTien();
            LoadCamera();
        }

        private void txtMaSP_Leave(object sender, EventArgs e)
        {
            LoadSP();
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            BUSHoaDon.Instance.XoaHoaDon();
            TatCamera();
        }
        private void LoadChiTietHoaDon()
        {
            BUSHoaDon.Instance.LoadChiTietHoaDon(dgvDanhSachHoaDon);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string masp = txtMaSP.Text;
            string soluong = txtSoLuong.Text;
            string giamgia = txtGiamGia.Text;
            makh = txtMaKH.Text;
            decimal sl = KiemtraslSanPham();

            if (string.IsNullOrWhiteSpace(masp) || string.IsNullOrWhiteSpace(soluong))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            // Kiểm tra khoảng trắng đầu và cuối trong maSP
            if (masp != masp.Trim())
            {
                MessageBox.Show("Mã sản phẩm không được có khoảng trắng ở đầu hoặc cuối.");
                return;
            }
            // Kiểm tra khoảng trắng đầu và cuối trong maKH
            if (makh != makh.Trim())
            {
                MessageBox.Show("Mã khách hàng không được có khoảng trắng ở đầu hoặc cuối.");
                return;
            }
            // Kiểm tra khoảng trắng đầu và cuối trong soLuong
            if (soluong != soluong.Trim())
            {
                MessageBox.Show("Số lượng không được có khoảng trắng ở đầu hoặc cuối.");
                return;
            }
            // Kiểm tra khoảng trắng đầu và cuối trong giamGia
            if (giamgia != giamgia.Trim())
            {
                MessageBox.Show("Giảm giá không được có khoảng trắng ở đầu hoặc cuối.");
                return;
            }
            // Kiểm tra khoảng trắng liên tiếp trong maSP
            if (Regex.IsMatch(masp, @"\s{2,}"))
            {
                MessageBox.Show("Mã sản phẩm không được có hai khoảng trắng liên tiếp.");
                return;
            }
            // Kiểm tra khoảng trắng liên tiếp trong maKH
            if (Regex.IsMatch(makh, @"\s{2,}"))
            {
                MessageBox.Show("Mã khách hàng không được có hai khoảng trắng liên tiếp.");
                return;
            }
            // Kiểm tra khoảng trắng liên tiếp trong soLuong
            if (Regex.IsMatch(soluong, @"\s{2,}"))
            {
                MessageBox.Show("Số lượng không được có hai khoảng trắng liên tiếp.");
                return;
            }
            // Kiểm tra khoảng trắng liên tiếp trong giamGia
            if (Regex.IsMatch(giamgia, @"\s{2,}"))
            {
                MessageBox.Show("Giảm giá không được có hai khoảng trắng liên tiếp.");
                return;
            }
            // Kiểm tra số lượng chỉ được là số
            if (!decimal.TryParse(soluong, out _))
            {
                MessageBox.Show("Số lượng chỉ được là số.");
                return;
            }
            // Kiểm tra giảm giá chỉ được là số
            if (!decimal.TryParse(soluong, out _))
            {
                MessageBox.Show("Giảm giá chỉ được là số.");
                return;
            }
            // Kiểm tra số lượng không được quá 18 chữ số
            if (soluong.Length > 18)
            {
                MessageBox.Show("Số lượng không được quá 18 chữ số");
                return;
            }
            // Kiểm tra giảm giá không được quá 18 chữ số
            if (giamgia.Length > 18)
            {
                MessageBox.Show("Giảm giá không được quá 18 chữ số");
                return;
            }
            // Kiểm tra số lượng phải khác 0
            if (soluong.Trim() == "0")
            {
                MessageBox.Show("Số lượng phải khác 0!");
                return;
            }
            if(txtGiamGia.Text == "")
            {
               if(sl != 0)
                {
                    txtGiamGia.Text = "0";
                    BUSHoaDon.Instance.ThemSanPham(txtMaSP, txtSoLuong, txtGiaSP, txtGiamGia, txtTienSauKhiGiam, txtMaKH);
                }    
            }  
            else
            {
                if (sl != 0)
                {
                    BUSHoaDon.Instance.ThemSanPham(txtMaSP, txtSoLuong, txtGiaSP, txtGiamGia, txtTienSauKhiGiam, txtMaKH);
                }
            }             
            LoadChiTietHoaDon();
            TinhTongTien();
            TruSanPhamTrongKho();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtTienSauKhiGiam.Text = "";
            txtMaSP.Focus();
        }
        private void TinhTongTien()
        {
            txtTongTienHD.Text = BUSHoaDon.Instance.TinhTongTienHD().ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            BUSHoaDon.Instance.ThanhToan(makh);
            LoadChiTietHoaDon();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtTienSauKhiGiam.Text = "";
            txtTongTienHD.Text = "";
            txtSDTKH.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtMaSP.Focus();
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //Nhan frame hinh anh tu camera
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader(); //Tao doi tuong doc barcode
            var result = reader.Decode(bitmap); //Doc barcode tu hinh anh
            if (result != null)
            {
                txtMaSP.Invoke(new MethodInvoker(delegate ()
                {
                    txtMaSP.Text = result.ToString(); //Hien thi ket qua doc duoc len textboxMaDocDuoc
                    txtMaSP.Focus();
                }));
            }
            picCamera.Image = bitmap; //Hien thi frame hinh anh len tren picturebox
        }
        private void TatCamera()
        {
            if (VideoCaptureDevice != null)
            {
                if (VideoCaptureDevice.IsRunning)
                {
                    VideoCaptureDevice.Stop();
                    picCamera.Image = null;
                }
            }
        }
        private void LoadCamera()
        {
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in FilterInfoCollection)
            {
                cboCamera.Items.Add(Device.Name);
                cboCamera.SelectedIndex = 0;
                VideoCaptureDevice = new VideoCaptureDevice();
            }
        }
        private void btnQuetMa_Click(object sender, EventArgs e)
        {
            //Khoi tao thiet bi video, dua tren thiet bi duoc con tu comboboxCamera
            VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[cboCamera.SelectedIndex].MonikerString);

            //Dang ky nhan du lieu frame moi tu Camera
            VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            VideoCaptureDevice.Start();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát không????", "Thông Báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            BUSHoaDon.Instance.XoaCTHD(masp);
            CongSanPhamTrongKho();
            TinhTongTien();
            LoadChiTietHoaDon();
        }
        private void dgvDanhSachHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = dgvDanhSachHoaDon.SelectedCells[0].RowIndex;
            var row = dgvDanhSachHoaDon.Rows[rowIndex];
            masp = row.Cells[0].Value.ToString().Trim();
            soluong = row.Cells[2].Value.ToString().Trim();
        }
        private void TruSanPhamTrongKho()
        {
            BUSHoaDon.Instance.TruSanPhamTrongKho(manv, txtMaSP, txtSoLuong.Text);
        }
        private void CongSanPhamTrongKho()
        {
            BUSHoaDon.Instance.CongSanPhamTrongKho(manv, masp, soluong);
        }
        private decimal KiemtraslSanPham()
        {
            return BUSHoaDon.Instance.KiemtraslSanPham(manv, txtMaSP);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {           
            frmReportHoaDon frm = new frmReportHoaDon();
            BUSHoaDon.Instance.XoaHoaDon();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            // Assuming 'txtSoLuong' is the TextBox from which 'soluong' is obtained
            string soluong = txtSoLuong.Text;

            if (string.IsNullOrWhiteSpace(soluong) || soluong == "0")
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                txtSoLuong.Text = "";
                return;
            }

            if (!int.TryParse(soluong, out int parsedSoluong) || parsedSoluong <= 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên dương!");
                txtSoLuong.Text = "";
                return;
            }

            if (Regex.IsMatch(soluong, @"\s{2,}"))
            {
                MessageBox.Show("Số lượng không được có hai khoảng trắng liên tiếp.");
                txtSoLuong.Text = "";
                return;
            }

            if (soluong != soluong.Trim())
            {
                MessageBox.Show("Số lượng không được có khoảng trắng ở đầu hoặc cuối.");
                txtSoLuong.Text = "";
                return;
            }

            // Passed all validations
            TongTienSauKhiGiam();
        }
    }
}
