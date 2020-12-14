/*-----------------------------------------------------------------------
<copyright file="ReportCenterController.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ExcelUpload;
using ProjectFirmaModels.Models;
using ProjectFirmaModels.Models.ExcelUpload;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirma.Web.Controllers
{
    public class ExcelUploadController : FirmaBaseController
    {
        #region ManageExcelUploadsAndEtl

        [CrossAreaRoute]
        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult ManageExcelUploadsAndEtl()
        {
            return ViewManageExcelUploadsAndEtl_Impl();
        }

        private ViewResult ViewManageExcelUploadsAndEtl_Impl()
        {
            var firmaPage = FirmaPageTypeEnum.UploadBudgetAndInvoiceExcel.GetFirmaPage();
            
            var fbmsUploadFormID = GenerateUploadFbmsFileUploadFormId();
            var pnBudgetsUploadFormID = GeneratePnBudgetsUploadFormID();

            var newFbmsExcelFileUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportFbmsExcelFile());
            var newPnBudgetExcelFileUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportPnBudgetsExcelFile());
            var doPublishingProcessingPostUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.DoPublishingProcessing(null));

            var viewData = new ManageExcelUploadsAndEtlViewData(CurrentFirmaSession, 
                                                                firmaPage, 
                                                                newFbmsExcelFileUploadUrl,
                                                                newPnBudgetExcelFileUploadUrl,
                                                                doPublishingProcessingPostUrl, 
                                                                fbmsUploadFormID,
                                                                pnBudgetsUploadFormID);
            var viewModel = new ManageExcelUploadsAndEtlViewModel();
            return RazorView<ManageExcelUploadsAndEtl, ManageExcelUploadsAndEtlViewData, ManageExcelUploadsAndEtlViewModel>(viewData, viewModel);
        }

        public static string GenerateUploadFbmsFileUploadFormId()
        {
            return $"uploadFbmsFileUpload";
        }

        public static string GeneratePnBudgetsUploadFormID()
        {
            return $"uploadPnBudgetsFileUpload";
        }

        #endregion ManageExcelUploadsAndEtl

        #region FBMSExcelUpload

        /// <summary>
        /// this is the number of rows down the header appears in the imported ETL excel file.
        /// If this continues to move around, we can write a search for the first header column by text ( "business area - key" for example).
        /// -- SLG & TK 3/16/2020
        /// </summary>
        public const int FbmsExcelFileHeaderRowOffset = 2;

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult ImportFbmsExcelFile()
        {
            var viewModel = new ImportFbmsExcelFileViewModel();
            return ViewImportFbmsExcelFile( viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportFbmsExcelFile(ImportFbmsExcelFileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewImportFbmsExcelFile(viewModel);
            }

            var httpPostedFileBase = viewModel.FileResourceData;

            return DoFbmsExcelImportForHttpPostedFile(httpPostedFileBase);
        }

        [FirmaAdminFeature]
        private ActionResult DoFbmsExcelImportForHttpPostedFile(HttpPostedFileBase httpPostedFileBase)
        {
            return DoFbmsExcelImportForFileStream(httpPostedFileBase.InputStream, httpPostedFileBase.FileName);
        }

        [FirmaAdminFeature]
        private ActionResult DoFbmsExcelImportForFileStream(Stream excelFileAsStream, string optionalOriginalFilename)
        {
            DateTime startTime = DateTime.Now;

            List<FbmsBudgetStageImportPayrecV3UnexpendedBalance> budgetStageImports;
            try
            {
                budgetStageImports = FbmsBudgetStageImportsHelper.LoadFbmsBudgetStageImportPayrecV3UnexpendedBalancesFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
            }
            catch (Exception ex)
            {
                return Common_LoadFromXls_ExceptionHandler(excelFileAsStream, optionalOriginalFilename, ex);
            }

            // GROOT

            LoadFbmsRecordsFromExcelFileObjectsIntoStagingTable(budgetStageImports, out var countAddedBudgets, this.CurrentFirmaSession);
            DateTime endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            string importTimeString = GetTaskTimeString("Import", elapsedTime);

            // Record that we uploaded
            var newImpProcessingForFbms = new ImpProcessing(ImpProcessingTableType.FBMS);
            newImpProcessingForFbms.UploadDate = endTime;
            newImpProcessingForFbms.UploadPerson = this.CurrentFirmaSession.Person;
            newImpProcessingForFbms.UploadedFiscalYears = null;
            HttpRequestStorage.DatabaseEntities.ImpProcessings.Add(newImpProcessingForFbms);
            HttpRequestStorage.DatabaseEntities.SaveChanges(this.CurrentFirmaSession);

            ProjectTaxonomyLeafTest.CallAllTaxonomyLeavesForAllProjectsToCheckForCrashes();

            SetMessageForDisplay($"{countAddedBudgets.ToGroupedNumeric()} FBMS records were successfully imported to database. </br>{importTimeString}.");
            // This is the right thing to return, since this starts off in a modal dialog
            return new ModalDialogFormJsonResult();
        }

        private static string GetTaskTimeString(string taskString, TimeSpan elapsedTime)
        {
            return $"{taskString} took {elapsedTime.TotalSeconds:0.0} seconds ({elapsedTime.TotalMinutes:0.00} minutes)";
        }

        public static void LoadFbmsRecordsFromExcelFileObjectsIntoStagingTable(List<FbmsBudgetStageImportPayrecV3UnexpendedBalance> budgetStageImports,
                                                                               out int countAddedBudgets,
                                                                               FirmaSession optionalCurrentFirmaSession)
        {
            // Now using unexpended payrecs
            countAddedBudgets = budgetStageImports.Count;
            var unexpendedPayrecs = budgetStageImports.Select(iub => new StageImpUnexpendedBalancePayRecV3(iub)).ToList();
            var existingPayrecs = HttpRequestStorage.DatabaseEntities.StageImpUnexpendedBalancePayRecV3s.ToList();
            existingPayrecs.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.StageImpUnexpendedBalancePayRecV3s.AddRange(unexpendedPayrecs);

            // This bulk load creates an obscene number of AuditLog records if we don't suppress them, and
            // they are completely inappropriate.
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(Tenant.SitkaTechnologyGroup.TenantID);
        }

        private PartialViewResult ViewImportFbmsExcelFile(ImportFbmsExcelFileViewModel viewModel)
        {
            var fmbsExcelFileUploadFormID = GenerateUploadFbmsFileUploadFormId();
            var newGisUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportFbmsExcelFile(null));
            var viewData = new ImportFbmsExcelFileViewData(fmbsExcelFileUploadFormID, newGisUploadUrl);
            return RazorPartialView<ImportFbmsExcelFile, ImportFbmsExcelFileViewData, ImportFbmsExcelFileViewModel>(viewData, viewModel);
        }

        #endregion FBMSExcelUpload

        #region pnBudgetExcelUpload

        /// <summary>
        /// this is the number of rows down the header appears in the imported ETL excel file.
        /// If this continues to move around, we can write a search for the first header column by text ( "business area - key" for example).
        /// -- SLG & TK 3/16/2020
        /// </summary>
        public const int PnBudgetExcelFileHeaderRowOffset = 2;

        
        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult ImportPnBudgetsExcelFile()
        {
            var viewModel = new ImportPnBudgetsExcelFileViewModel();
            return ViewImportPnBudgetsExcelFile(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportPnBudgetsExcelFile(ImportPnBudgetsExcelFileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewImportPnBudgetsExcelFile(viewModel);
            }

            var httpPostedFileBase = viewModel.FileResourceData;

            return DoPnBudgetsExcelImportForHttpPostedFile(httpPostedFileBase);
        }

        [FirmaAdminFeature]
        private ActionResult DoPnBudgetsExcelImportForHttpPostedFile(HttpPostedFileBase httpPostedFileBase)
        {
            return DoPnBudgetsExcelImportForFileStream(httpPostedFileBase.InputStream, httpPostedFileBase.FileName);
        }

        [FirmaAdminFeature]
        private ActionResult DoPnBudgetsExcelImportForFileStream(Stream excelFileAsStream, string optionalOriginalFilename)
        {
            DateTime startTime = DateTime.Now;
            List<PnBudgetsStageImport> pnBudgetStageImports;
            try
            {
                pnBudgetStageImports = PnBudgetStageImportsHelper.LoadFromXlsFile(excelFileAsStream, PnBudgetExcelFileHeaderRowOffset);
            }
            catch (Exception ex)
            {
                return Common_LoadFromXls_ExceptionHandler(excelFileAsStream, optionalOriginalFilename, ex);
            }

            LoadPnBudgetsRecordsFromExcelFileObjectsIntoStagingTable(pnBudgetStageImports, out var countAddedPnBudgets, out var importedFiscalYears, this.CurrentFirmaSession);

            DateTime endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            string importTimeString = GetTaskTimeString("Import", elapsedTime);

            // Record that we uploaded
            var newImpProcessingForPnBudgets = new ImpProcessing(ImpProcessingTableType.PNBudget);
            newImpProcessingForPnBudgets.UploadDate = endTime;
            newImpProcessingForPnBudgets.UploadPerson = this.CurrentFirmaSession.Person;
            newImpProcessingForPnBudgets.UploadedFiscalYears = String.Join(", ", importedFiscalYears);
            HttpRequestStorage.DatabaseEntities.ImpProcessings.Add(newImpProcessingForPnBudgets);
            HttpRequestStorage.DatabaseEntities.SaveChanges(this.CurrentFirmaSession);

            ProjectTaxonomyLeafTest.CallAllTaxonomyLeavesForAllProjectsToCheckForCrashes();

            SetMessageForDisplay($"{countAddedPnBudgets.ToGroupedNumeric()} PnBudget records were successfully imported to database.</br>{importTimeString}.");

            // This is the right thing to return, since this starts off in a modal dialog
            return new ModalDialogFormJsonResult();
        }

        public static void LoadPnBudgetsRecordsFromExcelFileObjectsIntoStagingTable(
                                        List<PnBudgetsStageImport> pnBudgetStageImports,
                                        out int countAddedPnBudgets,
                                        out List<int> importedFiscalYears,
                                        FirmaSession optionalCurrentFirmaSession)
        {
            // Count how many PNBudgets are being uploaded
            countAddedPnBudgets = pnBudgetStageImports.Count;
            // Get the PNBudgets database objects prepared for import
            var stagePnBudgetsBeingLoaded = pnBudgetStageImports.Select(x => new StageImpPnBudget(x)).ToList();
            // Clear out the existing PNBudgets from the database
            var existingPnBudgets = HttpRequestStorage.DatabaseEntities.StageImpPnBudgets.ToList();
            existingPnBudgets.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            // Put in the new PNBudgets in their place
            HttpRequestStorage.DatabaseEntities.StageImpPnBudgets.AddRange(stagePnBudgetsBeingLoaded);
            // Which FiscalYears were imported?
            importedFiscalYears = stagePnBudgetsBeingLoaded.Select(pnb =>
                Views.Shared.ProjectRunningBalanceObligationsAndExpenditures.FiscalMonthPeriodHelper
                    .GetFiscalYearForFiscalYearPeriodString(pnb.FiscalYearPeriod)).Distinct().OrderBy(fy => fy).ToList();

            // This bulk load creates an obscene number of AuditLog records if we don't suppress them, and
            // they are completely inappropriate.
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(Tenant.SitkaTechnologyGroup.TenantID);
        }

        private PartialViewResult ViewImportPnBudgetsExcelFile(ImportPnBudgetsExcelFileViewModel viewModel)
        {
            var pnBudgetsUploadFormID = GeneratePnBudgetsUploadFormID();
            var newGisUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportPnBudgetsExcelFile(null));
            var viewData = new ImportPnBudgetsExcelFileViewData(pnBudgetsUploadFormID, newGisUploadUrl);
            return RazorPartialView<ImportPnBudgetsExcelFile, ImportPnBudgetsExcelFileViewData, ImportPnBudgetsExcelFileViewModel>(viewData, viewModel);
        }

        #endregion pnBudgetExcelUpload

        #region CommonUploadStuff

        

        private ActionResult Common_LoadFromXls_ExceptionHandler(Stream excelFileAsStream, 
                                                                 string optionalOriginalFilename,
                                                                 Exception ex)
        {
            string tempExcelFilename = Path.GetTempFileName() + ".xlsx";
            using (var excelFileStream = System.IO.File.Create(tempExcelFilename))
            {
                excelFileAsStream.Seek(0, SeekOrigin.Begin);
                excelFileAsStream.CopyTo(excelFileStream);

                // If this is something really weird...
                if (!(ex is SitkaDisplayErrorException))
                {
                    // We want to capture the Excel file for future reference, since this blew up. But we really should be logging it into the logging folder and not a temp folder.
                    var errorLogMessage =
                        $"Unexpected exception while uploading Excel file by PersonID {CurrentFirmaSession.PersonID} ({CurrentFirmaSession.Person.GetFullNameFirstLast()}). Original filename \"{optionalOriginalFilename}\" File saved at \"{tempExcelFilename}\".\r\nException Details:\r\n{ex}";
                    SitkaLogger.Instance.LogDetailedErrorMessage(errorLogMessage);
                }

                var errorMessage =
                    $"There was a problem uploading your spreadsheet \"{optionalOriginalFilename}\": <br/><div style=\"\">{ex.Message}</div><br/><div>Nothing was saved to the database.</div><br/>If you need help, please email your spreadsheet to <a href=\"mailto:{FirmaWebConfiguration.SitkaSupportEmail}\">{FirmaWebConfiguration.SitkaSupportEmail}</a> with a note and we will try to help out.";
                // We originally did not do this, assuming the user would self correct, but it turns out Dorothy was expecting us to see crashes and respond, which is fine.
                // So, instead, we'll send an error email for each and every problem, even the ones we understand. -- SLG 7/9/2020
                SitkaLogger.Instance.LogDetailedErrorMessage(errorMessage);
                SetErrorForDisplay(errorMessage);
            }

            // This is the right thing to return, since this starts off in a modal dialog
            return new ModalDialogFormJsonResult();
        }

        #endregion CommonUploadStuff

        #region Publishing

        [HttpGet]
        [FirmaAdminFeature]
        public ActionResult DoPublishingProcessing()
        {
            throw new NotImplementedException("Just here to provide signature; do not call.");
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult DoPublishingProcessing(ManageExcelUploadsAndEtlViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                throw new SitkaDisplayErrorException("Not expecting model state to be bad; not running publishing processing.");
            }

            bool wasErrorDuringProcessing = false;
            DateTime startTime = DateTime.Now;
            try
            {
                DoPublishingSql(Logger);

                //int blah = 2;
                //if (1 == blah-1)
                //{
                //    //throw new Exception("Fake exception to test ideas..");
                //}

                // If we get this far, we've succeeded.
                // Log last import as successful.
                var processedDateTime = DateTime.Now;
                var latestImportProcessingForFbms = ImpProcessing.GetLatestImportProcessingForGivenType(HttpRequestStorage.DatabaseEntities, ImpProcessingTableType.FBMS);
                var latestImportProcessingForPnBudget = ImpProcessing.GetLatestImportProcessingForGivenType(HttpRequestStorage.DatabaseEntities, ImpProcessingTableType.PNBudget);
                if (latestImportProcessingForFbms == null || latestImportProcessingForPnBudget == null)
                {
                    // We don't expect this to really happen once things are running smoothly, but in the short
                    // term I want to know about it.
                    SetErrorForDisplay($"Could not find processing records for last upload (ImpProcessing)");
                }
                else
                {
                    latestImportProcessingForFbms.LastProcessedDate = processedDateTime;
                    latestImportProcessingForFbms.LastProcessedPerson = CurrentFirmaSession.Person;
                    latestImportProcessingForPnBudget.LastProcessedDate = processedDateTime;
                    latestImportProcessingForPnBudget.LastProcessedPerson = CurrentFirmaSession.Person;
                    HttpRequestStorage.DatabaseEntities.SaveChanges(this.CurrentFirmaSession);
                }
            }
            catch (Exception e)
            {
                SetErrorForDisplay($"Problem executing Publishing: {e.Message}");
                wasErrorDuringProcessing = true;
            }

            ProjectTaxonomyLeafTest.CallAllTaxonomyLeavesForAllProjectsToCheckForCrashes();

            DateTime endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            string processingTimeString = GetTaskTimeString("Publishing", elapsedTime);

            if (!wasErrorDuringProcessing)
            {
                SetMessageForDisplay($"Publishing Processing completed Successfully.<br/>{processingTimeString}");
            }
            else
            {
                // Apparently at the moment we can only have one error/warning, so since I want TWO messages, resorting to 
                // an error and a warning.
                SetWarningForDisplay($"Publishing Processing had problems.<br/>{processingTimeString}");
            }
            return RedirectToAction(new SitkaRoute<ExcelUploadController>(x => x.ManageExcelUploadsAndEtl()));
        }

        /// <summary>
        /// Do ObligationRequest matching.
        /// DoPublishingSql calls this as part of it's proc pReclamationImportFinancialStagingDataImport as well.
        /// </summary>
        /// <param name="optionalLogger"></param>
        public static void DoObligationRequestMatching(ILog optionalLogger)
        {
            try
            {
                optionalLogger?.Info($"Starting DoObligationRequestMatching");
                string vendorImportProc = "dbo.pRefreshCostAuthorityObligationNumberMatches";
                using (SqlConnection sqlConnection = CreateAndOpenSqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(vendorImportProc, sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // If we needed parameters, here's how we'd add them.
                        //cmd.Parameters.AddWithValue("@SocrataDataMartRawJsonImportID", socrataDataMartRawJsonImportID);
                        //cmd.Parameters.AddWithValue("@BienniumToImport", bienniumToImport);
                        cmd.ExecuteNonQuery();
                    }
                }
                optionalLogger?.Info($"Ending DoObligationRequestMatching");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new SitkaDisplayErrorException($"Problem calling SQL: {e.Message}");
            }
        }


        public static void DoPublishingSql(ILog optionalLogger)
        {
            try
            {
                optionalLogger?.Info($"Starting DoPublishingSql");
                string vendorImportProc = "dbo.pReclamationImportFinancialStagingDataImport";
                using (SqlConnection sqlConnection = CreateAndOpenSqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(vendorImportProc, sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // If we needed parameters, here's how we'd add them.
                        //cmd.Parameters.AddWithValue("@SocrataDataMartRawJsonImportID", socrataDataMartRawJsonImportID);
                        //cmd.Parameters.AddWithValue("@BienniumToImport", bienniumToImport);
                        cmd.ExecuteNonQuery();
                    }
                }
                optionalLogger?.Info($"Ending DoPublishingSql");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new SitkaDisplayErrorException($"Problem calling SQL: {e.Message}");
            }
        }

        public static SqlConnection CreateAndOpenSqlConnection()
        {
            var db = new ProjectFirmaSqlDatabase();
            var sqlConnection = db.CreateConnection();
            sqlConnection.Open();
            return sqlConnection;
        }



        #endregion Publishing
    }
}