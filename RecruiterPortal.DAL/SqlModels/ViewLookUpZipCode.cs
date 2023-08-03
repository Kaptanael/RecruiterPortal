using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class ViewLookUpZipCode
{
    public string SateCode { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string StateAbbr { get; set; } = null!;

    public string County { get; set; } = null!;

    public double? Decommissioned { get; set; }

    public string? Description { get; set; }
}
