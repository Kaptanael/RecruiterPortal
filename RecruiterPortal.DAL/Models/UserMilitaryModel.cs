using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class UserMilitaryModel
    {
        public long UserMilitaryID { get; set; }
        public string Branch { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string RankAtDischarge { get; set; }
        public string DischargeType { get; set; }
        public string DisonourComment { get; set; }
        public long UserID { get; set; }
    }
}
