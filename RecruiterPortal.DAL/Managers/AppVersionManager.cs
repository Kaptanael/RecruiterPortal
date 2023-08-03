using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;

namespace RecruiterPortalDAL.Managers
{
    public class AppVersionManager
    {
        public static DataTable GetAppVersion()
        {
            string spName = "SP_GET_App_Version";

            GenericRepository<AppVersion> appRepo = new GenericRepository<AppVersion>();
            SqlParameter[] sqlParameters = appRepo.GetSqlParametersFromStoredProcedure(spName);
            DataTable agencyDt = null;
            try
            {
                agencyDt = appRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return agencyDt;
        }
        public static int UpdateAppVersion(AppVersion appVersion)
        {
            string spName = "sp_UpdateAppVersion";

            try
            {

                GenericRepository<AppVersion> appVersionRepo = new GenericRepository<AppVersion>();
                SqlParameter[] sqlParameters = appVersionRepo.GetSqlParametersFromObject(appVersion, spName, "@p_");
                appVersionRepo.Update(spName, sqlParameters);
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
