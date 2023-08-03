using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class EmploymentManager
    {
        public static void InsertEmploy(UserCompany empInfo)
        {
            string spName = "sp_InsertUserCompany";

            try
            {
                GenericRepository<UserCompany> employInfo = new GenericRepository<UserCompany>();
                SqlParameter[] sqlParameters = employInfo.GetSqlParametersFromObject(empInfo, spName);
                employInfo.Insert(spName, sqlParameters);
                //SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

                //foreach (SqlParameter sqlParameter in sqlParameters)
                //{
                //    if ("@" + nameof(empInfo.CompanyName) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.CompanyName;
                //    }
                //    else if ("@" + nameof(empInfo.CompanyAddress) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.CompanyAddress;
                //    }
                //    else if ("@" + nameof(empInfo.Supervisor) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.Supervisor;
                //    }
                //    else if ("@" + nameof(empInfo.CompanyPhone) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.CompanyPhone;
                //    }
                //    else if ("@" + nameof(empInfo.JobTItle) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.JobTItle;
                //    }
                //    else if ("@" + nameof(empInfo.StartingSalary) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.StartingSalary;
                //    }
                //    else if ("@" + nameof(empInfo.EndingSalary) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.EndingSalary;
                //    }
                //    else if ("@" + nameof(empInfo.FromDate) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.FromDate;
                //    }
                //    else if ("@" + nameof(empInfo.ToDate) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.ToDate;
                //    }
                //    else if ("@" + nameof(empInfo.LeaveReason) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.LeaveReason;
                //    }
                //    else if ("@" + nameof(empInfo.UserID) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.UserID;
                //    }
                //    else if ("@" + nameof(empInfo.CanContactThisEmployer) == sqlParameter.ParameterName)
                //    {
                //        sqlParameter.Value = empInfo.CanContactThisEmployer;
                //    }
                //    else
                //    {
                //        sqlParameter.Value = DBNull.Value;
                //    }
                //}
                //List<SqlParameter> returnPrms = new GenericRepository<UserEmergencyInfo>().Insert(spName, sqlParameters);
                //return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateEmploy(UserCompany emergencyInfo)
        {
            string spName = "sp_UpdateUserCompany";

            try
            {
                GenericRepository<UserCompany> employInfo = new GenericRepository<UserCompany>();
                SqlParameter[] sqlParameters = employInfo.GetSqlParametersFromObject(emergencyInfo, spName);
                employInfo.Update(spName, sqlParameters);

                //foreach (SqlParameter sqlParameter in sqlParameters)
                //{

                //    //if ("@p_" + nameof(emergencyInfo.EmrFirstName) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.EmrFirstName;
                //    //}
                //    //else if ("@p_" + nameof(emergencyInfo.EmrLastName) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.EmrLastName;
                //    //}
                //    //else if ("@p_" + nameof(emergencyInfo.NatureOfRelationship) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.NatureOfRelationship;
                //    //}
                //    //else if ("@p_" + nameof(emergencyInfo.EmrHomePhone) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.EmrHomePhone;
                //    //}
                //    //else if ("@p_" + nameof(emergencyInfo.EmrCellPhone) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.EmrCellPhone;
                //    //}
                //    //else if ("@p_" + nameof(emergencyInfo.EmrWorkPhone) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.EmrWorkPhone;
                //    //}
                //    //else if ("@p_" + nameof(emergencyInfo.EmrType) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.EmrType;
                //    //}
                //    //else if ("@p_" + nameof(emergencyInfo.UserID) == sqlParameter.ParameterName)
                //    //{
                //    //    sqlParameter.Value = emergencyInfo.UserID;
                //    //}
                //    //else
                //    //{
                //    //    sqlParameter.Value = DBNull.Value;
                //    //}
                //}
                //return new GenericRepository<UserEmergencyInfo>().Update(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static IEnumerable<UserCompany> GetEmploy(long UserID)
        {
            string spName = "sp_GetUserCompanyByUserID";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserCompany>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@" + nameof(UserID) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = UserID;
                    }
                    else
                    {
                        sqlParameter.Value = DBNull.Value;
                    }
                }
                return new GenericRepository<UserCompany>().GetAll(spName, sqlParameters);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetEmployDataTable(long UserID)
        {
            string spName = "sp_GetUserCompanyByUserID";

            GenericRepository<UserCompany> userCompanyRepo = new GenericRepository<UserCompany>();
            dynamic expandoObject = new ExpandoObject();
            expandoObject.UserID = UserID;
            SqlParameter[] sqlParameters = userCompanyRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            DataTable userCompanyDataTable = null;
            try
            {
                userCompanyDataTable = userCompanyRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userCompanyDataTable;
        }
        public static IEnumerable<UserCompany> GetEmployByEmpId(long UserCompanyID)
        {
            string spName = "sp_GetUserCompanyByUserCompanyID";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserCompany>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@" + nameof(UserCompanyID) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = UserCompanyID;
                    }
                    else
                    {
                        sqlParameter.Value = DBNull.Value;
                    }
                }
                return new GenericRepository<UserCompany>().GetAll(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteEmploment(long UserCompanyID)
        {
            string spName = "sp_DeleteUserCompanyByCompanyID";

            try
            {
                SqlParameter[] sqlParameters = new GenericRepository<UserEmergencyInfo>().GetSqlParametersFromStoredProcedure(spName);

                foreach (SqlParameter sqlParameter in sqlParameters)
                {

                    if ("@" + nameof(UserCompanyID) == sqlParameter.ParameterName)
                    {
                        sqlParameter.Value = UserCompanyID;
                    }
                    else
                    {
                        sqlParameter.Value = DBNull.Value;
                    }
                }
                var result = new GenericRepository<UserCompany>().Delete(spName, sqlParameters);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
