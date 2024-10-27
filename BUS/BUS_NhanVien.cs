using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_NhanVien
    {
        private static BUS_NhanVien instance;

        public static BUS_NhanVien Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_NhanVien();
                }
                return instance;
            }
        }
         private BUS_NhanVien() { }

        //Load Combobox Cua Hang
        public void LoadCuaHang(ComboBox cb)
        {
            DAO_Kho.Instance.LoadCbMaCH(cb);
        }

        //Thêm nhân viên
        public void ThemNhanVien(TextBox manv, TextBox tennv, RadioButton gtnam, RadioButton gtnu, DateTimePicker ngaysinh, TextBox sdt, TextBox diachi, TextBox luong, ComboBox mach, TextBox chucvu)
        {
            string gioitinh;
            if (gtnam.Checked == true)
            {
                gioitinh = gtnam.Text;
            }
            else
            {
                gioitinh = gtnu.Text;
            }
            NhanVien nhanVien = new NhanVien
            {
                MaNV = manv.Text,
                TenNV = tennv.Text,
                GioiTinh = gioitinh,
                NgaySinh = Convert.ToDateTime(ngaysinh.Text),
                SDT = sdt.Text,
                DiaChi = diachi.Text,
                Luong = int.Parse(luong.Text),
                MaCH = mach.Text,
                ChucVu = chucvu.Text,
            };
            DAO_NhanVien.Instance.ThemNhanVien(nhanVien);
        }

        //Hiển thị danh sách nhân viên
        public void LoadNV(DataGridView data)
        {
            data.DataSource = DAO_NhanVien.Instance.LoadNV();
        }

        //Hiển thị dữ liệu xuống dgv
        public void LoadDgvLenForm(TextBox manv, TextBox tennv, RadioButton gtnam, RadioButton gtnu, DateTimePicker ngaysinh, TextBox sdt, TextBox diachi, TextBox luong, ComboBox mach,TextBox chucvu, DataGridView data)
        {
            try
            {
                DAO.DAO_NhanVien.Instance.LoadDgvLenForm(manv, tennv, gtnam, gtnu, ngaysinh, sdt, diachi, luong, mach, chucvu, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Sửa nhân viên
        public void SuaNV(TextBox manv, TextBox tennv, RadioButton gtnam, RadioButton gtnu, DateTimePicker ngaysinh, TextBox sdt, TextBox diachi, TextBox luong, ComboBox mach, TextBox chucvu)
        {
            string gioitinh;
            if (gtnam.Checked == true)
            {
                gioitinh = gtnam.Text;
            }
            else
            {
                gioitinh = gtnu.Text;
            }
            NhanVien nhanVien = new NhanVien
            {
                MaNV = manv.Text,
                TenNV = tennv.Text,
                GioiTinh = gioitinh,
                NgaySinh = Convert.ToDateTime(ngaysinh.Text),
                SDT = sdt.Text,
                DiaChi = diachi.Text,
                Luong = int.Parse(luong.Text),
                MaCH = mach.Text,
                ChucVu = chucvu.Text,
            };
            DAO_NhanVien.Instance.SuaNV(nhanVien);
        }

        //Xóa nhân viên
        public void XoaNV(TextBox manv)
        {
            DAO_NhanVien.Instance.XoaNV(manv.Text);
        }

        //Tìm kiếm nhân viên theo Mã NV
        public void TimKiemNVTheoMaNV(TextBox maNV, DataGridView data)
        {
            var dt = DAO_NhanVien.Instance.TimKiemNVTheoMaNV(maNV.Text).Select(t =>
            {
                return new
                {
                    t.MaNV,
                    t.TenNV,
                    t.NgaySinh,
                    t.GioiTinh,
                    t.DiaChi,
                    t.SDT,
                    t.Luong,
                    t.MaCH,
                    t.ChucVu,
                };
            }).ToList();
            data.DataSource = dt;
        }

        //Tìm kiếm nhân viên theo Tên NV
        public void TimKiemNVTheoTenNV(TextBox tenNV, DataGridView data)
        {
            var dt = DAO_NhanVien.Instance.TimKiemNVTheoTenNV(tenNV.Text).Select(t =>
            {
                return new
                {
                    t.MaNV,
                    t.TenNV,
                    t.NgaySinh,
                    t.GioiTinh,
                    t.DiaChi,
                    t.SDT,
                    t.Luong,
                    t.MaCH,
                    t.ChucVu
                };
            }).ToList();
            data.DataSource = dt;
        }


    }
}
