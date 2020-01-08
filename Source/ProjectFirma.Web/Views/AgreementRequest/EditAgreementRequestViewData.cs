/*-----------------------------------------------------------------------
<copyright file="EditNoteViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public class EditAgreementRequestViewData : FirmaViewData
    {

        public IEnumerable<SelectListItem> AgreementRequestStatuses { get; }
        public AgreementRequestStatusJsonList AgreementRequestStatusJsonList { get; }
        public ViewPageContentViewData ProjectStatusFirmaPage { get; }
        

        public EditAgreementRequestViewData(
             ProjectFirmaModels.Models.FirmaPage projectStatusFirmaPage
            , FirmaSession currentFirmaSession
            , List<ProjectFirmaModels.Models.ReclamationAgreementRequestStatus> allAgreementRequestStatuses) : base(currentFirmaSession)
        {
            AgreementRequestStatuses = allAgreementRequestStatuses.OrderBy(x => x.ReclamationAgreementRequestStatusID).ToSelectListWithEmptyFirstRow(x => x.ReclamationAgreementRequestStatusID.ToString(), x => x.AgreementRequestStatusDisplayName);
            AgreementRequestStatusJsonList = new AgreementRequestStatusJsonList(allAgreementRequestStatuses.Select(x => new AgreementRequestStatusJson(x)).ToList());
            ProjectStatusFirmaPage = new ViewPageContentViewData(projectStatusFirmaPage, currentFirmaSession);
        }
    }

    public class AgreementRequestStatusJsonList
    {
        public Dictionary<int, AgreementRequestStatusJson> AgreementRequestJsons { get; set; }

        public AgreementRequestStatusJsonList(List<AgreementRequestStatusJson> agreementRequestJsons)
        {
            AgreementRequestJsons = agreementRequestJsons.ToDictionary(x => x.ReclamationAgreementRequestStatusID, x=> x);
        }
    }



    public class AgreementRequestStatusJson
    {
        public int ReclamationAgreementRequestStatusID { get; set; }
        public string ReclamationAgreementRequestStatusDisplayName { get; set; }

        public AgreementRequestStatusJson(ProjectFirmaModels.Models.ReclamationAgreementRequestStatus reclamationAgreementRequestStatus)
        {
            ReclamationAgreementRequestStatusID = reclamationAgreementRequestStatus.ReclamationAgreementRequestStatusID;
            ReclamationAgreementRequestStatusDisplayName = reclamationAgreementRequestStatus.AgreementRequestStatusDisplayName;
        }
    }
}
