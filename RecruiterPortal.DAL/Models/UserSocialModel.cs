using System;

namespace RecruiterPortalDAL.Models
{
    public class UserSocialModel
    {
        public long? SocialId { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string FaceBook { get; set; }
        public long UserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
