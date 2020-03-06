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
        public IEnumerable<SelectListItem> Agreements { get; }
        public IEnumerable<SelectListItem> ContractTypes { get; }
        public IEnumerable<SelectListItem> AgreementRequestStatuses { get; }
        public IEnumerable<SelectListItem> FundingPriorities { get; }
        public IEnumerable<SelectListItem> Organizations { get; }
        public IEnumerable<SelectListItem> People { get; }

        public AgreementJsonList AgreementJsonList { get; }
        public ViewPageContentViewData ProjectStatusFirmaPage { get; }
        

        public EditAgreementRequestViewData(
             ProjectFirmaModels.Models.FirmaPage projectStatusFirmaPage
            , FirmaSession currentFirmaSession
            , List<ProjectFirmaModels.Models.Agreement> allAgreements
            , List<ContractType> allContractTypes
            , List<AgreementRequestStatus> allAgreementRequestStatuses
            , List<AgreementRequestFundingPriority> allFundingPriorities
            , List<ProjectFirmaModels.Models.Organization> allOrganizations
            , List<Person> allPeople) : base(currentFirmaSession)
        {
            Agreements = allAgreements.OrderBy(x => x.AgreementNumber).ToSelectListWithEmptyFirstRow(x => x.AgreementID.ToString(), x => $"{x.AgreementNumber} - {x.Organization?.GetDisplayName()}");
            ContractTypes = allContractTypes.OrderBy(x => x.ContractTypeDisplayName).ToSelectListWithEmptyFirstRow(x => x.ContractTypeID.ToString(), x => x.ContractTypeDisplayName);
            AgreementRequestStatuses = allAgreementRequestStatuses.OrderBy(x => x.AgreementRequestStatusID).ToSelectListWithEmptyFirstRow(x => x.AgreementRequestStatusID.ToString(), x => x.AgreementRequestStatusDisplayName);
            FundingPriorities = allFundingPriorities.OrderBy(x => x.AgreementRequestFundingPriorityID).ToSelectListWithEmptyFirstRow(x => x.AgreementRequestFundingPriorityID.ToString(), x => x.AgreementRequestFundingPriorityDisplayName);
            Organizations = allOrganizations.OrderBy(x => x.GetDisplayName()).ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(), x => x.GetDisplayName());
            People = allPeople.OrderBy(x => x.GetFullNameFirstLast()).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(), x => x.GetFullNameFirstLast());
            AgreementJsonList = new AgreementJsonList(allAgreements.Select(x => new AgreementJson(x)).ToList());
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

        public AgreementRequestStatusJson(ProjectFirmaModels.Models.AgreementRequestStatus agreementRequestStatus)
        {
            ReclamationAgreementRequestStatusID = agreementRequestStatus.AgreementRequestStatusID;
            ReclamationAgreementRequestStatusDisplayName = agreementRequestStatus.AgreementRequestStatusDisplayName;
        }
    }

    public class AgreementJsonList
    {
        public Dictionary<int, AgreementJson> AgreementJsons { get; set; }

        public AgreementJsonList(List<AgreementJson> agreementJsons)
        {
            AgreementJsons = agreementJsons.ToDictionary(x => x.ReclamationAgreementID, x => x);
        }
    }

    public class AgreementJson
    {
        public int ReclamationAgreementID { get; set; }
        public int? TechnicalRepresentativeID { get; set; }
        public int? OrganizationID { get; set; }


        public AgreementJson(ProjectFirmaModels.Models.Agreement agreement)
        {
            TechnicalRepresentativeID = null;
            TechnicalRepresentativeID = agreement.TechnicalRepresentative.HasValue ? (int)agreement.TechnicalRepresentative.Value : TechnicalRepresentativeID;
            OrganizationID = agreement.OrganizationID;
            ReclamationAgreementID = agreement.AgreementID;
        }
    }
}
