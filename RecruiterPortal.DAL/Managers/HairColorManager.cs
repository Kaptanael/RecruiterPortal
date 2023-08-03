using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class HairColorManager
    {
        public static IEnumerable<ViewHairColor> GetHairColor()
        {
            string spName = "sp_GetHairColor";
            try
            {
                GenericRepository<ViewHairColor> view_hair_color_Repo = new GenericRepository<ViewHairColor>();
                IEnumerable<ViewHairColor> view_hair_color_List = view_hair_color_Repo.GetAll(spName); ;

                return view_hair_color_List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetHairColorCodeByHairColor(string HairColor)
        {
            string spName = "sp_GetHairColorCodeByHairColor";
            DataTable hairColorDataTable = null;

            try
            {
                dynamic expandoObject = new ExpandoObject();
                expandoObject.HairColor = HairColor;
                GenericRepository<ViewHairColor> hairColorRepo = new GenericRepository<ViewHairColor>();
                SqlParameter[] sqlParameters = hairColorRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
                hairColorDataTable = hairColorRepo.LoadDataTable(spName, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return hairColorDataTable;
        }
    }
}
