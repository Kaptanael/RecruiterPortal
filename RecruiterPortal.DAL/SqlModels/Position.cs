using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class Position
{
    public int PositionId { get; set; }

    public string PositionName { get; set; } = null!;
}
