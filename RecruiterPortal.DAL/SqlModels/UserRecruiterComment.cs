using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class UserRecruiterComment
{
    public long UserRecruiterCommentId { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime CommentDate { get; set; }

    public long UserId { get; set; }

    public string RecruiterName { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
