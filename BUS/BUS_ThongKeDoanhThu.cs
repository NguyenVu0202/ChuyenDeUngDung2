using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_ThongKeDoanhThu
    {
        private static BUS_ThongKeDoanhThu instance;

        public static BUS_ThongKeDoanhThu Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new BUS_ThongKeDoanhThu();
                }
                return instance;
            }
        }
        public BUS_ThongKeDoanhThu() { }

        public void LoadMaCH(ComboBox mach)
        {
            mach.DataSource = DAO_ThongKeDoanhThu.Instance.LoadMaCH();
        }

        public void ThongKeDoanhThu(ComboBox mach, DateTimePicker tungay, DateTimePicker toingay, DataGridView data)
        {
            data.DataSource = DAO_ThongKeDoanhThu.Instance.ThongKeDoanhThu(mach.Text, tungay.Text, toingay.Text);
        }


    }
}
