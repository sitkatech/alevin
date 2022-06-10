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

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class EditObligationRequestViewData : FirmaViewData
    {
        public IEnumerable<SelectListItem> Agreements { get; }
        public IEnumerable<SelectListItem> ContractTypes { get; }
        public IEnumerable<SelectListItem> ObligationRequestStatuses { get; }
        public IEnumerable<SelectListItem> FundingPriorities { get; }
        public AgreementJsonList AgreementJsonList { get; }
        public ViewPageContentViewData ProjectStatusFirmaPage { get; }
        public int ModNumber { get; }


        public EditObligationRequestViewData(
             ProjectFirmaModels.Models.FirmaPage projectStatusFirmaPage
            , FirmaSession currentFirmaSession
            , List<ProjectFirmaModels.Models.Agreement> allAgreements
            , List<ContractType> allContractTypes
            , List<ObligationRequestStatus> allObligationRequestStatuses
            , List<ObligationRequestFundingPriority> allFundingPriorities
        ) : base(currentFirmaSession)
        {
            Agreements = allAgreements.OrderBy(x => x.AgreementNumber).ToSelectListWithEmptyFirstRow(x => x.AgreementID.ToString(), x => $"{x.AgreementNumber} - {x.Organization?.GetDisplayName()}");
            ContractTypes = allContractTypes.OrderBy(x => x.ContractTypeDisplayName).ToSelectListWithEmptyFirstRow(x => x.ContractTypeID.ToString(), x => x.ContractTypeDisplayName);
            ObligationRequestStatuses = allObligationRequestStatuses.OrderBy(x => x.ObligationRequestStatusID).ToSelectListWithEmptyFirstRow(x => x.ObligationRequestStatusID.ToString(), x => x.ObligationRequestStatusDisplayName);
            FundingPriorities = allFundingPriorities.OrderBy(x => x.ObligationRequestFundingPriorityID).ToSelectListWithEmptyFirstRow(x => x.ObligationRequestFundingPriorityID.ToString(), x => x.ObligationRequestFundingPriorityDisplayName);
            AgreementJsonList = new AgreementJsonList(allAgreements.Select(x => new AgreementJson(x)).ToList());
            ProjectStatusFirmaPage = new ViewPageContentViewData(projectStatusFirmaPage, currentFirmaSession);
        }
    }
}
