using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RecruiterPortal.DAL.Utility;
using System.Data;
using System.Transactions;

namespace RecruiterPortal.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext context;        

        public Repository(DbContext context)
        {
            this.context = context;            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ExcuteSqlQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (commandType == CommandType.Text)
            {
                return SqlQuery(sqlQuery, parameters);
            }
            else if (commandType == CommandType.StoredProcedure)
            {
                return StoredProcedure(sqlQuery, parameters);
            }

            return null;
        }


        public void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            try
            {
                if (context.Database.GetDbConnection().State == ConnectionState.Closed)
                {
                    context.Database.GetDbConnection().Open();
                }

                var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = commandText;
                command.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {                 
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<T> ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            try
            {
                if (context.Database.GetDbConnection().State == ConnectionState.Closed)
                {
                    context.Database.GetDbConnection().Open();
                }

                var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = commandText;
                command.CommandType = commandType;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                using (var reader = command.ExecuteReader())
                {                                        
                    return reader.Cast<T>();
                }

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        private IEnumerable<T> SqlQuery(string sqlQuery, SqlParameter[] parameters = null)
        {
            if (parameters != null && parameters.Any())
            {
                var parameterNames = new string[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterNames[i] = parameters[i].ParameterName;
                }

                var result = context.Database.SqlQueryRaw<T>(string.Format("{0}", sqlQuery, string.Join(",", parameterNames), parameters));
                return result.ToList();
            }
            else
            {
                var result = context.Database.SqlQueryRaw<T>(sqlQuery);
                return result.ToList();
            }
        }

        public IEnumerable<T> StoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            try
            {
                if (parameters != null && parameters.Any())
                {
                    var parameterNames = new string[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameterNames[i] = parameters[i].ParameterName;
                    }
                    using (context)
                    {
                        var result = context.Database.SqlQueryRaw<T>(string.Format("EXEC {0} {1}", storedProcedureName, string.Join(",", parameterNames)), parameters);
                        return result.ToList();
                    }
                }
                else
                {
                    using (context)
                    {
                        var result = context.Database.SqlQueryRaw<T>(string.Format("EXEC {0}", storedProcedureName));
                        return result.ToList();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SqlParameter> NonQueryStoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            try
            {
                if (parameters != null && parameters.Any())
                {
                    List<SqlParameter> outparameters = null;
                    var parameterNames = new string[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameterNames[i] = parameters[i].ParameterName;
                        if (parameters[i].Direction == ParameterDirection.Output || parameters[i].Direction == ParameterDirection.InputOutput)
                        {
                            if (outparameters == null)
                            {
                                outparameters = new List<SqlParameter>();
                            }
                            outparameters.Add(parameters[i]);
                        }
                    }
                    using (context)
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            var result = context.Database.ExecuteSqlRaw(string.Format("EXEC {0} {1}", storedProcedureName, string.Join(",", parameterNames)), parameters);

                            ts.Complete();
                            context.SaveChanges();

                            return outparameters;
                        }
                    }
                }
                else
                {
                    using (context)
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            var result = context.Database.ExecuteSqlRaw(string.Format("EXEC {0}", storedProcedureName));

                            ts.Complete();
                            context.SaveChanges();

                            return null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int NonQueryStoredProcedureRowCount(string storedProcedureName, SqlParameter[] parameters = null)
        {
            try
            {
                if (parameters != null && parameters.Any())
                {
                    var parameterNames = new string[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameterNames[i] = parameters[i].ParameterName;
                    }
                    using (context)
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            var result = context.Database.ExecuteSqlRaw(string.Format("EXEC {0} {1}", storedProcedureName, string.Join(",", parameterNames)), parameters);

                            ts.Complete();
                            context.SaveChanges();

                            return result;
                        }
                    }
                }
                else
                {
                    using (context)
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            var result = context.Database.ExecuteSqlRaw(string.Format("EXEC {0}", storedProcedureName));

                            ts.Complete();
                            context.SaveChanges();

                            return result;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable LoadDataSetStoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            string spName = storedProcedureName;
            SqlConnection con = new SqlConnection(context.Database.GetDbConnection().ConnectionString);
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dataTabel = new DataTable();

            try
            {                
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(parameters[i]);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection.Open();
                da.Fill(dataTabel);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if ((cmd.Connection != null) && (cmd.Connection.State != ConnectionState.Closed))
                {
                    cmd.Connection.Close();
                }
            }

            return dataTabel;
        }

        public SqlParameter[] StoredProcedureParams(string storedProcedureName)
        {
            string spName = storedProcedureName;
            SqlConnection con = new SqlConnection(context.Database.GetDbConnection().ConnectionString);
            SqlCommand cmd = new SqlCommand(@"SELECT PARAMETER_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, PARAMETER_MODE FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = @p_SpName", con);
            cmd.CommandType = CommandType.Text;
            SqlParameter sqlSPNameParameter = new SqlParameter("p_SpName", SqlDbType.NVarChar, 500);
            sqlSPNameParameter.Value = storedProcedureName;
            cmd.Parameters.Add(sqlSPNameParameter);

            DataTable dataTabel = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.Connection.Open();
                da.Fill(dataTabel);

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if ((cmd.Connection != null) && (cmd.Connection.State != ConnectionState.Closed))
                {
                    cmd.Connection.Close();
                }
            }

            if (dataTabel.Rows != null && dataTabel.Rows.Count > 0)
            {
                SqlParameter[] parameters = new SqlParameter[dataTabel.Rows.Count];

                int count = 0;
                foreach (DataRow dataRow in dataTabel.Rows)
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    if (SqlHelper.GetDbType(dataRow["DATA_TYPE"].ToString()) == SqlDbType.NVarChar)
                    {
                        sqlParameter = new SqlParameter(dataRow["PARAMETER_NAME"].ToString(), SqlHelper.GetDbType(dataRow["DATA_TYPE"].ToString()), Convert.ToInt32(dataRow["CHARACTER_MAXIMUM_LENGTH"]));
                        sqlParameter.Direction = SqlHelper.GetDirection(dataRow["PARAMETER_MODE"].ToString());
                    }
                    else
                    {
                        sqlParameter = new SqlParameter(dataRow["PARAMETER_NAME"].ToString(), SqlHelper.GetDbType(dataRow["DATA_TYPE"].ToString()));
                        sqlParameter.Direction = SqlHelper.GetDirection(dataRow["PARAMETER_MODE"].ToString());
                    }
                    parameters[count] = sqlParameter;
                    count++;
                }

                return parameters;
            }
            else
            {
                return null;
            }
        }
    }
}
