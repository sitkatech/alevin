using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class ManageExcelUploadsAndEtlViewData : FirmaViewData
    {
        public string UploadFbmsSpreadSheetUrl { get; set; }
        public string UploadFbmsFormID { get; set; }

        public string UploadPnBudgetsSpreadSheetUrl { get; set; }
        public string UploadPnBudgetsFormID { get; set; }

        public string DoPublishingProcessingPostUrl { get; set; }

        public ManageExcelUploadsAndEtlViewData(FirmaSession currentFirmaSession,
                                       ProjectFirmaModels.Models.FirmaPage firmaPage,
                                       string uploadFbmsSpreadSheetUrl,
                                       string uploadPnBudgetsSpreadSheetUrl,
                                       string doPublishingProcessingPostUrl,
                                       string uploadFbmsFormID,
                                       string uploadPnBudgetsFormID
                                       ) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Upload Budget and Invoice Data";
            UploadFbmsSpreadSheetUrl = uploadFbmsSpreadSheetUrl;
            UploadFbmsFormID = uploadFbmsFormID;

            UploadPnBudgetsSpreadSheetUrl = uploadPnBudgetsSpreadSheetUrl;
            UploadPnBudgetsFormID = uploadPnBudgetsFormID;

            DoPublishingProcessingPostUrl = doPublishingProcessingPostUrl;
        }
    }
}