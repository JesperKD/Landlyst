using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Landlyst.Models;

namespace Landlyst.DataHandling
{
    public class RoomSearch
    {
        private static GetDBData GetDBData { get; set; }


        public List<RoomViewModel> searchRooms(RoomViewModel roomModel)
        {
            GetDBData = new GetDBData();
            List<RoomViewModel> tempList = new List<RoomViewModel>();

            foreach (Room item in GetDBData.GetRooms())
            {
                if (roomModel.Balcony == item.Balcony && roomModel.Doublebed == item.Doublebed && roomModel.Split_Beds == item.Split_Beds && roomModel.Bathtub == item.Bathtub && roomModel.Jacuzzi == item.Jacuzzi && roomModel.Kitchen == item.Kitchen)
                {
                    RoomViewModel tempModel = new RoomViewModel();

                    tempModel.RoomNr = item.RoomNr;
                    tempModel.Balcony = item.Balcony;
                    tempModel.Doublebed = item.Doublebed;
                    tempModel.Split_Beds = item.Split_Beds;
                    tempModel.Bathtub = item.Bathtub;
                    tempModel.Jacuzzi = item.Jacuzzi;
                    tempModel.Kitchen = item.Kitchen;

                    tempList.Add(tempModel);
                }
            }
            return tempList;
        }

        public Room FindOrderedRoom(OrderViewModel order)
        {
            GetDBData = new GetDBData();
            Room room = new Room();

            foreach (Room item in GetDBData.GetRooms())
            {
                if (order.RoomNr == item.RoomNr)
                {
                    room = item;
                }
            }

            return room;
        }

    }
}
