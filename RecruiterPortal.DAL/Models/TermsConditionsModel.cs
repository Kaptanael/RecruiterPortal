using System;

namespace RecruiterPortalDAL.Models
{
    public class TermsConditionModel
    {
        public long? TermsConditionsID { get; set; }
        public string EffectiveDate { get; set; }
        public string FacilityName { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string OfficePhone { get; set; }
        public string Position { get; set; }
        public string RatePayCompensation { get; set; }
        public Nullable<byte> DaysPerWeek { get; set; }
        public string NameGeneralLiabilityInsurance { get; set; }
        public string GeneralLiabilityInsurancePolicyNo { get; set; }
        public string NameMalpracticeInsurance { get; set; }
        public string MalpracticeInsurancePolicyNo { get; set; }
        public string NameWorkersCompensationInsurance { get; set; }
        public string WorkersCompensationInsurancePolicyNo { get; set; }
        public string NameDisabilityInsurance { get; set; }
        public string NameDisabilityInsurancePolicyNo { get; set; }
        public string SignatureDate { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedDate { get; set; }
        public long UserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
