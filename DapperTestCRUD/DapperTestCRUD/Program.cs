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
                var query = "Select top 10 * from "+nameof(Produkt);
                var resultQuery = dBConnection.Query<Produkt>(query);
                foreach (var item in resultQuery)
                {
                    if (( item.Jednostka_Produktu != "sztuki" ))
                        Console.WriteLine(item);
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
