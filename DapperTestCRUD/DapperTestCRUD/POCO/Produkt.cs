using DapperTestCRUD.Interface;
using System.Text;
using System;
using System.Collections.Generic;
using Dapper;

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
            using (var db = DBConnection())
            {
                db.Open();
                var rowsAffected = db.Execute("DELETE FROM Produkt WHERE IdProdukt = @IdProdukt ",new { IdProdukt = recordId });
                return RowsAffected(rowsAffected);
            }
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
                return db.QuerySingleOrDefault<Produkt>(query);
            }
        }
        public bool InsertRecord(Produkt record)
        {
            using (var db = DBConnection())
            {
                db.Open();
                var rowsAffected = db.Execute("INSERT INTO Produkt(Nazwa,JednostkaProduktu) values(@Nazwa,@JednostkaProduktu)",new { Nazwa = record.Nazwa,JednostkaProduktu = record.JednostkaProduktu });
                return RowsAffected(rowsAffected);
            }
        }
        public bool UpdateRecord(Produkt record,int recordId)
        {
            using (var db = DBConnection())
            {
                db.Open();
                var rowsAffected = db.Execute(@"UPDATE Produkt SET Nazwa = @Nazwa, JednostkaProduktu = @JednostkaProduktu WHERE IdProdukt = @IdProdukt ",new { IdProdukt = recordId,Nazwa = record.Nazwa,JednostkaProduktu = record.JednostkaProduktu });
                return RowsAffected(rowsAffected);
            }
        }
        public int GetLastID()
        {
            using (var db = DBConnection())
            {
                db.Open();
                var lastProdukt = db.QueryFirst<Produkt>($"SELECT TOP 1 * FROM {nameof(Produkt)} ORDER BY IdProdukt DESC");
                return lastProdukt.IdProdukt;
            }
        }
        private bool RowsAffected(int rowsAffected)
        {
            return rowsAffected > 0 ? true : false;
        }
    }
}
