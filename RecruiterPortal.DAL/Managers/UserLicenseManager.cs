using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class UserLicenseManager
    {
        public static void Save(UserLicense userLicense)
        {
            string spName = "sp_InsertUserLicense";

            try
            {
                GenericRepository<UserLicense> userLicenseRepo = new GenericRepository<UserLicense>();
                SqlParameter[] sqlParameters = userLicenseRepo.GetSqlParametersFromObject(userLicense, spName);
                userLicenseRepo.Insert(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(UserLicense userLicense)
        {
            string spName = "sp_UpdateUserLicense";

            try
            {
                GenericRepository<UserLicense> userLicenseRepo = new GenericRepository<UserLicense>();
                SqlParameter[] sqlParameters = userLicenseRepo.GetSqlParametersFromObject(userLicense, spName);
                userLicenseRepo.Update(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(long licenseId)
        {
            string spName = "sp_DeleteUserLicense";

            try
            {
                GenericRepository<UserLicense> userLicenseRepo = new GenericRepository<UserLicense>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.LicenseID = licenseId;
                SqlParameter[] sqlParameters = userLicenseRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                userLicenseRepo.Delete(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<UserLicense> GetUserLicenseByUserId(long userId)
        {
            string spName = "sp_GetUserLicense";

            try
            {
                GenericRepository<UserLicense> userLicenseRepo = new GenericRepository<UserLicense>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = userLicenseRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                IEnumerable<UserLicense> licenses = userLicenseRepo.GetAll(spName, sqlParameters); ;

                return licenses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetUserLicenseDataTableByUserId(Int64 p_UserID)
        {
            string spName = "sp_GetUserLicense";

            GenericRepository<UserLicense> userLicenseRepo = new GenericRepository<UserLicense>();
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = p_UserID;
            SqlParameter[] sqlParameters = userLicenseRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable licenceDataTable = null;
            try
            {
                licenceDataTable = userLicenseRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return licenceDataTable;
        }
        public static IEnumerable<UserLicense> GetUserLicenseByFileType(long userId, byte fileType)
        {
            string spName = "sp_GetUserLicenseByFileType";

            try
            {
                GenericRepository<UserLicense> userLicenseRepo = new GenericRepository<UserLicense>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                expandoObject.FileType = fileType;
                SqlParameter[] sqlParameters = userLicenseRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                IEnumerable<UserLicense> licenses = userLicenseRepo.GetAll(spName, sqlParameters); ;

                return licenses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static UserLicense GetUserLicenseById(long licenseId)
        {
            string spName = "sp_GetUserLicenseByID";

            try
            {
                GenericRepository<UserLicense> licenseRepo = new GenericRepository<UserLicense>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.LicenseID = licenseId;
                SqlParameter[] sqlParameters = licenseRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                UserLicense license = licenseRepo.GetOne(spName, sqlParameters); ;

                return license;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
