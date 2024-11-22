using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class DAO_ThongKeLuongNhanVienTheoCH
	{
		private static DAO_ThongKeLuongNhanVienTheoCH instance;

		public static DAO_ThongKeLuongNhanVienTheoCH Instance
		{
			get
			{
				if (instance == null)
					instance = new DAO_ThongKeLuongNhanVienTheoCH();
				return instance;
			}
		}
		private DAO_ThongKeLuongNhanVienTheoCH() { }

		public class DTO_ThongKeDoanhThu
		{
			public string MaNV { get; set; }
			public string TenNV { get; set; }
			public string SĐT { get; set; }
			public decimal? Luong { get; set; }
			public string MaCH { get; set; }
			public string DiaChi { get; set; }
			public int MaTinhLuong { get; set; }
			public decimal? PhuCap { get; set; }
			public decimal? Thuong { get; set; }
			public int? NgayNghiPhep { get; set; }
			public int? NgayNghiKhongPhep { get; set; }
			public int? NgayNghiConLai { get; set; }
			public decimal? LuongThucLinh { get; set; }
			public DateTime? NgayTinhLuong { get; set; }


		}

		public List<string> LoadMaCH()
		{
			List<string> list = new List<string>();

			using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
			{
				var mach = (from ch in db.CuaHangs
							select new
							{
								ch.MaCH
							}).ToList();

				foreach (var item in mach)
				{
					list.Add(item.MaCH);
				}
			}
			return list;
		}

		public List<DTO_ThongKeDoanhThu> ThongKeLuongNVTheoCH(string maCH)
		{
			List<DTO_ThongKeDoanhThu> list = new List<DTO_ThongKeDoanhThu>();

			try
			{
				using (DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi()))
				{
					// Querying and projecting data directly with LINQ
					var salesData = (from ch in db.CuaHangs
									 join nv in db.NhanViens on ch.MaCH equals nv.MaCH
									 join tl in db.BangTinhLuongs on ch.MaCH equals tl.MaCH
									 where ch.MaCH == maCH
									 select new DTO_ThongKeDoanhThu
									 {
										 MaNV = nv.MaNV,
										 TenNV = nv.TenNV,
										 SĐT = nv.SDT,
										 Luong = nv.Luong,
										 DiaChi = ch.DiaChi,
										 MaCH = ch.MaCH,
										 MaTinhLuong = tl.MaTinhLuong,
										 PhuCap = tl.PhuCap,
										 Thuong = tl.Thuong,
										 NgayNghiPhep = tl.NgayNghiPhep,
										 NgayNghiKhongPhep = tl.NgayNghiKhongPhep,
										 LuongThucLinh = tl.LuongThucLinh,
										 NgayTinhLuong = tl.NgayTinhLuong,
										 NgayNghiConLai = tl.NgayNghiConLai
									 }).ToList();

					// If data exists, it's already been projected into DTO_ThongKeDoanhThu
					if (salesData.Any())
					{
						list.AddRange(salesData);
					}
				}
			}
			catch (Exception ex)
			{
				// Log the exception or handle accordingly
				Console.WriteLine($"Error: {ex.Message}");
				// Optionally, rethrow or return an empty list based on your needs
			}

			return list;
		}



	}
}
