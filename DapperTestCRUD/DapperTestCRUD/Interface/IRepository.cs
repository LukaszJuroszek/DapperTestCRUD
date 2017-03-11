using System.Collections.Generic;

namespace DapperTestCRUD.Interface
{
    interface IRepository<T>
    {
        ICollection<T> GetRecords(int amount,bool DescOrAsc);
        T GetSingleRecord(int recordId);
        bool InsertRecord(T record);
        bool DeleteRecord(int recordId);
        bool UpdateRecord(T record);
        
    }
}
