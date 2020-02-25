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
using System.IO;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Web.Mvc;
using System.Web.WebPages;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.ReportTemplates;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ExcelUpload;
using ProjectFirma.Web.Views.ReportCenter;
using ProjectFirma.Web.Views.Shared;
using SharpDocx;

namespace ProjectFirma.Web.Controllers
{
    public class ExcelUploadController : FirmaBaseController
    {
        [CrossAreaRoute]
        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult ManageFbmsUpload()
        {
            var firmaPage = FirmaPageTypeEnum.ReportCenterProjects.GetFirmaPage();
            var formID = GenerateUploadFbmsFileUploadFormID();
            var newGisUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportExcelFile());
            var viewData = new ManageFbmsUploadViewData(CurrentFirmaSession, firmaPage, newGisUploadUrl, formID);
            return RazorView<ManageFbmsUpload, ManageFbmsUploadViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult ImportExcelFile()
        {
            var viewModel = new ImportEtlExcelFileViewModel();
            return ViewImportEtlExcelFile( viewModel);
        }


        private PartialViewResult ViewImportEtlExcelFile(ImportEtlExcelFileViewModel viewModel)
        {
            var mapFormID = GenerateUploadFbmsFileUploadFormID();
            var newGisUploadUrl = SitkaRoute<ExcelUploadController>.BuildUrlFromExpression(x => x.ImportExcelFile(null));
            var viewData = new ImportEtlExcelFileViewData(mapFormID, newGisUploadUrl);
            return RazorPartialView<ImportEtlExcelFile, ImportEtlExcelFileViewData, ImportEtlExcelFileViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportExcelFile( ImportEtlExcelFileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewImportEtlExcelFile(viewModel);
            }

            var httpPostedFileBase = viewModel.FileResourceData;
            List<BudgetTransferBulk> budgetTransferBulks;
            try
            {
                budgetTransferBulks = BudgetTransferBulksHelper.LoadFromXlsFile(httpPostedFileBase.InputStream);
                
            }
            catch (Exception ex)
            {
                // If this is something really weird...
                if (!(ex is SitkaDisplayErrorException))
                {
                    // We want to capture the Excel file for future reference, since this blew up. But we really should be logging it into the logging folder and not a temp folder.
                    var tempFilename = Path.GetTempFileName() + ".xlsx";
                    httpPostedFileBase.SaveAs(tempFilename);
                    var errorLogMessage = string.Format("Unexpected exception while uploading Excel file by PersonID {0} ({1}). File saved at \"{2}\".\r\nException Details:\r\n{3}",
                        CurrentFirmaSession.PersonID,
                        CurrentFirmaSession.Person.GetFullNameFirstLast(),
                        tempFilename,
                        ex);
                    SitkaLogger.Instance.LogDetailedErrorMessage(errorLogMessage);
                }
                var errorMessage = string.Format("There was a problem uploading your spreadsheet \"{0}\": <br/><div style=\"\">{1}</div><br/><div>No budget updates were saved to the database</div><br/>If you need help, please email your spreadsheet to <a href=\"mailto:{2}\">{2}</a> with a note and we will try to help out.", httpPostedFileBase.FileName, ex.Message, FirmaWebConfiguration.SitkaSupportEmail);
                SetErrorForDisplay(errorMessage);

                return new ModalDialogFormJsonResult();
            }

            var countAdded = budgetTransferBulks.Count;
            var payrecs = budgetTransferBulks.Select(x => new StageImpPayRecV3(x)).ToList();
            var existingPayrecs = HttpRequestStorage.DatabaseEntities.StageImpPayRecV3s.ToList();
            existingPayrecs.ForEach(x => x.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.StageImpPayRecV3s.AddRange(payrecs);



            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{countAdded} Budget Transfers were Successfully saved to database.");
            return new ModalDialogFormJsonResult();
        }


        public static string GenerateUploadFbmsFileUploadFormID()
        {
            return $"uploadFbmsFileUpload";
        }
    }
}