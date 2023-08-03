using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class USCISModel
    {
        public long USCISID { get; set; }
        public string USCISNumber { get; set; }
        public Nullable<System.DateTime> WorkAuthExpiryDate { get; set; }
        public string I94AdmissionNumber { get; set; }
        public string ForeignPassort { get; set; }
        public string TranslatorFirstName { get; set; }
        public string TranslatorLastName { get; set; }
        public string StreetAddress { get; set; }
        public string Apt { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string AdditionalInformation { get; set; }
        public Nullable<System.DateTime> EmploymentDate { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentNumber { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public long UserID { get; set; }
        public Nullable<bool> IsNonCitizen { get; set; }
        public Nullable<bool> IsLawFullPermanent { get; set; }
    }
}
