using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserReference
{
    public long UserReferenceId { get; set; }

    public string? RefLastName { get; set; }

    public string RefFirstName { get; set; } = null!;

    public string? RefMiddleName { get; set; }

    public string? NatureOfRelationship { get; set; }

    public string? CompanyName { get; set; }

    public long? EminstituteId { get; set; }

    public string? RefPhone { get; set; }

    public string? RefAddress { get; set; }

    public long UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ReferenceType { get; set; }

    public string? RefEmail { get; set; }

    public virtual User User { get; set; } = null!;
}
