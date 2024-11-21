using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_ThongKeLuongNhanVienTheoCH
    {
        private static BUS_ThongKeLuongNhanVienTheoCH instance;

        public static BUS_ThongKeLuongNhanVienTheoCH Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_ThongKeLuongNhanVienTheoCH();
                return instance;
            }
        }
        private BUS_ThongKeLuongNhanVienTheoCH() { }

        public void ThongKeLuongNVTheoCH(ComboBox maCH, DataGridView data)
        {
            var dt = DAO_ThongKeLuongNhanVienTheoCH.Instance.ThongKeLuongNVTheoCH(maCH.Text).Select(t =>
            {
                return new
                {
                    MaNV = t.MaNV,
                    TenNV = t.TenNV,
                    GioiTinh = t.GioiTinh,
                    NgaySinh = t.NgaySinh,
                    SDT = t.SDT,
                    Luong = t.Luong,
                    DiaChi = t.DiaChi,
                    MaCH = t.MaCH,
                };
            }).ToList();
            data.DataSource = dt;
        }

        public void LoadMaCH(ComboBox cb)
        {
            cb.DataSource = DAO_ThongKeLuongNhanVienTheoCH.Instance.LoadMaCH();
        }
    }
}
