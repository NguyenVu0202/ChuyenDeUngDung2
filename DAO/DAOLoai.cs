using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAOLoai
    {
        private static DAOLoai instance;
        DataBHXDataContext db = new DataBHXDataContext(DAODoiChuoiKetNoi.Instance.ThayDoiChuoiKetNoi());
        public static DAOLoai Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAOLoai();
                }
                return instance;
            }


        }
        public DAOLoai() { }
        public List<Loai> View()
        {
            List<Loai> list = new List<Loai>();

            var loai = (from el in db.Loais
                        select new
                        {
                            el.MaLoai,
                            el.TenLoai,
                        }).ToList();

            foreach (var item in loai)
            {
                Loai loai1 = new Loai();
                loai1.MaLoai = item.MaLoai;
                loai1.TenLoai = item.TenLoai;
                list.Add(loai1);
            }

            return list;
        }

        private const string kitu = "L";
        private string MaTuDong()
        {
            var lastLoai = db.Loais
                      .Where(l => l.MaLoai.StartsWith(kitu))
                      .OrderByDescending(l => l.MaLoai)
                      .FirstOrDefault();
            if (lastLoai == null)
            {
                return $"{kitu}001";
            }

            string lastMa = lastLoai.MaLoai;

            if (!lastMa.StartsWith(kitu))
            {
                throw new Exception("Mã nhà cung cấp không hợp lệ.");
            }

            string numberPart = lastMa.Substring(kitu.Length);

            if (!int.TryParse(numberPart, out int number))
            {
                throw new Exception("Mã loại không hợp lệ.");
            }

            number++;
            return $"{kitu}{number:D3}";
        }
        public void Them(TextBox maloai, TextBox tenloai)
        {
            try
            {
                Loai loai = new Loai();
                loai.MaLoai = MaTuDong();
                loai.TenLoai = tenloai.Text;
                db.Loais.InsertOnSubmit(loai);
                db.SubmitChanges();
                MessageBox.Show("Thêm Loại Sản Phẩm Thành Công");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi trùng mã!!!");
            }
        }
        public void Xoa(string maloai)
        {
            var dtLoai = db.Loais.FirstOrDefault(a => a.MaLoai == maloai);
            try
            {
                if (dtLoai != null)
                {
                    db.Loais.DeleteOnSubmit(dtLoai);
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Muốn xóa mã loại vui lòng xóa sản phẩm trước!");
            }
        }
        public bool Sua(Loai loai)
        {
            var edit = db.Loais.SingleOrDefault(a => a.MaLoai == loai.MaLoai);
            if (edit != null)
            {
                edit.MaLoai = loai.MaLoai;
                edit.TenLoai = loai.TenLoai;
                db.SubmitChanges();
                MessageBox.Show("Sửa Loại Sản Phẩm Thành Công");
                return true;
            }
            else
            {
                MessageBox.Show("Sửa Loại Sản Phẩm Thất Bại");
            }
            return false;
        }

        public void Load(TextBox maloai, TextBox tenloai, DataGridView data)
        {
            var rowIndex = data.SelectedCells[0].RowIndex;
            var row = data.Rows[rowIndex];
            maloai.Text = row.Cells[0].Value.ToString().Trim();
            tenloai.Text = row.Cells[1].Value.ToString().Trim();
        }
    }
}
