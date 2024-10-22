using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_CuaHang
    {
        private static DAO_CuaHang instance;
        public static DAO_CuaHang Instance 
        { 
            get 
            { 
                if (instance == null)
                {
                    instance = new DAO_CuaHang();
                }
                return instance; 
            }
        
        }

        private DAO_CuaHang() { }

        //Hien thi toan bo thong tin cua hang
        public List<CuaHang> Xem()
        {
            List<CuaHang>  cuaHang = new List<CuaHang>();
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                cuaHang = db.CuaHangs.Select(x => x).ToList();
            }
            return cuaHang;
        }

        //Them Cua Hang
        public void Them(CuaHang cuaHang)
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                db.CuaHangs.InsertOnSubmit(cuaHang);
                db.SubmitChanges();

            }
        }

        //Xoa Cua Hang
        public void Xoa(TextBox cuaHang)
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                try
                {
                    var ch = db.CuaHangs.FirstOrDefault(a => a.MaCH == cuaHang.Text);
                    if (ch != null)
                    {
                        db.CuaHangs.DeleteOnSubmit(ch);
                        db.SubmitChanges();
                        MessageBox.Show("Xóa Thành Công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa Thất Bại" + ex.Message);
                }
            }
        }

        //Sua Cua Hang
        public bool Sua(string maCH, CuaHang ch)
        {
            using (DataBHXDataContext db = new DataBHXDataContext())
            {
                var chupdate = db.CuaHangs.SingleOrDefault(a => a.MaCH == maCH);
                if (chupdate != null)
                {
                    chupdate.MaCH = ch.MaCH;
                    chupdate.DiaChi = ch.DiaChi;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }



    }
}
