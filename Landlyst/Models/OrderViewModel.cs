using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.Models
{
    public class OrderViewModel
    {
        //Reservation info

        [DisplayName("Værelses Nummer")]
        public int RoomNr { get; set; }
        
        [DisplayName("Reserveres fra:")]
        public DateTime StartDate { get; set; }
        
        [DisplayName("Reserveres til:")]
        public DateTime EndDate { get; set; }

        public int Price { get; set; }


        //Customer Info:

        [DisplayName("Post nummer")]
        public int Postcode { get; set; }

        [DisplayName("Fornavn")]
        public string FirstName { get; set; }

        [DisplayName("Efternavn")]
        public string LastName { get; set; }

        [DisplayName("Telefon nummer")]
        public int PhoneNr { get; set; }

        public string Email { get; set; }
    }
}
