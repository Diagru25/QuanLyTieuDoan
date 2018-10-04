using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.DAO
{
    public class MonTheLucDAO
    {
        QuanLyTieuDoanDbContext db = null;

        public MonTheLucDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }

        public List<MonTheLuc> GetAll()
        {
            return db.MonTheLucs.ToList();
        }
        public bool Add(MonTheLuc item)
        {
            try
            {
                db.MonTheLucs.Add(item);
                db.SaveChanges();

                HocVien_TheLuc temp = new HocVien_TheLuc();
                temp.KetQua = 0;
                temp.MonTheLucID = item.ID;
                List<HocVien> hv = db.HocViens.ToList();
                HocVienDAO dao = new HocVienDAO();
                foreach(var x in hv)
                {
                    temp.HocVienID = x.ID;
                    dao.Add_HocVien_MonTheLuc(temp);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(MonTheLuc item)
        {
            try
            {
                MonTheLuc temp = db.MonTheLucs.Find(item.ID);

                temp.Ten = item.Ten;
                temp.DonViTinh = item.DonViTinh;
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
                db.MonTheLucs.Remove(db.MonTheLucs.Find(id));
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
