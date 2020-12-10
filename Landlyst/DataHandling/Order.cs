using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling
{
    public class Order
    {
        public int OrderID { get; set; }

        public int RoomNr { get; set; }

        public int CustomerID { get; set; }

        public string OrderStatus { get; set; }

        public int Price { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
