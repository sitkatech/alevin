﻿/*-----------------------------------------------------------------------
<copyright file="TestFileResource.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestFileResource
        {
            public static FileResourceInfo Create()
            {
                var fileResourceInfo = new FileResourceInfo(FileResourceMimeType.JPEG.FileResourceMimeTypeID,
                    MakeTestImagefileBaseName(),
                    ".jpg",
                    Guid.NewGuid(),
                    LoginConstants.PersonID,
                    DateTime.Now);
                fileResourceInfo.FileResourceDatas.Add(new FileResourceData(fileResourceInfo.FileResourceInfoID, new byte[2000]));
                return fileResourceInfo;
            }

            public static FileResourceInfo Create(DatabaseEntities dbContext)
            {
                var fileResourceInfo = new FileResourceInfo(FileResourceMimeType.JPEG.FileResourceMimeTypeID,
                    MakeTestImagefileBaseName(),
                    ".jpg",
                    Guid.NewGuid(),
                    LoginConstants.PersonID,
                    DateTime.Now);
                fileResourceInfo.FileResourceDatas.Add(new FileResourceData(fileResourceInfo.FileResourceInfoID, new byte[2000]));
                dbContext.AllFileResourceInfos.Add(fileResourceInfo);
                return fileResourceInfo;
            }

            private static string MakeTestImagefileBaseName()
            {
                return MakeTestName("SomeTestImageFile", FileResourceInfo.FieldLengths.OriginalBaseFilename);
            }
        }
    }
}
