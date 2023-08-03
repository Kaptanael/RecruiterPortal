using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class HepaBHIPPAManager
    {
        public static int SaveHepaBHIPPA(HepaBhippa userHepaBHIPPA)
        {
            string spName = "sp_HepaBHIPPA_Insert";

            try
            {
                GenericRepository<HepaBhippa> userHepaBHIPPARepo = new GenericRepository<HepaBhippa>();
                SqlParameter[] sqlParameters = userHepaBHIPPARepo.GetSqlParametersFromObject(userHepaBHIPPA, spName, "@");
                userHepaBHIPPARepo.Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateHepaBHIPPA(HepaBhippa userHepaBHIPPA)
        {
            string spName = "sp_HepaBHIPPA_Update";

            try
            {
                GenericRepository<HepaBhippa> userHepaBHIPPARepo = new GenericRepository<HepaBhippa>();
                SqlParameter[] sqlParameters = userHepaBHIPPARepo.GetSqlParametersFromObject(userHepaBHIPPA, spName, "@");
                return userHepaBHIPPARepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteHepaBHIPPA(long hepaBHIPPAID)
        {
            string spName = "sp_HepaBHIPPA_Delete";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@HepaBHIPPAID" == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = hepaBHIPPAID;
                    }
                    else
                    {
                        sqlParameter.Value = DBNull.Value;
                    }
                }
                var result = new GenericRepository<Usci>().Delete(spName, sqlParameters);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static HepaBhippa GetByUserID(Int64 userID)
        {
            string spName = "sp_HepaBHIPPA_Select";


            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userID;
            SqlParameter[] sqlParameters = new GenericRepository<HepaBhippa>().GetSqlParametersFromExpandoObject(expandoObject, spName, "@");

            HepaBhippa userHepaBHIPPA;

            try
            {
                userHepaBHIPPA = new GenericRepository<HepaBhippa>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userHepaBHIPPA;
        }

        public static DataTable GetHepaBHIPPADtByUserID(Int64 userID)
        {
            string spName = "sp_HepaBHIPPA_Select";


            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = userID;
            GenericRepository<HepaBhippa> hepaHipaRepo = new GenericRepository<HepaBhippa>();
            SqlParameter[] sqlParameters = hepaHipaRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable hepaHippaDataTable = null;
            try
            {
                hepaHippaDataTable = hepaHipaRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hepaHippaDataTable;
        }
    }
}
