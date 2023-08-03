using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class UserReferenceModel
    {
        public long UserReferenceID { get; set; }
        public string RefLastName { get; set; }
        public string RefFirstName { get; set; }
        public string RefMiddleName { get; set; }
        public string ReferenceType { get; set; }
        public string NatureOfRelationship { get; set; }
        public string CompanyName { get; set; }
        public Nullable<long> EMInstituteID { get; set; }
        public string RefPhone { get; set; }
        public string RefEmail { get; set; }
        public string RefAddress { get; set; }
        public long UserID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        
    }
}
