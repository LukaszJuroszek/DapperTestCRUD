using DapperTestCRUD.Interface;
using System.Text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DapperTestCRUD
{
    public class Produkt : IRepository<Produkt>
    {
        public int IdProdukt { get; set; }
        public string Nazwa { get; set; }
        public string JednostkaProduktu { get; set; }

        public int DBConnection {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{IdProdukt},{Nazwa},{JednostkaProduktu}");
            return sb.ToString();
        }
        public bool DeleteRecord(int recordId)
        {
            using (var db=)
            {

            }
            throw new NotImplementedException();
        }
        public ICollection<Produkt> GetRecords(int amount,bool DescOrAsc)
        {
            throw new NotImplementedException();
        }
        public Produkt GetSingleRecord(int recordId)
        {
            throw new NotImplementedException();
        }
        public bool InsertRecord(Produkt record)
        {
            throw new NotImplementedException();
        }
        public bool UpdateRecord(Produkt record)
        {
            throw new NotImplementedException();
        }
        
    }
}
