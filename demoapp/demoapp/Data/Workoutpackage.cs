using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Data
{
    public partial class Workoutpackage
    {
        public Workoutpackage()
        {
            Invoicedetails = new HashSet<Invoicedetail>();
            Membercards = new HashSet<Membercard>();
        }

        public int Idg { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Timestart { get; set; }
        public DateTime? Timeend { get; set; }
        public int? Price { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Invoicedetail> Invoicedetails { get; set; }
        public virtual ICollection<Membercard> Membercards { get; set; }
    }
}
