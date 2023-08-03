using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class TermsConditionsManager
    {
        public static int InsertTermsCondition(TermsCondition termsCondition)
        {
            string spName = "sp_InsertTermsConditions";

            try
            {
                GenericRepository<TermsCondition> termsConditionRepo = new GenericRepository<TermsCondition>();
                SqlParameter[] sqlParameters = termsConditionRepo.GetSqlParametersFromObject(termsCondition, spName, "@");
                termsConditionRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateTermsCondition(TermsCondition termsCondition)
        {
            string spName = "sp_UpdateTermsConditions";

            try
            {
                GenericRepository<TermsCondition> termsConditionRepo = new GenericRepository<TermsCondition>();
                SqlParameter[] sqlParameters = termsConditionRepo.GetSqlParametersFromObject(termsCondition, spName, "@");
                return termsConditionRepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static TermsCondition GetTermsConditionByUserId(long userId)
        {
            string spName = "sp_GetTermsConditionsByUserID";

            try
            {
                GenericRepository<TermsCondition> termsConditionsRepo = new GenericRepository<TermsCondition>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = termsConditionsRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@");

                return termsConditionsRepo.GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetTermsConditionDataTableByUserId(long userId)
        {
            string spName = "sp_GetTermsConditionsByUserID";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userId;
            GenericRepository<TermsCondition> termsConditionsRepo = new GenericRepository<TermsCondition>();
            SqlParameter[] sqlParameters = termsConditionsRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable termsConditionsDataTable = null;
            try
            {
                termsConditionsDataTable = termsConditionsRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return termsConditionsDataTable;
        }
    }
}
