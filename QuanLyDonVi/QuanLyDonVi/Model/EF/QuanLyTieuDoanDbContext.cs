namespace QuanLyDonVi.Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyTieuDoanDbContext : DbContext
    {
        public QuanLyTieuDoanDbContext()
            : base("name=QuanLyTieuDoanDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CongTacDang> CongTacDangs { get; set; }
        public virtual DbSet<DaiDoi> DaiDois { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<HocVien_CongTacDang> HocVien_CongTacDang { get; set; }
        public virtual DbSet<HocVien_MonHoc> HocVien_MonHoc { get; set; }
        public virtual DbSet<HocVien_TheLuc> HocVien_TheLuc { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<Lop_MonHoc> Lop_MonHoc { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<MonTheLuc> MonTheLucs { get; set; }
        public virtual DbSet<TieuDoan> TieuDoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
