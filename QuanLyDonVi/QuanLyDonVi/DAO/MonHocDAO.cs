using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public List<MonHoc> GetMonNotByLopID()
        {

        }

        // lay ra nhung mon hoc ma lop do dang hoc
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

        // lay ra nhung mon hoc ma lop day chua co
        //public List<MonHoc> GetMonByLopID_No(long id)
        //{
        //    var list  = db.MonHocs.ToList();
        //    var list1 = (from a in db.Lop_MonHoc
        //                join
        //                b in db.MonHocs
        //                on a.MonHocID equals b.ID
        //                where (a.LopID != id)
        //                select b).ToList();


        //    foreach (MonHoc item in list1)
        //    {
        //        if (list.Where(x=>x.ID == item.ID).SingleOrDefault() != null)
        //        {
        //            list.Remove(list.Find(item));
        //        }
        //    }

        //    return list;
        //}
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

        public bool Add_Lop_MonHoc(Lop_MonHoc item)
        {
            try
            {
                db.Lop_MonHoc.Add(item);
                db.SaveChanges();

                // tự động thêm vào bảng HocVien_MonHoc với tất cả các HV thuộc lớp có id = item.LopID
                List<long> list = new HocVienDAO().GetHocVienIDByLopID(item.LopID);
                HocVien_MonHoc temp = new HocVien_MonHoc();

                foreach (long i in list)
                {
                    temp.HocVienID = i;
                    temp.MonHocID = item.MonHocID;
                    temp.Diem = 0;
                    if(new HocVienDAO().Add_HocVien_MonHoc(temp) == false)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove_Lop_MonHoc(long lop_id, long monhoc_id)
        {
            try
            {
                Lop_MonHoc item = new Lop_MonHoc();
                item = db.Lop_MonHoc.Where(x => x.LopID == lop_id && x.MonHocID == monhoc_id).SingleOrDefault();

                db.Lop_MonHoc.Remove(item);
                db.SaveChanges();

                List<long> list = new HocVienDAO().GetHocVienIDByLopID(lop_id);
                HocVien_MonHoc temp = new HocVien_MonHoc();

                foreach (long i in list)
                {
                    temp = db.HocVien_MonHoc.Where(x => x.HocVienID == i && x.MonHocID == monhoc_id).SingleOrDefault();
                    if (new HocVienDAO().Remove_HocVien_MonHoc(temp) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
