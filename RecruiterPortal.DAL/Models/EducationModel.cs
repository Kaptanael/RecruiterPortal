using System;

namespace RecruiterPortalDAL.Models
{
    public class EducationModel
    {
        public long EducationID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string Degree { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsGraduate { get; set; }
        public int InstitutionType { get; set; }

        public string InstitutionTypeName { get; set; }
    }
        
}