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
                            }; 

            // Tạo một danh sách tạm để lưu trữ kết quả
            var tempList = new List<ChiTietHoaDonDTO>();

            foreach (var item in salesData)
            {
                ChiTietHoaDonDTO statistic = new ChiTietHoaDonDTO
                {
                    MaSP = item.MaSP,
                    TenSP = item.TenSP,
                    SoLuong = (decimal)item.tongsluong,
                    ThanhTien = (decimal)item.tongtien,
                };

                // Kiểm tra xem sản phẩm đã tồn tại trong danh sách tạm chưa
                var existingItem = tempList.FirstOrDefault(x => x.MaSP == statistic.MaSP);
                if (existingItem != null)
                {
                    // Nếu đã tồn tại, cộng dồn số lượng và thành tiền
                    existingItem.SoLuong += statistic.SoLuong;
                    existingItem.ThanhTien += statistic.ThanhTien;
                }
                else
                {
                    // Nếu chưa tồn tại, thêm mới vào danh sách
                    tempList.Add(statistic);
                }
            }

            // Gán lại danh sách tạm vào danh sách cuối cùng
            thongke = tempList;

            return thongke;
        }

    
        public List<CuaHang> CuaHangByMa(string cuahang)
        {
            return db.CuaHangs
                .Where(kh => kh.MaCH.Contains(cuahang))
                .ToList();
        }
    }
}
