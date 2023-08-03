using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserCompany
{
    public long UserCompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public long? EminstituteId { get; set; }

    public string? CompanyAddress { get; set; }

    public string? Supervisor { get; set; }

    public string CompanyPhone { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public long? EmpositionId { get; set; }

    public string? StartingSalary { get; set; }

    public string? EndingSalary { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public long UserId { get; set; }

    public bool CanContactThisEmployer { get; set; }

    public string? LeaveReason { get; set; }

    public string? Responisiblities { get; set; }

    public virtual User User { get; set; } = null!;
}
