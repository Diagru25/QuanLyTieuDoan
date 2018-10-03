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
                            NgaySinh = (DateTime)a.NgaySinh,
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

        public List<long> GetHocVienIDByLopID(long lop_id)
        {
            var list = (from a in db.HocViens.Where(x => x.LopID == lop_id) select new { a.ID }).ToList();

            List<long> liID = new List<long>();
            foreach (var item in list)
            {
                liID.Add(item.ID);
            }

            return liID;
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
                db.HocVien_MonHoc.Remove(db.HocVien_MonHoc.Where(x => x.HocVienID == item.HocVienID && x.MonHocID == item.MonHocID).SingleOrDefault());
<<<<<<< HEAD
=======
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DiemView> KetQuaHocTap(long hocvienid, int hocky)
        {
            var data = from a in db.HocVien_MonHoc
                       join b in db.MonHocs on a.MonHocID equals b.ID
                       where a.HocVienID == hocvienid && (int)b.KyHoc == hocky
                       select new DiemView()
                       {
                           HocVienID = a.HocVienID,
                           KetQua = (float)a.Diem,
                           MonHoc = b.Ten,
                           MonHocID = a.MonHocID,
                           SoTin = (int)b.SoTin
                       };
            return data.ToList();
        }
        public bool EditDiem(HocVien_MonHoc item)
        {
            try
            {
                var dbEntry = db.HocVien_MonHoc.SingleOrDefault(x => x.HocVienID == item.HocVienID && x.MonHocID == item.MonHocID);
                dbEntry.Diem = item.Diem;
>>>>>>> 94f2b37dd013245cfcadbf1b2cbb2c1edcf877fc
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
