using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.Model.View
{
    public class HocVienView
    {
        public long ID { get; set; }
        public string Ten { get; set; }
        public string CapBac { get; set; }
        public string ChucVu { get; set; }
        public string DonVi { get; set; }
        public DateTime NgaySinh { get; set; }
        public long TieuDoan_ID { get; set; }
        public string TieuDoan_Ten { get; set; }
        public long DaiDoi_ID { get; set; }
        public string DaiDoi_Ten { get; set; }
        public long Lop_ID { get; set; }
        public string Lop_Ten { get; set; }
    }
}
