using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Landlyst.DataHandling
{
    public static class ConnectDB
    {
        /// <summary>
        /// Returns a connection string for the Database
        /// </summary>
        /// <returns></returns>
        public static string ConnectionSource()
        {
            string[] file = File.ReadAllLines($"{Environment.CurrentDirectory}\\DatabaseConnect.txt");
            
            return file[0];
        }
    }
}
