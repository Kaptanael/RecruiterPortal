using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class Cbcform
{
    public long Cbcid { get; set; }

    public long UserId { get; set; }

    public string? AliasAka { get; set; }

    public string? HomePhone { get; set; }

    public string? AgencyIdentification { get; set; }

    public string? LthhpPfi { get; set; }

    public string? LhcsaLicense { get; set; }

    public string? AgencyName { get; set; }

    public string? AtelephoneNo { get; set; }

    public string? AplastName { get; set; }

    public string? ApfirstName { get; set; }

    public string? AstreetNo { get; set; }

    public string? AstreetName { get; set; }

    public string? Aapt { get; set; }

    public string? Acity { get; set; }

    public string? Astate { get; set; }

    public string? AzipCode { get; set; }

    public string? Aemail { get; set; }

    public string? Adate { get; set; }

    public string? FingerprintingMethod { get; set; }

    public string? FingerprintServicesName { get; set; }

    public string? FstAddress { get; set; }

    public string? Fcity { get; set; }

    public string? Fstate { get; set; }

    public string? Fzip { get; set; }

    public string? FidentificationVerified { get; set; }

    public string? FfirstName { get; set; }

    public string? FlastName { get; set; }

    public string? Ftitle { get; set; }

    public string? Signature { get; set; }

    public string? DateFingerPrinted { get; set; }

    public string? MotherMaidenName { get; set; }

    public string? ParentorLegalGuardian { get; set; }

    public string? Title { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
