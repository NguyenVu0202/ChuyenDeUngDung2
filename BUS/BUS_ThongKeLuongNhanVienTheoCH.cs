using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DAO.DAO_ThongKeLuongNhanVienTheoCH;

namespace BUS
{
	public class BUS_ThongKeLuongNhanVienTheoCH
	{
		private static BUS_ThongKeLuongNhanVienTheoCH instance;

		public static BUS_ThongKeLuongNhanVienTheoCH Instance
		{
			get
			{
				if (instance == null)
					instance = new BUS_ThongKeLuongNhanVienTheoCH();
				return instance;
			}
		}
		private BUS_ThongKeLuongNhanVienTheoCH() { }

		public List<DTO_ThongKeDoanhThu> ThongKeLuongNVTheoCH(string maCH, DateTimePicker tungay, DateTimePicker denngay)
		{
			// Call the DAO method to get data
			var salesData = DAO_ThongKeLuongNhanVienTheoCH.Instance.ThongKeLuongNVTheoCH(maCH, tungay.Text, denngay.Text);

			// Here you can add additional business logic if needed
			// For example, you could apply filters, calculations, or other transformations

			// Return the processed data
			return salesData;
		}

		public void LoadMaCH(ComboBox cb)
		{
			cb.DataSource = DAO_ThongKeLuongNhanVienTheoCH.Instance.LoadMaCH();
		}
	}
}
