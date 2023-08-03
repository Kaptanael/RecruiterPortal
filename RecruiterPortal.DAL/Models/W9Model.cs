using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterPortalDAL.Models
{
    public class W9Model
    {
        public long WID { get; set; }
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public Nullable<bool> CompanyLiability { get; set; }
        public Nullable<bool> IndividualProprietor { get; set; }
        public Nullable<bool> CCorporation { get; set; }
        public Nullable<bool> SCorporation { get; set; }
        public Nullable<bool> Partnership { get; set; }
        public Nullable<bool> Trust { get; set; }
        public Nullable<bool> Other { get; set; }
        public string PayeeCode { get; set; }
        public string ReportingCode { get; set; }
        public string StreetAddress { get; set; }
        public string AptNo { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string AccountNumber { get; set; }
        public string RequesterNameAddress { get; set; }
        public string SSN { get; set; }
        public string EmployerIdNo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public long UserID { get; set; }
    }
}
