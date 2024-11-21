using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuyenDe
{
	public partial class frmThongKeLuongNhanVien : Form
	{
		public frmThongKeLuongNhanVien()
		{
			InitializeComponent();
		}

        private void LoadMaCH()
        {
            BUS_ThongKeLuongNhanVienTheoCH.Instance.LoadMaCH(cbMaCH);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BUS_ThongKeLuongNhanVienTheoCH.Instance.ThongKeLuongNVTheoCH(cbMaCH, dgvLuongNhanVien);
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbMaCH.SelectedIndex = -1;
            dgvLuongNhanVien.DataSource = null;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void frmThongKeLuongNhanVien_Load(object sender, EventArgs e)
        {
            // Cấu hình AutoComplete cho TextBox txtMaNV
            cbMaCH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaCH.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Tạo AutoCompleteStringCollection để chứa dữ liệu
            AutoCompleteStringCollection dataMaNV = new AutoCompleteStringCollection();
            dataMaNV.AddRange(LayDanhSachMaCH()); // Lấy danh sách mã nhân viên và thêm vào AutoComplete
            cbMaCH.AutoCompleteCustomSource = dataMaNV;
            LoadMaCH();
            cbMaCH.SelectedIndex = -1;
        }

        private string[] LayDanhSachMaCH()
        {
            // Giả sử phương thức LoadMaNV() trả về danh sách mã nhân viên từ cơ sở dữ liệu
            List<string> danhSachMaNV = DAO_ThongKeLuongNhanVienTheoCH.Instance.LoadMaCH();
            return danhSachMaNV.ToArray();
        }
    }
}
