using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public class BUSKhachHang
    {
        private static BUSKhachHang instance;
        public static BUSKhachHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUSKhachHang();
                return instance;
            }
        }
        private BUSKhachHang() { }
        public void View(DataGridView data)
        {
            var dt = DAOKhachHang.Instance.View().Select(t =>
            {
                return new
                {
                    t.MaKH,
                    t.TenKH,
                    t.GioiTinh,
                    t.DiaChi,
                    t.SDT
                };
            }).ToList();
            data.DataSource = dt;
        }

        public void Them(TextBox makh, TextBox tenkh, RadioButton gioitinh, TextBox diachi, TextBox sdt)
        {
            DAOKhachHang.Instance.Them(makh, tenkh, gioitinh, diachi, sdt);
        }
        public void Sua(TextBox makh, TextBox tenkh, RadioButton gioitinh, TextBox diachi, TextBox sdt)
        {
            KhachHang kh = new KhachHang
            {
                MaKH = makh.Text,
                TenKH = makh.Text,
                GioiTinh = makh.Text,
                DiaChi = makh.Text,
                SDT = makh.Text
            };
            DAOKhachHang.Instance.Sua(kh);
        }
        public void Xoa(TextBox maKhachHang)
        {
            DAOKhachHang.Instance.Xoa(maKhachHang.Text);
        }

        public void Load(TextBox makh, TextBox tenkh, RadioButton  gioitinh, TextBox diachi,  TextBox sdt, DataGridView data) {
            DAOKhachHang.Instance.Load(makh, tenkh, gioitinh, diachi, sdt, data);
        }
    }
}
