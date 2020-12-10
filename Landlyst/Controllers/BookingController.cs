using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Landlyst.Models;
using Microsoft.AspNetCore.Mvc;
using Landlyst.DataHandling;

namespace Landlyst.Controllers
{
    public class BookingController : Controller
    {
        private static List<RoomViewModel> roomViewList { get; set; }
        private static RoomViewModel roomViewModel { get; set; }
        private static OrderViewModel orderViewModel { get; set; }
        private static RoomSearch roomSearch { get; set; }
        private static int chosenRoomNr { get; set; }
        private static Data Data { get; set; }
        
        [HttpGet]
        public IActionResult RoomSearch()
        {
            DateCheck dateCheck = new DateCheck();
            dateCheck.CheckOrderOutOfDate();

            return View();
        }

        [HttpPost]
        public IActionResult RoomSearch(RoomViewModel roomModel)
        {
            roomSearch = new RoomSearch();
            roomViewList = new List<RoomViewModel>();

            if (roomSearch.searchRooms(roomModel) != null && roomSearch.searchRooms(roomModel).Count != 0)
            {
                roomViewList = roomSearch.searchRooms(roomModel);
                return Redirect("SearchResult");
            }
            else
            {
                return Redirect("RoomSearchFailed");
            }
        }

        public IActionResult RoomSearchFailed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchResult()
        {



            return View(roomViewList);
        }

        [HttpPost]
        public IActionResult SearchResult(int roomNr)
        {

            return View();
        }

        [HttpGet]
        public IActionResult BookingPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookingPage(int roomNr)
        {

            return View();
        }

        public IActionResult ConfirmBooking(OrderViewModel ordViewModel)
        {

            PriceCalc pricecalc = new PriceCalc();

            ordViewModel.Price = pricecalc.CalculatePrice(ordViewModel);

            return View(ordViewModel);
        }


        public IActionResult CompletedBooking(OrderViewModel ordViewModel)
        {
            Data = new Data();
            Data.UpdateDBData.SaveUpdatedRoom(ordViewModel.RoomNr);
            Data.UpdateDBData.SaveCustomer(ordViewModel);
            Data.UpdateDBData.SaveOrder(ordViewModel);

            return View();
        }


    }
}
