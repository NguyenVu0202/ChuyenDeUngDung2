using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOTimSanPham
    {
        private static DAOTimSanPham instance;
        DataBHXDataContext db = new DataBHXDataContext();

        public static DAOTimSanPham Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAOTimSanPham();
                }
                return instance;
            }
        }

        public DAOTimSanPham() { }
        public List<SanPham> TimSanPhamBangMa(string maSP)
        {
            var sanPhams = (from sp in db.SanPhams
                            where sp.MaSP.Contains(maSP) // Tìm kiếm bằng mã sản phẩm
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
        public List<SanPham> TimSanPhamBangTen(string tenSp)
        {
            var sanPhams = (from sp in db.SanPhams
                            where sp.TenSP.Contains(tenSp) // Tìm kiếm bằng tên sản phẩm
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
        public List<SanPham> TimKiemSanPhamByMa(string sp)
        {
            return db.SanPhams
                .Where(kh => kh.MaSP.Contains(sp))
                .ToList();
        }
        public List<SanPham> TimKiemSanPhamByTen(string sp)
        {
            return db.SanPhams
                .Where(kh => kh.TenSP.Contains(sp))
                .ToList();
        }
    }
}
