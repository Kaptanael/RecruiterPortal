using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using RecruiterPortal.DAL.Utility;

namespace RecruiterPortalDAL.Managers
{
    public class VerificationManager
    {
        public static int Verifiy(UserVerification userVerification)
        {
            string spName = "sp_UpdateUserVerification";


            try
            {                
                GenericRepository<UserVerification> userVerificationRepo = new GenericRepository<UserVerification>();
                SqlParameter[] sqlParameters = userVerificationRepo.GetSqlParametersFromObject(userVerification, spName, "@p_");                
                return userVerificationRepo.Update(spName, sqlParameters); ;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            
        }

        public static int ResendVerificationCode(long p_UserID, string p_userEmail)
        {
            string spName = "sp_ResendVerificationCode";


            try
            {
                dynamic ResendVerification = new System.Dynamic.ExpandoObject();

                ResendVerification.p_UserID = p_UserID;
                ResendVerification.p_userEmail = p_userEmail;

                GenericRepository<UserVerification> userVerificationRepo = new GenericRepository<UserVerification>();
                SqlParameter[] sqlParameters = userVerificationRepo.GetSqlParametersFromExpandoObject(ResendVerification, spName, "@");

                string verificationCOde = CodeGenerator.AutoGenerate(5);
                foreach (SqlParameter sqlParameter in sqlParameters)
                {
                    if (sqlParameter.ParameterName == "@p_VerficationCode")
                    {
                        sqlParameter.Value = verificationCOde;
                    }
                }

                var result = userVerificationRepo.Update(spName, sqlParameters);                

                if (result != 0)
                {
                    string mailBody = "Use this code to verify your account for UMR Recruitment Service: " + verificationCOde;
                    string mailSubject = "Verification code for UMR Recruitment Service";

                    //MailSender.SendEmail(p_userEmail, mailSubject, mailBody);
                }
                return result;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}
