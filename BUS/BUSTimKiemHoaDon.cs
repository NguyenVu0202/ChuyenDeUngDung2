using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUSTimKiemHoaDon
    {
        private static BUSTimKiemHoaDon instance;

        public static BUSTimKiemHoaDon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUSTimKiemHoaDon();
                }
                return instance;
            }
        }

        public BUSTimKiemHoaDon() { }
        public void TimKiemHoaDonTheoMaHD(TextBox mahd, DataGridView data, string mach)
        {
            var dt = DAOTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaHD(mahd.Text, mach).Select(t =>
            {
                return new
                {
                    t.MaHD,
                    t.NgayBan,
                    t.TongTien,
                    t.MaKH,
                    t.TenNV
                };
            }).ToList();
            data.DataSource = dt;
        }

        public void TimKiemHoaDonTheoMaKH(string makh, DataGridView data, string mach)
        {
            var dt = DAOTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaKH(makh, mach).Select(t =>
            {
                return new
                {
                    t.MaHD,
                    t.NgayBan,
                    t.TongTien,
                    t.MaKH,
                    t.TenNV
                };
            }).ToList();
            data.DataSource = dt;
        }

        public void TimKiemHoaDonTheoNgayBan(DateTimePicker ngayban, DataGridView data, string mach)
        {
            var dt = DAOTimKiemHoaDon.Instance.TimKiemHoaDonTheoNgayBan(ngayban.Text, mach).Select(t =>
            {
                return new
                {
                    t.MaHD,
                    t.NgayBan,
                    t.TongTien,
                    t.MaKH,
                    t.TenNV
                };
            }).ToList();
            data.DataSource = dt;
        }
        public string MaCuaHang(string manv)
        {
            return DAOTimKiemHoaDon.Instance.MaCuaHang(manv);
        }
        public void AutoTimKiemMaKH(ComboBox cb)
        {
            DAOTimKiemHoaDon.Instance.AutoTimKiemMaKH(cb);
        }
    }
}
