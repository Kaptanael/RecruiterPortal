using static RecruiterPortal.DAL.Utility.Utility;

namespace RecruiterPortalDAL.Models
{
    public class UserLicenseCreateUpdateModel
    {
        public long LicenseID { get; set; }
        public string LicenseNameA { get; set; }
        public string LicenseNameB { get; set; }
        public string LicenseNameC { get; set; }
        public string LicenseNo { get; set; }
        public string ExpiryDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public long UserID { get; set; }
        public string FileData { get; set; }
        public string FileName { get; set; }
        public string IssuedDate { get; set; }
        public EnumFileType? FileType { get; set; }
        public string IssueAuthority { get; set; }
        public string StateCode { get; set; }
    }
}
