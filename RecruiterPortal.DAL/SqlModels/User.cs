using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? MiddleName { get; set; }

    public bool IsVerified { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? AgencyId { get; set; }

    public virtual ICollection<AgreementFrom> AgreementFroms { get; set; } = new List<AgreementFrom>();

    public virtual ICollection<Cbcform> Cbcforms { get; set; } = new List<Cbcform>();

    public virtual ICollection<ChangeTracker> ChangeTrackers { get; set; } = new List<ChangeTracker>();

    public virtual ICollection<GeneratedFile> GeneratedFiles { get; set; } = new List<GeneratedFile>();

    public virtual ICollection<HepaBhippa> HepaBhippas { get; set; } = new List<HepaBhippa>();

    public virtual ICollection<InfluenzaVaccination> InfluenzaVaccinations { get; set; } = new List<InfluenzaVaccination>();

    public virtual ICollection<NurseForm> NurseForms { get; set; } = new List<NurseForm>();

    public virtual ICollection<TermsCondition> TermsConditions { get; set; } = new List<TermsCondition>();

    public virtual ICollection<Usci> Uscis { get; set; } = new List<Usci>();

    public virtual ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();

    public virtual ICollection<UserEducation> UserEducations { get; set; } = new List<UserEducation>();

    public virtual ICollection<UserEmergencyInfo> UserEmergencyInfos { get; set; } = new List<UserEmergencyInfo>();

    public virtual ICollection<UserFile> UserFiles { get; set; } = new List<UserFile>();

    public virtual ICollection<UserLicense> UserLicenses { get; set; } = new List<UserLicense>();

    public virtual ICollection<UserMilitary> UserMilitaries { get; set; } = new List<UserMilitary>();

    public virtual ICollection<UserPhoto> UserPhotos { get; set; } = new List<UserPhoto>();

    public virtual ICollection<UserPhysical> UserPhysicals { get; set; } = new List<UserPhysical>();

    public virtual ICollection<UserRecruiterComment> UserRecruiterComments { get; set; } = new List<UserRecruiterComment>();

    public virtual ICollection<UserReference> UserReferences { get; set; } = new List<UserReference>();

    public virtual ICollection<UserSignature> UserSignatures { get; set; } = new List<UserSignature>();

    public virtual ICollection<UserSocial> UserSocials { get; set; } = new List<UserSocial>();

    public virtual ICollection<UserVerification> UserVerifications { get; set; } = new List<UserVerification>();

    public virtual ICollection<W9from> W9froms { get; set; } = new List<W9from>();
}
