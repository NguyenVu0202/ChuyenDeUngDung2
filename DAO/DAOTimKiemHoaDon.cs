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
        public class HoaDonDTO
        {
            public int MaHD { get; set; }
            public DateTime? NgayBan { get; set; }
            public decimal TongTien { get; set; }
            public string MaKH { get; set; }
            public string TenNV { get; set; }
        }
        public List<HoaDonDTO> TimKiemHoaDonTheoMaHD(string mahd, string mach)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();

            using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
            {
                var hoadon = (from hd in db.HoaDons
                              join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                              join ch in db.CuaHangs on nv.MaCH equals ch.MaCH
                              where hd.MaHD == int.Parse(mahd) && ch.MaCH == mach
                              select new
                              {
                                  hd.MaHD,
                                  hd.NgayBan,
                                  hd.TongTien,
                                  hd.MaKH,
                                  nv.TenNV,
                              }).ToList();
                if(hoadon.Count > 0)
                {
                    foreach (var item in hoadon)
                    {
                        HoaDonDTO h = new HoaDonDTO();
                        h.MaHD = item.MaHD;
                        h.NgayBan = item.NgayBan;
                        h.TongTien = (decimal)item.TongTien;
                        h.MaKH = item.MaKH;
                        h.TenNV = item.TenNV;
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

        public List<HoaDonDTO> TimKiemHoaDonTheoMaKH(string makh, string mach)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();

            using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
            {
                var hoadon = (from hd in db.HoaDons
                              join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                              join ch in db.CuaHangs on nv.MaCH equals ch.MaCH
                              where hd.MaKH == makh && ch.MaCH == mach
                              select new
                              {
                                  hd.MaHD,
                                  hd.NgayBan,
                                  hd.TongTien,
                                  hd.MaKH,
                                  nv.TenNV,
                              }).ToList();
                if(hoadon.Count > 0)
                {
                    foreach (var item in hoadon)
                    {
                        HoaDonDTO h = new HoaDonDTO();
                        h.MaHD = item.MaHD;
                        h.NgayBan = item.NgayBan;
                        h.TongTien = (decimal)item.TongTien;
                        h.MaKH = item.MaKH;
                        h.TenNV = item.TenNV;
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

        public List<HoaDonDTO> TimKiemHoaDonTheoNgayBan(string ngayban, string mach)
        {
            List<HoaDonDTO> lst = new List<HoaDonDTO>();

            using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
            {
                var ngayBanFormatted = Convert.ToDateTime(ngayban).ToString("yyyy/MM/dd");
                var hoadon = (from hd in db.HoaDons
                              join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                              join ch in db.CuaHangs on nv.MaCH equals ch.MaCH
                              where hd.NgayBan == Convert.ToDateTime(ngayBanFormatted) && ch.MaCH == mach
                              select new
                              {
                                  hd.MaHD,
                                  hd.NgayBan,
                                  hd.TongTien,
                                  hd.MaKH,
                                  nv.TenNV
                              }).ToList();
                foreach (var item in hoadon)
                {
                    HoaDonDTO h = new HoaDonDTO();
                    h.MaHD = item.MaHD;
                    h.NgayBan = item.NgayBan;
                    h.TongTien = (decimal)item.TongTien;
                    h.MaKH = item.MaKH;
                    h.TenNV = item.TenNV;
                    lst.Add(h);
                }
            }
            return lst;
        }
        public string MaCuaHang(string manv)
        {
            using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
            {
                var mch = db.NhanViens.FirstOrDefault(x => x.MaNV ==  manv);
                string mach = mch.MaCH;
                return mach;
            }
        }
    }
}
