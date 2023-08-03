using Microsoft.Data.SqlClient;
using System.Dynamic;

namespace RecruiterPortal.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string storedProcedureName, SqlParameter[] parameters = null);
        T GetOne(string storedProcedureName, SqlParameter[] parameters = null);
        List<SqlParameter> Insert(string storedProcedureName, SqlParameter[] parameters = null);
        int Update(string storedProcedureName, SqlParameter[] parameters = null);
        int Delete(string storedProcedureName, SqlParameter[] parameters = null);
        void Save(string storedProcedureName, SqlParameter[] parameters = null);
        bool DoesExist(string storedProcedureName, SqlParameter[] parameters = null);
        SqlParameter[] GetSqlParametersFromObject(T obj, string spName, string preFix = "@");
        SqlParameter[] GetSqlParametersFromExpandoObject(ExpandoObject obj, string spName, string preFix = "@");

    }
}
 