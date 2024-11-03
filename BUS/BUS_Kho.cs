using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_Kho
    {
        private static BUS_Kho instance;

        public static BUS_Kho Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_Kho();
                }
                return instance;
            }
        }

        // Load dgv
        //public void Xem(DataGridView data)
        //{
        //    var dt = DAO_Kho.Instance.Xem().Select(t =>
        //    {


        //        return new
        //        {
        //            t.MaKho,
        //            t.MaCH,
        //            t.MaSP,
        //            t.SoLuong,

        //        };
        //    }).ToList();
        //    data.DataSource = dt;
        //}

        public List<object> GetKhoWithProductName()
        {
            return DAO_Kho.Instance.GetKhoWithProductName();
        }

        //Load Combobox San Pham
        public void LoadSanPham(ComboBox cb)
        {
            DAO_Kho.Instance.LoadCbMaSP(cb);
        }

        //Load Combobox Cua Hang
        public void LoadCuaHang(ComboBox cb)
        {
            DAO_Kho.Instance.LoadCbMaCH(cb);
        }

        //Them Kho
        public void ThemKho(string maKho, string maCH, string maSP, decimal soLuong)
        {
            // Kiểm tra xem tên sản phẩm có tồn tại hay không
            string tenSanPham = DAO_Kho.Instance.GetTenSanPham(maSP);
            if (string.IsNullOrEmpty(tenSanPham))
            {
                MessageBox.Show("Mã sản phẩm không tồn tại");
                return;
            }

            // Tạo đối tượng Kho và gán các giá trị
            Kho kho = new Kho
            {
                MaKho = maKho,
                MaCH = maCH,
                MaSP = maSP,
                SoLuong = soLuong
            };

            // Thêm vào kho qua lớp DAO_Kho
            bool isSuccess = DAO_Kho.Instance.ThemKho(kho);
            if (isSuccess)
            {
                MessageBox.Show("Thêm Thành Công.");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại Trùng Sản Phẩm");
            }
        }

        //Xoa Kho
        public void XoaKho(TextBox maKho)
        {
            DAO_Kho.Instance.XoaKho(maKho.Text);
        }

        public void LoadDgvLenForm(TextBox maKho, ComboBox maCH, ComboBox maSP, TextBox soLuong, DataGridView data)
        {
            DAO_Kho.Instance.LoadDgvLenForm(maKho, maCH, maSP, soLuong, data);
        }

        //Tim kiếm kho
        public void TimKiemMaKho(TextBox makho, DataGridView data)
        {
            data.DataSource = DAO.DAO_Kho.Instance.TimKiemMaKho(makho.Text);
        }

        public bool KiemTraTonTaiKho(string maCH, string maKho)
        {
            return DAO_Kho.Instance.KiemTraTonTaiKho(maCH, maKho);
        }

    }
}
