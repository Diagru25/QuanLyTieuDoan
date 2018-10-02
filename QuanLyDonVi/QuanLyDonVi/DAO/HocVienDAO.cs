using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDonVi.Model.EF;
using QuanLyDonVi.Model.View;

namespace QuanLyDonVi.DAO
{
    public class HocVienDAO
    {
        QuanLyTieuDoanDbContext db = null;
        public HocVienDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }
        public List<HocVien> GetAll()
        {
            return db.HocViens.ToList();
        }
        public List<HocVienView> GetDonVi()
        {
            var data = (from a in db.HocViens
                        join b in db.Lops on a.LopID equals b.ID
                        join c in db.DaiDois on b.DaiDoiID equals c.ID
                        join d in db.TieuDoans on c.TieuDoanID equals d.ID
                        select new HocVienView()
                        {
                            ID = a.ID,
                            CapBac = a.CapBac,
                            ChucVu = a.ChucVu,
                            DaiDoi_ID = (long)b.DaiDoiID,
                            DaiDoi_Ten = b.Ten,
                            Ten = a.Ten,
                            Lop_ID = (long)a.LopID,
                            Lop_Ten = b.Ten,
                            TieuDoan_ID = (long)c.TieuDoanID,
                            TieuDoan_Ten = d.Ten,
                            DonVi = "Lớp " + b.Ten + " - " + c.Ten + " - " + d.Ten
                        });
            return data.ToList();
        }
        public bool Insert(HocVien item)
        {
            try
            {
                db.HocViens.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(HocVien item)
        {
            var dbEntry = db.HocViens.SingleOrDefault(x => x.ID == item.ID);
            try
            {
                dbEntry.LopID = item.LopID;
                dbEntry.LopTruong = item.LopTruong;
                dbEntry.NgayNhapNgu = item.NgayNhapNgu;
                dbEntry.NgaySinh = item.NgaySinh;
                dbEntry.NgayVaoDang = item.NgayVaoDang;
                dbEntry.NgayVaoDoan = item.NgayVaoDoan;
                dbEntry.NoiSinh = item.NoiSinh;
                dbEntry.QueQuan = item.QueQuan;
                dbEntry.Ten = item.Ten;
                dbEntry.GioiTinh = item.GioiTinh;
                dbEntry.CapBac = item.CapBac;
                dbEntry.ChucVu = item.ChucVu;
                dbEntry.DiaChi = item.DiaChi;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var dbEntry = db.HocViens.SingleOrDefault(x => x.ID == id);
                db.HocViens.Remove(dbEntry);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<object> GetHocVienIDByLopID(long lop_id)
        {
            var list = (from a in db.HocViens.Where(x => x.LopID == lop_id) select new {a = a.ID});

            return list.ToList<Object>();
        }

        public bool Add_HocVien_MonHoc(HocVien_MonHoc item)
        {
            try
            {
                db.HocVien_MonHoc.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove_HocVien_MonHoc(HocVien_MonHoc item)
        {
            try
            {
                db.HocVien_MonHoc.Remove(db.HocVien_MonHoc.Where(x=>x.HocVienID == item.HocVienID && x.MonHocID == item.MonHocID).SingleOrDefault());
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
