using System;
using System.Collections.Generic;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class Khoahoc
    {
        public Khoahoc()
        {
            Baihocs = new HashSet<Baihoc>();
        }

        public int Idkhoahoc { get; set; }
        public string Tenkhoahoc { get; set; }
        public string Linkkhoahoc { get; set; }
        public string Motakhoahoc { get; set; }
        public string Anhkhoahoc { get; set; }
        public DateTime? Thoigiantaokhoahoc { get; set; }
        public DateTime? Thoigiansuakhoahoc { get; set; }
        public string Nguoitaokhoahoc { get; set; }
        public string Nguoisuakhoahoc { get; set; }
        public bool Trangthaikhoahoc { get; set; }
        public int Iddanhmuc { get; set; }

        public virtual Danhmuc IddanhmucNavigation { get; set; }
        public virtual ICollection<Baihoc> Baihocs { get; set; }
    }
}
