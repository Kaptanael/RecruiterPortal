using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserEmergencyInfo
{
    public long UserEmergencyInfoId { get; set; }

    public string EmrLastName { get; set; } = null!;

    public string EmrFirstName { get; set; } = null!;

    public string? NatureOfRelationship { get; set; }

    public string? EmrCellPhone { get; set; }

    public string EmrHomePhone { get; set; } = null!;

    public byte EmrType { get; set; }

    public long UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? EmrWorkPhone { get; set; }

    public virtual User User { get; set; } = null!;
}
