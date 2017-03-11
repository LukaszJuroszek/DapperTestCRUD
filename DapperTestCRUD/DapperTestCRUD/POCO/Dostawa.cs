using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTestCRUD
{
    public class Dostawa
    {
        public int IdDostawa { get; set; }
        public int IdProdukt { get; set; }
        public int IdMagazyn { get; set; }
        public int IdDdostawcy { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }
        public SqlDateTime DataDostawy { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{IdDostawa},{IdProdukt},{IdMagazyn},{IdDdostawcy},{Ilosc},{Cena},{DataDostawy}");
            return sb.ToString();
        }
    }
}
