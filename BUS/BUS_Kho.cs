using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
	public class BUS_Kho
	{
		private static BUS_Kho instance;

		public static BUS_Kho Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new BUS_Kho();
				}
				return instance;
			}
		}


		public List<object> GetKhoWithProductName()
		{
			return DAO_Kho.Instance.GetKhoWithProductName();
		}

		//Load Combobox San Pham
		public void LoadSanPham(ComboBox cb)
		{
			DAO_Kho.Instance.LoadCbMaSP(cb);
		}

		//Load Combobox Cua Hang
		public void LoadCuaHang(ComboBox cb)
		{
			DAO_Kho.Instance.LoadCbMaCH(cb);
		}


		//Xoa Kho
		public void XoaKho(TextBox maKho)
		{
			DAO_Kho.Instance.XoaKho(maKho.Text);
		}

		public void LoadDgvLenForm(TextBox maKho, ComboBox maCH, ComboBox maSP, TextBox soLuong, DataGridView data)
		{
			DAO_Kho.Instance.LoadDgvLenForm(maKho, maCH, maSP, soLuong, data);
		}

		//Tim kiếm kho
		public void TimKiemMaKho(TextBox makho, DataGridView data)
		{
			data.DataSource = DAO.DAO_Kho.Instance.TimKiemMaKho(makho.Text);
		}



		public void Them(string maCH, string maKho, string maSP, decimal soLuong)
		{
			Kho kho = new Kho
			{
				MaKho = maKho,
				MaCH = maCH,
				MaSP = maSP,
				SoLuong = soLuong

			};
			DAO_Kho.Instance.Them(maKho, kho);
		}

		//public void CapNhatSanPham(string maKho, string maCH, string maSP, decimal soLuongCapNhat)
		//{
		//    try
		//    {
		//        DAO_Kho.Instance.CapNhatSanPhamTrongKho(maKho, maCH, maSP, soLuongCapNhat);
		//    }
		//    catch (Exception ex)
		//    {
		//        throw new Exception("Không thể lưu thay đổi xuống cơ sở dữ liệu: " + ex.Message);
		//    }
		//}

		public bool SuaKho(string maKho, string maCH, string maSP, decimal soLuong)
		{
			// Create a new Kho object with the provided data
			Kho kho = new Kho
			{
				MaKho = maKho,
				MaCH = maCH,
				MaSP = maSP,
				SoLuong = soLuong
			};

			// Call the DAO layer to update the record and return the result
			return DAO_Kho.Instance.Sua(kho);
		}
	}
}
