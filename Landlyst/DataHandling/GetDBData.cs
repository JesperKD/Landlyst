﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Landlyst.DataHandling
{
    public class GetDBData
    {
        /// <summary>
        /// Returns List of orders from Database
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(ConnectDB.ConnectionSource()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("exec SelectAllOrders", connection);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int OrderID = (int)rdr["OrderID"];
                    int RoomNr = (int)rdr["RoomNr"];
                    int CustomerID = (int)rdr["CustomerID"];
                    string OrderStatus = (string)rdr["OrderStatus"];
                    int price = (int)rdr["Price"];
                    DateTime CreationDate = (DateTime)rdr["CreationDate"];
                    DateTime StartDate = (DateTime)rdr["StartDate"];
                    DateTime EndDate = (DateTime)rdr["EndDate"];

                    Order f = new Order();
                    f.OrderID = OrderID;
                    f.RoomNr = RoomNr;
                    f.CustomerID = CustomerID;
                    f.OrderStatus = OrderStatus;
                    f.Price = price;
                    f.CreationDate = CreationDate;
                    f.StartDate = StartDate;
                    f.EndDate = EndDate;

                    orders.Add(f);
                }

            }
            return orders;
        }

        /// <summary>
        /// Returns list of rooms from Database
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(ConnectDB.ConnectionSource()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("exec SelectAllRooms", connection);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int RoomNr = (int)rdr["RoomNr"];
                    bool Balcony = (bool)rdr["Balcony"];
                    bool doublebed = (bool)rdr["doublebed"];
                    bool split_beds = (bool)rdr["split_beds"];
                    bool bathtub = (bool)rdr["bathtub"];
                    bool jacuzzi = (bool)rdr["jacuzzi"];
                    bool kitchen = (bool)rdr["kitchen"];
                    int roomstatus = (int)rdr["RoomStatus"];

                    Room f = new Room();
                    f.RoomNr = RoomNr;
                    f.Balcony = Balcony;
                    f.Doublebed = doublebed;
                    f.Split_Beds = split_beds;
                    f.Bathtub = bathtub;
                    f.Jacuzzi = jacuzzi;
                    f.Kitchen = kitchen;
                    f.RoomStatus = roomstatus;

                    rooms.Add(f);
                }

            }
            return rooms;
        }

        /// <summary>
        /// Returns a list of all customers in the database
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            List<Customer> customerList = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(ConnectDB.ConnectionSource()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("exec SelectAllCustomers", connection);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int CustomerID = (int)rdr["CustomerID"];
                    int Postcode = (int)rdr["Postcode"];
                    string firstname = (string)rdr["Fname"];
                    string lastname = (string)rdr["Lname"];
                    int PhoneNr = (int)rdr["PhoneNr"];
                    string Email = (string)rdr["Email"];


                    Customer f = new Customer();
                    f.CustomerID = CustomerID;
                    f.Postcode = Postcode;
                    f.FirstName = firstname;
                    f.LastName = lastname;
                    f.PhoneNr = PhoneNr;
                    f.Email = Email;

                    customerList.Add(f);
                }

            }
            return customerList;
        }
    }
}
