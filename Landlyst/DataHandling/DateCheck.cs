using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Landlyst.Models;

namespace Landlyst.DataHandling
{
    public class DateCheck
    {
        Data Data { get; set; }

        /// <summary>
        /// Checks if any current orders are over their ending date
        /// </summary>
        public void CheckOrderOutOfDate()
        {
            Data = new Data();
            List<int> outofdateOrders = new List<int>();

            foreach(var item in Data.GetDBData.GetOrders())
            {
                if(DateTime.Now.Date > item.EndDate)
                {
                    outofdateOrders.Add(item.OrderID);
                }
            }

            if(outofdateOrders.Count > 0)
            {
                Data.UpdateDBData.DeleteOrders(outofdateOrders);
            }
        }
    }
}
