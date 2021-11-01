using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMWebApITekMod10.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}
