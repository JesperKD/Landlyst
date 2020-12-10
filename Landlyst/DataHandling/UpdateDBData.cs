using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Landlyst.Models;

namespace Landlyst.DataHandling
{
    public class UpdateDBData
    {
        private static Data Data { get; set; }
        private static CustomerSearch CustomerSearch { get; set; }

        /// <summary>
        /// Creates the order in the database
        /// </summary>
        /// <param name="orderViewModel"></param>
        public void SaveOrder(OrderViewModel orderViewModel)
        {
            CustomerSearch = new CustomerSearch();
            int customerID = CustomerSearch.FindCustomerID(orderViewModel);

            using (SqlConnection connection = new SqlConnection(ConnectDB.ConnectionSource()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO OrderTable(RoomNr, CustomerID, OrderStatus, Price, CreationDate, StartDate, EndDate) VALUES(@Rn, @CID, @Os, @Price, @CD, @SD, @ED)", connection);
                cmd.Parameters.Add(new SqlParameter("@Rn", orderViewModel.RoomNr));
                cmd.Parameters.Add(new SqlParameter("@CID", customerID));
                cmd.Parameters.Add(new SqlParameter("@Os", 1));
                cmd.Parameters.Add(new SqlParameter("@Price", orderViewModel.Price));
                cmd.Parameters.Add(new SqlParameter("@CD", DateTime.Now.Date));
                cmd.Parameters.Add(new SqlParameter("@SD", orderViewModel.StartDate));
                cmd.Parameters.Add(new SqlParameter("@ED", orderViewModel.EndDate));

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the chosen room in the database
        /// </summary>
        /// <param name="roomNr"></param>
        public void SaveUpdatedRoom(int roomNr)
        {
            using (SqlConnection connection = new SqlConnection(ConnectDB.ConnectionSource()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE RoomTable SET RoomStatus=2 WHERE RoomNr={roomNr}", connection);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Creates new customer in the database
        /// </summary>
        /// <param name="orderViewModel"></param>
        public void SaveCustomer(OrderViewModel orderViewModel)
        {
            Data = new Data();
            using (SqlConnection connection = new SqlConnection(ConnectDB.ConnectionSource()))
            {
                connection.Open();
                bool newCustomer = true;

                foreach (var item in Data.GetDBData.GetCustomers())
                {
                    if (item.PhoneNr == orderViewModel.PhoneNr)
                    {
                        newCustomer = false;
                        break;
                    }
                }

                if (newCustomer == true)
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO CustomerTable(Postcode, Fname, Lname, PhoneNr, Email) VALUES(@Pc, @Fn, @Ln, @Ph, @Em)", connection);

                    cmd.Parameters.Add(new SqlParameter("@Pc", orderViewModel.Postcode));
                    cmd.Parameters.Add(new SqlParameter("@Fn", orderViewModel.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@Ln", orderViewModel.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Ph", orderViewModel.PhoneNr));
                    cmd.Parameters.Add(new SqlParameter("@Em", orderViewModel.Email));

                    cmd.ExecuteNonQuery();
                }


            }
        }

        /// <summary>
        /// Deletes orders that are out of date
        /// </summary>
        /// <param name="outOfDateOrders"></param>
        public void DeleteOrders(List<int> outOfDateOrders)
        {
            using (SqlConnection connection = new SqlConnection(ConnectDB.ConnectionSource()))
            {
                connection.Open();
                foreach (int item in outOfDateOrders)
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM OrderTable WHERE OrderID={item}", connection);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
