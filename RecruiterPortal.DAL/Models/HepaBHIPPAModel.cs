using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class HepaBHIPPAModel
    {
        public long HepaBHIPPAID { get; set; }
        public Nullable<bool> HasHepaConcent { get; set; }
        public Nullable<bool> HasHepaSheet { get; set; }
        public Nullable<bool> HasHepaTraining { get; set; }
        public Nullable<bool> IsExamined { get; set; }
        public Nullable<bool> HasNoCostHepa { get; set; }
        public Nullable<bool> HasFacilityInfo { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> SignatureDate { get; set; }
        public string WitnessName { get; set; }
        public Nullable<System.DateTime> WitnessSignatureDate { get; set; }
        public string ComplianceOfficer { get; set; }
        public long UserID { get; set; }
    }
}
