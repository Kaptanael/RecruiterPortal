using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class UserSocialManager
    {
        public static int InsertUserSocial(UserSocial userSocial)
        {
            string spName = "sp_InsertUserSocial";

            try
            {
                GenericRepository<UserSocial> userSocialRepo = new GenericRepository<UserSocial>();
                SqlParameter[] sqlParameters = userSocialRepo.GetSqlParametersFromObject(userSocial, spName, "@");
                userSocialRepo.Insert(spName, sqlParameters);
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateUserSocial(UserSocial userSocial)
        {
            string spName = "sp_UpdateUserSocial";

            try
            {
                GenericRepository<UserSocial> userSocialRepo = new GenericRepository<UserSocial>();
                SqlParameter[] sqlParameters = userSocialRepo.GetSqlParametersFromObject(userSocial, spName, "@");
                return userSocialRepo.Update(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static UserSocial GetUserSocialByUserId(long userId)
        {
            string spName = "sp_GetUserSocialUserID";

            try
            {
                GenericRepository<UserSocial> userSocialRepo = new GenericRepository<UserSocial>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = userSocialRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@");
                return userSocialRepo.GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetUserSocialDataTableByUserId(long userId)
        {
            string spName = "sp_GetUserSocialUserID";
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userId;

            GenericRepository<UserSocial> userSocialRepo = new GenericRepository<UserSocial>();
            SqlParameter[] sqlParameters = userSocialRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable influenzaVaccinationDataTable = null;

            try
            {
                influenzaVaccinationDataTable = userSocialRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return influenzaVaccinationDataTable;
        }
    }
}
