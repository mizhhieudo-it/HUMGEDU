using System;
using System.Collections.Generic;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class Baihoc
    {
        public int Idbaihoc { get; set; }
        public string Tieudebaihoc { get; set; }
        public string Motabaihoc { get; set; }
        public string Linkvideobaihoc { get; set; }
        public string Linkbaihoc { get; set; }
        public DateTime? Thoigiantaobaihoc { get; set; }
        public DateTime? Thoigiansuabaihoc { get; set; }
        public string Nguoitaobaihoc { get; set; }
        public string Nguoisuabaihoc { get; set; }
        public bool? Trangthaibaihoc { get; set; }
        public int Idkhoahoc { get; set; }

        public virtual Khoahoc IdkhoahocNavigation { get; set; }
    }
}
