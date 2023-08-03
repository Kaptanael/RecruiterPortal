using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserMilitary
{
    public long UserMilitaryId { get; set; }

    public string? Branch { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? RankAtDischarge { get; set; }

    public bool? TypeOfDischarge { get; set; }

    public string? DisonourComment { get; set; }

    public long UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
