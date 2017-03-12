using DapperTestCRUD;
using Xunit;
namespace Tests
{
    public class Clas1
    {
        [Fact]
        public void InsertingProduktTest()
        {
            var affectedRowsExpectedInserted = true;
            var affectedRowsExpectedDeleted = true;
            var nazwaExpected = "TestName";
            var jednostkaProduktuExpected = "sztuki";
            var produkt = new Produkt
            {
                Nazwa = "TestName",
                JednostkaProduktu = "sztuki"
            };
            var affectedRowsActual = produkt.InsertRecord(produkt);
            Assert.Equal(affectedRowsExpectedInserted,affectedRowsActual);
            var lastId = produkt.GetLastID();
            var actualProdukt = produkt.GetSingleRecord(lastId);
            Assert.Equal(nazwaExpected,actualProdukt.Nazwa);
            Assert.Equal(nazwaExpected,actualProdukt.Nazwa);
            Assert.Equal(jednostkaProduktuExpected,actualProdukt.JednostkaProduktu);
            var deleteProduktActualRowAffacted = produkt.DeleteRecord(lastId);
            Assert.Equal(affectedRowsExpectedDeleted,deleteProduktActualRowAffacted);
        }
    }
}
