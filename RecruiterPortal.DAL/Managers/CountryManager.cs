using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class CountryManager
    {
        public static IEnumerable<ViewCountryName> GetCountryName(string countryName)
        {
            string spName = "sp_GetCountryName";
            try
            {
                GenericRepository<ViewCountryName> view_Country_NameRepo = new GenericRepository<ViewCountryName>();
                dynamic expandoObject = new ExpandoObject();
                expandoObject.CountryName = countryName;
                SqlParameter[] sqlParameters = view_Country_NameRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                IEnumerable<ViewCountryName> view_CountryNameList = view_Country_NameRepo.GetAll(spName, sqlParameters); ;

                return view_CountryNameList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
