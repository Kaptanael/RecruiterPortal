using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class UserFileModel
    {
        public long UserFileID { get; set; }
        public byte[] FIleData { get; set; }
        public string FileName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public long UserID { get; set; }
        public byte FileType { get; set; }

    }
}
