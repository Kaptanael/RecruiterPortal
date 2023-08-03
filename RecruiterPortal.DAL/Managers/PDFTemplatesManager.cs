using Microsoft.Data.SqlClient;
using RecruiterPortal.DAL.Repository;
using System.Data;
using System.Dynamic;

namespace RecruiterPortalDAL.Managers
{
    public class PDFTemplatesManager
    {
        public static DataTable GetPDFTemplatesFileType(string fileTypeCode)
        {
            //string spName = "sp_GetPDFFileTemplateFileType";
            //dynamic expandoObject = new ExpandoObject();
            //expandoObject.FileTypeCode = fileTypeCode;
            //GenericRepository<PDFTemplate> userRepo = new GenericRepository<PDFTemplate>();
            //SqlParameter[] sqlParameters = userRepo.GetSqlParametersFromExpandoObject(expandoObject, spName);
            //DataTable pdfTemplate = null;
            //try
            //{
            //    pdfTemplate = userRepo.LoadDataTable(spName, sqlParameters);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return pdfTemplate;

            return new DataTable();
        }
    }
}
