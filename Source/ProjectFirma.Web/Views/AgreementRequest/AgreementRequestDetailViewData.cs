﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.CostAuthority;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.TextControls;

//using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public class AgreementRequestDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.ReclamationAgreementRequest ReclamationAgreementRequest { get; }

        public string IndexUrl { get; }
        public string EditRequisitionInformationUrl { get; }
        public bool UserCanEditRequisitionInformation { get; }
        public bool UserCanInteractWithSubmissionNotes { get; }
        public EntityNotesViewData AgreementRequestNotesViewData { get; }

        public AgreementRequestDetailViewData(FirmaSession currentFirmaSession,
            ReclamationAgreementRequest reclamationAgreementRequest, bool userCanInteractWithSubmissionNotes,
            EntityNotesViewData agreementRequestNotesViewData) : base(currentFirmaSession)
        {
            PageTitle = $"Agreement Request: {reclamationAgreementRequest.ReclamationAgreementRequestID.ToString("D4")}";
            EntityName = "Agreement Request Detail";
            ReclamationAgreementRequest = reclamationAgreementRequest;
            IndexUrl = SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(c => c.AgreementRequestIndex());
            EditRequisitionInformationUrl = SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(c => c.EditRequisitionInformation(reclamationAgreementRequest));
            UserCanEditRequisitionInformation = new AgreementRequestCreateFeature().HasPermissionByFirmaSession(currentFirmaSession);
            UserCanInteractWithSubmissionNotes = userCanInteractWithSubmissionNotes;
            AgreementRequestNotesViewData = agreementRequestNotesViewData;
        }

    }
}