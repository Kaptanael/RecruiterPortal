using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class PositionManager
    {
        public static IEnumerable<Position> GetPosition(string position)
        {
            string spName = "sp_GetPosition";
            try
            {
                GenericRepository<Position> positionRepo = new GenericRepository<Position>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.Position_Name = position;
                SqlParameter[] sqlParameters = positionRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                IEnumerable<Position> positionList = positionRepo.GetAll(spName, sqlParameters); ;

                return positionList;
            }
            catch (Exception ex)
            {
                throw  new Exception(ex.Message);
            }
        }
    }
}
