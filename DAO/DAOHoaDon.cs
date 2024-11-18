using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DAO
{
    public class DAOHoaDon
    {
        private static DAOHoaDon instance;
        DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());
        public static DAOHoaDon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAOHoaDon();
                }
                return instance;
            }

        }
        private DAOHoaDon() { }
        public class ChiTietHoaDonDTO
        {
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public decimal SoLuong { get; set; }
            public decimal GiaSP { get; set; }
            public decimal? GiamGia { get; set; }
            public decimal ThanhTien { get; set; }
        }
        public List<string> LoadKhachHang(string maKH)
        {
            var kh = db.KhachHangs.SingleOrDefault(x => x.MaKH == maKH);
            List<string> lst = new List<string>();
            if (kh != null)
            {
                lst.Add(kh.TenKH.ToString());
                lst.Add(kh.SDT.ToString());
            }
            return lst;
        }
        public List<string> LoadSanPham(string maSP)
        {
            var sp = db.SanPhams.SingleOrDefault(x => x.MaSP == maSP);
            List<string> lst = new List<string>();
            if (sp != null)
            {
                lst.Add(sp.TenSP.ToString());
                lst.Add(sp.GiaBan.ToString());
                lst.Add(sp.GiamGia.ToString());
            }
            return lst;
        }
        public void TaoHoaDon(string manv)
        {
            HoaDon hoaDon = new HoaDon
            {
                NgayBan = DateTime.Now,
                TongTien = 0,
                MaKH = null,
                MaNV = manv
            };

            db.HoaDons.InsertOnSubmit(hoaDon);
            db.SubmitChanges();
        }
        public void XoaHoaDon()
        {
            var hd = db.HoaDons.SingleOrDefault(x => x.TongTien == 0);
            if(hd != null)
            {
                db.HoaDons.DeleteOnSubmit(hd);
            }    
            db.SubmitChanges();
        }
        public List<ChiTietHoaDonDTO> LoadChiTietHoaDon()
        {
            List<ChiTietHoaDonDTO> listcthd = new List<ChiTietHoaDonDTO>();
            var cthd = (from ct in db.ChiTietHoaDons
                       join sp in db.SanPhams on ct.MaSP equals sp.MaSP
                       where ct.MaHD == null
                       select new
                       {
                           ct.MaSP,
                           TenSP = sp.TenSP,
                           ct.SoLuong,
                           ct.GiaSP,
                           ct.GiamGia,
                           ct.ThanhTien
                       }).ToList();
            foreach (var item in cthd)
            {
                ChiTietHoaDonDTO chitiet = new ChiTietHoaDonDTO
                {
                    MaSP = item.MaSP,
                    TenSP = item.TenSP,
                    SoLuong = (decimal)item.SoLuong,
                    GiaSP = (decimal)item.GiaSP,
                    GiamGia = (decimal)item.GiamGia,
                    ThanhTien = (decimal)item.ThanhTien,
                };
                listcthd.Add(chitiet);


            }
            return listcthd;
        }
        public void ThemSanPham(ChiTietHoaDon cthd, string makh)
        {
            try
            {
                db.ChiTietHoaDons.InsertOnSubmit(cthd);
                HoaDon hd = db.HoaDons.FirstOrDefault(x => x.TongTien == 0);
                if (hd == null)
                {
                    hd.MaKH = makh;
                }
                
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm" + ex.Message);
            }
        }
        public decimal TinhTongTienHD()
        {
            var cthd = from ct in db.ChiTietHoaDons
                       where ct.MaHD == null
                       select ct;

            if (cthd.Any())
            {
                var tt = db.ChiTietHoaDons
                           .Where(x => x.MaHD == null)
                           .Sum(x => (decimal?)x.ThanhTien)
                           .GetValueOrDefault();
                return tt;
            }
            return 0;
        }
        public void ThanhToan(string makh)
        {
            HoaDon hd = db.HoaDons.FirstOrDefault(x => x.TongTien == 0);
            var cthd = (from ct in db.ChiTietHoaDons
                                             where ct.MaHD == null
                                             select ct).ToList();
            var cthd1 = (from ct in db.ChiTietHoaDons
                        where ct.MaHD == null
                        select ct).FirstOrDefault();

            var tt = db.ChiTietHoaDons
                           .Where(x => x.MaHD == null)
                           .Sum(x => (decimal?)x.ThanhTien)
                           .GetValueOrDefault();

            if (hd != null)
            {
                hd.TongTien = tt;
                hd.MaKH = string.IsNullOrEmpty(makh) ? null : makh;

                foreach (var ct in cthd)
                {
                    ct.MaHD = hd.MaHD;
                }

                db.SubmitChanges();
            }

        }
        public void XoaCTHD(string masp)
        {
            if(masp != "")
            {
                var cthd = db.ChiTietHoaDons.FirstOrDefault(x => x.MaHD == null && x.MaSP == masp);
                db.ChiTietHoaDons.DeleteOnSubmit(cthd);
                db.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm bạn muốn xóa!");
            }    
        }
        public void TruSanPhamTrongKho(string manv, string masp, string soluong)
        {
            var sl = (from k in db.Khos
                     join nv in db.NhanViens on k.MaCH equals nv.MaCH
                     where nv.MaNV == manv && k.MaSP == masp
                     select k.SoLuong).FirstOrDefault();
            var mk = (from k in db.Khos
                     join nv in db.NhanViens on k.MaCH equals nv.MaCH
                     where nv.MaNV == manv
                     select k.MaKho).FirstOrDefault();
            string makho = mk.ToString();
            var kho = db.Khos.FirstOrDefault(x => x.MaKho == makho && x.MaSP == masp);
            if(sl != 0)
            {
                if(kho != null)
                {
                    kho.SoLuong -= decimal.Parse(soluong);
                    db.SubmitChanges();
                }    
            }
            else
            {
                MessageBox.Show("Sản phẩm đã hết trong kho!");
            }    
        }
        public void CongSanPhamTrongKho(string manv, string masp, string soluong)
        {
            var sl = (from k in db.Khos
                      join nv in db.NhanViens on k.MaCH equals nv.MaCH
                      where nv.MaNV == manv && k.MaSP == masp
                      select k.SoLuong).FirstOrDefault();
            var mk = (from k in db.Khos
                      join nv in db.NhanViens on k.MaCH equals nv.MaCH
                      where nv.MaNV == manv
                      select k.MaKho).FirstOrDefault();
            string makho = mk.ToString();
            var kho = db.Khos.FirstOrDefault(x => x.MaKho == makho && x.MaSP == masp);
            if (sl != 0)
            {
                if (kho != null)
                {
                    kho.SoLuong += decimal.Parse(soluong);
                    db.SubmitChanges();
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm đã hết trong kho!");
            }
        }
        public decimal KiemtraslSanPham(string manv, string masp)
        {
            if (!string.IsNullOrEmpty(manv) && !string.IsNullOrEmpty(masp))
            {
				var sl = (from k in db.Khos
						  join nv in db.NhanViens on k.MaCH equals nv.MaCH
						  where nv.MaNV == manv && k.MaSP == masp
						  select k.SoLuong).FirstOrDefault();
				return (decimal)sl;
			}
            return 0;
        }
        public void loadMaKH(System.Windows.Forms.ComboBox cb)
        {
            List<string> list = new List<string>();
            var makh = from kh in db.KhachHangs
                       select kh.MaKH;
            foreach (var item in makh)
            {
                list.Add(item);
            }
            cb.DataSource = new BindingSource(list, null);
            cb.AutoCompleteMode = AutoCompleteMode.None;
            cb.AutoCompleteSource = AutoCompleteSource.None;
        }
        public void AutoTimKiemMaKH(System.Windows.Forms.ComboBox cb)
        {
            var makh = from kh in db.KhachHangs
                       select kh.MaKH;

            string filter = cb.Text.ToLower();

            var filteredItems = makh.Where(item => item.ToLower().Contains(filter)).ToList();

            cb.DataSource = null;

            cb.DataSource = filteredItems;

            cb.DroppedDown = true;

            cb.Text = filter;

            cb.SelectionStart = filter.Length;
        }
    }
}
