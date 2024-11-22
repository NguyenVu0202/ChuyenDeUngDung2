using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BUSTimSanPham
    {
        private DAOTimSanPham sp = new DAOTimSanPham();
        private static BUSTimSanPham instance;

        public static BUSTimSanPham Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUSTimSanPham();
                }
                return instance;
            }
        }

        public BUSTimSanPham() { }
        public List<SanPham> TimSanPhamBangMa(string maSP) { return sp.TimSanPhamBangMa(maSP); }
        public List<SanPham> TimSanPhamBangTen(string tenSP) { return sp.TimSanPhamBangTen(tenSP); }
        public List<SanPham> TimSanPham(string maSP, string tenSP) { return sp.TimSanPham(maSP, tenSP); }
        public List<SanPham> TimKiemSanPhamByMa(string sanpham) { return sp.TimKiemSanPhamByMa(sanpham); }
        public List<SanPham> TimKiemSanPhamByTen(string sanpham) { return sp.TimKiemSanPhamByTen(sanpham); }
    }
}
