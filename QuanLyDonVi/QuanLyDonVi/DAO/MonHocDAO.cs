using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.DAO
{
    public class MonHocDAO
    {
        QuanLyTieuDoanDbContext db = null;

        public MonHocDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }

        public List<MonHoc> GetAll()
        {
            return db.MonHocs.ToList();
        }

        public List<MonHoc> GetMonByLopID(long id)
        {
            var list = (from a in db.Lop_MonHoc
                        join
                        b in db.MonHocs
                        on a.MonHocID equals b.ID
                        where (a.LopID == id)
                        select b).ToList();
            return list;
        }
        public bool Add(MonHoc item)
        {
            try
            {
                db.MonHocs.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(MonHoc item)
        {
            try
            {
                MonHoc temp = db.MonHocs.Find(item.ID);

                temp.Ten = item.Ten;
                temp.KyHoc = item.KyHoc;
                temp.SoTin = item.SoTin;

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
                db.MonHocs.Remove(db.MonHocs.Find(id));
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
