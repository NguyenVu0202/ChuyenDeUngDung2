using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_CuaHang
    {
        private static BUS_CuaHang instance;

        public static BUS_CuaHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_CuaHang();
                }
                return instance;
            }
        }

        public BUS_CuaHang() { }

        public void Xem(DataGridView data)
        {
            data.DataSource = DAO_CuaHang.Instance.Xem();
        }

        public void Them(CuaHang ch)
        {
            DAO_CuaHang.Instance.Them(ch);
        }
        public void Xoa(TextBox ch)
        {
            DAO_CuaHang.Instance.Xoa(ch);
        }

        public bool Sua(string maCH, CuaHang ch)
        {
            return DAO_CuaHang.Instance.Sua(maCH, ch);
        }
    }
}
