using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Models.EF
{
    public partial class HangHoa
    {
        public Guid MaHh { get; set; }
        public string TenHh { get; set; }
        public string MoTa { get; set; }
        public double DonGia { get; set; }
        public short GiamGia { get; set; }
        public int MaLoai { get; set; }

        public virtual Loai MaLoaiNavigation { get; set; }
    }
}
