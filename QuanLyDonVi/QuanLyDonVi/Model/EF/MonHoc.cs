namespace QuanLyDonVi.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonHoc")]
    public partial class MonHoc
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        public int? KyHoc { get; set; }

        public int? SoTin { get; set; }
    }
}
