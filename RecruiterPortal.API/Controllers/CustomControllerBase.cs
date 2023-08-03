using Microsoft.AspNetCore.Mvc;
using RecruiterPortal.DAL.SqlModels;
using RecruiterPortalDAL.Managers;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Security.Claims;

namespace RecruiterPortal.API.Controllers
{
    [Route("api/base")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        [Route("user")]
        [HttpGet]
        public IActionResult CurrentUser()
        {
            try
            {
                var currentUser = GetCurrentUser();
                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                //Log.Write(ex);
                //if (ApplicantPortalAPI.AuthorizationServer.Constants.IsProductionBuild)
                //{
                //    return StatusCode(500);
                //}
                //else
                //{
                //    return StatusCode(500, ex);
                //}

                return StatusCode(500);
            }
        }
        [Route("is-user-verified")]
        [HttpGet]
        public IActionResult IsCurrentUserVerified()
        {
            try
            {
                bool isVerified = GetCurrentUser().IsVerified;
                return Ok(isVerified);
            }
            catch (Exception ex)
            {
                //Log.Write(ex);
                //if (ApplicantPortalAPI.AuthorizationServer.Constants.IsProductionBuild)
                //{
                //    return StatusCode(500);
                //}
                //else
                //{
                //    return StatusCode(500, ex);
                //}

                return StatusCode(500);
            }
        }
        [NonAction]
        internal User GetCurrentUser()
        {
            var caller = User as ClaimsPrincipal;
            var currentUserClaim = "KKKKK"; //caller.FindFirst(ApplicantPortalAPI.AuthorizationServer.Constants.CurrentUserClaim);
            User currentUser = null;
            //if (currentUserClaim != null && !string.IsNullOrEmpty(currentUserClaim.Value))
            //{
            //    dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(currentUserClaim.Value);                
            //    currentUser = JsonConvert.DeserializeObject<User>(currentUserClaim.Value);
            //}
            return currentUser;
        }

        #region Pdf Helpers
        [NonAction]
        public static string[] GetPhoneParts(string phoneNumber)
        {
            string[] phoneParts = new string[3];
            string phoneFirstPart = string.Empty; string phoneSecondPart = string.Empty; string phoneThirdPart = string.Empty;
            int officePhoneLength = phoneNumber.Length;
            if (officePhoneLength <= 3)
            {
                phoneFirstPart = phoneNumber.Substring(0, officePhoneLength);
            }
            else if (officePhoneLength > 3 && officePhoneLength <= 6)
            {
                phoneFirstPart = phoneNumber.Substring(0, 3);
                phoneSecondPart = phoneNumber.Substring(3, officePhoneLength - 3);
            }
            else if (officePhoneLength > 6 && officePhoneLength <= 10)
            {
                phoneFirstPart = phoneNumber.Substring(0, 3);
                phoneSecondPart = phoneNumber.Substring(3, 3);
                phoneThirdPart = phoneNumber.Substring(6, officePhoneLength - 6);
            }
            else
            {
                phoneFirstPart = phoneNumber.Substring(0, 3);
                phoneSecondPart = phoneNumber.Substring(3, 3);
                phoneThirdPart = phoneNumber.Substring(6, 4);
            }

            phoneParts[0] = phoneFirstPart;
            phoneParts[1] = phoneSecondPart;
            phoneParts[2] = phoneThirdPart;

            return phoneParts;
        }

        [NonAction]
        public static string[] GetDateParts(string date)
        {
            string[] dateParts = new string[3];
            DateTime convertedDate = Convert.ToDateTime(date);
            dateParts[0] = convertedDate.Month.ToString();
            dateParts[1] = convertedDate.Day.ToString();
            dateParts[2] = convertedDate.Year.ToString();
            return dateParts;
        }

        [NonAction]
        public static string[] GetLongDateParts(string date)
        {
            string[] dateParts = new string[3];
            DateTime convertedDate = Convert.ToDateTime(date);
            dateParts[0] = convertedDate.Month.ToString().Length == 1 ? "0" + convertedDate.Month.ToString() : convertedDate.Month.ToString();
            dateParts[1] = convertedDate.Day.ToString().Length == 1 ? "0" + convertedDate.Day.ToString() : convertedDate.Day.ToString();
            dateParts[2] = convertedDate.Year.ToString();
            return dateParts;
        }
        [NonAction]
        public static string GetEnumDescription(Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }

        public enum EnumEducationInstitutionType
        {
            [Description("High School")]
            HighSchool = 0,
            [Description("College")]
            College = 1,
            [Description("University")]
            University = 2,
            [Description("Other")]
            Other = 3
        }
        #endregion
        
        [NonAction]
        internal void MapObjects(object source, object destination)
        {
            Type sourcetype = source.GetType();
            Type destinationtype = destination.GetType();

            var sourceProperties = sourcetype.GetProperties();
            var destionationProperties = destinationtype.GetProperties();

            var commonproperties = from sp in sourceProperties
                                   join dp in destionationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };

            foreach (var match in commonproperties)
            {
                match.dp.SetValue(destination, match.sp.GetValue(source, null), null);
            }
        }
        [NonAction]
        public string GetApplicantFirstName()
        {
            return GetCurrentUser().FirstName;
        }
        [NonAction]
        public string GetApplicantLastName()
        {
            return GetCurrentUser().LastName;
        }
        [NonAction]
        public string GetApplicantMiddleName()
        {
            return GetCurrentUser().MiddleName;
        }
        [NonAction]
        public string GetApplicantEmail()
        {
            return GetCurrentUser().Email;
        }
        [NonAction]
        public static string GetPhoneWithExtension(DataTable dtPhones, string type)
        {
            string locationPhone = "";

            if (dtPhones.Rows.Count > 0)
            {
                int institutePhoneID = Convert.ToInt32(dtPhones.Rows[0]["id"].ToString());
                //DataTable dtPhonesExtension = InstitutionManager.GetInstitutePhoneExtention(institutePhoneID);
                //if (dtPhonesExtension.Rows.Count > 0)
                //{
                //    List<string> extension = new List<string>();
                //    foreach (DataRow r in dtPhonesExtension.Rows)
                //    {
                //        extension.Add(r["ExtensionNumber"].ToString());
                //    }
                //    //locationPhone = Utility.GetPhoneNumber(dtPhones, type, Utility.PhoneFormat, extension);
                //}
                //else
                //{
                //    //locationPhone = Utility.GetPhoneNumber(dtPhones, type, Utility.PhoneFormat);
                //}
            }
            return locationPhone;
        }
        [NonAction]
        public bool AddGeneratedFile(long termplateId, byte[] fileData, string templateFIleName, long userid, int fileType)
        {
            string msg = string.Empty;
            bool success = false;
            //DataRow oRow = GeneratedFilesManager.GetBlankGeneratedFilesDataRow();
            GeneratedFile generatedFile = new GeneratedFile();
            generatedFile.UserId = userid;
            generatedFile.FileData = fileData;
            generatedFile.FileName = $"{templateFIleName}_{GetCurrentUser().FirstName}_{DateTime.Now.ToString("MMddyyyyHHmmss")}.pdf";
            generatedFile.TermplateId = termplateId;
            generatedFile.FileTypeCode = fileType.ToString();
            generatedFile.CreatedDate = DateTime.Now;
            GeneratedFilesManager.InsertGeneratedFile(generatedFile);
            return success;
            //return success;
        }
        [NonAction]
        public bool UpdateGeneratedFile(long termplateId, byte[] fileData, string templateFIleName, long generatedFileId, long userId, int fileType)
        {
            string msg = string.Empty;
            bool success = false;
            GeneratedFile generatedFile = new GeneratedFile();
            generatedFile.GeneratedFileId = generatedFileId;
            generatedFile.UserId = userId;
            generatedFile.FileData = fileData;
            generatedFile.FileName = $"{templateFIleName}_{GetCurrentUser().FirstName}_{DateTime.Now.ToString("MMddyyyyHHmmss")}.pdf";
            generatedFile.TermplateId = termplateId;
            generatedFile.FileTypeCode = fileType.ToString();
            generatedFile.UpdatedDate = DateTime.Now;
            GeneratedFilesManager.UpdateGeneratedFile(generatedFile);
            return success;
        }

        [NonAction]
        protected string GetApplicantName()
        {
            string applicantName = string.Empty;
            if (!string.IsNullOrEmpty(GetCurrentUser().MiddleName))
            {
                applicantName = GetCurrentUser().FirstName + " " + GetCurrentUser().MiddleName + " " + GetCurrentUser().LastName;
            }
            else
            {
                applicantName = GetCurrentUser().FirstName + " " + GetCurrentUser().LastName;
            }
            return applicantName;
        }

        [NonAction]
        public void MapDataRow(DataRow drSource, DataRow drDestination)
        {
            List<string> columNames = new List<string>();

            foreach (DataColumn item in drDestination.Table.Columns)
            {
                columNames.Add(item.ColumnName);
            }

            foreach (var item in columNames)
            {
                if (drSource[item] != null && drDestination[item] != null)
                {
                    drDestination[item] = drSource[item];
                }

            }
        }
    }
}
