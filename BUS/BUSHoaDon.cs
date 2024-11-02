using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUSHoaDon
    {
        private static BUSHoaDon instance;
        public static BUSHoaDon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUSHoaDon();
                }
                return instance;
            }

        }

        private BUSHoaDon() { }
        public List<string> LoadKhachHang(TextBox maKH)
        {
            List<string> list = new List<string>();
            list = DAOHoaDon.Instance.LoadKhachHang(maKH.Text);
            return list;
        }
        public List<string> LoadSanPham(TextBox maSP)
        {
            List<string> list = new List<string>();
            list = DAOHoaDon.Instance.LoadSanPham(maSP.Text);
            return list;
        }
        public void TaoHoaDon(string manv)
        {
            DAOHoaDon.Instance.TaoHoaDon(manv);
        }
        public void XoaHoaDon()
        {
            DAOHoaDon.Instance.XoaHoaDon();
        }
        public void LoadChiTietHoaDon(DataGridView data)
        {
            data.DataSource = DAOHoaDon.Instance.LoadChiTietHoaDon();
        }
        public void ThemSanPham(TextBox masp, TextBox soluong, TextBox giasp, TextBox giamgia, TextBox thanhtien, TextBox makh)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon
            {
                MaSP = masp.Text,
                SoLuong = decimal.Parse(soluong.Text),
                GiaSP = decimal.Parse(giasp.Text),
                GiamGia = int.Parse(giamgia.Text),
                ThanhTien = decimal.Parse(thanhtien.Text)
            };
            DAOHoaDon.Instance.ThemSanPham(cthd, makh.Text);
        }
        public decimal TinhTongTienHD()
        {
            return DAOHoaDon.Instance.TinhTongTienHD();
        }
        public void ThanhToan()
        {
            DAOHoaDon.Instance.ThanhToan();
        }
        public void XoaCTHD(string masp)
        {
            DAOHoaDon.Instance.XoaCTHD(masp);
        }
        public void TruSanPhamTrongKho(string manv, TextBox masp, string soluong)
        {
            DAOHoaDon.Instance.TruSanPhamTrongKho(manv, masp.Text, soluong);
        }
        public void CongSanPhamTrongKho(string manv, string masp, string soluong)
        {
            DAOHoaDon.Instance.CongSanPhamTrongKho(manv, masp, soluong);
        }
        public decimal KiemtraslSanPham(string manv, TextBox masp)
        {
            return DAOHoaDon.Instance.KiemtraslSanPham(manv, masp.Text);
        }
    }
}
