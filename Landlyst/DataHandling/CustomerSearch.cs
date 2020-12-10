using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Landlyst.Models;

namespace Landlyst.DataHandling
{
    public class CustomerSearch
    {
        Data Data { get; set; }

        /// <summary>
        /// Looks through CustomerList to check for customerID
        /// </summary>
        /// <param name="orderViewModel"></param>
        /// <returns></returns>
        public int FindCustomerID(OrderViewModel orderViewModel)
        {
            Data = new Data();
            int customerID = 0;

            foreach(var item in Data.GetDBData.GetCustomers())
            {
                if(item.PhoneNr == orderViewModel.PhoneNr)
                {
                    customerID = item.CustomerID;
                }
            }

            return customerID;
        }
    }
}
