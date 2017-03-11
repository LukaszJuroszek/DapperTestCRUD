using Dapper;
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
                var query = "Select top 10 * from "+nameof(Dostawa);
                var resultQuery = dBConnection.Query<Dostawa>(query);
                foreach (var item in resultQuery)
                {
                        Console.WriteLine(item.DataDostawy);
                }
            }
        }
        private static SqlConnection GetDBConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["msSQLDataBase"].ConnectionString);
        }
    }
}
