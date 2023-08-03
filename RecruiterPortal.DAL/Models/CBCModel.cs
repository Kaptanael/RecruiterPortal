using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class CBCModel
    {
        public long CBCID { get; set; }
        public long UserID { get; set; }
        public string Alias_AKA{ get; set; }
        public string HomePhone { get; set; }
        public string AgencyIdentification { get; set; }
        public string LTHHP_PFI { get; set; }
        public string LHCSA_License { get; set; }
        public string AgencyName { get; set; }
        public string ATelephoneNo { get; set; }
        public string APLastName { get; set; }
        public string APFirstName { get; set; }
        public string AStreetNo { get; set; }
        public string AStreetName { get; set; }
        public string AApt { get; set; }
        public string ACity { get; set; }
        public string AState { get; set; }
        public string AZipCode { get; set; }
        public string AEmail { get; set; }
        public string ADate { get; set; }
        public string FingerprintingMethod { get; set; }
        public string FingerprintServicesName { get; set; }
        public string FStAddress { get; set; }
        public string FCity { get; set; }
        public string FState { get; set; }
        public string FZip { get; set; }
        public string FIdentificationVerified { get; set; }
        public string FFirstName { get; set; }
        public string FLastName { get; set; }
        public string FTitle { get; set; }
        public string Signature { get; set; }
        public string DateFingerPrinted { get; set; }
        public string MotherMaidenName { get; set; }
        public string ParentorLegalGuardian { get; set; }
        public string Title { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
