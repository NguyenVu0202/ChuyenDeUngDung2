using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAODoiChuoiKetNoi
    {
        private static string connectionString;
        private static DAODoiChuoiKetNoi instance;
        private string filePath = @"D:\DoiChuoi.txt";
        string chuoiketnoi = "";
        public static DAODoiChuoiKetNoi Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAODoiChuoiKetNoi();
                return instance;
            }
        }

        private DAODoiChuoiKetNoi() { }
        public string ThayDoiChuoiKetNoi()
        {
            return $"Data Source={ChuoiKetNoi()};Initial Catalog=BachHoaXanh;Integrated Security=True;TrustServerCertificate=True";
        }
        public string ChuoiKetNoi()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                chuoiketnoi = sr.ReadToEnd();
            }
            return chuoiketnoi;
        }
    }
}
