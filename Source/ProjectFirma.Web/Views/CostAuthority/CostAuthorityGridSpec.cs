/*-----------------------------------------------------------------------
<copyright file="CostAuthorityGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.CostAuthority
{
    public class CostAuthorityGridSpec : GridSpec<ProjectFirmaModels.Models.ReclamationCostAuthority>
    {
        public CostAuthorityGridSpec(FirmaSession currentFirmaSession)
        {
            // Cost Authority Work Breakdown Structure
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString(), a => a.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 125, DhtmlxGridColumnFilterType.Text);
            // Cost Authority Number
            Add("Cost Authority Number", a => a.CostAuthorityNumber, 125, DhtmlxGridColumnFilterType.Text);
            // Projects
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderStringPlural(), ca => GetProjectHrefsString(ca), 250, DhtmlxGridColumnFilterType.Text);
            // Agreements
            Add(FieldDefinitionEnum.Agreement.ToType().ToGridHeaderStringPlural(), ca => GetAgreementsHrefsString(ca), 100, DhtmlxGridColumnFilterType.Text);
            // Description
            Add("Account Structure Description", ca => ca.AccountStructureDescription, 200, DhtmlxGridColumnFilterType.Text);
            // Job Number
            Add("Job Number", ca => ca.JobNumber, 100, DhtmlxGridColumnFilterType.Text);
            // Authority
            Add("Authority", ca => ca.Authority, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }

        private static HtmlString GetAgreementsHrefsString(ReclamationCostAuthority reclamationCostAuthority)
        {
            List<ProjectFirmaModels.Models.Agreement> agreements = reclamationCostAuthority.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.Agreement).ToList();
            List<HtmlString> agreementsHrefHtmlStrings = agreements.Select(a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.AgreementNumber)).ToList();

            var commaDelimitedHrefStrings = new HtmlString(string.Join(", ", agreementsHrefHtmlStrings));
            return commaDelimitedHrefStrings;
        }


        private static HtmlString GetProjectHrefsString(ReclamationCostAuthority reclamationCostAuthority)
        {
            var projects = reclamationCostAuthority.ReclamationCostAuthorityProjects.Select(rcap => rcap.Project)
                .ToList();
            List<HtmlString> projectsHrefHtmlStrings = projects.Select(p => UrlTemplate.MakeHrefString(p.GetDetailUrl(), p.GetDisplayName())).ToList();

            var commaDelimitedHrefStrings =  new HtmlString(string.Join(", ", projectsHrefHtmlStrings));
            return commaDelimitedHrefStrings;
        }
    }
}