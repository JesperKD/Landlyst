using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Landlyst.Models;

namespace Landlyst.DataHandling
{
    public class PriceCalc
    {
        private static GetDBData GetDBData { get; set; }

        public int CalculatePrice(OrderViewModel order)
        {
            RoomSearch roomSearch = new RoomSearch();
            Room room = roomSearch.FindOrderedRoom(order);
            int price = 695;

            if (room.Balcony == true)
            {
                price += 150;
            }

            if (room.Doublebed == true || room.Split_Beds == true)
            {
                price += 200;
            }

            if (room.Bathtub == true)
            {
                price += 50;
            }

            if (room.Jacuzzi == true)
            {
                price += 175;
            }

            if (room.Kitchen == true)
            {
                price += 350;
            }

            TimeSpan timespan = order.EndDate - order.StartDate;

            for (int i = 1; i < timespan.Days; i++)
            {
                price += price;
            }

            return price;
        }
    }
}
