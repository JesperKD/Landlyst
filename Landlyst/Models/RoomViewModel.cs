using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.Models
{
    public class RoomViewModel
    {
        [DisplayName("Værelses Nummer")]
        public int RoomNr { get; set; }

        [DisplayName("Balkon")]
        public bool Balcony { get; set; }

        [DisplayName("Dobbelt Seng")]
        public bool Doublebed { get; set; }

        [DisplayName("2 enkelt senge")]
        public bool Split_Beds { get; set; }

        [DisplayName("Badekar")]
        public bool Bathtub { get; set; }

        [DisplayName("Jacuzzi")]
        public bool Jacuzzi { get; set; }

        [DisplayName("Eget Køkken")]
        public bool Kitchen { get; set; }
    }
}
