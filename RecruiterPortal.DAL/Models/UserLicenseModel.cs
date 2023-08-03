using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class UserLicenseModel
    {
        public long LicenseID { get; set; }
        public string LicenseNameA { get; set; }
        public string LicenseNameB { get; set; }
        public string LicenseNameC { get; set; }
        public string LicenseNo { get; set; }
        public string ExpiryDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public long UserID { get; set; }
        public byte[] FIleData { get; set; }
        public string FileName { get; set; }
        public string IssuedDate { get; set; }
        public byte? FileType { get; set; }
        public string IssueAuthority { get; set; }
        public string StateCode { get; set; }
    }
}
