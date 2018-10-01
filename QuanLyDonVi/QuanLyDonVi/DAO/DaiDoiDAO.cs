using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.DAO
{
    public class DaiDoiDAO
    {
        QuanLyTieuDoanDbContext db = null;

        public DaiDoiDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }

        public List<DaiDoi> GetAll()
        {
            return db.DaiDois.ToList();
        }
        public List<DaiDoi> GetAllByTieuDoanID(long id)
        {
            return db.DaiDois.Where(x => x.TieuDoanID == id).ToList();
        }
        public long GetTieuDoanIDByDaiDoiID(long id)
        {
            return (long)db.DaiDois.Find(id).TieuDoanID;
        }
        public bool Add(DaiDoi item)
        {
            try
            {
                db.DaiDois.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(DaiDoi item)
        {
            try
            {
                DaiDoi temp = db.DaiDois.Find(item.ID);

                temp.Ten = item.Ten;
                temp.GhiChu = item.GhiChu;
                temp.TieuDoanID = item.TieuDoanID;

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
                db.DaiDois.Remove(db.DaiDois.Find(id));
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
