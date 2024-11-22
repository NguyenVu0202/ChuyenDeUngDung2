using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;

namespace BUS
{
    public class BUSNhaCungCap
    {
        private static BUSNhaCungCap instance;

        public static BUSNhaCungCap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUSNhaCungCap();
                }
                return instance;
            }


        }
        private BUSNhaCungCap() { }
        public void View(DataGridView data)
        {
            var dt = DAONhaCungCap.Instance.View().Select(t =>
            {
                return new
                {
                    t.MaNCC,
                    t.TenNCC,
                };
            }).ToList();
            data.DataSource = dt;
        }
        public void Them(TextBox mancc, TextBox tenncc)
        {
            DAONhaCungCap.Instance.Them(mancc, tenncc);
        }
        public void Sua(TextBox mancc, TextBox tenncc)
        {

            NCC ncc = new NCC
            {
                MaNCC = mancc.Text,
                TenNCC = tenncc.Text,
            };
            DAONhaCungCap.Instance.Sua(ncc);
        }

        public void Xoa(TextBox mancc)
        {
            DAONhaCungCap.Instance.Xoa(mancc.Text);
        }

        public void Load(TextBox mancc, TextBox tenncc, DataGridView data)
        {
            DAONhaCungCap.Instance.Load(mancc, tenncc, data);
        }
    }
}
