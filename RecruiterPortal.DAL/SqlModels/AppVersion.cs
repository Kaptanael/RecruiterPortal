using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class AppVersion
{
    public long Id { get; set; }

    public string? CurrenctVersion { get; set; }

    public string? OldVersion { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
