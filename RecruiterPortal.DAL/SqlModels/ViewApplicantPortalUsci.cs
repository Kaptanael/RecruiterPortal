using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class ViewApplicantPortalUsci
{
    public long Uscisid { get; set; }

    public string? Uscisnumber { get; set; }

    public DateTime? WorkAuthExpiryDate { get; set; }

    public DateTime? I94admissionNumber { get; set; }

    public string? ForeignPassort { get; set; }

    public string? TranslatorFirstName { get; set; }

    public string? TranslatorLastName { get; set; }

    public string? StreetAddress { get; set; }

    public string? Apt { get; set; }

    public string? ZipCode { get; set; }

    public string? City { get; set; }

    public string? StateName { get; set; }

    public string? AdditionalInformation { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public string? DocumentTitle { get; set; }

    public string? DocumentNumber { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public long UserId { get; set; }
}
