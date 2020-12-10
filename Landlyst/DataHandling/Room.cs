using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling
{
    public class Room
    {
        public int RoomNr { get; set; }

        public bool Balcony { get; set; }

        public bool Doublebed { get; set; }

        public bool Split_Beds { get; set; }

        public bool Bathtub { get; set; }

        public bool Jacuzzi { get; set; }

        public bool Kitchen { get; set; }

        public bool RoomStatus { get; set; }
    }
}
