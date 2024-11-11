using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUSDoiChuoiKetNoi
    {
        private static BUSDoiChuoiKetNoi instance;
        public static BUSDoiChuoiKetNoi Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUSDoiChuoiKetNoi();
                return instance;
            }
        }

        private BUSDoiChuoiKetNoi() { }
        public void ThayDoiChuoiKetNoi()
        {
            DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi();
        }
    }
}
