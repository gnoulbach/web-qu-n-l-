using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapp.Models
{
    public class UserModel
    {
       
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
        public int? Status { get; set; }

    }
}
