/*-----------------------------------------------------------------------
<copyright file="ExcelUploadControllerTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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

using System.Collections.Generic;
using System.IO;
using log4net;
using NUnit.Framework;
using ProjectFirma.Web.Views.ExcelUpload;
using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirma.Web.Controllers
{
    [TestFixture]
    public class ExcelUploadControllerTest
    {
        protected ILog Logger = LogManager.GetLogger(typeof(ExcelUploadControllerTest));

        [Test]
        [Description("Simulate the uploading and processing of the Excel FBMS information")]
        public void TestExcelUploadAndPublishingProcess()
        {
            const string pathToSampleFbmsExcelFileThatWouldBeUploaded = "C:\\git\\sitkatech\\alevin\\Source\\ProjectFirma.Web\\Controllers\\ExcelUploadControllerTestData\\Sitka AP Rpt_2020-03-13 added Dates.xlsx";

            FileStream excelFileStream = new FileStream(pathToSampleFbmsExcelFileThatWouldBeUploaded, FileMode.Open, FileAccess.Read);

            List<FbmsBudgetStageImport> budgetTransferBulks = FbmsBudgetStageImportsHelper.LoadFromXlsFile(excelFileStream, ExcelUploadController.FbmsExcelFileHeaderRowOffset);
            List<FbmsInvoiceStageImport> invoiceStageImports = FbmsInvoiceStageImportsHelper.LoadFromXlsFile(excelFileStream, ExcelUploadController.FbmsExcelFileHeaderRowOffset);

            ExcelUploadController.DoEtlProcessingOnFbmsRecordsLoadedIntoPairedStagingTables(budgetTransferBulks, invoiceStageImports,  out int countOfCountAddedBudgets, out int countOfAddedInvoices, null);
        }

    }
}
