using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class CBCManager
    {
        public static int SaveCBC(Cbcform userCBC)
        {
            string spName = "sp_InsertCBC";

            try
            {
                GenericRepository<Cbcform> cbcFormRepo = new GenericRepository<Cbcform>();
                SqlParameter[] sqlParameters = cbcFormRepo.GetSqlParametersFromObject(userCBC, spName, "@p_");
                cbcFormRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateCBC(Cbcform cBCForm)
        {
            string spName = "sp_UpdateUserCBC";

            try
            {

                GenericRepository<Cbcform> cbcFormRepo = new GenericRepository<Cbcform>();
                SqlParameter[] sqlParameters = cbcFormRepo.GetSqlParametersFromObject(cBCForm, spName, "@p_");
                cbcFormRepo.Update(spName, sqlParameters);
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Cbcform GetByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserCBC";


            SqlParameter[] sqlParameters = new GenericRepository<Cbcform>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_UserID;
                }
            }

            Cbcform cbc;

            try
            {
                cbc = new GenericRepository<Cbcform>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cbc;
        }

        public static DataTable GetCBCDataTableByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserCBC";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.p_UserID = p_UserID;
            GenericRepository<Cbcform> cbcRepo = new GenericRepository<Cbcform>();
            SqlParameter[] sqlParameters = cbcRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable cbcDataTable = null;
            try
            {
                cbcDataTable = cbcRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cbcDataTable;
        }
    }
}
