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

        // Using original object for reference, with many columns, but not unexpended balance

        //[FirmaAdminFeature]
        //private ActionResult DoFbmsExcelImportForFileStream(Stream excelFileAsStream, string optionalOriginalFilename)
        //{
        //    DateTime startTime = DateTime.Now;

        //    List<FbmsBudgetStageImportOriginalPayrecV3> budgetStageImports;
        //    List<FbmsInvoiceStageImport> invoiceStageImports;
        //    try
        //    {
        //        budgetStageImports = FbmsBudgetStageImportsHelper.LoadFbmsBudgetStageImportOriginalPayrecV3sFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
        //        invoiceStageImports = FbmsInvoiceStageImportsHelper.LoadFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Common_LoadFromXls_ExceptionHandler(excelFileAsStream, optionalOriginalFilename, ex);
        //    }

        //    LoadFbmsRecordsFromExcelFileObjectsIntoPairedStagingTables(budgetStageImports, invoiceStageImports, out var countAddedBudgets, out var countAddedInvoices, this.CurrentFirmaSession);
        //    DateTime endTime = DateTime.Now;
        //    var elapsedTime = endTime - startTime;
        //    string importTimeString = GetTaskTimeString("Import", elapsedTime);

        //    // Record that we uploaded
        //    var newImpProcessingForFbms = new ImpProcessing(ImpProcessingTableType.FBMS);
        //    newImpProcessingForFbms.UploadDate = endTime;
        //    newImpProcessingForFbms.UploadPerson = this.CurrentFirmaSession.Person;
        //    HttpRequestStorage.DatabaseEntities.ImpProcessings.Add(newImpProcessingForFbms);
        //    HttpRequestStorage.DatabaseEntities.SaveChanges(this.CurrentFirmaSession);

        //    SetMessageForDisplay($"{countAddedBudgets.ToGroupedNumeric()} Budget records were successfully imported to database. </br> {countAddedInvoices.ToGroupedNumeric()} Invoice records were Successfully saved to database.</br>{importTimeString}.");
        //    // This is the right thing to return, since this starts off in a modal dialog
        //    return new ModalDialogFormJsonResult();
        //}

        [FirmaAdminFeature]
        private ActionResult DoFbmsExcelImportForFileStream(Stream excelFileAsStream, string optionalOriginalFilename)
        {
            DateTime startTime = DateTime.Now;

            List<FbmsBudgetStageImportPayrecV3UnexpendedBalance> budgetStageImports;
            //List<FbmsInvoiceStageImport> invoiceStageImports;
            try
            {
                budgetStageImports = FbmsBudgetStageImportsHelper.LoadFbmsBudgetStageImportPayrecV3UnexpendedBalancesFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
                // Unsure if this is gone long term, but it's gone for now. -- SLG 6/11/2020
                //invoiceStageImports = FbmsInvoiceStageImportsHelper.LoadFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
            }
            catch (Exception ex)
            {
                return Common_LoadFromXls_ExceptionHandler(excelFileAsStream, optionalOriginalFilename, ex);
            }

            //LoadFbmsRecordsFromExcelFileObjectsIntoPairedStagingTables(budgetStageImports, invoiceStageImports, out var countAddedBudgets, out var countAddedInvoices, this.CurrentFirmaSession);
            LoadFbmsRecordsFromExcelFileObjectsIntoPairedStagingTables(budgetStageImports, out var countAddedBudgets, this.CurrentFirmaSession);
            DateTime endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            string importTimeString = GetTaskTimeString("Import", elapsedTime);

            // Record that we uploaded
            var newImpProcessingForFbms = new ImpProcessing(ImpProcessingTableType.FBMS);
            newImpProcessingForFbms.UploadDate = endTime;
            newImpProcessingForFbms.UploadPerson = this.CurrentFirmaSession.Person;
            HttpRequestStorage.DatabaseEntities.ImpProcessings.Add(newImpProcessingForFbms);
            HttpRequestStorage.DatabaseEntities.SaveChanges(this.CurrentFirmaSession);

            //SetMessageForDisplay($"{countAddedBudgets.ToGroupedNumeric()} Budget records were successfully imported to database. </br> {countAddedInvoices.ToGroupedNumeric()} Invoice records were Successfully saved to database.</br>{importTimeString}.");
            SetMessageForDisplay($"{countAddedBudgets.ToGroupedNumeric()} Budget records were successfully imported to database. </br>{importTimeString}.");
            // This is the right thing to return, since this starts off in a modal dialog
            return new ModalDialogFormJsonResult();
        }


        // 

        private static string GetTaskTimeString(string taskString, TimeSpan elapsedTime)
        {
            return $"{taskString} took {elapsedTime.TotalSeconds:0.0} seconds ({elapsedTime.TotalMinutes:0.00} minutes)";
        }

        public static void LoadFbmsRecordsFromExcelFileObjectsIntoPairedStagingTables(
                                        List<FbmsBudgetStageImportPayrecV3UnexpendedBalance> budgetStageImports,
                                        // gone for now.
                                        //List<FbmsInvoiceStageImport> invoiceStageImports, 
                                        out int countAddedBudgets,
                                        //out int countAddedInvoices,
                                        FirmaSession optionalCurrentFirmaSession)
        {
            // Now using unexpended payrecs
            countAddedBudgets = budgetStageImports.Count;
            var unexpendedPayrecs = budgetStageImports.Select(iub => new StageImpUnexpendedBalancePayRecV3(iub)).ToList();
            var existingPayrecs = HttpRequestStorage.DatabaseEntities.StageImpUnexpendedBalancePayRecV3s.ToList();
            existingPayrecs.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.StageImpUnexpendedBalancePayRecV3s.AddRange(unexpendedPayrecs);

            // Gone for now; may come back as separate import. -- 6/11/2020 -- SLG 

            //countAddedInvoices = invoiceStageImports.Count;
            //var invoices = invoiceStageImports.Select(x => new StageImpApGenSheet(x)).ToList();
            //var existingInvoices = HttpRequestStorage.DatabaseEntities.StageImpApGenSheets.ToList();
            //existingInvoices.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            //HttpRequestStorage.DatabaseEntities.StageImpApGenSheets.AddRange(invoices);

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

            LoadPnBudgetsRecordsFromExcelFileObjectsIntoStagingTable(pnBudgetStageImports, out var countAddedPnBudgets, this.CurrentFirmaSession);

            DateTime endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            string importTimeString = GetTaskTimeString("Import", elapsedTime);

            // Record that we uploaded
            var newImpProcessingForPnBudgets = new ImpProcessing(ImpProcessingTableType.PNBudget);
            newImpProcessingForPnBudgets.UploadDate = endTime;
            newImpProcessingForPnBudgets.UploadPerson = this.CurrentFirmaSession.Person;
            HttpRequestStorage.DatabaseEntities.ImpProcessings.Add(newImpProcessingForPnBudgets);
            HttpRequestStorage.DatabaseEntities.SaveChanges(this.CurrentFirmaSession);

            SetMessageForDisplay($"{countAddedPnBudgets.ToGroupedNumeric()} PnBudget records were successfully imported to database.</br>{importTimeString}.");

            // This is the right thing to return, since this starts off in a modal dialog
            return new ModalDialogFormJsonResult();
        }

        public static void LoadPnBudgetsRecordsFromExcelFileObjectsIntoStagingTable(
                                        List<PnBudgetsStageImport> pnBudgetStageImports,
                                        out int countAddedPnBudgets,
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
                    var errorLogMessage = string.Format(
                        "Unexpected exception while uploading Excel file by PersonID {0} ({1}). Original filename \"{4}\" File saved at \"{2}\".\r\nException Details:\r\n{3}",
                        CurrentFirmaSession.PersonID,
                        CurrentFirmaSession.Person.GetFullNameFirstLast(),
                        tempExcelFilename,
                        optionalOriginalFilename,
                        ex);
                    SitkaLogger.Instance.LogDetailedErrorMessage(errorLogMessage);
                }

                var errorMessage = string.Format(
                    "There was a problem uploading your spreadsheet \"{0}\": <br/><div style=\"\">{1}</div><br/><div>Nothing was saved to the database.</div><br/>If you need help, please email your spreadsheet to <a href=\"mailto:{2}\">{2}</a> with a note and we will try to help out.",
                    optionalOriginalFilename, ex.Message, FirmaWebConfiguration.SitkaSupportEmail);
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