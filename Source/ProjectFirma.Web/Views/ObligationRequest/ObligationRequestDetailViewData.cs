/*-----------------------------------------------------------------------
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class ObligationRequestDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.ObligationRequest ObligationRequest { get; }

        public string CostAuthorityObligationRequestGridName { get; }
        public CostAuthorityObligationRequestGridSpec CostAuthorityObligationRequestGridSpec { get; }
        public string CostAuthorityObligationRequestGridDataUrl { get; }

        public string IndexUrl { get; }
        public string EditObligationRequestBasicsUrl { get; }
        public string EditRequisitionInformationUrl { get; }
        public bool UserCanEditObligationRequest { get; }
        public bool UserCanEditRequisitionInformation { get; }
        public bool UserCanInteractWithSubmissionNotes { get; }
        public EntityNotesViewData ObligationRequestNotesViewData { get; }

        public bool ShowPotentialMatches { get; }
        public List<CostAuthorityObligationRequestPotentialObligationNumberMatch> PotentialMatches { get; }
        public string PotentialMatchesGridName { get; }
        public CostAuthorityObligationRequestPotentialObligationNumberMatchGridSpec PotentialMatchesGridSpec { get; }
        public string PotentialMatchesGridDataUrl { get; }

        public ObligationRequestDetailViewData(FirmaSession currentFirmaSession,
                                                ProjectFirmaModels.Models.ObligationRequest obligationRequest,
                                                bool userCanInteractWithSubmissionNotes,
                                                EntityNotesViewData obligationRequestNotesViewData) : base(currentFirmaSession)
        {
            PageTitle = $"Obligation Request: {obligationRequest.ObligationRequestID.ToString("D4")}";
            EntityName = "Obligation Request Detail";
            ObligationRequest = obligationRequest;
            IndexUrl = SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(c => c.ObligationRequestIndex());
            EditObligationRequestBasicsUrl = SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(c => c.Edit(obligationRequest));
            EditRequisitionInformationUrl = SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(c => c.EditRequisitionInformation(obligationRequest));
            UserCanEditObligationRequest = new ObligationRequestCreateFeature().HasPermissionByFirmaSession(currentFirmaSession);
            UserCanEditRequisitionInformation = new ObligationRequestCreateFeature().HasPermissionByFirmaSession(currentFirmaSession);
            UserCanInteractWithSubmissionNotes = userCanInteractWithSubmissionNotes;
            ObligationRequestNotesViewData = obligationRequestNotesViewData;

            // Potential Matches
            PotentialMatches = obligationRequest.CostAuthorityObligationRequests
                .SelectMany(x => x.CostAuthorityObligationRequestPotentialObligationNumberMatches).ToList();
            PotentialMatchesGridName = "potentialMatchesGrid";
            PotentialMatchesGridSpec = new CostAuthorityObligationRequestPotentialObligationNumberMatchGridSpec(currentFirmaSession);
            PotentialMatchesGridDataUrl = SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(cac => cac.PotentialObligationRequestMatchesJsonData(obligationRequest));
            ShowPotentialMatches = obligationRequest.ObligationNumber == null && 
                                   obligationRequest.Agreement == null &&
                                   PotentialMatches.Any();

                                   var costAuthorityIDList = obligationRequest.Agreement != null
                ? obligationRequest.Agreement.AgreementCostAuthorities
                    .Select(x => x.CostAuthorityID).ToList()
                : new List<int>();

            CostAuthorityObligationRequestGridName = "costAuthorityObligationRequestGrid";
            CostAuthorityObligationRequestGridSpec = new CostAuthorityObligationRequestGridSpec(CurrentFirmaSession, obligationRequest.ObligationRequestStatus == ObligationRequestStatus.Draft, costAuthorityIDList)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} associated with {FieldDefinitionEnum.ObligationRequest.ToType().GetFieldDefinitionLabel()} {obligationRequest.ObligationRequestID.ToString("D4")}",
                ObjectNamePlural = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabelPluralized()} associated with {FieldDefinitionEnum.ObligationRequest.ToType().GetFieldDefinitionLabel()} {obligationRequest.ObligationRequestID.ToString("D4")}",
                SaveFiltersInCookie = true
            };
            CostAuthorityObligationRequestGridDataUrl = SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(cac => cac.CostAuthorityObligationRequestsJsonData(obligationRequest));
        }

    }
}
