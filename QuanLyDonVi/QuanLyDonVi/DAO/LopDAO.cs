using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.DAO
{
    public class LopDAO
    {
        QuanLyTieuDoanDbContext db = null;

        public LopDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }

        public List<Lop> GetAll()
        {
            return db.Lops.ToList();
        }

        public bool Add(Lop item)
        {
            try
            {
                db.Lops.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Lop item)
        {
            try
            {
                Lop temp = db.Lops.Find(item.ID);

                temp.Ten = item.Ten;
                temp.GhiChu = item.GhiChu;
                temp.DaiDoiID = item.DaiDoiID;

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
                db.Lops.Remove(db.Lops.Find(id));
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
