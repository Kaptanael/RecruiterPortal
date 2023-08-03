namespace RecruiterPortal.DAL.Models
{
    public class AgreementModel
    {
        public long AgreementID { get; set; }
        public string ContractorName { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string Notary { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public long UserID { get; set; }
    }
}
