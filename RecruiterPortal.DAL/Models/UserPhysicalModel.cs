using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class UserPhysicalModel
    {
        public long UserPhysicalID { get; set; }
        public string Height { get; set; }
        public string EyeColor { get; set; }
        public string Race { get; set; }
        public string Weight { get; set; }
        public string HairColor { get; set; }
        public long UserID { get; set; }
    }
}
