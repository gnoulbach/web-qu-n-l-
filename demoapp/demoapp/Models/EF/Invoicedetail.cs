using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Models.EF
{
    public partial class Invoicedetail
    {
        public int Idch { get; set; }
        public int? InvoiceId { get; set; }
        public int? PackageId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Workoutpackage Package { get; set; }
    }
}
