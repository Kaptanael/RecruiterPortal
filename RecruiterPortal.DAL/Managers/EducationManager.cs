using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Collections;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class EducationManager
    {
        public static IEnumerable<UserEducation> GetEducationByUserID(long UserID)
        {
            string spName = "sp_GetEducationByUserID";

            try
            {
                GenericRepository<UserEducation> userEducationRepo = new GenericRepository<UserEducation>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = UserID;
                SqlParameter[] sqlParameters = userEducationRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                IEnumerable<UserEducation> userEducationList = userEducationRepo.GetAll(spName, sqlParameters); ;

                return userEducationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UserEducation GetEducationByEduID(long UserEducationID)
        {
            string spName = "sp_GetEducationByEduID";

            try
            {
                GenericRepository<UserEducation> userEducationRepo = new GenericRepository<UserEducation>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserEducationID = UserEducationID;
                SqlParameter[] sqlParameters = userEducationRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                UserEducation userEducation = userEducationRepo.GetOne(spName, sqlParameters); ;

                return userEducation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateEducation(UserEducation userEducation)
        {
            string spName = "sp_UpdateEducationByEduID";

            try
            {
                GenericRepository<UserEducation> userEducationRepo = new GenericRepository<UserEducation>();
                SqlParameter[] sqlParameters = userEducationRepo.GetSqlParametersFromObject(userEducation, spName);
                userEducationRepo.Insert(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertEducation(UserEducation userEducation)
        {
            string spName = "sp_InsertEducation";

            try
            {
                GenericRepository<UserEducation> userEducationRepo = new GenericRepository<UserEducation>();
                SqlParameter[] sqlParameters = userEducationRepo.GetSqlParametersFromObject(userEducation, spName);
                userEducationRepo.Insert(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteEducationByUserID(long UserID)
        {
            string spName = "sp_DeleteEducationByUserID";

            try
            {
                GenericRepository<UserEducation> userEducationRepo = new GenericRepository<UserEducation>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = UserID;
                SqlParameter[] sqlParameters = userEducationRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                userEducationRepo.Delete(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteEducationByEduID(long UserEducationID)
        {
            string spName = "sp_DeleteEducation";

            try
            {
                GenericRepository<UserEducation> userEducationRepo = new GenericRepository<UserEducation>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserEducationID = UserEducationID;
                SqlParameter[] sqlParameters = userEducationRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                userEducationRepo.Delete(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEducationByUserIDandInstitutionType(long UserID,int InstitutionType)
        {
            string spName = "sp_GetEducationByUserIDAndInstitutionType";

            GenericRepository<UserEducation> educationRepo = new GenericRepository<UserEducation>();
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = UserID;
            expandoObject.InstitutionType = InstitutionType;
            SqlParameter[] sqlParameters = educationRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable educationDataTable = null;
            try
            {
                educationDataTable = educationRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return educationDataTable;
        }
        
    }
}
