using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserVerification
{
    public long UserVerificationId { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool Active { get; set; }

    public string? VerficationCode { get; set; }

    public virtual User User { get; set; } = null!;
}
