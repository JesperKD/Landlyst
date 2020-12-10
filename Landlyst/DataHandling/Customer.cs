using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public int Postcode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNr { get; set; }

        public string Email { get; set; }
    }
}
