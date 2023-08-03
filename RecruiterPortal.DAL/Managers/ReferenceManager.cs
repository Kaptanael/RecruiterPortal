using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class ReferenceManager
    {
        public static void Save(UserReference userReference)
        {
            string spName = "sp_InsertUserReference";

            try
            {
                GenericRepository<UserReference> userReferenceRepo = new GenericRepository<UserReference>();
                SqlParameter[] sqlParameters = userReferenceRepo.GetSqlParametersFromObject(userReference, spName);
                userReferenceRepo.Insert(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(UserReference userReference)
        {
            string spName = "sp_UpdateUserReferenceByUserReferenceID";

            try
            {
                GenericRepository<UserReference> userReferenceRepo = new GenericRepository<UserReference>();
                SqlParameter[] sqlParameters = userReferenceRepo.GetSqlParametersFromObject(userReference, spName);
                userReferenceRepo.Update(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(long userReferenceId)
        {
            string spName = "sp_DeleteUserReferenceByUserReferenceID";

            try
            {
                GenericRepository<UserReference> userReferenceRepo = new GenericRepository<UserReference>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserReferenceID = userReferenceId;
                SqlParameter[] sqlParameters = userReferenceRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                userReferenceRepo.Delete(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<UserReference> GetUserReferenceByUserId(long userId)
        {
            string spName = "sp_GetUserReferenceByUserID";

            try
            {
                GenericRepository<UserReference> userReferenceRepo = new GenericRepository<UserReference>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = userReferenceRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                IEnumerable<UserReference> userReferences = userReferenceRepo.GetAll(spName, sqlParameters); ;

                return userReferences;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetUserReferenceDataTableByUserId(long userId)
        {
            string spName = "sp_GetUserReferenceByUserID";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userId;
            GenericRepository<UserReference> referenceRepo = new GenericRepository<UserReference>();
            SqlParameter[] sqlParameters = referenceRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable referenceDataTable = null;
            try
            {
                referenceDataTable = referenceRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return referenceDataTable;
        }
        public static UserReference GetUserReferenceById(long userReferenceId)
        {
            string spName = "sp_GetUserReferenceByID";

            try
            {
                GenericRepository<UserReference> userReferenceRepo = new GenericRepository<UserReference>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserReferenceID = userReferenceId;
                SqlParameter[] sqlParameters = userReferenceRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                UserReference userReference = userReferenceRepo.GetOne(spName, sqlParameters); ;

                return userReference;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
