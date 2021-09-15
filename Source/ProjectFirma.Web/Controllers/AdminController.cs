/*-----------------------------------------------------------------------
<copyright file="AdminController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.IO.Compression;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Admin;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Controllers
{
    public class AdminController : FirmaBaseController
    {
        [HttpGet]
        [FirmaAdminFeature]
        public ActionResult AdminDetail()
        {
            var viewData = new AdminDetailViewData(CurrentFirmaSession);
            return RazorView<AdminDetail, AdminDetailViewData>(viewData);
        }

        [HttpPost]
        [FirmaAdminFeature]
        public FileContentResult DownloadWebLogFileZipArchive()
        {
            var webLogZipFileName = "WebLogZipFile.zip";
            using (var tempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(webLogZipFileName))
            {
                ZipFile.CreateFromDirectory(FirmaWebConfiguration.LogFileFolder.FullName, tempFile.FileInfo.FullName);
                var zipFileBytes = System.IO.File.ReadAllBytes(tempFile.FileInfo.FullName);
                return File(zipFileBytes, "application/zip", webLogZipFileName);
            }
        }
    }
}
