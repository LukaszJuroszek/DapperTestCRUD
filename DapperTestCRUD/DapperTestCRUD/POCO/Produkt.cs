using System.Text;

namespace DapperTestCRUD
{
    public class Produkt
    {
        public int IdProdukt { get; set; }
        public string Nazwa { get; set; }
        public string JednostkaProduktu { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{IdProdukt}, {Nazwa}, {JednostkaProduktu}");
            return sb.ToString();
        }
    }
}
