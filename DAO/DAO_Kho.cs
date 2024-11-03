using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_Kho
    {
        private static DAO_Kho instance;
        public static DAO_Kho Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_Kho();
                }
                return instance;
            }

        }

        private DAO_Kho() { }

        //Load Combobox MaSP
        public void LoadCbMaSP(ComboBox cb)
        {
            Dictionary<string, string> lst = new Dictionary<string, string>();
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var tenSP = from sp in db.SanPhams
                            select new
                            {
                                sp.MaSP,
                                sp.TenSP,
                            };
                foreach (var item in tenSP)
                {
                    lst.Add(item.MaSP, item.TenSP);
                }
                cb.DataSource = new BindingSource(lst, null);
                cb.DisplayMember = "Value";
                cb.ValueMember = "Key";
            }
        }

        //Load Combobox MaCH
        public void LoadCbMaCH(ComboBox cb)
        {
            List<string> lst = new List<string>();
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var mach = from k in db.CuaHangs
                           select new { k.MaCH };
                foreach (var item in mach)
                {
                    lst.Add(item.MaCH);
                }
                cb.DataSource = lst;
            }
        }

        //Hien Thi Kho
        //public List<Kho> Xem()
        //{
        //    List<Kho> sp = new List<Kho>();

        //    using (DataBHXDataContext db = new DataBHXDataContext())
        //    {
        //        var kho = (from kh in db.Khos

        //                   select new
        //                   {
        //                       kh.MaKho,
        //                       kh.MaCH,
        //                       kh.MaSP,

        //                       kh.SoLuong,
        //                   }).ToList();

        //        foreach (var item in kho)
        //        {
        //            Kho khos = new Kho();
        //            khos.MaKho = item.MaKho;
        //            khos.MaCH = item.MaCH;
        //            khos.MaSP = item.MaSP;
        //            khos.SoLuong = item.SoLuong;
        //            sp.Add(khos);
        //        }
        //    }
        //    return sp;
        //}

        public List<object> GetKhoWithProductName()
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var query = from kho in db.Khos
                            join sanPham in db.SanPhams on kho.MaSP equals sanPham.MaSP
                            select new
                            {
                                kho.MaKho,
                                kho.MaCH,
                                kho.MaSP,
                                sanPham.TenSP,
                                kho.SoLuong
                            };
                return query.ToList<object>();
            }
        }

        //Them Kho
        public bool ThemKho(Kho kho)
        {
            try
            {
                using (DataBHXDataContext db = new DataBHXDataContext())
                {
                    // Thêm đối tượng Kho vào cơ sở dữ liệu
                    db.Khos.InsertOnSubmit(kho);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string GetTenSanPham(string maSP)
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);
                return sanPham?.TenSP; // Trả về tên sản phẩm hoặc null nếu không tìm thấy
            }
        }


        public bool KiemTraTonTaiKho(string maKho, string maCH)
        {
            // Sử dụng LINQ to SQL để kiểm tra sự tồn tại của MaKho và MaCH trong bảng Kho
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                // Kiểm tra xem có bản ghi nào trong Kho có MaKho và MaCH tương ứng không
                return db.Khos.Any(k => k.MaKho == maKho && k.MaCH == maCH);
            }
        }

        //Xoa Kho
        public void XoaKho(string maKho)
        {
                try
                {
                    using (DataBHXDataContext db = new DataBHXDataContext())
                    {
                        var kho = db.Khos.FirstOrDefault(p => p.MaKho == maKho);
                        db.Khos.DeleteOnSubmit(kho);
                        db.SubmitChanges();
                        MessageBox.Show("Xóa Thành Công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa Thất Bại" + ex.Message);
                }
        }

        public void LoadDgvLenForm(TextBox maKho, ComboBox maCH, ComboBox maSP, TextBox soLuong, DataGridView data)
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var rowIndex = data.SelectedCells[0].RowIndex;
                var row = data.Rows[rowIndex];
                maKho.Text = row.Cells[0].Value.ToString().Trim();
                maCH.Text = row.Cells[1].Value.ToString().Trim();
                var sp = (from s in db.SanPhams
                          where s.MaSP == row.Cells[2].Value.ToString().Trim()
                          select s.TenSP).FirstOrDefault();
                maSP.Text = sp.ToString();
                soLuong.Text = row.Cells[4].Value.ToString().Trim();
            }
        }

        //Tìm kiếm kho theo MaKho
        public DataTable TimKiemMaKho(string makho)
        {
            DataTable table = new DataTable();

            // Define the columns of the DataTable
            table.Columns.Add("MaKho", typeof(string));
            table.Columns.Add("MaCH", typeof(string));
            table.Columns.Add("DiaChi", typeof(string));
            table.Columns.Add("MaSP", typeof(string));
            table.Columns.Add("TenSP", typeof(string));
            table.Columns.Add("HinhAnh", typeof(string));
            table.Columns.Add("SoLuong", typeof(decimal));
            DataBHXDataContext db = new DataBHXDataContext();
            var kho = (from sp in db.SanPhams
                       join k in db.Khos on sp.MaSP equals k.MaSP
                       join ch in db.CuaHangs on k.MaCH equals ch.MaCH
                       where k.MaKho == makho
                       select new
                       {
                           k.MaKho,
                           k.MaCH,
                           ch.DiaChi,
                           k.MaSP,
                           sp.TenSP,
                           k.SoLuong
                       }).ToList();
            if (kho != null)
            {
                foreach (var item in kho)
                {
                    DataRow row = table.NewRow();
                    row["MaKho"] = item.MaKho;
                    row["MaCH"] = item.MaCH;
                    row["DiaChi"] = item.DiaChi;
                    row["MaSP"] = item.MaSP;
                    row["TenSP"] = item.TenSP;
                    row["SoLuong"] = item.SoLuong;
                    table.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Không có kho này!");
            }
            return table;
        }

        public List<string> LoadMaKho()
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                // Lấy danh sách MaNV từ bảng NhanVien và chuyển thành List<string>
                return db.Khos
                              .Select(nv => nv.MaKho)
                              .ToList();
            }
        }
    }
}
