using System;

namespace RecruiterPortalDAL.Models
{
    public class InfluenzaVaccinationModel
    {
        public long? InfluenzaVaccinationID { get; set; }
        public string FacilityName { get; set; }
        public string ReasonDeclination { get; set; }
        public string Signature { get; set; }
        public string EntryDate { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public long UserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        
    }
}
