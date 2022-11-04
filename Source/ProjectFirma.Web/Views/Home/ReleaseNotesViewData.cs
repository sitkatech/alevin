﻿/*-----------------------------------------------------------------------
<copyright file="ReleaseNotesViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.Home
{
    public class ReleaseNotesViewData : FirmaViewData
    {
        public List<ProjectFirmaModels.Models.ReleaseNote> Notes { get; }
        public string AddNoteUrl { get; }
        public bool CanEditNotes { get; }

        public ReleaseNotesViewData(FirmaSession currentFirmaSession,
                                    List<ProjectFirmaModels.Models.ReleaseNote> notes,
                                    string addNoteUrl,
                                    string entityName,
                                    bool canEditNotes,
                                    ProjectFirmaModels.Models.FirmaPage releaseNotesFirmaPage) :
                                    base(currentFirmaSession, releaseNotesFirmaPage)
        {
            PageTitle = "Release Notes";
            Notes = notes;
            AddNoteUrl = addNoteUrl;
            EntityName = entityName;
            CanEditNotes = canEditNotes;
        }
    }
}


