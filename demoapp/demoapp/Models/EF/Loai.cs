using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Models.EF
{
    public partial class Loai
    {
        public Loai()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        public int MaLoai { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
