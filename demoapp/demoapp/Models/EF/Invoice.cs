using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Models.EF
{
    public partial class Invoice
    {
        public Invoice()
        {
            Invoicedetails = new HashSet<Invoicedetail>();
        }

        public int Idhd { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Invoicedetail> Invoicedetails { get; set; }
    }
}
