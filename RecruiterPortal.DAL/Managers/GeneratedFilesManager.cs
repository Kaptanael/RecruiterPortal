using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class GeneratedFilesManager
    {
        public static int InsertGeneratedFile(GeneratedFile generatedFile)
        {
            string spName = "sp_InsertGeneratedFile";

            try
            {
                GenericRepository<GeneratedFile> generatedFileRepo = new GenericRepository<GeneratedFile>();
                SqlParameter[] sqlParameters = generatedFileRepo.GetSqlParametersFromObject(generatedFile, spName, "@");
                generatedFileRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateGeneratedFile(GeneratedFile generatedFile)
        {
            string spName = "sp_UpdateGeneratedFile";

            try
            {
                GenericRepository<GeneratedFile> generatedFileRepo = new GenericRepository<GeneratedFile>();
                SqlParameter[] sqlParameters = generatedFileRepo.GetSqlParametersFromObject(generatedFile, spName, "@");
                return generatedFileRepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static GeneratedFile GetGeneratedFileByUserIdAndFileType(long userId)
        {
            string spName = "sp_GetGeneratedFileByUserId";

            try
            {
                GenericRepository<GeneratedFile> generatedFileRepo = new GenericRepository<GeneratedFile>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = generatedFileRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@");

                return generatedFileRepo.GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetGeneratedFileByUserIdAndFileType(long userId, string fileTypeCode)
        {


            string spName = "sp_GetGeneratedFileByUserIdAndFileType";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userId;
            expandoObject.FileTypeCode = fileTypeCode;
            GenericRepository<GeneratedFile> generatedFileRepo = new GenericRepository<GeneratedFile>();
            SqlParameter[] sqlParameters = generatedFileRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable generatedFileDataTable = null;
            try
            {
                generatedFileDataTable = generatedFileRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return generatedFileDataTable;
        }
    }
}
