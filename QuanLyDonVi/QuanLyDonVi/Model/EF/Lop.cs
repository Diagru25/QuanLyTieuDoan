namespace QuanLyDonVi.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lop")]
    public partial class Lop
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        public long? DaiDoiID { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
    }
}
