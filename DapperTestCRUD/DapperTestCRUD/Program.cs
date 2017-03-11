using Dapper;
using DapperTestCRUD.POCO;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DapperTestCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            //sample query, gets 10 records from Produkt
            using (var dBConnection = GetDBConnection())
            {
                dBConnection.Open();
                var query = "Select top 10 * from "+nameof(Dostawca);
                var resultQuery = dBConnection.Query<Dostawca>(query);
                foreach (var item in resultQuery)
                {
                        Console.WriteLine(item);
                }
            }
        }
        private static SqlConnection GetDBConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["msSQLDataBase"].ConnectionString);
        }
    }
}
