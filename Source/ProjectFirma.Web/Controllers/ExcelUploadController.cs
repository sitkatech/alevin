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
            // WRONG
            var newPnBudgetExcelFileUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportFbmsExcelFile());
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
        public const int FbmsExcelFileHeaderRowOffset = 3;



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
            List<FbmsBudgetStageImport> budgetStageImports;
            List<FbmsInvoiceStageImport> invoiceStageImports;
            try
            {
                budgetStageImports = FbmsBudgetStageImportsHelper.LoadFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
                invoiceStageImports = FbmsInvoiceStageImportsHelper.LoadFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
            }
            catch (Exception ex)
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
                        "There was a problem uploading your spreadsheet \"{0}\": <br/><div style=\"\">{1}</div><br/><div>No budget updates were saved to the database</div><br/>If you need help, please email your spreadsheet to <a href=\"mailto:{2}\">{2}</a> with a note and we will try to help out.",
                        optionalOriginalFilename, ex.Message, FirmaWebConfiguration.SitkaSupportEmail);
                    SetErrorForDisplay(errorMessage);
                }

                // This is the right thing to return, since this starts off in a modal dialog
                return new ModalDialogFormJsonResult();
            }

            DoEtlProcessingOnFbmsRecordsLoadedIntoPairedStagingTables(budgetStageImports, invoiceStageImports, out var countAddedBudgets, out var countAddedInvoices, this.CurrentFirmaSession);

            SetMessageForDisplay($"{countAddedBudgets} Budget records were Successfully saved to database. </br> {countAddedInvoices} Invoice records were Successfully saved to database.");
            // This is the right thing to return, since this starts off in a modal dialog
            return new ModalDialogFormJsonResult();
        }

        public static void DoEtlProcessingOnFbmsRecordsLoadedIntoPairedStagingTables(
                                        List<FbmsBudgetStageImport> budgetStageImports,
                                        List<FbmsInvoiceStageImport> invoiceStageImports, 
                                        out int countAddedBudgets,
                                        out int countAddedInvoices,
                                        FirmaSession optionalCurrentFirmaSession)
        {
            countAddedBudgets = budgetStageImports.Count;
            var payrecs = budgetStageImports.Select(x => new StageImpPayRecV3(x)).ToList();
            var existingPayrecs = HttpRequestStorage.DatabaseEntities.StageImpPayRecV3s.ToList();
            existingPayrecs.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.StageImpPayRecV3s.AddRange(payrecs);

            countAddedInvoices = invoiceStageImports.Count;
            var invoices = invoiceStageImports.Select(x => new StageImpApGenSheet(x)).ToList();
            var existingInvoices = HttpRequestStorage.DatabaseEntities.StageImpApGenSheets.ToList();
            existingInvoices.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.StageImpApGenSheets.AddRange(invoices);

            if (optionalCurrentFirmaSession != null)
            {
                HttpRequestStorage.DatabaseEntities.SaveChanges(optionalCurrentFirmaSession.Person);
            }
            else
            {
                // This is most likely a test context anyhow
                HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(Tenant.SitkaTechnologyGroup.TenantID);
            }
        }

        private PartialViewResult ViewImportFbmsExcelFile(ImportFbmsExcelFileViewModel viewModel)
        {
            var mapFormId = GenerateUploadFbmsFileUploadFormId();
            var newGisUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportFbmsExcelFile(null));
            var viewData = new ImportFbmsExcelFileViewData(mapFormId, newGisUploadUrl);
            return RazorPartialView<ImportFbmsExcelFile, ImportFbmsExcelFileViewData, ImportFbmsExcelFileViewModel>(viewData, viewModel);
        }

        #endregion ETLExcelUpload

        #region pnBudgetExcelUpload

        /// <summary>
        /// this is the number of rows down the header appears in the imported ETL excel file.
        /// If this continues to move around, we can write a search for the first header column by text ( "business area - key" for example).
        /// -- SLG & TK 3/16/2020
        /// </summary>
        public const int PnBudgetExcelFileHeaderRowOffset = 3;

        /*
        [CrossAreaRoute]
        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult ManageUpload()
        {
            return ViewManageExcelUploadsAndEtl_Impl();
        }

        private ViewResult ViewManageExcelUploadsAndEtl_Impl()
        {
            var firmaPage = FirmaPageTypeEnum.UploadBudgetAndInvoiceExcel.GetFirmaPage();
            var formId = GenerateUploadFbmsFileUploadFormId();
            var newExcelFileUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportFbmsExcelFile());
            var doPublishingProcessingPostUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.DoPublishingProcessing(null));
            var viewData = new ManageExcelUploadsAndEtlViewData(CurrentFirmaSession, firmaPage, newExcelFileUploadUrl, doPublishingProcessingPostUrl, formId);
            var viewModel = new ManageExcelUploadsAndEtlViewModel();
            return RazorView<ManageExcelUploadsAndEtl, ManageExcelUploadsAndEtlViewData, ManageExcelUploadsAndEtlViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult ImportFbmsExcelFile()
        {
            var viewModel = new ImportFbmsExcelFileViewModel();
            return ViewImportFbmsExcelFile(viewModel);
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
            List<FbmsBudgetStageImport> budgetStageImports;
            List<FbmsInvoiceStageImport> invoiceStageImports;
            try
            {
                budgetStageImports = FbmsBudgetStageImportsHelper.LoadFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
                invoiceStageImports = FbmsInvoiceStageImportsHelper.LoadFromXlsFile(excelFileAsStream, FbmsExcelFileHeaderRowOffset);
            }
            catch (Exception ex)
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
                        "There was a problem uploading your spreadsheet \"{0}\": <br/><div style=\"\">{1}</div><br/><div>No budget updates were saved to the database</div><br/>If you need help, please email your spreadsheet to <a href=\"mailto:{2}\">{2}</a> with a note and we will try to help out.",
                        optionalOriginalFilename, ex.Message, FirmaWebConfiguration.SitkaSupportEmail);
                    SetErrorForDisplay(errorMessage);
                }

                // This is the right thing to return, since this starts off in a modal dialog
                return new ModalDialogFormJsonResult();
            }

            DoEtlProcessingOnFbmsRecordsLoadedIntoPairedStagingTables(budgetStageImports, invoiceStageImports, out var countAddedBudgets, out var countAddedInvoices, this.CurrentFirmaSession);

            SetMessageForDisplay($"{countAddedBudgets} Budget records were Successfully saved to database. </br> {countAddedInvoices} Invoice records were Successfully saved to database.");
            // This is the right thing to return, since this starts off in a modal dialog
            return new ModalDialogFormJsonResult();
        }

        public static void DoEtlProcessingOnFbmsRecordsLoadedIntoPairedStagingTables(
                                        List<FbmsBudgetStageImport> budgetStageImports,
                                        List<FbmsInvoiceStageImport> invoiceStageImports,
                                        out int countAddedBudgets,
                                        out int countAddedInvoices,
                                        FirmaSession optionalCurrentFirmaSession)
        {
            countAddedBudgets = budgetStageImports.Count;
            var payrecs = budgetStageImports.Select(x => new StageImpPayRecV3(x)).ToList();
            var existingPayrecs = HttpRequestStorage.DatabaseEntities.StageImpPayRecV3s.ToList();
            existingPayrecs.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.StageImpPayRecV3s.AddRange(payrecs);

            countAddedInvoices = invoiceStageImports.Count;
            var invoices = invoiceStageImports.Select(x => new StageImpApGenSheet(x)).ToList();
            var existingInvoices = HttpRequestStorage.DatabaseEntities.StageImpApGenSheets.ToList();
            existingInvoices.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.StageImpApGenSheets.AddRange(invoices);

            if (optionalCurrentFirmaSession != null)
            {
                HttpRequestStorage.DatabaseEntities.SaveChanges(optionalCurrentFirmaSession.Person);
            }
            else
            {
                // This is most likely a test context anyhow
                HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(Tenant.SitkaTechnologyGroup.TenantID);
            }
        }

        private PartialViewResult ViewImportFbmsExcelFile(ImportFbmsExcelFileViewModel viewModel)
        {
            var mapFormId = GenerateUploadFbmsFileUploadFormId();
            var newGisUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportFbmsExcelFile(null));
            var viewData = new ImportFbmsExcelFileViewData(mapFormId, newGisUploadUrl);
            return RazorPartialView<ImportFbmsExcelFile, ImportFbmsExcelFileViewData, ImportFbmsExcelFileViewModel>(viewData, viewModel);
        }


        */
        #endregion pnBudgetExcelUpload

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

            try
            {
                DoPublishingSql(Logger);
            }
            catch (Exception e)
            {
                SetErrorForDisplay($"Problem executing Publishing: {e.Message}");
            }

            SetMessageForDisplay($"Publishing Processing completed Successfully");
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