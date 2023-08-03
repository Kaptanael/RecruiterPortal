using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserDetail
{
    public long UserDetailsId { get; set; }

    public string? StreetAddress { get; set; }

    public string? Apt { get; set; }

    public string? ZipCode { get; set; }

    public string Phone { get; set; } = null!;

    public string? Ssn { get; set; }

    public DateTime? DateAvailable { get; set; }

    public string? DesiredSalary { get; set; }

    public string? DesiredPosition { get; set; }

    public bool IsUscitizen { get; set; }

    public bool IsAuthorized { get; set; }

    public bool IsOldClient { get; set; }

    public bool IsConvict { get; set; }

    public string? ConvictionDetail { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? City { get; set; }

    public string? StateName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? CountryOfBirth { get; set; }

    public string? CountryFromApplied { get; set; }

    public virtual User User { get; set; } = null!;
}
