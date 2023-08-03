using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class EmploymentModel
    {
        public string UserCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Supervisor { get; set; }
        public string CompanyPhone { get; set; }
        public string JobTItle { get; set; }
        public string StartingSalary { get; set; }
        public string EndingSalary { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool CanContactThisEmployer { get; set; }
        public string LeaveReason { get; set; }
        public string Responisiblities { get; set; }
        
    }
}
