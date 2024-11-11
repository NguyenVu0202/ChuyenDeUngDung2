using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ThongKeDoanhThu
    {
        private static DAO_ThongKeDoanhThu instance;

        public static DAO_ThongKeDoanhThu Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new DAO_ThongKeDoanhThu();
                }
                return instance;
            }
        }
        public DAO_ThongKeDoanhThu() { }

        public List<string> LoadMaCH()
        {
            List<string> list = new List<string>();

            using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
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

        public DataTable ThongKeDoanhThu(string mach, string tungay, string toingay)
        {
            DataTable table = new DataTable();

            // Define the columns of the DataTable
            table.Columns.Add("MaCuaHang", typeof(string));
            table.Columns.Add("TongDoanhThu", typeof(decimal));
            table.Columns.Add("TuNgay", typeof(string));
            table.Columns.Add("DenNgay", typeof(string));

            using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
            {
                var tuNgayFormatted = Convert.ToDateTime(tungay);
                var toiNgayFormatted = Convert.ToDateTime(toingay);
                var thongke = from hd in db.HoaDons
                              join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                              join ch in db.CuaHangs on nv.MaCH equals ch.MaCH
                              where ch.MaCH == mach && hd.NgayBan >= tuNgayFormatted && hd.NgayBan <= toiNgayFormatted
                              group hd by new { ch.MaCH, tuNgayFormatted, toiNgayFormatted } into g
                              select new
                              {
                                  MaCuaHang = g.Key.MaCH,
                                  TongDoanhThu = g.Sum(x => x.TongTien),
                                  TuNgay = tuNgayFormatted.ToString("yyyy/MM/dd"),
                                  DenNgay = toiNgayFormatted.ToString("yyyy/MM/dd")
                              };
                foreach (var item in thongke)
                {
                    // Create a new row for each item in the result
                    DataRow row = table.NewRow();
                    row["MaCuaHang"] = item.MaCuaHang;
                    row["TongDoanhThu"] = item.TongDoanhThu;
                    row["TuNgay"] = item.TuNgay;
                    row["DenNgay"] = item.DenNgay;
                    table.Rows.Add(row);
                }
            }
            return table;
        }
    }
}
