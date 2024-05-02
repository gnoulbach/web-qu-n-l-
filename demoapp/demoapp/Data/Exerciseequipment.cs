using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Data
{
    public partial class Exerciseequipment
    {
        public int Idm { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public int? Price { get; set; }
        public string Note { get; set; }
    }
}
