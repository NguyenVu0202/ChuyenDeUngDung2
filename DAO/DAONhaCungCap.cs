using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAONhaCungCap
    {
        private static DAONhaCungCap instance;
        DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());
        public static DAONhaCungCap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAONhaCungCap();
                }
                return instance;
            }


        }
        public DAONhaCungCap() { }
        public List<NCC> View()
        {
            List<NCC> list = new List<NCC>();

            var ncc = (from el in db.NCCs
                       select new
                       {
                           el.MaNCC,
                           el.TenNCC,
                       }).ToList();

            foreach (var item in ncc)
            {
                NCC ncc1 = new NCC();
                ncc1.MaNCC = item.MaNCC;
                ncc1.TenNCC = item.TenNCC;
                list.Add(ncc1);
            }

            return list;
        }

        private const string kitu = "NCC";
        private string MaTuDong()
        {
            var lastNCC = db.NCCs
                             .Where(l => l.MaNCC.StartsWith(kitu))
                             .OrderByDescending(l => l.MaNCC)
                             .FirstOrDefault();
            if (lastNCC == null)
            {
                return $"{kitu}001";
            }

            string lastMa = lastNCC.MaNCC;

            if (!lastMa.StartsWith(kitu))
            {
                throw new Exception("Mã loại không hợp lệ.");
            }
            int number = int.Parse(lastMa.Substring(1));
            number++;
            return $"{kitu}{number:D3}";
        }
        public void Them(TextBox mancc, TextBox tenncc)
        {
            try
            {
                NCC ncc = new NCC();
                ncc.MaNCC = MaTuDong();
                ncc.TenNCC = tenncc.Text;
                db.NCCs.InsertOnSubmit(ncc);
                db.SubmitChanges();
                MessageBox.Show("Thêm Nhà Cung Cấp Thành Công");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi trùng mã");
            }
        }
        public void Xoa(string mancc)
        {
            try
            {
                var ncc = db.NCCs.FirstOrDefault(a => a.MaNCC == mancc);
                if (ncc != null)
                {
                    db.NCCs.DeleteOnSubmit(ncc);
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng xóa sản phẩm trước!");
            }
        }
        public bool Sua(NCC ncc)
        {
            var edit = db.NCCs.SingleOrDefault(a => a.MaNCC == ncc.MaNCC);
            if (edit != null)
            {
                edit.MaNCC = ncc.MaNCC;
                edit.TenNCC = ncc.TenNCC;
                db.SubmitChanges();
                MessageBox.Show("Sửa Nhà Cung Cấp Thành Công");
                return true;
            }
            else
            {
                MessageBox.Show("Sửa Nhà Cung Cấp Thất Bại");
            }
            return false;
        }

        public void Load(TextBox mancc, TextBox tenncc, DataGridView data)
        {
            var rowIndex = data.SelectedCells[0].RowIndex;
            var row = data.Rows[rowIndex];
            mancc.Text = row.Cells[0].Value.ToString().Trim();
            tenncc.Text = row.Cells[1].Value.ToString().Trim();
        }
    }
}
