using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserPhysical
{
    public long UserPhysicalId { get; set; }

    public string? Height { get; set; }

    public string? EyeColor { get; set; }

    public string? Race { get; set; }

    public string? Weight { get; set; }

    public string? HairColor { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
