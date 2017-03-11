using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTestCRUD
{
    class Dostawa
    {
        public int IdDostawa { get; set; }
        public int IdProdukt { get; set; }
        public int IdMagazyn { get; set; }
        public int IdDdostawcy{ get; set; }
        public int Ilosc { get; set; }
        public decimal Cena{ get; set; }
        public SqlDateTime  DataDostawy { get; set; }
    }
}
