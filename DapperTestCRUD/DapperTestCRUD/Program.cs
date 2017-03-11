using System;

namespace DapperTestCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            var produkts = new Produkt();
            var result = produkts.GetRecords(100,false);
            foreach (var item in result)
                Console.WriteLine(item);
            var produkt = produkts.GetSingleRecord(2);
            Console.WriteLine(produkt);
        }
    }
}