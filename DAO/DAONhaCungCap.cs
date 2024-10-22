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
        DataBHXDataContext db = new DataBHXDataContext();
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

        public void Them(TextBox mancc, TextBox tenncc)
        {
            try
            {              
                NCC ncc = new NCC();
                ncc.MaNCC = mancc.Text;            
                ncc.TenNCC = tenncc.Text;
                db.NCCs.InsertOnSubmit(ncc);
                db.SubmitChanges();
                MessageBox.Show("Thêm Nhà Cung Cấp Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
        }
        public void Xoa(string mancc)
        {
            var ncc = db.NCCs.FirstOrDefault(a => a.MaNCC == mancc);
            if (ncc != null)
            {
                db.NCCs.DeleteOnSubmit(ncc);
                db.SubmitChanges();
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
