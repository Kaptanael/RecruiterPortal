using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class NurseFormModel
    {
        public long? NurseFormID { get; set; }
        public string ApplyingForJobType { get; set; }
        public string ApplyingForPosition { get; set; }
        public string LicensedJurisdiction { get; set; }
        public string FailedRNLicensing { get; set; }
        public string FailedPNLicensing { get; set; }
        public string CGFNSCNATSCompleted { get; set; }
        public string CGFNSExaminationDate { get; set; }
        public string CGFNSCertificateNumber { get; set; }
        public string CNATSExaminationDate { get; set; }
        public string CNATSExamScore { get; set; }
        public string NursingSchoolAttended { get; set; }
        public string NursingSchoolAddress { get; set; }
        public string NursingSchoolCompletedDate { get; set; }
        public string PermitteesName { get; set; }
        public string RNLPNEmployed { get; set; }
        public string EmployerName { get; set; }
        public string EmployerStreetAddress { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerStateProvince { get; set; }
        public string EmployerZipCode { get; set; }
        public string EmployerCountry { get; set; }
        public string EmployerTelephone { get; set; }
        public string EmployerFax { get; set; }
        public string EmployerEmail { get; set; }
        public string PracticeName { get; set; }
        public string PracticeStreetAddress { get; set; }
        public string PracticeCity { get; set; }
        public string PracticeStateProvince { get; set; }
        public string PracticeZipCode { get; set; }
        public string PracticeCountry { get; set; }
        public string PracticeTelephone { get; set; }
        public string PracticeFax { get; set; }
        public string PracticeEmail { get; set; }
        public string RegisteredProfessionalNurse { get; set; }
        public string NewYorkStateLicenseNumber1 { get; set; }
        public string NewYorkStateLicenseNumber2 { get; set; }
        public string SignatureBehalfEmployer { get; set; }
        public string SignatureDate { get; set; }
        public string PrintName { get; set; }
        public string Title { get; set; }
        public string NewYorkStateProfession { get; set; }
        public string NewYorkStateProfessionalLicenseNumber { get; set; }
        public long UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
