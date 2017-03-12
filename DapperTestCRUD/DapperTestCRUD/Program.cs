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
            var produktToInsert = new Produkt
            {
                Nazwa = "TestProdukt",
                JednostkaProduktu = "sztuki"
            };
            var updatedProdukt = new Produkt
            {
                Nazwa = "newTestProdukt",
                JednostkaProduktu = "sztuki"
            };
            Console.WriteLine(produkts.UpdateRecord(updatedProdukt,58));
            Console.WriteLine(produkts.InsertRecord(produktToInsert));
            produkt.DeleteRecord(50);
        }
    }
}