using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class InfluenzaVaccinationManager
    {
        public static int InsertInfluenzaVaccination(InfluenzaVaccination influenzaVaccination)
        {
            string spName = "sp_InsertInfluenzaVaccination";

            try
            {
                GenericRepository<InfluenzaVaccination> influenzaVaccinationRepo = new GenericRepository<InfluenzaVaccination>();
                SqlParameter[] sqlParameters = influenzaVaccinationRepo.GetSqlParametersFromObject(influenzaVaccination, spName, "@");
                influenzaVaccinationRepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateInfluenzaVaccination(InfluenzaVaccination influenzaVaccination)
        {
            string spName = "sp_UpdateInfluenzaVaccination";

            try
            {
                GenericRepository<InfluenzaVaccination> influenzaVaccinationRepo = new GenericRepository<InfluenzaVaccination>();
                SqlParameter[] sqlParameters = influenzaVaccinationRepo.GetSqlParametersFromObject(influenzaVaccination, spName, "@");
                return influenzaVaccinationRepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static InfluenzaVaccination GetInfluenzaVaccinationByUserId(long userId)
        {
            string spName = "sp_GetInfluenzaVaccinationUserID";

            try
            {
                GenericRepository<InfluenzaVaccination> influenzaVaccinationRepo = new GenericRepository<InfluenzaVaccination>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = userId;
                SqlParameter[] sqlParameters = influenzaVaccinationRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@");

                return influenzaVaccinationRepo.GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetInfluenzaVaccinationDataTableByUserId(long userId)
        {
            string spName = "sp_GetInfluenzaVaccinationUserID";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userId;
            GenericRepository<InfluenzaVaccination> influenzaVaccinationRepo = new GenericRepository<InfluenzaVaccination>();
            SqlParameter[] sqlParameters = influenzaVaccinationRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable influenzaVaccinationDataTable = null;
            try
            {
                influenzaVaccinationDataTable = influenzaVaccinationRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return influenzaVaccinationDataTable;            
        }
    }
}
