using Dapper;
using DapperTestCRUD.POCO;
using System;

namespace DapperTestCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            var produkts = new Produkt();
            var result = produkts.GetRecords(100,true);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
