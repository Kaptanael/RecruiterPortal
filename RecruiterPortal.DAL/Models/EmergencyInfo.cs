using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class EmergencyInfo
    {
        public string EmrLastName { get; set; }
        public string EmrFirstName { get; set; }
        public string NatureOfRelationship { get; set; }
        public string EmrCellPhone { get; set; }
        public string EmrHomePhone { get; set; }
        public string EmrType { get; set; }
        public string UserID { get; set; }
        public string EmrWorkPhone { get; set; }
    }
}
