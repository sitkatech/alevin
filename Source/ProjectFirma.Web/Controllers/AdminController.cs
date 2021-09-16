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

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Admin;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using Toad.WebInstaller;
using Toad.WebInstaller.Database.DatabaseUtil;

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



        //[FirmaAdminFeature]
        //public ViewResult DownloadServerLogs()
        //{
        //    var viewData = new DownloadServerLogsViewData(CurrentPerson);
        //    var viewModel = new ExportSqlDataViewModel();
        //    return RazorView<DownloadServerLogs, DownloadServerLogsViewData, ExportSqlDataViewModel>(viewData, viewModel);
        //}

        //[FirmaAdminFeature]
        //[HttpPost]
        //public FileStreamResult DownloadServerLogs(ExportSqlDataViewModel viewModel)
        //{
        //    var logsZipFile = DirectoryZipper.CreateZipPackage(ToadWebConfiguration.LogFileFolder);
        //    var dateTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        //    var fileDownloadName = string.Format("web_server_logs_{0}.zip", dateTimeStamp);
        //    const string fileMimeType = "application/zip";
        //    var file = File(logsZipFile, fileMimeType, fileDownloadName);
        //    return file;
        //}

        [FirmaAdminFeature]
        public ViewResult ExportSqlData()
        {
            var viewData = new ExportSqlDataViewData(CurrentFirmaSession);
            var viewModel = new ExportSqlDataViewModel();
            return RazorView<ExportSqlData, ExportSqlDataViewData, ExportSqlDataViewModel>(viewData, viewModel);
        }

        [FirmaAdminFeature]
        [HttpPost]
        public FileContentResult ExportSqlData(ExportSqlDataViewModel viewModel)
        {
            var dbServerName = HttpRequestStorage.DatabaseEntities.Database.Connection.DataSource;
            var dbName = HttpRequestStorage.DatabaseEntities.Database.Connection.Database;
            var backupViaSqlFileCreator = new DatabaseBackupViaSqlFileCreator(dbServerName, dbName);
            var sqlBackup = backupViaSqlFileCreator.CreateSqlBackup();
            var preambleByteOrderMarkToIndicateFileIsUtf16 = Encoding.Unicode.GetPreamble();
            var fileContentsAsBytes = preambleByteOrderMarkToIndicateFileIsUtf16.Concat(Encoding.Unicode.GetBytes(sqlBackup)).ToArray();
            var dateTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            return File(fileContentsAsBytes, "application/sql; charset=utf-16", string.Format("tdrreportingbackup_{0}.sql", dateTimeStamp));
        }

        [FirmaAdminFeature]
        public ViewResult UpdateSite()
        {
            var viewData = new UpdateSiteViewData(CurrentFirmaSession);
            var viewModel = new UpdateSiteViewModel();
            return RazorView<UpdateSite, UpdateSiteViewData, UpdateSiteViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult UpdateSite(UpdateSiteViewModel viewModel)
        {
            var outputMessages = new List<string>();
            Action<string> logFunction = outputMessages.Add;

            string statusString = "Unknown";

            if (ModelState.IsValid)
            {
                var webSiteDir = new DirectoryInfo(HttpContext.Server.MapPath("/").TrimEnd('\\'));

                var dbServerName = HttpRequestStorage.DatabaseEntities.Database.Connection.DataSource;
                var dbName = HttpRequestStorage.DatabaseEntities.Database.Connection.Database;

                var installer = new WebAppInstallerUtility(webSiteDir, viewModel.PostedFileBase, dbName, dbServerName, logFunction);

                try
                {
                    // Do the complete installation process
                    installer.DoInstallation();
                    // Only mark success here
                    statusString = "Success!";
                }
                catch (Exception e)
                {
                    logFunction(e.ToString());
                    statusString = "Failure";
                }
            }

            var outputMessagesLines = string.Join("\r\n", outputMessages);

            // We have to resort to a super simple, primitive view, otherwise most every deploy will throw a false alarm 
            // about a crash only related to changing the views in the middle of a request. These are meaningless, but very disturbing.
            // 
            // Add a little html formatting, otherwise this is totally hard to read
            string backButton = SitkaRoute<AdminController>.BuildLinkFromExpression(c => c.UpdateSite(), "Back to Update Site");

            string htmlWrapper = string.Format(@"
<html>
<body>
<h1>{0}</h1>
{1}
<pre>
{2}
</pre>
</body>
</html>", statusString, backButton, Server.HtmlEncode(outputMessagesLines));

            return Content(htmlWrapper, "text/html");
        }
        [FirmaAdminFeature]
        public ViewResult RunSqlScript()
        {
            var viewData = new RunSqlScriptViewData(CurrentFirmaSession);
            var viewModel = new RunSqlScriptViewModel();
            return RazorView<RunSqlScript, RunSqlScriptViewData, RunSqlScriptViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult RunSqlScript(RunSqlScriptViewModel viewModel)
        {
            var outputMessages = new List<string>();
            Action<string> logFunction = outputMessages.Add;

            string statusString = "Unknown";

            if (ModelState.IsValid)
            {
                var webSiteDir = new DirectoryInfo(HttpContext.Server.MapPath("/").TrimEnd('\\'));

                var dbServerName = HttpRequestStorage.DatabaseEntities.Database.Connection.DataSource;
                var dbName = HttpRequestStorage.DatabaseEntities.Database.Connection.Database;

                var installer = new WebAppInstallerUtility(webSiteDir, viewModel.PostedFileBase, dbName, dbServerName, logFunction);

                try
                {
                    // Do the complete installation process
                    installer.DoInstallation();
                    // Only mark success here
                    statusString = "Success!";
                }
                catch (Exception e)
                {
                    logFunction(e.ToString());
                    statusString = "Failure";
                }
            }

            var outputMessagesLines = string.Join("\r\n", outputMessages);

            // We have to resort to a super simple, primitive view, otherwise most every deploy will throw a false alarm 
            // about a crash only related to changing the views in the middle of a request. These are meaningless, but very disturbing.
            // 
            // Add a little html formatting, otherwise this is totally hard to read
            string backButton = SitkaRoute<AdminController>.BuildLinkFromExpression(c => c.RunSqlScript(), "Back to Update Site");

            string htmlWrapper = string.Format(@"
<html>
<body>
<h1>{0}</h1>
{1}
<pre>
{2}
</pre>
</body>
</html>", statusString, backButton, Server.HtmlEncode(outputMessagesLines));

            return Content(htmlWrapper, "text/html");
        }

    }
}
