using System;
using System.Collections.Generic;

#nullable disable

namespace EDUHUMG.Models
{
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Khoahocs = new HashSet<Khoahoc>();
        }

        public int Iddanhmuc { get; set; }
        public string Tendanhmuc { get; set; }
        public string Linkdanhmuc { get; set; }

        public virtual ICollection<Khoahoc> Khoahocs { get; set; }
    }
}
