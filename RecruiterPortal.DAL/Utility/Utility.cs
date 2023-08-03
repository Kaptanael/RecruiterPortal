using System.ComponentModel;

namespace RecruiterPortal.DAL.Utility
{
    public class Utility
    {
        public const string APPLICANTDB_CONNECTION_STRING_NAME = "ApplicantDbConnectionStringName";
        public enum EnumEmergencyInfo
        {
            None = 0,
            Primary = 1,
            Secondary = 2,
        }

        public enum Ranks
        {
            Finance = 0, Recruiter = 1, Human_Resource = 2
        }

        public enum EnumTypeOfDischarge
        {
            Honorable = 1,
            Dishonorable = 0
        }
        public enum EnumFileType
        {
            [Description("UMR Health Form")]
            UmrHealthForm = 1,
            [Description("Passport SSN Tin")]
            PassportSsnTin = 2,
            [Description("Resume")]
            Resume = 3,
            [Description("Certificate License")]
            CertificateLicense = 4,
            [Description("CPR")]
            Cpr = 5,
            [Description("Physical Exam")]
            PhysicalExam = 6,
            [Description("Agency Hired")]
            AgencyHired = 7,
            [Description("Declination Influenza")]
            DeclinationInfluenza = 8,
            [Description("Emergency Contact")]
            EmergencyContact = 9,
            [Description("Employment Eligibility")]
            EmploymentEligibility = 10,
            [Description("Hepatitis B")]
            HepatitisB = 11,
            [Description("HIPPA Form")]
            HippaForm = 12,
            [Description("NYS CHRC")]
            NysChrc = 13,
            [Description("Payroll")]
            Payroll = 14,
            [Description("W9")]
            W9 = 15,
            [Description("Reference Letters")]
            ReferenceLetters = 16,
            [Description("Employment Application")]
            EmploymentApplication = 17,
            [Description("Voided Cheque")]
            VoidedCheque = 18,
            [Description("Administrative Fee Agreement")]
            AdministrativeFeeAgreement = 19,
            [Description("Independent Contractor Agreement")]
            IndependentContractorAgreement = 20,
            [Description("Employment Contract")]
            EmploymentContract = 21,
            [Description("W9 Cover Sheet")]
            W9CoverSheet = 22,
            [Description("Terms And Conditions Independent Contractor")]
            TermsAndConditionsIndependentContractor = 23,
            [Description("Nurse Form")]
            NurseForm = 24,
            [Description("USCIS Form")]
            USCIS = 25
        }
        
        public static string[] GetPhoneParts(string phoneNumber)
        {
            string[] phoneParts = new string[3];
            string phoneFirstPart = string.Empty; string phoneSecondPart = string.Empty; string phoneThirdPart = string.Empty;
            int officePhoneLength = phoneNumber.Length;
            if (officePhoneLength <= 3)
            {
                phoneFirstPart = phoneNumber.Substring(0, officePhoneLength);
            }
            else if (officePhoneLength > 3 && officePhoneLength <= 6)
            {
                phoneFirstPart = phoneNumber.Substring(0, 3);
                phoneSecondPart = phoneNumber.Substring(3, officePhoneLength - 3);
            }
            else if (officePhoneLength > 6 && officePhoneLength <= 10)
            {
                phoneFirstPart = phoneNumber.Substring(0, 3);
                phoneSecondPart = phoneNumber.Substring(3, 3);
                phoneThirdPart = phoneNumber.Substring(6, officePhoneLength - 6);
            }
            else
            {
                phoneFirstPart = phoneNumber.Substring(0, 3);
                phoneSecondPart = phoneNumber.Substring(3, 3);
                phoneThirdPart = phoneNumber.Substring(6, 4);
            }

            phoneParts[0] = phoneFirstPart;
            phoneParts[1] = phoneSecondPart;
            phoneParts[2] = phoneThirdPart;

            return phoneParts;
        }
    }
}
