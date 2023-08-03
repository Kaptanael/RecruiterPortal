using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class AgreementFrom
{
    public long AgreementId { get; set; }

    public string? ContractorName { get; set; }

    public string? StreetAddress { get; set; }

    public string? ZipCode { get; set; }

    public string? City { get; set; }

    public string? StateName { get; set; }

    public string? Notary { get; set; }

    public DateTime? Date { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
