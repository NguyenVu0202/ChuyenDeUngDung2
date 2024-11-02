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
        public void TimKiemHoaDonTheoMaHD(TextBox mahd, DataGridView data)
        {
            var dt = DAOTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaHD(mahd.Text).Select(t =>
            {
                return new
                {
                    t.MaHD,
                    t.NgayBan,
                    t.TongTien,
                    t.MaKH,
                    t.MaNV
                };
            }).ToList();
            data.DataSource = dt;
        }

        public void TimKiemHoaDonTheoMaKH(TextBox makh, DataGridView data)
        {
            var dt = DAOTimKiemHoaDon.Instance.TimKiemHoaDonTheoMaKH(makh.Text).Select(t =>
            {
                return new
                {
                    t.MaHD,
                    t.NgayBan,
                    t.TongTien,
                    t.MaKH,
                    t.MaNV
                };
            }).ToList();
            data.DataSource = dt;
        }

        public void TimKiemHoaDonTheoNgayBan(DateTimePicker ngayban, DataGridView data)
        {
            var dt = DAOTimKiemHoaDon.Instance.TimKiemHoaDonTheoNgayBan(ngayban.Text).Select(t =>
            {
                return new
                {
                    t.MaHD,
                    t.NgayBan,
                    t.TongTien,
                    t.MaKH,
                    t.MaNV
                };
            }).ToList();
            data.DataSource = dt;
        }
    }
}
