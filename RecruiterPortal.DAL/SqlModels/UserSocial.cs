using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserSocial
{
    public long SocialId { get; set; }

    public string? Linkedin { get; set; }

    public string? Twitter { get; set; }

    public string? FaceBook { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
