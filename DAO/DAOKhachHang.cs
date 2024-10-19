using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAOKhachHang
    {
        private static DAOKhachHang instance;
        DataBHXDataContext db = new DataBHXDataContext();
        public static DAOKhachHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAOKhachHang();
                return instance;
            }
        }
        public DAOKhachHang() { }
        public List<KhachHang> View()
        {
            List<KhachHang> list = new List<KhachHang>();
            var kh = (from el in db.KhachHangs
                      select new
                      {
                          el.MaKH,
                          el.TenKH,
                          el.GioiTinh,
                          el.DiaChi,
                          el.SDT
                      }).ToList();
            foreach (var item in kh)
            {
                KhachHang kh1 = new KhachHang();
                kh1.MaKH = item.MaKH;
                kh1.TenKH = item.TenKH;
                kh1.GioiTinh = item.GioiTinh;
                kh1.DiaChi = item.DiaChi;
                kh1.SDT = item.SDT;
                list.Add(kh1);
            }
            return list;
        }
        public void Them(TextBox makh, TextBox tenkh, RadioButton gioitinh, TextBox diachi, TextBox sdt)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = makh.Text;
                kh.TenKH = tenkh.Text;
                kh.GioiTinh = gioitinh.Checked.ToString();
                kh.DiaChi = diachi.Text;
                kh.SDT = sdt.Text;
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                MessageBox.Show("Thêm Khách Hàng Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }
        public void Xoa(string maKH)
        {
            try
            {
                var dtKH = db.KhachHangs.FirstOrDefault(a => a.MaKH == maKH);
                if(dtKH == null)
                {
                    db.KhachHangs.DeleteOnSubmit(dtKH);
                    db.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }
        public bool Sua(KhachHang khachHang)
        {
            var edit = db.KhachHangs.SingleOrDefault(a => a.MaKH == khachHang.MaKH);
            if (edit != null)
            {
                edit.MaKH = khachHang.MaKH;
                edit.TenKH = khachHang.TenKH;
                edit.GioiTinh = khachHang.GioiTinh;
                edit.DiaChi = khachHang.DiaChi;
                edit.SDT = khachHang.SDT;
                db.SubmitChanges();
                MessageBox.Show("Sửa Khách Hàng Thành Công");
                return true;
            }
            else {
                MessageBox.Show("Sửa Khách Hàng Không  Thành Công"); 
            } return false; 
        }
        public void Load(TextBox makh, TextBox tenkh, RadioButton gioitinh, TextBox diachi, TextBox sdt, DataGridView data)
        {
            var rowInDex = data.SelectedCells[0].RowIndex;
            var row = data.Rows[rowInDex];
            makh.Text = row.Cells[0].Value.ToString().Trim();
            tenkh.Text = row.Cells[1].Value.ToString().Trim();
            gioitinh.Text = row.Cells[2].Value.ToString().Trim();
            diachi.Text = row.Cells[3].Value.ToString().Trim();
            sdt.Text = row.Cells[4].Value.ToString().Trim();
        }
    }
}
