using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class ManageFbmsUploadViewData : FirmaViewData
    {
        public string UploadFbmsSpreadSheetUrl { get; set; }
        public string UploadFormID { get; set; }

        public ManageFbmsUploadViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, string uploadFbmsSpreadSheetUrl, string uploadFormID) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Upload Budget and Invoice Data";
            UploadFbmsSpreadSheetUrl = uploadFbmsSpreadSheetUrl;
            UploadFormID = uploadFormID;
        }
    }
}