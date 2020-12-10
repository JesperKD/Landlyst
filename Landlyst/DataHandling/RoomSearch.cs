using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Landlyst.Models;

namespace Landlyst.DataHandling
{
    public class RoomSearch
    {
        private static Data Data { get; set; }

        /// <summary>
        /// Returns rooms that match chosen inventory
        /// </summary>
        /// <param name="roomModel"></param>
        /// <returns></returns>
        public List<RoomViewModel> searchRooms(RoomViewModel roomModel)
        {
            Data = new Data();
            List<RoomViewModel> tempList = new List<RoomViewModel>();

            foreach (Room item in Data.GetDBData.GetRooms())
            {
                if (item.RoomStatus == 1 && roomModel.Balcony == item.Balcony && roomModel.Doublebed == item.Doublebed && roomModel.Split_Beds == item.Split_Beds && roomModel.Bathtub == item.Bathtub && roomModel.Jacuzzi == item.Jacuzzi && roomModel.Kitchen == item.Kitchen)
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

        /// <summary>
        /// returns room object of ordered room
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Room FindOrderedRoom(OrderViewModel order)
        {
            Data = new Data();
            Room room = new Room();

            foreach (Room item in Data.GetDBData.GetRooms())
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
