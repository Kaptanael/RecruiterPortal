using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using RecruiterPortal.DAL.Utility;
using System.Data;
using System.Dynamic;
using static RecruiterPortal.DAL.Utility.Utility;

namespace RecruiterPortalDAL.Managers
{
    public class UserManager
    {   
        public static bool ValidateUser(string p_Email, string p_Password, bool useEncryption = true)
        {
            bool IsValid = false;
            string spName = "SP_USERVALIDATE";


            dynamic ValiddateLogin = new System.Dynamic.ExpandoObject();

            ValiddateLogin.p_Email = p_Email;
            if (!useEncryption)
            {
                ValiddateLogin.p_Password = p_Password.Trim();
            }
            else
            {
                ValiddateLogin.p_Password = SHA256Hasher.GetSHA256Hash(AESEncryptor.EncryptStringToBytes_Aes(p_Password.Trim()));
            }

            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(ValiddateLogin, spName, "@");           

            try
            {

                if (userRepo.DoesExist(spName, sqlParameters))
                {
                    IsValid = true;
                }
                else
                {
                    IsValid = false;
                }
            }
            catch (Exception ex)
            {             
                throw new Exception(ex.Message);
            }            

            return IsValid;
        }
        public static bool ValidateUser(string p_Email, string p_Password, int p_AgencyId, bool useEncryption = true)
        {
            bool IsValid = false;
            string spName = "SP_USERVALIDATEWithAgencyId";


            dynamic ValiddateLogin = new System.Dynamic.ExpandoObject();

            ValiddateLogin.p_Email = p_Email;
            ValiddateLogin.p_AgencyId = p_AgencyId;
            if (!useEncryption)
            {
                ValiddateLogin.p_Password = p_Password.Trim();
            }
            else
            {
                ValiddateLogin.p_Password = SHA256Hasher.GetSHA256Hash(AESEncryptor.EncryptStringToBytes_Aes(p_Password.Trim()));
            }

            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(ValiddateLogin, spName, "@");            

            try
            {

                if (userRepo.DoesExist(spName, sqlParameters))
                {
                    IsValid = true;
                }
                else
                {
                    IsValid = false;
                }
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            

            return IsValid;
        }
        public static User GetUserByID(Int64 p_UserID)
        {
            string spName = "SP_GETUSERBYUSERID";
            dynamic UserEmail = new System.Dynamic.ExpandoObject();
            UserEmail.p_UserID = p_UserID;

            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(UserEmail, spName, "@");
           
            User appUser = null;
            try
            {

                appUser = userRepo.GetOne(spName, sqlParameters);

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            

            return appUser;
        }
        public static DataTable GetUserDetailsByID(long UserID)
        {
            string spName = "sp_GetUserDetailsByUserID";
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = UserID;
            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable appUser = null;
            try
            {
                appUser = userRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return appUser;
        }
        public static void SaveUserDetails(long UserID, ApplicantInfoModel applicantInfoModel)
        {
            string spName = "sp_InsertUserDetails";
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = UserID;
            GenericRepository<ApplicantInfoModel> applicantInfRepo = new GenericRepository<ApplicantInfoModel>();
            SqlParameter[] sqlParameters = applicantInfRepo.GetSqlParametersFromObject(expandoObject, applicantInfoModel, spName);
            try
            {
                applicantInfRepo.Save(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static User GetUserByName(string p_Email)
        {
            string spName = "SP_GETUSERBYUSERNAME";

            dynamic UserEmail = new System.Dynamic.ExpandoObject();

            UserEmail.p_Email = p_Email;

            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(UserEmail, spName, "@");           
            User appUser = null;

            try
            {

                appUser = userRepo.GetOne(spName, sqlParameters);

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            

            return appUser;
        }       
        public static bool GetUserByEmail(string p_Email)
        {
            dynamic UserEmail = new System.Dynamic.ExpandoObject();
            bool IsValid = false;
            string spName = "SP_GETUSERBYUSERNAME";
            dynamic ValiddateLogin = new System.Dynamic.ExpandoObject();
            ValiddateLogin.p_Email = p_Email;

            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(ValiddateLogin, spName, "@");

            try
            {

                if (userRepo.DoesExist(spName, sqlParameters))
                {
                    IsValid = true;
                }
                else
                {
                    IsValid = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return IsValid;
        }
        public static ViewAgency GetAgencyByURL(string p_url)
        {
            string spName = "SP_GET_AgencyByUrl";


            dynamic agencyObject = new System.Dynamic.ExpandoObject();
            agencyObject.p_Url = p_url;

            GenericRepository<ViewAgency> agencyRepo = new GenericRepository<ViewAgency>();

            SqlParameter[] sqlParameters = agencyRepo.GetSqlParametersFromExpandoObject(agencyObject, spName, "@");

            try
            {
                ViewAgency agency = null;

                try
                {

                    agency = agencyRepo.GetOne(spName, sqlParameters);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return agency;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int Register(User user)
        {
            string spName = "sp_RegisterUser";


            try
            {
                user.Password = SHA256Hasher.GetSHA256Hash(AESEncryptor.EncryptStringToBytes_Aes(user.Password));
                GenericRepository<User> userRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromObject(user, spName, "@p_");

                string verificationCOde = CodeGenerator.AutoGenerate(5);
                foreach (SqlParameter sqlParameter in sqlParameters)
                {
                    if (sqlParameter.ParameterName == "@p_VerficationCode")
                    {
                        sqlParameter.Value = verificationCOde;
                    }
                }

                List<SqlParameter> returnPrms = userRepo.Insert(spName, sqlParameters);                
                string mailBody = "Use this code to verify your account for UMR Recruitment Service: " + verificationCOde;
                string mailSubject = "Verification code for UMR Recruitment Service";

                //MailSender.SendEmail(user.Email, mailSubject, mailBody);

                return 1;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }            
        }

        public static bool SendMailToRecruiter(long userId)
        {
            string spName = "SP_GetMatchApplicantRecruiterMail";

            try
            {
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                GenericRepository<User> userRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);

                DataTable userDt = userRepo.LoadDataTable(spName, sqlParameters);
                string toAddress = string.Empty;
                string applicantName = string.Empty;

                if (userDt != null && userDt.Rows.Count > 0)
                {
                    toAddress = userDt.Rows[0]["POP3UserName"].ToString();
                    DataTable dtUserDetail = GetUserDetailsByID(userId);

                    if (dtUserDetail != null && dtUserDetail.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtUserDetail.Rows[0]["MiddleName"].ToString()))
                        {
                            applicantName = dtUserDetail.Rows[0]["FirstName"].ToString() + " " + dtUserDetail.Rows[0]["MiddleName"].ToString() + " " + dtUserDetail.Rows[0]["LastName"].ToString();
                        }
                        else
                        {
                            applicantName = dtUserDetail.Rows[0]["FirstName"].ToString() + " " + dtUserDetail.Rows[0]["LastName"].ToString();
                        }
                    }

                    string mailBody = applicantName + " has uploaded a file.";
                    string mailSubject = "File Upload Notification";

                    if (!string.IsNullOrEmpty(toAddress))
                    {
                        //MailSender.SendEmail(toAddress, mailSubject, mailBody);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool SendMailToRecruiterDBModified(long userId, string fileNameModified)
        {
            string spName = "SP_GetMatchApplicantRecruiterMail";

            try
            {
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                GenericRepository<User> userRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);

                DataTable userDt = userRepo.LoadDataTable(spName, sqlParameters);
                string toAddress = string.Empty;
                string applicantName = string.Empty;

                if (userDt != null && userDt.Rows.Count > 0)
                {
                    toAddress = userDt.Rows[0]["POP3UserName"].ToString();
                    DataTable dtUserDetail = GetUserDetailsByID(userId);

                    if (dtUserDetail != null && dtUserDetail.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtUserDetail.Rows[0]["MiddleName"].ToString()))
                        {
                            applicantName = dtUserDetail.Rows[0]["FirstName"].ToString() + " " + dtUserDetail.Rows[0]["MiddleName"].ToString() + " " + dtUserDetail.Rows[0]["LastName"].ToString();
                        }
                        else
                        {
                            applicantName = dtUserDetail.Rows[0]["FirstName"].ToString() + " " + dtUserDetail.Rows[0]["LastName"].ToString();
                        }
                    }

                    string mailBody = applicantName + " " + fileNameModified + " info modified.";
                    string mailSubject = fileNameModified + " Info Change Notification";

                    if (!string.IsNullOrEmpty(toAddress))
                    {
                        //MailSender.SendEmail(toAddress, mailSubject, mailBody);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool SendMailToFinance(EnumFileType enumFileType, long userId)
        {
            try
            {
                string toAddress = string.Empty;
                string mailBody = string.Empty;
                string applicantName = string.Empty;
                string emails = string.Empty;
                DataTable userDt = GetUserEmailByRank((int)Ranks.Finance);

                if (userDt != null && userDt.Rows.Count > 0)
                {
                    DataTable dtUserDetail = GetUserDetailsByID(userId);

                    if (dtUserDetail != null && dtUserDetail.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtUserDetail.Rows[0]["MiddleName"].ToString()))
                        {
                            applicantName = dtUserDetail.Rows[0]["FirstName"].ToString() + " " + dtUserDetail.Rows[0]["MiddleName"].ToString() + " " + dtUserDetail.Rows[0]["LastName"].ToString();
                        }
                        else
                        {
                            applicantName = dtUserDetail.Rows[0]["FirstName"].ToString() + " " + dtUserDetail.Rows[0]["LastName"].ToString();
                        }
                    }

                    foreach (DataRow row in userDt.Rows)
                    {
                        toAddress += row["POP3UserName"].ToString() + ";";
                    }
                    if (enumFileType == EnumFileType.Payroll)
                    {
                        mailBody = applicantName + " has uploaded a payroll file.";
                    }
                    else if (enumFileType == EnumFileType.VoidedCheque)
                    {
                        mailBody = applicantName + " has uploaded a voided cheque file.";
                    }

                    string mailSubject = "File Upload Notification";

                    if (!string.IsNullOrEmpty(toAddress))
                    {
                        //MailSender.SendEmailMultipleToAddress(toAddress, mailSubject, mailBody);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetUserEmailByRank(int enumId)
        {
            string spName = "SP_GetUserEmailByRank";
            dynamic expandoObject = new ExpandoObject();
            expandoObject.EnumID = enumId;
            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable userDt = null;

            try
            {
                userDt = userRepo.LoadDataTable(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userDt;
        }
        public static DataTable GetMatchApplicantRecruiterMail(long userId)
        {
            string spName = "SP_GetMatchApplicantRecruiterMail";
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userId;
            GenericRepository<User> userRepo = new GenericRepository<User>();
            SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable userDt = null;

            try
            {
                userDt = userRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userDt;
        }


        public static int DeleteUserByEmail(string email)
        {
            string spName = "sp_ApendUserEmail";

            dynamic obj = new System.Dynamic.ExpandoObject();
            string generateCode = CodeGenerator.AutoGenerate(3);

            obj.UpdateEmail = email + generateCode;
            obj.Email = email;

            try
            {
                GenericRepository<User> userRepo = new GenericRepository<User>();
                SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(obj, spName, "@p_");
                return userRepo.Update(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
