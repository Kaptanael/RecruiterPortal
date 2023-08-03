using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class UserSignatureManager
    {
        public static int InsertUserSignature(UserSignature userSignature)
        {
            string spName = "sp_InsertUserSignature";

            try
            {
                GenericRepository<UserSignature> userSignatureRepo = new GenericRepository<UserSignature>();
                SqlParameter[] sqlParameters = userSignatureRepo.GetSqlParametersFromObject(userSignature, spName, "@");
                userSignatureRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateUserSignature(UserSignature userSignature)
        {
            string spName = "sp_UpdateUserSignature";

            try
            {
                GenericRepository<UserSignature> userSignatureRepo = new GenericRepository<UserSignature>();
                SqlParameter[] sqlParameters = userSignatureRepo.GetSqlParametersFromObject(userSignature, spName, "@");
                return userSignatureRepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static UserSignature GetUserSignatureByUserId(long userId)
        {
            string spName = "sp_GetUserSignatureUserID";

            try
            {
                GenericRepository<UserSignature> userSignatureRepo = new GenericRepository<UserSignature>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = userSignatureRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@");

                return userSignatureRepo.GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
