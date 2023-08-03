using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class UserPhotoManager
    {
        public static void Insert(UserPhoto userPhoto)
        {
            string spName = "sp_InsertUserPhoto";

            try
            {
                GenericRepository<UserPhoto> userPhotoRepo = new GenericRepository<UserPhoto>();
                SqlParameter[] sqlParameters = userPhotoRepo.GetSqlParametersFromObject(userPhoto, spName);
                userPhotoRepo.Insert(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Update(UserPhoto userPhoto)
        {
            string spName = "sp_UpdateUserPhoto";

            try
            {
                GenericRepository<UserPhoto> userPhotoRepo = new GenericRepository<UserPhoto>();
                SqlParameter[] sqlParameters = userPhotoRepo.GetSqlParametersFromObject(userPhoto, spName);
                userPhotoRepo.Update(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(Int64 p_UserID)
        {
            string spName = "sp_DeleteUserPhoto";

            try
            {
                GenericRepository<UserPhoto> userPhotoRepo = new GenericRepository<UserPhoto>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = p_UserID;
                SqlParameter[] sqlParameters = userPhotoRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                userPhotoRepo.Delete(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static UserPhoto GetUserPhotoByUserId(Int64 UserID)
        {
            string spName = "sp_GetUserPhoto";


            SqlParameter[] sqlParameters = new GenericRepository<UserPhoto>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = UserID;
                }
            }

            UserPhoto userPhoto;

            try
            {
                userPhoto = new GenericRepository<UserPhoto>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userPhoto;
        }
    }
}
