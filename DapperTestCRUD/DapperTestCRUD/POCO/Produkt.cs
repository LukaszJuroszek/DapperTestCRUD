using DapperTestCRUD.Interface;
using System.Text;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace DapperTestCRUD
{
    public class Produkt : Repository, IRepository<Produkt>
    {
        public int IdProdukt { get; set; }
        public string Nazwa { get; set; }
        public string JednostkaProduktu { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{IdProdukt},{Nazwa},{JednostkaProduktu}");
            return sb.ToString();
        }
        public bool DeleteRecord(int recordId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Produkt> GetRecords(int amount,bool descOrAsc)
        {
            if (amount <= 0)
                throw new Exception("amount should by lower that 0 ");
            var descOrNot = descOrAsc ? "DESC" : "ASC";
            using (var db = DBConnection())
            {
                db.Open();
                var query = $"SELECT TOP {amount} * FROM Produkt ORDER BY IdProdukt {descOrNot}";
                return db.Query<Produkt>(query);
            }
        }
        public Produkt GetSingleRecord(int recordId)
        {
            using (var db = DBConnection())
            {
                db.Open();
                var query = $"SELECT * FROM Produkt WHERE IdProdukt={recordId}";
                return db.Query<Produkt>(query).SingleOrDefault();
            }
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
