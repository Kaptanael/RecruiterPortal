using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserEducation
{
    public long UserEducationId { get; set; }

    public string SchoolName { get; set; } = null!;

    public string? SchoolAddress { get; set; }

    public string Degree { get; set; } = null!;

    public int? FromDate { get; set; }

    public int? ToDate { get; set; }

    public bool IsGraduate { get; set; }

    public long UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public byte? InstitutionType { get; set; }

    public virtual User User { get; set; } = null!;
}
