using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTestCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dBConnection = GetDBConnection())
            {
                dBConnection.Open();
                var query = "Select * from Produkt";
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
