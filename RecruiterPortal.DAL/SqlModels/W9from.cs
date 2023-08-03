using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class W9from
{
    public long Wid { get; set; }

    public string? Name { get; set; }

    public string? BusinessName { get; set; }

    public bool? CompanyLiability { get; set; }

    public bool? IndividualProprietor { get; set; }

    public bool? Ccorporation { get; set; }

    public bool? Scorporation { get; set; }

    public bool? Partnership { get; set; }

    public string? PayeeCode { get; set; }

    public string? ReportingCode { get; set; }

    public string? StreetAddress { get; set; }

    public string? AptNo { get; set; }

    public string? ZipCode { get; set; }

    public string? City { get; set; }

    public string? StateName { get; set; }

    public string? AccountNumber { get; set; }

    public string? RequesterNameAddress { get; set; }

    public string? Ssn { get; set; }

    public string? EmployerIdNo { get; set; }

    public DateTime? Date { get; set; }

    public long UserId { get; set; }

    public bool? Trust { get; set; }

    public bool? Other { get; set; }

    public virtual User User { get; set; } = null!;
}
