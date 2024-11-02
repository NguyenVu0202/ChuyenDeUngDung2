using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAOTimKiemHoaDon
    {
        private static DAOTimKiemHoaDon instance;

        public static DAOTimKiemHoaDon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAOTimKiemHoaDon();
                }
                return instance;
            }
        }

        public DAOTimKiemHoaDon() { }
        public List<HoaDon> TimKiemHoaDonTheoMaHD(string mahd)
        {
            List<HoaDon> lst = new List<HoaDon>();

            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var hoadon = (from hd in db.HoaDons
                              where hd.MaHD == int.Parse(mahd)
                              select new
                              {
                                  hd.MaHD,
                                  hd.NgayBan,
                                  hd.TongTien,
                                  hd.MaKH,
                                  hd.MaNV
                              }).ToList();
                if(hoadon.Count > 0)
                {
                    foreach (var item in hoadon)
                    {
                        HoaDon h = new HoaDon();
                        h.MaHD = item.MaHD;
                        h.NgayBan = item.NgayBan;
                        h.TongTien = item.TongTien;
                        h.MaKH = item.MaKH;
                        h.MaNV = item.MaNV;
                        lst.Add(h);
                    }
                }    
                else
                {
                    MessageBox.Show("Mã hóa đơn không tồn tại!");
                }    
            }
            return lst;
        }

        public List<HoaDon> TimKiemHoaDonTheoMaKH(string makh)
        {
            List<HoaDon> lst = new List<HoaDon>();

            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var hoadon = (from hd in db.HoaDons
                              where hd.MaKH == makh
                              select new
                              {
                                  hd.MaHD,
                                  hd.NgayBan,
                                  hd.TongTien,
                                  hd.MaKH,
                                  hd.MaNV
                              }).ToList();
                if(hoadon.Count > 0)
                {
                    foreach (var item in hoadon)
                    {
                        HoaDon h = new HoaDon();
                        h.MaHD = item.MaHD;
                        h.NgayBan = item.NgayBan;
                        h.TongTien = item.TongTien;
                        h.MaKH = item.MaKH;
                        h.MaNV = item.MaNV;
                        lst.Add(h);
                    }
                }
                else
                {
                    MessageBox.Show("Mã khách hàng không tồn tại!");
                }    
            }
            return lst;
        }

        public List<HoaDon> TimKiemHoaDonTheoNgayBan(string ngayban)
        {
            List<HoaDon> lst = new List<HoaDon>();

            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var ngayBanFormatted = Convert.ToDateTime(ngayban).ToString("yyyy/MM/dd");
                var hoadon = (from hd in db.HoaDons
                              where hd.NgayBan == Convert.ToDateTime(ngayBanFormatted)
                              select new
                              {
                                  hd.MaHD,
                                  hd.NgayBan,
                                  hd.TongTien,
                                  hd.MaKH,
                                  hd.MaNV
                              }).ToList();
                foreach (var item in hoadon)
                {
                    HoaDon h = new HoaDon();
                    h.MaHD = item.MaHD;
                    h.NgayBan = item.NgayBan;
                    h.TongTien = item.TongTien;
                    h.MaKH = item.MaKH;
                    h.MaNV = item.MaNV;
                    lst.Add(h);
                }
            }
            return lst;
        }
    }
}
