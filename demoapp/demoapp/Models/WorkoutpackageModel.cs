using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Models
{
    public class WorkoutpackageModel
    {
        public WorkoutpackageModel()
        {
            Invoicedetails = new HashSet<InvoicedetailModel>();
            Membercards = new HashSet<MembercardModel>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Timestart { get; set; }
        public DateTime? Timeend { get; set; }
        public int? Price { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<InvoicedetailModel> Invoicedetails { get; set; }
        public virtual ICollection<MembercardModel> Membercards { get; set; }
    }
}
