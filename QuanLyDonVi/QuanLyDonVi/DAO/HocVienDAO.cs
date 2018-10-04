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

                //Them mon hoc

                List<Lop_MonHoc> monhoc = db.Lop_MonHoc.Where(x => x.LopID == item.LopID).ToList();
                HocVien_MonHoc temp_mh = new HocVien_MonHoc();
                temp_mh.HocVienID = item.ID;
                temp_mh.Diem = 0;
                foreach(var mh in monhoc)
                {
                    temp_mh.MonHocID = mh.MonHocID;
                    this.Add_HocVien_MonHoc(temp_mh);
                }

                // Them mon the luc

                List<MonTheLuc> montheluc = db.MonTheLucs.ToList();
                HocVien_TheLuc temp_mtl = new HocVien_TheLuc();
                temp_mtl.HocVienID = item.ID;
                temp_mtl.KetQua = 0;
                foreach(var mtl in montheluc)
                {
                    temp_mtl.MonTheLucID = mtl.ID;
                    this.Add_HocVien_MonTheLuc(temp_mtl);
                }

                //Them mon cong tac dang

                List<CongTacDang> monctd = db.CongTacDangs.ToList();
                HocVien_CongTacDang temp_mctd = new HocVien_CongTacDang();
                temp_mctd.HocVienID = item.ID;
                temp_mctd.Diem = 0;
                foreach (var mctd in monctd)
                {
                    temp_mctd.Diem = mctd.ID;
                    this.Add_HocVien_CongTacDang(temp_mctd);
                }

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

                // Xoa ket qua hoc tap 

                List<HocVien_MonHoc> monhoc = db.HocVien_MonHoc.Where(x => x.HocVienID == id).ToList();

                foreach(var item in monhoc)
                {
                    db.HocVien_MonHoc.Remove(item);
                }

                // Xoa ket qua TL

                List<HocVien_TheLuc> montl = db.HocVien_TheLuc.Where(x => x.HocVienID == id).ToList();

                foreach (var item in montl)
                {
                    db.HocVien_TheLuc.Remove(item);
                }

                //Xoa ket qua CTD

                List<HocVien_CongTacDang> monctd = db.HocVien_CongTacDang.Where(x => x.HocVienID == id).ToList();

                foreach (var item in monctd)
                {
                    db.HocVien_CongTacDang.Remove(item);
                }
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
        public bool Add_HocVien_MonTheLuc(HocVien_TheLuc item)
        {
            try
            {
                db.HocVien_TheLuc.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Add_HocVien_CongTacDang(HocVien_CongTacDang item)
        {
            try
            {
                db.HocVien_CongTacDang.Add(item);
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
