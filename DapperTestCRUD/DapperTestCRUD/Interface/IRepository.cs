using System.Collections.Generic;

namespace DapperTestCRUD.Interface
{
    interface IRepository<T>
    {
        IEnumerable<T> GetRecords(int amount,bool descOrAsc);
        T GetSingleRecord(int recordId);
        bool InsertRecord(T record);
        bool DeleteRecord(int recordId);
        bool UpdateRecord(T record);
        
    }
}
