using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class ChangeTracker
{
    public long ChangeTrackerId { get; set; }

    public bool HasNewChanges { get; set; }

    public DateTime? ChangeDate { get; set; }

    public DateTime? ImportDate { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
