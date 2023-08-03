using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class ViewImportedApplcant
{
    public long? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? MiddleName { get; set; }

    public bool? IsVerified { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ImporterName { get; set; }
}
