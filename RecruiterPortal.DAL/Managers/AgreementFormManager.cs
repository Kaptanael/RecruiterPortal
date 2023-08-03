using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class AgreementFormManager
    {
        public static int SaveAgreement(AgreementFrom agreement)
        {
            string spName = "sp_InsertAgreementForm";

            try
            {
                GenericRepository<AgreementFrom> agreementRepo = new GenericRepository<AgreementFrom>();
                SqlParameter[] sqlParameters = agreementRepo.GetSqlParametersFromObject(agreement, spName, "@p_");
                agreementRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateAgreement(AgreementFrom agreement)
        {
            string spName = "sp_UpdateAgreementForm";

            try
            {

                GenericRepository<AgreementFrom> agreementRepo = new GenericRepository<AgreementFrom>();
                SqlParameter[] sqlParameters = agreementRepo.GetSqlParametersFromObject(agreement, spName, "@p_");
                agreementRepo.Update(spName, sqlParameters);
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static AgreementFrom GetAgreementByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserAgreement";


            SqlParameter[] sqlParameters = new GenericRepository<AgreementFrom>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_UserID;
                }
            }

            AgreementFrom agreement;

            try
            {
                agreement = new GenericRepository<AgreementFrom>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return agreement;
        }

        public static DataTable GetAgreementDataTableByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserAgreement";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.p_UserID = p_UserID;
            GenericRepository<AgreementFrom> agreementRepo = new GenericRepository<AgreementFrom>();
            SqlParameter[] sqlParameters = agreementRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable agreementDataTable = null;
            try
            {
                agreementDataTable = agreementRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return agreementDataTable;
        }
    }
}
