using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Data
{
    public partial class Membercard
    {
        public int Idt { get; set; }
        public int? UserId { get; set; }
        public int? PackageId { get; set; }
        public DateTime? Timestart { get; set; }
        public DateTime? Timeend { get; set; }
        public int? Status { get; set; }

        public virtual Workoutpackage Package { get; set; }
        public virtual User User { get; set; }
    }
}
