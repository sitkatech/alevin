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
    public class EditCostAuthorityAgreementRequestsViewData : FirmaViewData
    {
        public IEnumerable<SelectListItem> CostAuthorities { get; }
        public CostAuthorityJsonList CostAuthorityJsonList { get; }
        public ViewPageContentViewData ProjectStatusFirmaPage { get; }
        

        public EditCostAuthorityAgreementRequestsViewData(
             ProjectFirmaModels.Models.FirmaPage projectStatusFirmaPage
            , FirmaSession currentFirmaSession
            , List<ReclamationCostAuthority> allCostAuthorities
            , ReclamationAgreementRequest reclamationAgreementRequest
            ) : base(currentFirmaSession)
        {
            var costAuthoritiesToOmit =
                reclamationAgreementRequest.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest
                    .Select(x => x.CostAuthorityID);
            var reclamationCostAuthoritiesToUse = allCostAuthorities
                .Where(x => !costAuthoritiesToOmit.Contains(x.ReclamationCostAuthorityID)).ToList();
            CostAuthorities = reclamationCostAuthoritiesToUse
                .OrderBy(x => x.CostAuthorityWorkBreakdownStructure)
                .ToSelectListWithEmptyFirstRow(x => x.ReclamationCostAuthorityID.ToString(), x => x.CostAuthorityWorkBreakdownStructure, "Select CAWBS");
            CostAuthorityJsonList = new CostAuthorityJsonList(reclamationCostAuthoritiesToUse.Select(x => new CostAuthorityJson(x)).ToList());
            ProjectStatusFirmaPage = new ViewPageContentViewData(projectStatusFirmaPage, currentFirmaSession);
        }
    }


    public class CostAuthorityJsonList
    {
        public Dictionary<int, CostAuthorityJson> CostAuthorityJsons { get; set; }

        public CostAuthorityJsonList(List<CostAuthorityJson> costAuthorityJson)
        {
            CostAuthorityJsons = costAuthorityJson.ToDictionary(x => x.ReclamationCostAuthorityID, x => x);
        }
    }

    public class CostAuthorityJson
    {
        public int ReclamationCostAuthorityID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public string AccountStructureDescription { get; set; }
        public string Note { get; set; }
        public Money? ProjectedObligation { get; set; }

        public bool PreventDelete { get; set; }

        public CostAuthorityJson()
        {
        }


        public CostAuthorityJson(ReclamationCostAuthority reclamationCostAuthority)
        {
            ReclamationCostAuthorityID = reclamationCostAuthority.ReclamationCostAuthorityID;
            CostAuthorityWorkBreakdownStructure = reclamationCostAuthority.CostAuthorityWorkBreakdownStructure;
            AccountStructureDescription = reclamationCostAuthority.AccountStructureDescription;

        }

        public CostAuthorityJson(ReclamationCostAuthorityAgreementRequest costAuthorityAgreementRequest)
        {
            ReclamationCostAuthorityID = costAuthorityAgreementRequest.CostAuthority.ReclamationCostAuthorityID;
            CostAuthorityWorkBreakdownStructure = costAuthorityAgreementRequest.CostAuthority.CostAuthorityWorkBreakdownStructure;
            AccountStructureDescription = costAuthorityAgreementRequest.CostAuthority.AccountStructureDescription;
            Note = costAuthorityAgreementRequest.ReclamationCostAuthorityAgreementRequestNote;
            ProjectedObligation = costAuthorityAgreementRequest.ProjectedObligation;

        }
    }

}
