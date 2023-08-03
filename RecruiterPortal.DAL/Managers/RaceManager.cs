using RecruiterPortal.DAL.Repository;
using RecruiterPortal.DAL.SqlModels;

namespace RecruiterPortalDAL.Managers
{
    public class RaceManager
    {
        public static IEnumerable<ViewRace> GetRace()
        {
            string spName = "sp_GetRace";
            try
            {
                GenericRepository<ViewRace> view_Race_Repo = new GenericRepository<ViewRace>();
                IEnumerable<ViewRace> view_Race_List = view_Race_Repo.GetAll(spName); ;

                return view_Race_List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
