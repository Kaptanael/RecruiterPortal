using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class NurseForm
{
    public long NurseFormId { get; set; }

    public bool? LicensedJurisdiction { get; set; }

    public bool? FailedRnlicensing { get; set; }

    public bool? FailedPnlicensing { get; set; }

    public string? Cgfnscnatscompleted { get; set; }

    public DateTime? CgfnsexaminationDate { get; set; }

    public string? CgfnscertificateNumber { get; set; }

    public DateTime? CnatsexaminationDate { get; set; }

    public string? CnatsexamScore { get; set; }

    public string? NursingSchoolAttended { get; set; }

    public string? NursingSchoolAddress { get; set; }

    public DateTime? NursingSchoolCompletedDate { get; set; }

    public string? PermitteesName { get; set; }

    public string? Rnlpnemployed { get; set; }

    public string? EmployerName { get; set; }

    public string? EmployerStreetAddress { get; set; }

    public string? EmployerCity { get; set; }

    public string? EmployerStateProvince { get; set; }

    public string? EmployerZipCode { get; set; }

    public string? EmployerCountry { get; set; }

    public string? EmployerTelephone { get; set; }

    public string? EmployerFax { get; set; }

    public string? EmployerEmail { get; set; }

    public string? PracticeName { get; set; }

    public string? PracticeStreetAddress { get; set; }

    public string? PracticeCity { get; set; }

    public string? PracticeStateProvince { get; set; }

    public string? PracticeZipCode { get; set; }

    public string? PracticeCountry { get; set; }

    public string? PracticeTelephone { get; set; }

    public string? PracticeFax { get; set; }

    public string? PracticeEmail { get; set; }

    public string? RegisteredProfessionalNurse { get; set; }

    public string? NewYorkStateLicenseNumber1 { get; set; }

    public string? NewYorkStateLicenseNumber2 { get; set; }

    public string? SignatureBehalfEmployer { get; set; }

    public DateTime? SignatureDate { get; set; }

    public string? PrintName { get; set; }

    public string? Title { get; set; }

    public string? NewYorkStateProfession { get; set; }

    public string? NewYorkStateProfessionalLicenseNumber { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool? ApplyingForJobType { get; set; }

    public byte? ApplyingForPosition { get; set; }

    public virtual User User { get; set; } = null!;
}
