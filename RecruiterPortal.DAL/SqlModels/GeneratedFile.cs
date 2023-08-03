using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class GeneratedFile
{
    public long GeneratedFileId { get; set; }

    public long UserId { get; set; }

    public byte[]? FileData { get; set; }

    public string? FileName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long TermplateId { get; set; }

    public string? FileTypeCode { get; set; }

    public virtual User User { get; set; } = null!;
}
