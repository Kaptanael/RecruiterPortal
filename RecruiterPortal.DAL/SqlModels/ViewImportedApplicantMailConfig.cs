using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class ViewImportedApplicantMailConfig
{
    public long ApplicantPortalUserId { get; set; }

    public string? Pop3userName { get; set; }
}
