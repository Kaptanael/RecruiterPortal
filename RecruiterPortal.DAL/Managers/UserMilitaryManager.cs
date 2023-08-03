using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class UserMilitaryManager
    {
        public static int SaveUserMilitary(UserMilitary userMilitary)
        {
            string spName = "sp_InsertUserMilitary";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserMilitary>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@p_" + nameof(userMilitary.Branch).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userMilitary.Branch;
                    }
                    else if ("@p_" + nameof(userMilitary.FromDate) == sqlParameter.ParameterName)
                    {
                        if (userMilitary.FromDate != null)
                        {
                            sqlParameter.Value = userMilitary.FromDate;
                        }
                        else {
                            sqlParameter.Value = DBNull.Value;
                        }
                    }
                    else if ("@p_" + nameof(userMilitary.ToDate) == sqlParameter.ParameterName)
                    {
                        if (userMilitary.ToDate != null)
                        {
                            sqlParameter.Value = userMilitary.ToDate;
                        }
                        else
                        {
                            sqlParameter.Value = DBNull.Value;
                        }
                    }
                    else if ("@p_" + nameof(userMilitary.RankAtDischarge) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userMilitary.RankAtDischarge;
                    }
                    else if ("@p_" + nameof(userMilitary.TypeOfDischarge) == sqlParameter.ParameterName)
                    {
                        if (userMilitary.TypeOfDischarge != null)
                        {
                            sqlParameter.Value = userMilitary.TypeOfDischarge;
                        }
                        else
                        {
                            sqlParameter.Value = DBNull.Value;
                        }
                    }
                    else if ("@p_" + nameof(userMilitary.DisonourComment) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userMilitary.DisonourComment;
                    }
                    else if ("@p_" + nameof(userMilitary.UserId) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userMilitary.UserId;
                    }
                }

                List<SqlParameter> returnPrms = new GenericRepository<UserMilitary>().Insert(spName, sqlParameters);

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateUserMilitary(UserMilitary userMilitary)
        {
            string spName = "sp_UpdateUserMilitary";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserMilitary>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {
                    if ("@p_" + nameof(userMilitary.UserMilitaryId).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userMilitary.UserMilitaryId;
                    }
                    else if ("@p_" + nameof(userMilitary.Branch).ToLower() == sqlParameter.ParameterName.ToLower())
                    {
                        sqlParameter.Value = userMilitary.Branch;
                    }
                    else if ("@p_" + nameof(userMilitary.FromDate) == sqlParameter.ParameterName)
                    {
                        if (userMilitary.FromDate != null)
                        {
                            sqlParameter.Value = userMilitary.FromDate;
                        }
                        else
                        {
                            sqlParameter.Value = DBNull.Value;
                        }
                    }
                    else if ("@p_" + nameof(userMilitary.ToDate) == sqlParameter.ParameterName)
                    {
                        if (userMilitary.ToDate != null)
                        {
                            sqlParameter.Value = userMilitary.ToDate;
                        }
                        else
                        {
                            sqlParameter.Value = DBNull.Value;
                        }
                    }
                    else if ("@p_" + nameof(userMilitary.RankAtDischarge) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userMilitary.RankAtDischarge;
                    }
                    else if ("@p_" + nameof(userMilitary.TypeOfDischarge) == sqlParameter.ParameterName)
                    {
                        if (userMilitary.TypeOfDischarge != null)
                        {
                            sqlParameter.Value = userMilitary.TypeOfDischarge;
                        }
                        else 
                        {
                            sqlParameter.Value = DBNull.Value;
                        }
                    }
                    else if ("@p_" + nameof(userMilitary.DisonourComment) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userMilitary.DisonourComment;
                    }
                    else if ("@p_" + nameof(userMilitary.UserId) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = userMilitary.UserId;
                    }
                }

                return new GenericRepository<UserMilitary>().Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static UserMilitary GetByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserMilitary";


            SqlParameter[] sqlParameters = new GenericRepository<UserMilitary>().GetSqlParametersFromStoredProcedure(spName);

            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if ("@" + nameof(p_UserID) == sqlParameter.ParameterName)
                {
                    sqlParameter.Value = p_UserID;
                }
            }

            UserMilitary userMilitary;

            try
            {
                userMilitary = new GenericRepository<UserMilitary>().GetOne(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userMilitary;
        }
        public static DataTable GetUserMilitaryByUserID(Int64 p_UserID)
        {
            string spName = "sp_GetUserMilitary";

            dynamic expandoObject = new ExpandoObject();
            expandoObject.p_UserID = p_UserID;
            GenericRepository<UserMilitary> militaryRepo = new GenericRepository<UserMilitary>();
            SqlParameter[] sqlParameters = militaryRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable militaryDataTable = null;
            try
            {
                militaryDataTable = militaryRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return militaryDataTable;
        }
    }
}
