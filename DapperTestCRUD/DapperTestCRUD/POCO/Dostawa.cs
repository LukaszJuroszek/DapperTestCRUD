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
        public int ID_Dostawa { get; set; }
        public int ID_Produkt { get; set; }
        public int ID_Magazyn { get; set; }
        public int ID_Ddostawcy{ get; set; }
        public int Ilosc { get; set; }
        public decimal Cena{ get; set; }
        public SqlDateTime  DataDostawy { get; set; }
    }
}
