using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Models
{
    public class ExerciseequipmentModel
    {
        [Required]
        [MaxLength(50)]
       
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public int? Price { get; set; }
        public string Note { get; set; }
    }
}
