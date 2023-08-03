using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;

namespace RecruiterPortalDAL.Managers
{
    public class AgencyManager
    {
        public static ViewAgency GetAgencyByURLPrefix(string p_Url)
        {
            string spName = "SP_GET_AgencyByUrl";
            SqlParameter[] sqlParameters = new GenericRepository<ViewAgency>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_Url) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_Url;
                }
            }

            ViewAgency agency;

            try
            {
                agency = new GenericRepository<ViewAgency>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return agency;
        }
        public static DataTable GetAgencies()
        {
            string spName = "SP_All_GET_Agency";
            GenericRepository<ViewAgency> agencyRepo = new GenericRepository<ViewAgency>();
            SqlParameter[] sqlParameters = agencyRepo.GetSqlParametersFromStoredProcedure(spName);
            DataTable agencyDt = null;
            try
            {
                agencyDt = agencyRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return agencyDt;
        }
    }
}
