namespace QuanLyDonVi.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongTacDang")]
    public partial class CongTacDang
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public double? Dat { get; set; }

        public double? Kha { get; set; }

        public double? Gioi { get; set; }

        public int? Nam { get; set; }
    }
}
