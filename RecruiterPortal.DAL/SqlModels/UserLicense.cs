using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserLicense
{
    public long LicenseId { get; set; }

    public string? LicenseNameA { get; set; }

    public string? LicenseNameB { get; set; }

    public string? LicenseNameC { get; set; }

    public string? LicenseNo { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public long UserId { get; set; }

    public byte[]? FileData { get; set; }

    public string? FileName { get; set; }

    public DateTime? IssuedDate { get; set; }

    public byte? FileType { get; set; }

    public string? IssueAuthority { get; set; }

    public string? StateCode { get; set; }

    public virtual User User { get; set; } = null!;
}
