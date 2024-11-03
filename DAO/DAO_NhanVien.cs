using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_NhanVien
    {
        private static DAO_NhanVien instance;

        public static DAO_NhanVien Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO_NhanVien();
                return instance;
            }
        }
        public DAO_NhanVien() { }

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

        //Thêm nhân viên
        public void ThemNhanVien(NhanVien nhanVien)
        {
            try
            {
                using (DataBHXDataContext db = new DataBHXDataContext())
                {
                    db.NhanViens.InsertOnSubmit(nhanVien);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm Thành Công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại" + ex.Message);
            }
        }

        //Hiển thị danh sách nhân viên
        public List<NhanVien> LoadNV()
        {
            List<NhanVien> listnv = new List<NhanVien>();
            DataBHXDataContext db = new DataBHXDataContext();
            var nv = (from s in db.NhanViens
                      select new
                      {
                          s.MaNV,
                          s.TenNV,
                          s.GioiTinh,
                          s.NgaySinh,
                          s.SDT,
                          s.DiaChi,
                          s.Luong,
                          s.MaCH,
                          s.ChucVu

                      }).ToList();
                
                foreach (var item in nv)
                {
                    NhanVien nhanVien = new NhanVien();
                    nhanVien.MaNV = item.MaNV;
                    nhanVien.TenNV = item.TenNV;
                    nhanVien.GioiTinh = item.GioiTinh;
                    nhanVien.NgaySinh = item.NgaySinh;
                    nhanVien.SDT = item.SDT;
                    nhanVien.DiaChi = item.DiaChi;
                    nhanVien.Luong = item.Luong;
                    nhanVien.MaCH = item.MaCH;
                    nhanVien.ChucVu = item.ChucVu;
                    listnv.Add(nhanVien);
                }
            return listnv;
        }

        //Hiển thị dữ liệu xuống dgv
        public void LoadDgvLenForm(TextBox manv, TextBox tennv, RadioButton gtnam, RadioButton gtnu, DateTimePicker ngaysinh, TextBox sdt, TextBox diachi, TextBox luong, ComboBox mach, TextBox chucvu, DataGridView data)
        {
            var rowIndex = data.SelectedCells[0].RowIndex;
            var row = data.Rows[rowIndex];
            manv.Text = row.Cells["MaNV"].Value?.ToString().Trim();
            tennv.Text = row.Cells["TenNV"].Value?.ToString().Trim();
            if (row.Cells["GioiTinh"].Value?.ToString().Trim() == "Nam")
            {
                gtnam.Checked = true;
            }
            else
            {
                gtnu.Checked = true;
            }
            ngaysinh.Text = row.Cells["NgaySinh"].Value != null
                ? ((DateTime)row.Cells["NgaySinh"].Value).ToString("yyyy-MM-dd")
                : "";
            sdt.Text = row.Cells["SDT"].Value?.ToString().Trim();
            luong.Text = row.Cells["Luong"].Value?.ToString().Trim();
            diachi.Text = row.Cells["DiaChi"].Value?.ToString().Trim();
            mach.Text = row.Cells["MaCH"].Value?.ToString().Trim();
            chucvu.Text = row.Cells["ChucVu"].Value?.ToString().Trim();

        }

        //Sửa nhân viên
        public void SuaNV(NhanVien nhanVien)
        {
            try
            {
                DataBHXDataContext db = new DataBHXDataContext();

                // Tìm nhân viên dựa trên mã nhân viên (MaNV)
                NhanVien nv = db.NhanViens.SingleOrDefault(p => p.MaNV == nhanVien.MaNV);

                // Kiểm tra nếu nhân viên tồn tại
                if (nv != null)
                {
                    nv.TenNV = nhanVien.TenNV;
                    nv.GioiTinh = nhanVien.GioiTinh;
                    nv.NgaySinh = nhanVien.NgaySinh;
                    nv.SDT = nhanVien.SDT;
                    nv.Luong = nhanVien.Luong;
                    nv.DiaChi = nhanVien.DiaChi;
                    nv.MaCH = nhanVien.MaCH;
                    nv.ChucVu = nhanVien.ChucVu;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Sửa nhân viên thành công! (Mã nhân viên không được phép thay đổi)");
                }
                else
                {
                    MessageBox.Show("Sửa nhân viên không thành công! (Mã nhân viên không được phép thay đổi)");
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo thất bại và lỗi
                MessageBox.Show("Sửa thất bại: " + ex.Message);
            }

        }

        //Xóa nhân viên
        public void XoaNV(string maNV)
        {
            try
            {
                DataBHXDataContext db = new DataBHXDataContext();
                var nv = db.NhanViens.FirstOrDefault(p => p.MaNV == maNV);
                db.NhanViens.DeleteOnSubmit(nv);
                db.SubmitChanges();
                MessageBox.Show("Xóa Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại: " + ex.Message);
            }
        }

        //Tìm kiếm nhân viên theo Mã Nhân Viên
        public List<NhanVien> TimKiemNVTheoMaNV(string MaNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            DataBHXDataContext db = new DataBHXDataContext();
            var nv = db.NhanViens.SingleOrDefault(p => p.MaNV == MaNV);
            if (nv != null)
            {
                NhanVien nhanvien = new NhanVien
                {
                    MaNV = nv.MaNV,
                    TenNV = nv.TenNV,
                    GioiTinh = nv.GioiTinh,
                    DiaChi = nv.DiaChi,
                    SDT = nv.SDT,
                    NgaySinh = nv.NgaySinh,
                    Luong = nv.Luong,
                    MaCH = nv.MaCH,
                    ChucVu = nv.ChucVu,
                };
                list.Add(nhanvien);
            }
            else
            {
                MessageBox.Show("Không Có Mã Nhân Viên");
            }
            return list;
        }

        //Tìm kiếm Nhân Viên theo tên nhân viên
        public List<NhanVien> TimKiemNVTheoSĐTNV(string MaNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            DataBHXDataContext db = new DataBHXDataContext();
            var nv = db.NhanViens.SingleOrDefault(p => p.SDT == MaNV);
            if (nv != null)
            {
                NhanVien nhanvien = new NhanVien
                {
                    MaNV = nv.MaNV,
                    TenNV = nv.TenNV,
                    GioiTinh = nv.GioiTinh,
                    DiaChi = nv.DiaChi,
                    SDT = nv.SDT,
                    NgaySinh = nv.NgaySinh,
                    Luong = nv.Luong,
                    MaCH = nv.MaCH,
                    ChucVu = nv.ChucVu,
                };
                list.Add(nhanvien);
            }
            else
            {
                MessageBox.Show("Không Có SĐT cần tìm");
            }
            return list;
        }

        public bool KiemTraMaNV(string maNV)
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                return db.NhanViens.Any(nv => nv.MaNV == maNV);
            }
        }

      

        //Load Mã Nhân Viên
        public List<string> LoadMaNV()
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                // Lấy danh sách MaNV từ bảng NhanVien và chuyển thành List<string>
                return db.NhanViens
                              .Select(nv => nv.MaNV)
                              .ToList();
            }
        }

        //Load Tên Nhân Viên
        public List<string> LoadSDTNV()
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                // Lấy danh sách số điện thoại từ bảng NhanVien và chuyển thành List<string>
                return db.NhanViens
                         .Select(nv => nv.SDT)
                         .ToList();
            }
        }



    }
}
