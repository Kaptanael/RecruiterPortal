using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class InfluenzaVaccination
{
    public long InfluenzaVaccinationId { get; set; }

    public string? FacilityName { get; set; }

    public string? ReasonDeclination { get; set; }

    public string? Signature { get; set; }

    public DateTime? EntryDate { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
