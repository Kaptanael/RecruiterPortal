using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class EmergencyInfoManager
    {
        public static int InsertEmrInfo(UserEmergencyInfo emergencyInfo)
        {
            string spName = "sp_InsertEmrInfo";

            try
            {
                //SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

                //foreach (SqlParameter sqlParameter in sqlParameters)
                //{

                //    if ("@p_" + nameof(emergencyInfo.EmrFirstName) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrFirstName;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrLastName) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrLastName;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.NatureOfRelationship) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.NatureOfRelationship;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrHomePhone) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrHomePhone;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrCellPhone) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrCellPhone;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrWorkPhone) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrWorkPhone;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.UserID) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.UserID;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrType) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrType;
                //    }
                //    else
                //    {
                //        sqlParameter.Value = DBNull.Value;
                //    }
                //}
                GenericRepository<UserEmergencyInfo> userEmergencyInfoRepo = new GenericRepository< UserEmergencyInfo > ();
                SqlParameter[] sqlParameters = userEmergencyInfoRepo.GetSqlParametersFromObject(emergencyInfo, spName, "@p_");
                userEmergencyInfoRepo.Insert(spName, sqlParameters); 

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateEmrInfo(UserEmergencyInfo emergencyInfo)
        {
            string spName = "sp_UpdateEmrInfo";

            try
            {
                //SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

                //foreach (SqlParameter sqlParameter in sqlParameters)
                //{

                //    if ("@p_" + nameof(emergencyInfo.EmrFirstName) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrFirstName;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrLastName) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrLastName;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.NatureOfRelationship) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.NatureOfRelationship;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrHomePhone) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrHomePhone;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrCellPhone) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrCellPhone;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrWorkPhone) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrWorkPhone;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.EmrType) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.EmrType;
                //    }
                //    else if ("@p_" + nameof(emergencyInfo.UserID) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = emergencyInfo.UserID;
                //    }
                //    else
                //    {
                //        sqlParameter.Value = DBNull.Value;
                //    }
                //}
                //return new GenericRepository<UserEmergencyInfo>().Update(spName, sqlParameters);

                GenericRepository<UserEmergencyInfo> userEmergencyInfoRepo = new GenericRepository<UserEmergencyInfo>();
                SqlParameter[] sqlParameters = userEmergencyInfoRepo.GetSqlParametersFromObject(emergencyInfo, spName, "@p_");
                return userEmergencyInfoRepo.Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool AlreadyEmrInfoExist(long UserID, byte EmrType)
        {
            bool IsValid = false;
            string spName = "sp_GetEmrInfoByUserIdAndEmrType";


            //SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

            //foreach (SqlParameter sqlParameter in sqlParameters)
            //{
            //    if ("@p_" + nameof(UserID) == sqlParameter.ParameterName)
            //    {
            //        sqlParameter.Value = UserID;
            //    }
            //    else if ("@p_" + nameof(EmrType) == sqlParameter.ParameterName)
            //    {
            //        sqlParameter.Value = EmrType;
            //    }
            //}
            try
            {
                GenericRepository<UserEmergencyInfo> userEmergencyInfoRepo = new GenericRepository<UserEmergencyInfo>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = UserID;
                expandoObject.EmrType = EmrType;
                SqlParameter[] sqlParameters = userEmergencyInfoRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@p_");
                
                if (userEmergencyInfoRepo.DoesExist(spName, sqlParameters))
                {
                    IsValid = true;
                }
                else
                {
                    IsValid = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return IsValid;
        }
        public static IEnumerable<UserEmergencyInfo> GetEmrInfo(long UserID)
        {
            string spName = "sp_GetEmrInfoByUserId";

            try
            {
                //SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

                //foreach (SqlParameter sqlParameter in sqlParameters)
                //{

                //    if ("@p_" + nameof(UserID) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = UserID;
                //    }
                //    else
                //    {
                //        sqlParameter.Value = DBNull.Value;
                //    }
                //}
                //return new GenericRepository<UserEmergencyInfo>().GetAll(spName, sqlParameters);

                GenericRepository<UserEmergencyInfo> userEmergencyInfoRepo = new GenericRepository<UserEmergencyInfo>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.UserID = UserID;
                SqlParameter[] sqlParameters = userEmergencyInfoRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@p_");

                return userEmergencyInfoRepo.GetAll(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetEmrInfoDataTableByUserID(long UserID, byte EmrType)
        {
            string spName = "sp_GetEmrInfoByUserIdAndEmrType";

            GenericRepository<UserEmergencyInfo> userEmergencyInfoRepo = new GenericRepository<UserEmergencyInfo>();
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = UserID;
            expandoObject.EmrType = EmrType;
            SqlParameter[] sqlParameters = userEmergencyInfoRepo.GetSqlParametersFromExpandoObject(expandoObject, spName, "@p_");
            DataTable emrInfoDataTable = null;
            try
            {
                emrInfoDataTable = userEmergencyInfoRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emrInfoDataTable;
        }
    }
}
