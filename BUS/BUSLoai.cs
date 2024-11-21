using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;

namespace BUS
{
    public class BUSLoai
    {
        private static BUSLoai instance;

        public static BUSLoai Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUSLoai();
                }
                return instance;
            }


        }
        private BUSLoai() { }
        public void View(DataGridView data)
        {
            var dt = DAOLoai.Instance.View().Select(t =>
            {
                return new
                {
                    t.MaLoai,
                    t.TenLoai,
                };
            }).ToList();
            data.DataSource = dt;
        }
        public void Them(TextBox maloai, TextBox tenloai)
        {
            DAOLoai.Instance.Them(maloai, tenloai);
        }
        public void Sua(TextBox maloai, TextBox tenloai)
        {

            Loai loai = new Loai
            {
                MaLoai = maloai.Text,
                TenLoai = tenloai.Text,
            };
            DAOLoai.Instance.Sua(loai);
        }

        public void Xoa(TextBox maloai)
        {
            DAOLoai.Instance.Xoa(maloai.Text);
        }

        public void Load(TextBox maloai, TextBox tenloai, DataGridView data)
        {
            DAOLoai.Instance.Load(maloai, tenloai, data);
        }
    }
}
