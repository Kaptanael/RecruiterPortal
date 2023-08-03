using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class W9FormManager
    {
        public static int SaveW9Form(W9from w9Form)
        {
            string spName = "sp_InsertW9Form";

            try
            {
                GenericRepository<W9from> w9Repo = new GenericRepository<W9from>();
                SqlParameter[] sqlParameters = w9Repo.GetSqlParametersFromObject(w9Form, spName, "@p_");
                w9Repo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateW9Form(W9from agreement)
        {
            string spName = "sp_UpdateW9Form";

            try
            {
                GenericRepository<W9from> w9Repo = new GenericRepository<W9from>();
                SqlParameter[] sqlParameters = w9Repo.GetSqlParametersFromObject(agreement, spName, "@p_");
                w9Repo.Update(spName, sqlParameters);
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static W9from GetW9FormByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserW9Form";

            SqlParameter[] sqlParameters = new GenericRepository<W9from>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_UserID;
                }
            }

            W9from w9Form;

            try
            {
                w9Form = new GenericRepository<W9from>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return w9Form;
        }
        public static DataTable GetW9FormDataTableByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserW9Form";
            dynamic expandoObject = new ExpandoObject();
            expandoObject.p_UserID = p_UserID;
            GenericRepository<W9from> w9Repo = new GenericRepository<W9from>();
            SqlParameter[] sqlParameters = w9Repo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable w9DataTable = null;

            try
            {
                w9DataTable = w9Repo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return w9DataTable;
        }
    }
}
