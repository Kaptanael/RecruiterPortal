using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;

namespace RecruiterPortalDAL.Managers
{
    public class UploadFileManager
    {
        public static int SaveUserFile(UserFile userFile)
        {
            string spName = "sp_InsertUserFile";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserFile>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@p_" + nameof(userFile.FileType).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userFile.FileType;
                    }
                    else if ("@p_" + nameof(userFile.FileData).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userFile.FileData;
                    }
                    else if ("@p_" + nameof(userFile.FileName) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userFile.FileName;
                    }
                    else if ("@p_" + nameof(userFile.CreatedDate) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userFile.CreatedDate;
                    }
                    else if ("@p_" + nameof(userFile.UserId) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userFile.UserId;
                    }
                }

                List<SqlParameter> returnPrms = new GenericRepository<UserFile>().Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
        public static IEnumerable<UserFile> GetUserFileByID(Int64 p_UserID)
        {
            string spName = "sp_GetUserFileDetails";
            SqlParameter[] sqlParameters = new GenericRepository<User>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_UserID;
                }
            }

            IEnumerable<UserFile> userFiles = null;

            try
            {

                userFiles = new GenericRepository<UserFile>().GetAll(spName, sqlParameters);

            }
            catch (Exception ex)
            {                 
                throw new Exception(ex.Message);
            }

            return userFiles;
        }
        public static IEnumerable<UserFile> GetUserFileByFileType(Int64 p_UserID,byte p_FileType)
        {
            string spName = "sp_GetUserFileDetailsByFileType";
            SqlParameter[] sqlParameters = new GenericRepository<User>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_UserID;
                }
                if ("@" + nameof(p_FileType) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_FileType;
                }
            }

            IEnumerable<UserFile> userFiles = null;

            try
            {

                userFiles = new GenericRepository<UserFile>().GetAll(spName, sqlParameters);

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }

            return userFiles;
        }
        public static int DeleteUserFile(long p_UserFileID)
        {
            string spName = "sp_DeleteUserFile";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserFile>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@" + nameof(p_UserFileID) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = p_UserFileID;
                    }
                }

                var result = new GenericRepository<UserFile>().Delete(spName, sqlParameters);
                return result;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}
