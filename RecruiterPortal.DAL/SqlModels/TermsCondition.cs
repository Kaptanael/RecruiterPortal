using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class TermsCondition
{
    public long TermsConditionsId { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public string? FacilityName { get; set; }

    public string? StreetAddress { get; set; }

    public string? ZipCode { get; set; }

    public string? City { get; set; }

    public string? StateName { get; set; }

    public string? OfficePhone { get; set; }

    public string? Position { get; set; }

    public string? RatePayCompensation { get; set; }

    public byte? DaysPerWeek { get; set; }

    public string? NameGeneralLiabilityInsurance { get; set; }

    public string? GeneralLiabilityInsurancePolicyNo { get; set; }

    public string? NameMalpracticeInsurance { get; set; }

    public string? MalpracticeInsurancePolicyNo { get; set; }

    public string? NameWorkersCompensationInsurance { get; set; }

    public string? WorkersCompensationInsurancePolicyNo { get; set; }

    public string? NameDisabilityInsurance { get; set; }

    public string? NameDisabilityInsurancePolicyNo { get; set; }

    public DateTime? SignatureDate { get; set; }

    public string? AuthorizedBy { get; set; }

    public DateTime? AuthorizedDate { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
