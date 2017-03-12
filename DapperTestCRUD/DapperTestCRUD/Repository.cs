using System.Configuration;
using System.Data.SqlClient;

namespace DapperTestCRUD
{
    public abstract class Repository
    {
        protected static SqlConnection DBConnection()
        {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["msSQLDataBase"].ConnectionString);
        }
    }
}
