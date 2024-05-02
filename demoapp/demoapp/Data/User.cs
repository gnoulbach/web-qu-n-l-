using System;
using System.Collections.Generic;

#nullable disable

namespace demoapp.Data
{
    public partial class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
            Membercards = new HashSet<Membercard>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? Salary { get; set; }
        public string Role { get; set; }
        public int? Point { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Membercard> Membercards { get; set; }
    }
}
