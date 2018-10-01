namespace QuanLyDonVi.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocVien")]
    public partial class HocVien
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(200)]
        public string NoiSinh { get; set; }

        [StringLength(200)]
        public string QueQuan { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVaoDoan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVaoDang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhapNgu { get; set; }

        public long? LopID { get; set; }

        public bool? LopTruong { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string CapBac { get; set; }
    }
}
