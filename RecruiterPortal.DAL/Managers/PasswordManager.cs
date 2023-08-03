using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using RecruiterPortal.DAL.Utility;

namespace RecruiterPortalDAL.Managers
{
    public class PasswordManager
    {
        public static int ChangePassword(long UserID, string Password)
        {
            string spName = "sp_UpdatePassword";
            try
            {
                dynamic ChangePassword = new System.Dynamic.ExpandoObject();

                ChangePassword.UserID = UserID;
                ChangePassword.Password = SHA256Hasher.GetSHA256Hash(AESEncryptor.EncryptStringToBytes_Aes(Password));

                GenericRepository<User> userVerificationRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userVerificationRepo.GetSqlParametersFromExpandoObject(ChangePassword, spName, "@p_");             

                return userVerificationRepo.Update(spName, sqlParameters);
            }
            catch (Exception ex)
            {             
                throw new Exception(ex.Message);
            }            
        }
        public static int ForgotPassword(string p_Email)
        {
            string spName = "sp_UpdatePasswordByEmail";
            try
            {

                string p_Password = CodeGenerator.GenerateTemporaryPassword();
                dynamic ForgotPassword = new System.Dynamic.ExpandoObject();

                ForgotPassword.p_Email = p_Email;
                ForgotPassword.p_Password = SHA256Hasher.GetSHA256Hash(AESEncryptor.EncryptStringToBytes_Aes(p_Password));

                GenericRepository<User> userVerificationRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userVerificationRepo.GetSqlParametersFromExpandoObject(ForgotPassword, spName, "@");
                
                var result = userVerificationRepo.Update(spName, sqlParameters);

                if (result != 0)
                {
                    string mailBody = "Use this password to login to your account for UMR Recruitment Service: " + p_Password;
                    string mailSubject = "Password for UMR Recruitment Service";

                    //MailSender.SendEmail(p_Email, mailSubject, mailBody);
                }
                return result;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
        public static bool IsEmailExist(string p_Email)
        {
            string spName = "SP_GETUSERBYUSERNAME";

            try
            {
                dynamic ForgotPassword = new System.Dynamic.ExpandoObject();

                ForgotPassword.p_Email = p_Email;

                GenericRepository<User> userVerificationRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userVerificationRepo.GetSqlParametersFromExpandoObject(ForgotPassword, spName, "@");

                return userVerificationRepo.DoesExist(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool CheckOldPassword(string p_Email, string p_Password)
        {
            bool isValid = false;
            string spName = "SP_USERVALIDATE";

            dynamic CheckOldPassword = new System.Dynamic.ExpandoObject();

            try
            {
                CheckOldPassword.p_Email = p_Email;
                CheckOldPassword.p_Password = SHA256Hasher.GetSHA256Hash(AESEncryptor.EncryptStringToBytes_Aes(p_Password.Trim()));

                GenericRepository<User> userVerificationRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userVerificationRepo.GetSqlParametersFromExpandoObject(CheckOldPassword, spName, "@");

                if (userVerificationRepo.DoesExist(spName, sqlParameters))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isValid;
        }
    }
}
