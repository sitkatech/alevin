/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationGridSpec : GridSpec<ObligationNumber>
    {
        public ObligationGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "Obligation";
            ObjectNamePlural = "Obligations";
            SaveFiltersInCookie = true;

            //// ObligationNumber
            //Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), ob => ob.ObligationNumberKey, 100, DhtmlxGridColumnFilterType.Text);
            // ObligationNumber as link
            Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), ob => UrlTemplate.MakeHrefString(ob?.GetDetailUrl(), ob?.ObligationNumberKey), 100, DhtmlxGridColumnFilterType.Text);
            // Agreement
            Add(FieldDefinitionEnum.Agreement.ToType().ToGridHeaderStringPlural(), ra => UrlTemplate.MakeHrefString(ra.ReclamationAgreement?.GetDetailUrl(), ra.ReclamationAgreement?.GetDisplayName()), 300, DhtmlxGridColumnFilterType.Html);
        }
    }
}