using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class UserPhysicalManager
    {
        public static int SaveUserPhysical(UserPhysical userPhysical)
        {
            string spName = "sp_InsertUserPhysical";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserPhysical>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@p_" + nameof(userPhysical.Height).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userPhysical.Height;
                    }
                    else if ("@p_" + nameof(userPhysical.EyeColor) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.EyeColor;
                    }
                    else if ("@p_" + nameof(userPhysical.Race) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.Race;
                    }
                    else if ("@p_" + nameof(userPhysical.Weight) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.Weight;
                    }
                    else if ("@p_" + nameof(userPhysical.HairColor) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.HairColor;
                    }
                    else if ("@p_" + nameof(userPhysical.UserId) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.UserId;
                    }
                }

                List<SqlParameter> returnPrms = new GenericRepository<UserPhysical>().Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateUserPhysical(UserPhysical userPhysical)
        {
            string spName = "sp_UpdateUserPhysical";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserPhysical>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {
                    if ("@p_" + nameof(userPhysical.UserPhysicalId).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userPhysical.UserPhysicalId;
                    }
                    else if ("@p_" + nameof(userPhysical.Height).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userPhysical.Height;
                    }
                    else if ("@p_" + nameof(userPhysical.EyeColor) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.EyeColor;
                    }
                    else if ("@p_" + nameof(userPhysical.Race) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.Race;
                    }
                    else if ("@p_" + nameof(userPhysical.Weight) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.Weight;
                    }
                    else if ("@p_" + nameof(userPhysical.HairColor) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.HairColor;
                    }
                    else if ("@p_" + nameof(userPhysical.UserId) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userPhysical.UserId;
                    }
                }

                return new GenericRepository<UserPhysical>().Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static UserPhysical GetByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserPhysical";


            SqlParameter[] sqlParameters = new GenericRepository<UserPhysical>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_UserID;
                }
            }

            UserPhysical userPhysical;

            try
            {
                userPhysical = new GenericRepository<UserPhysical>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userPhysical;
        }

        public static DataTable GetPhysicalDtByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserPhysical";

            GenericRepository<UserLicense> physicalRepo = new GenericRepository<UserLicense>();
            dynamic expandoObject = new ExpandoObject();
            expandoObject.p_UserID = p_UserID;
            SqlParameter[] sqlParameters = physicalRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable physicalDataTable = null;
            try
            {
                physicalDataTable = physicalRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return physicalDataTable;
        }
    }
}
