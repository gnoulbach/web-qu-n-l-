using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Models
{
    public class InvoiceModel
    {
        public InvoiceModel()
        {
            Invoicedetails = new HashSet<InvoicedetailModel>();
        }

        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }

        public virtual UserModel User { get; set; }
        public virtual ICollection<InvoicedetailModel> Invoicedetails { get; set; }
    }
}
