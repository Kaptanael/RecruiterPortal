using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class USCISManager
    {
        public static int SaveUSCIS(Usci userUSCIS)
        {
            string spName = "sp_USCIS_Insert";

            try
            {
                GenericRepository<Usci> userUSCISRepo = new GenericRepository<Usci>();
                SqlParameter[] sqlParameters = userUSCISRepo.GetSqlParametersFromObject(userUSCIS, spName, "@");
                userUSCISRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateUSCIS(Usci userUSCIS)
        {
            string spName = "sp_USCIS_Update";

            try
            {
                GenericRepository<Usci> userUSCISRepo = new GenericRepository<Usci>();
                SqlParameter[] sqlParameters = userUSCISRepo.GetSqlParametersFromObject(userUSCIS, spName, "@");
                return userUSCISRepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteUSCIS(long uSCISID)
        {
            string spName = "sp_USCIS_Delete";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@USCISID" == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = uSCISID;
                    }
                    else
                    {
                        sqlParameter.Value = DBNull.Value;
                    }
                }
                var result = new GenericRepository<Usci>().Delete(spName, sqlParameters);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Usci GetByUserID(Int64 userID)
        {
            string spName = "sp_USCIS_Select";


            GenericRepository<UserEmergencyInfo> userEmergencyInfoRepo = new GenericRepository<UserEmergencyInfo>();
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userID;
            SqlParameter[] sqlParameters = new GenericRepository<Usci>().GetSqlParametersFromExpandoObject(expandoObject, spName, "@");

            Usci userUSCIS;

            try
            {
                userUSCIS = new GenericRepository<Usci>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userUSCIS;
        }

        public static DataTable GetUSCISUserID(Int64 userID)
        {
            string spName = "sp_USCIS_Select";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userID;
            GenericRepository<Usci> uscisRepo = new GenericRepository<Usci>();
            SqlParameter[] sqlParameters = uscisRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable uscisDataTable = null;
            try
            {
                uscisDataTable = uscisRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return uscisDataTable;
        }
    }
}
