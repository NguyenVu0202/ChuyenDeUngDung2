using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAO.DAOHoaDon;

namespace DAO
{
    public class DAOThongKeSanPhamDaBan
    {
        private static DAOThongKeSanPhamDaBan instance;
        DataBHXDataContext db = new DataBHXDataContext();

        public static DAOThongKeSanPhamDaBan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAOThongKeSanPhamDaBan();
                }
                return instance;
            }
        }

        public DAOThongKeSanPhamDaBan() { }
        public List<ChiTietHoaDonDTO> ThongKe(string maCH, DateTime startDate, DateTime endDate)
        {
            List<ChiTietHoaDonDTO> thongke = new List<ChiTietHoaDonDTO>();

            var salesData = from ct in db.ChiTietHoaDons
                            join sp in db.SanPhams on ct.MaSP equals sp.MaSP
                            join hd in db.HoaDons on ct.MaHD equals hd.MaHD
                            join nv in db.NhanViens on hd.MaNV equals nv.MaNV // Kết nối với bảng Nhân Viên
                            where hd.NgayBan >= startDate && hd.NgayBan <= endDate
                                  && nv.MaCH == maCH // Lọc theo mã cửa hàng từ bảng Nhân Viên
                            group new { ct, sp } by new { ct.MaSP, sp.TenSP, sp.GiaBan, ct.GiamGia } into g
                            select new
                            {
                                g.Key.MaSP,
                                g.Key.TenSP,
                                tongsluong = g.Sum(x => x.ct.SoLuong),
                                tongtien = g.Sum(x => x.ct.ThanhTien), // Nếu bạn có trường ThanhTien trong ChiTietHoaDon
                                gia = g.Key.GiaBan, // Lấy giá từ sản phẩm
                                giam = g.Key.GiamGia // Lấy giảm giá từ sản phẩm
                            };

            foreach (var item in salesData)
            {
                ChiTietHoaDonDTO statistic = new ChiTietHoaDonDTO
                {
                    MaSP = item.MaSP,
                    TenSP = item.TenSP,
                    SoLuong = (decimal)item.tongsluong,
                    ThanhTien = (decimal)item.tongtien,
                    GiaSP = (decimal)item.gia, // Gán giá
                    GiamGia = (decimal)item.giam // Gán giảm giá
                };
                thongke.Add(statistic);
            }

            return thongke;
        }

        public List<SanPham> TimSanPham(string maSP, string tenSP)
        {
            var sanPhams = (from sp in db.SanPhams
                            where (string.IsNullOrWhiteSpace(maSP) || sp.MaSP == maSP) &&
                                  (string.IsNullOrWhiteSpace(tenSP) || sp.TenSP == tenSP) // Tìm kiếm bằng mã và tên sản phẩm
                            select new
                            {
                                sp.MaSP,
                                sp.TenSP,
                                sp.MaLoai,
                                sp.MaNCC,
                                sp.GiaBan,
                                sp.HinhAnh,
                                sp.GhiChu
                            }).ToList();

            List<SanPham> result = new List<SanPham>();
            foreach (var item in sanPhams)
            {
                SanPham sanPham = new SanPham
                {
                    MaSP = item.MaSP,
                    TenSP = item.TenSP,
                    MaLoai = item.MaLoai,
                    MaNCC = item.MaNCC,
                    GiaBan = item.GiaBan,
                    HinhAnh = item.HinhAnh,
                    GhiChu = item.GhiChu
                };
                result.Add(sanPham);
            }
            return result;
        }
        public List<CuaHang> CuaHangByMa(string cuahang)
        {
            return db.CuaHangs
                .Where(kh => kh.MaCH.Contains(cuahang))
                .ToList();
        }
    }
}
