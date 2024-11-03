using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ThongKeLuongNhanVienTheoCH
    {
        private static DAO_ThongKeLuongNhanVienTheoCH instance;

        public static DAO_ThongKeLuongNhanVienTheoCH Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_ThongKeLuongNhanVienTheoCH();
                return instance;
            }
        }
        private DAO_ThongKeLuongNhanVienTheoCH() { }

        public List<string> LoadMaCH()
        {
            List<string> list = new List<string>();

            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var mach = (from ch in db.CuaHangs
                            select new
                            {
                                ch.MaCH
                            }).ToList();

                foreach (var item in mach)
                {
                    list.Add(item.MaCH);
                }
            }
            return list;
        }

        public List<NhanVien> ThongKeLuongNVTheoCH(string maCH)
        {
            List<NhanVien> list = new List<NhanVien>();
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                // Truy vấn để lấy nhân viên theo MaCH và sắp xếp theo Luong giảm dần
                var nhanvien = (from nv in db.NhanViens
                                where nv.MaCH == maCH
                                orderby nv.Luong descending // Sắp xếp theo Luong từ cao xuống thấp
                                select new
                                {
                                    nv.MaNV,
                                    nv.TenNV,
                                    nv.GioiTinh,
                                    nv.NgaySinh,
                                    nv.SDT,
                                    nv.Luong,
                                    nv.DiaChi,
                                    nv.MaCH
                                }).ToList();

                if (nhanvien.Count > 0)
                {
                    foreach (var nv in nhanvien)
                    {
                        NhanVien nhanVien = new NhanVien
                        {
                            MaNV = nv.MaNV,
                            TenNV = nv.TenNV,
                            GioiTinh = nv.GioiTinh,
                            NgaySinh = nv.NgaySinh,
                            SDT = nv.SDT,
                            Luong = nv.Luong,
                            DiaChi = nv.DiaChi,
                            MaCH = nv.MaCH
                        };
                        list.Add(nhanVien);
                    }
                }
            }
            return list;
        }



    }
}
