using System.ComponentModel.DataAnnotations;

namespace RecruiterPortalDAL.Models
{
    public class UserSignatureModel
    {
        public long UserSignatureID { get; set; }

        [Required, StringLength(500)]
        public string SignatureName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public long UserID { get; set; }
    }
}
