using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Models
{
    public class InvoicedetailModel
    {
        public int? InvoiceId { get; set; }
        public int? PackageId { get; set; }

        public virtual InvoiceModel Invoice { get; set; }
        public virtual WorkoutpackageModel Package { get; set; }
    }
}
