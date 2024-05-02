using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Models
{
    public class MembercardModel
    {
        public int? UserId { get; set; }
        public int? PackageId { get; set; }
        public DateTime? Timestart { get; set; }
        public DateTime? Timeend { get; set; }
        public int? Status { get; set; }

        public virtual WorkoutpackageModel Package { get; set; }
        public virtual UserModel User { get; set; }
    }
}
