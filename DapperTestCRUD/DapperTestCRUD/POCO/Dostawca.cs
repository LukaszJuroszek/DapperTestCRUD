using System.Text;

namespace DapperTestCRUD.POCO
{
    public class Dostawca
    {
        public int IdDostawca { get; set; }
        public string Imie{ get; set; }
        public string Nazwisko{ get; set; }
        public string Miejscowosc{ get; set; }
        public string Ulica { get; set; }
        public string Telefon { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{IdDostawca},{Imie},{Nazwisko},{Miejscowosc},{Ulica},{Telefon}");
            return sb.ToString();
        }
    }
}
