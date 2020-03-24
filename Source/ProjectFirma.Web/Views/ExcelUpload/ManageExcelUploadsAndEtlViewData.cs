using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class ManageExcelUploadsAndEtlViewData : FirmaViewData
    {
        public string UploadFbmsSpreadSheetUrl { get; set; }
        public string UploadFormID { get; set; }

        public string DoPublishingProcessingPostUrl { get; set; }

        public ManageExcelUploadsAndEtlViewData(FirmaSession currentFirmaSession, 
                                       ProjectFirmaModels.Models.FirmaPage firmaPage,
                                       string uploadFbmsSpreadSheetUrl, 
                                       string doPublishingProcessingPostUrl, 
                                       string uploadFormID) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Upload Budget and Invoice Data";
            UploadFbmsSpreadSheetUrl = uploadFbmsSpreadSheetUrl;
            UploadFormID = uploadFormID;

            DoPublishingProcessingPostUrl = doPublishingProcessingPostUrl;
        }
    }
}