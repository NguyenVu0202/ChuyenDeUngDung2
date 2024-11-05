using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using static DAO.DAOHoaDon;

namespace BUS
{
    public class BUSThongKeSanPhamDaBan
    {
        private DAOThongKeSanPhamDaBan dao = new DAOThongKeSanPhamDaBan();
        private static BUSThongKeSanPhamDaBan instance;

        public static BUSThongKeSanPhamDaBan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUSThongKeSanPhamDaBan();
                }
                return instance;
            }
        }

        public BUSThongKeSanPhamDaBan() { }

        public List<ChiTietHoaDonDTO> ThongKe(string maCH, DateTime startDate, DateTime endDate) { return dao.ThongKe(maCH, startDate, endDate); }
        public List<CuaHang> CuaHangByMa(string cuahang) { return dao.CuaHangByMa(cuahang); }
    }
}
