﻿using ProjectFirma.Web.Common;
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



        public bool PublishingProcessingIsNeeded
        {
            get
            {
                bool fbmsProcessingIsNeeded = LatestImportProcessingForFbms?.LastProcessedDate == null;
                bool pnBudgetProcessingIsNeeded = LatestImportProcessingForPnBudget?.LastProcessedDate == null;

                bool publishingProcessingIsNeeded = fbmsProcessingIsNeeded || pnBudgetProcessingIsNeeded;
                return publishingProcessingIsNeeded;
            }
        }

        public ImpProcessing LatestImportProcessingForFbms;
        public ImpProcessing LatestImportProcessingForPnBudget;

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

            LatestImportProcessingForFbms = ImpProcessing.GetLatestImportProcessingForGivenType(HttpRequestStorage.DatabaseEntities, ImpProcessingTableType.FBMS);
            LatestImportProcessingForPnBudget = ImpProcessing.GetLatestImportProcessingForGivenType(HttpRequestStorage.DatabaseEntities, ImpProcessingTableType.PNBudget);
        }

        #region LastUploadInfo
        public string GetLastFbmsUploadedDateAndPersonString()
        {
            var lastFbmsUploadDate = LatestImportProcessingForFbms?.UploadDate;
            return lastFbmsUploadDate != null ? $"{lastFbmsUploadDate.ToString()} - {LatestImportProcessingForFbms.UploadPerson.GetFullNameFirstLast()}" : "Unknown";
        }

        public string GetLastPnBudgetUploadedDateAndPersonString()
        {
            var lastPnBudgetUploadDate = LatestImportProcessingForPnBudget?.UploadDate;
            return lastPnBudgetUploadDate != null ? $"{lastPnBudgetUploadDate.ToString()} - {LatestImportProcessingForPnBudget.UploadPerson.GetFullNameFirstLast()}" : "Unknown";
        }

        #endregion LastUploadInfo


        public string GetLastFbmsLastProcessedDateAndPersonString()
        {
            var lastFbmsProcessedDate = LatestImportProcessingForFbms?.LastProcessedDate;
            return lastFbmsProcessedDate != null ? $"{lastFbmsProcessedDate.ToString()} - {LatestImportProcessingForFbms.LastProcessedPerson.GetFullNameFirstLast()}" : "Unknown";
        }

        public string GetLastPnBudgetProcessedDateAndPersonString()
        {
            var lastPnBudgetProcessedDate = LatestImportProcessingForPnBudget?.LastProcessedDate;
            return lastPnBudgetProcessedDate != null ? $"{lastPnBudgetProcessedDate.ToString()} - {LatestImportProcessingForPnBudget.LastProcessedPerson.GetFullNameFirstLast()}" : "Unknown";
        }

        public string GetLastPnBudgetProcessedDateAndPersonAndFiscalYearsString()
        {
            var lastPnBudgetProcessedDate = LatestImportProcessingForPnBudget?.LastProcessedDate;
            return lastPnBudgetProcessedDate != null ? $"{lastPnBudgetProcessedDate.ToString()} - {LatestImportProcessingForPnBudget.LastProcessedPerson.GetFullNameFirstLast()} - FY {GetLastPnBudgetFiscalYearsProcessedString()}" : "Unknown";
        }



        /// <summary>
        /// Return "2019, 2020" for example
        /// These are the fiscal years for the *LAST SUCCESSFUL* processing run.
        /// </summary>
        /// <returns></returns>
        public string GetLastPnBudgetFiscalYearsProcessedString()
        {
            var lastPnBudgetProcessedDate = LatestImportProcessingForPnBudget?.LastProcessedDate;
            var lastUploadedFiscalYearsThatNeedProcessing = lastPnBudgetProcessedDate!= null ? LatestImportProcessingForPnBudget?.UploadedFiscalYears : string.Empty;
            return lastUploadedFiscalYearsThatNeedProcessing != null ? lastUploadedFiscalYearsThatNeedProcessing : "Unknown";
        }

        /// <summary>
        /// Return "2019, 2020" for example
        /// These are the fiscal years in the last UPLOAD. These may or may not have been processed.
        /// </summary>
        /// <returns></returns>
        public string GetLastPnBudgetFiscalYearsUploadedString()
        {
            var lastUploadedFiscalYearsThatNeedProcessing = LatestImportProcessingForPnBudget?.UploadedFiscalYears;
            return lastUploadedFiscalYearsThatNeedProcessing != null ? lastUploadedFiscalYearsThatNeedProcessing : "Unknown";
        }

    }
}