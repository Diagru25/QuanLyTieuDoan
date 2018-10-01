using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.DAO
{
    public class TieuDoanDAO
    {
        QuanLyTieuDoanDbContext db = null;

        public TieuDoanDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }

        public List<TieuDoan> GetAll()
        {
            return db.TieuDoans.ToList();
        }

        public bool Add(TieuDoan item)
        {
            try
            {
                db.TieuDoans.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(TieuDoan item)
        {
            try
            {
                TieuDoan temp = db.TieuDoans.Find(item.ID);

                temp.Ten = item.Ten;
                temp.GhiChu = item.GhiChu;

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
                db.TieuDoans.Remove(db.TieuDoans.Find(id));
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
