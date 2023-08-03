using System;
using System.Collections.Generic;

namespace RecruiterPortal.DAL.SqlModels;

public partial class ViewPdftemplate
{
    public long TermplateId { get; set; }

    public string? FileTypeCode { get; set; }

    public byte[]? FileData { get; set; }

    public string? FileName { get; set; }
}
