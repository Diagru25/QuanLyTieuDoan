namespace QuanLyDonVi.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HocVien_TheLuc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HocVienID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MonTheLucID { get; set; }

        public double? KetQua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKiemTra { get; set; }
    }
}
