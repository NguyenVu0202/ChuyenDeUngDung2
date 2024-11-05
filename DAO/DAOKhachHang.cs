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
        public void Them(TextBox makh, TextBox tenkh, RadioButton gtNam, RadioButton gtNu, TextBox sdt, TextBox diachi)
        {
            try
            {
                string gioitinh;
                gioitinh = gtNam.Checked ? gtNam.Text : gtNu.Text;
                KhachHang kh = new KhachHang();
                kh.MaKH = makh.Text;
                kh.TenKH = tenkh.Text;
                kh.GioiTinh = gioitinh;
                kh.DiaChi = diachi.Text;
                kh.SDT = sdt.Text;
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                MessageBox.Show("Thêm Khách Hàng Thành Công");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi trùng mã!!!");
            }
        }
        public void Xoa(string maKH)
        {
            var dtKH = db.KhachHangs.FirstOrDefault(a => a.MaKH == maKH);
            if (dtKH != null)
            {
                db.KhachHangs.DeleteOnSubmit(dtKH);
                db.SubmitChanges();
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
                return true;
            }
            return false;
        }
        public void Load(TextBox makh, TextBox tenkh, RadioButton gtNam, RadioButton gtNu, TextBox sdt, TextBox diachi, DataGridView data)
        {
            var rowInDex = data.SelectedCells[0].RowIndex;
            var row = data.Rows[rowInDex];
            makh.Text = row.Cells[0].Value.ToString().Trim();
            tenkh.Text = row.Cells[1].Value.ToString().Trim();
            if (row.Cells["GioiTinh"].Value.ToString().Trim() == "Nam")
                gtNam.Checked = true;
            else gtNu.Checked = true;
            diachi.Text = row.Cells[3].Value.ToString().Trim();
            sdt.Text = row.Cells[4].Value.ToString().Trim();
        }

        public List<KhachHang> TimKiemTheoMa(string makh)
        {
            List<KhachHang> list = new List<KhachHang>();

            // Tìm tất cả khách hàng có số điện thoại tương ứng
            var khachHangs = db.KhachHangs.Where(p => p.MaKH == makh).ToList();

            // Kiểm tra nếu có khách hàng tìm thấy
            if (khachHangs.Any())
            {
                foreach (var kh in khachHangs)
                {
                    KhachHang khachhang = new KhachHang
                    {
                        MaKH = kh.MaKH,
                        TenKH = kh.TenKH,
                        GioiTinh = kh.GioiTinh,
                        SDT = kh.SDT,
                        DiaChi = kh.DiaChi
                    };
                    list.Add(khachhang);
                }
            }
            else
            {
                MessageBox.Show("Không có mã khách hàng này!");
            }
            return list;
        }



        public List<KhachHang> TimKiemTheoSDT(string sdt)
        {
            List<KhachHang> list = new List<KhachHang>();

            // Tìm tất cả khách hàng có số điện thoại tương ứng
            var khachHangs = db.KhachHangs.Where(p => p.SDT == sdt).ToList();

            // Kiểm tra nếu có khách hàng tìm thấy
            if (khachHangs.Any())
            {
                foreach (var kh in khachHangs)
                {
                    KhachHang khachhang = new KhachHang
                    {
                        MaKH = kh.MaKH,
                        TenKH = kh.TenKH,
                        GioiTinh = kh.GioiTinh,
                        SDT = kh.SDT,
                        DiaChi = kh.DiaChi
                    };
                    list.Add(khachhang);
                }
            }
            else
            {
                MessageBox.Show("Không có số điện thoại khách hàng này!");
            }

            return list;
        }
        public List<KhachHang> TimKhachHangMa(string khachhang)
        {
            return db.KhachHangs
                .Where(kh => kh.MaKH.Contains(khachhang))
                .ToList();
        }
        public List<KhachHang> TimKhachHangSDT(string khachhang)
        {
            return db.KhachHangs
                .Where(kh => kh.SDT.Contains(khachhang))
                .ToList();
        }
    }
}
