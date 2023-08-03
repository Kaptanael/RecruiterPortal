using Microsoft.Data.SqlClient;
using System.Data;

namespace RecruiterPortal.DAL.Repository
{
    public interface IRepository<T> : IDisposable
    {        
        IEnumerable<T> ExcuteSqlQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters = null);
     
        void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        IEnumerable<T> ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null);
    }
}
