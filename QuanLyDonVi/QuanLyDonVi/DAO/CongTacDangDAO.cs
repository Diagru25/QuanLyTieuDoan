using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.DAO
{
    public class CongTacDangDAO
    {
        QuanLyTieuDoanDbContext db = null;

        public CongTacDangDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }

        public List<CongTacDang> GetAll()
        {
            return db.CongTacDangs.ToList();
        }
        public bool Add(CongTacDang item)
        {
            try
            {
                db.CongTacDangs.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(CongTacDang item)
        {
            try
            {
                CongTacDang temp = db.CongTacDangs.Find(item.ID);

                temp.Ten = item.Ten;
                temp.Dat = item.Dat;
                temp.Kha = item.Kha;
                temp.Gioi = item.Gioi;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(long id)
        {
            try
            {
                db.CongTacDangs.Remove(db.CongTacDangs.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
