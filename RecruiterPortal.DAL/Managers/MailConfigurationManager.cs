using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;

namespace RecruiterPortalDAL.Managers
{
    public class MailConfigurationManager
    {
        public const string POP3USERNAME = "trahman@ael-bd.com";
        public static ViewMailConfiguration GetEailConfigByAdress(string p_POP3UserName)
        {
            string spName = "sp_GetMailConfigByPOP3UserName";
            SqlParameter[] sqlParameters = new GenericRepository<ViewMailConfiguration>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_POP3UserName) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_POP3UserName;
                }
            }
            ViewMailConfiguration mailVerfication = null;
            try
            {

                mailVerfication = new GenericRepository<ViewMailConfiguration>().GetOne(spName, sqlParameters);

            }
            catch (Exception ex)
            {             
                throw new Exception(ex.Message);
            }            

            return mailVerfication;
        }
    }
}
