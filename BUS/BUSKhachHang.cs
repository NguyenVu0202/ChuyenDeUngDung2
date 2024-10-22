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

        public void Them(TextBox makh, TextBox tenkh, RadioButton gtNam, RadioButton gtNu, TextBox diachi, TextBox sdt)
        {
            DAOKhachHang.Instance.Them(makh, tenkh, gtNam, gtNu, diachi, sdt);
        }
        public bool Sua(KhachHang khachhang)
        {
            return DAOKhachHang.Instance.Sua(khachhang);
        }
        public void Xoa(TextBox maKhachHang)
        {
            DAOKhachHang.Instance.Xoa(maKhachHang.Text);
        }

        public void Load(TextBox makh, TextBox tenkh, RadioButton  gtNam, RadioButton gtNu, TextBox diachi,  TextBox sdt, DataGridView data) {
            DAOKhachHang.Instance.Load(makh, tenkh, gtNam, gtNu, diachi, sdt, data);
        }
        public void TimKhachHangTheoMa(TextBox maKhachHang, DataGridView data)
        {
            data.DataSource = DAOKhachHang.Instance.TimKiemTheoMa(maKhachHang.Text);
        }

        public void TimKhachHangTheoTen(TextBox tenkhachhang, DataGridView data)
        {
            data.DataSource = DAOKhachHang.Instance.TimKiemTheoTen(tenkhachhang.Text);
        }
        public void TimKhachHangTheoSDT(TextBox sdtkhachhang, DataGridView data)
        {
            data.DataSource = DAOKhachHang.Instance.TimKiemTheoSDT(sdtkhachhang.Text);
        }
    }
}
