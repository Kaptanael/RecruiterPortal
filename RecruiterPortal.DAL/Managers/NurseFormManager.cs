using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class NurseFormManager
    {
        public static int InsertNurseForm(NurseForm nurseForm)
        {
            string spName = "sp_InsertNurseForm";

            try
            {
                GenericRepository<NurseForm> nurseFormRepo = new GenericRepository<NurseForm>();
                SqlParameter[] sqlParameters = nurseFormRepo.GetSqlParametersFromObject(nurseForm, spName, "@");
                nurseFormRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateNurseForm(NurseForm nurseForm)
        {
            string spName = "sp_UpdateNurseForm";

            try
            {
                GenericRepository<NurseForm> nurseFormRepo = new GenericRepository<NurseForm>();
                SqlParameter[] sqlParameters = nurseFormRepo.GetSqlParametersFromObject(nurseForm, spName, "@");
                return nurseFormRepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static NurseForm GetNurseFormByUserId(long userId)
        {
            string spName = "sp_GetNurseFormByUserID";

            try
            {
                GenericRepository<NurseForm> nurseFormRepo = new GenericRepository<NurseForm>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = nurseFormRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@");

                return nurseFormRepo.GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetNurseDataTableByUserId(long userId)
        {
            string spName = "sp_GetNurseFormByUserID";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userId;
            GenericRepository<NurseForm> nurseRepo = new GenericRepository<NurseForm>();
            SqlParameter[] sqlParameters = nurseRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable nurseDataTable = null;
            try
            {
                nurseDataTable = nurseRepo.LoadDataTable(spName, sqlParameters);
                return nurseDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
