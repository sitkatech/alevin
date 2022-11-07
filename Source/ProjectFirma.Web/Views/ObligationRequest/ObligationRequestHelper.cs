/*-----------------------------------------------------------------------
<copyright file="ProjectCreateHelper.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.Web;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public static class ObligationRequestHelper
    {
        private static readonly string NewObligationRequestUrl =
            SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(x => x.New());

        private static string GetAddNewObligationRequestText() =>
            $"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} Create a new {FieldDefinitionEnum.ObligationRequest.ToType().GetFieldDefinitionLabel()}";


        public static HtmlString AddObligationRequestButton()
        {
            return ModalDialogFormHelper.ModalDialogFormLink(GetAddNewObligationRequestText(), NewObligationRequestUrl,
                $"Add a {FieldDefinitionEnum.ObligationRequest.ToType().GetFieldDefinitionLabel()}", 900, "Save",
                "Cancel",
                new List<string> {"btn", "btn-firma"}, null, null);
        }


        private static string EditCostAuthorityObligationRequestsUrl(this ProjectFirmaModels.Models.ObligationRequest obligationRequest)
        {
            return SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(x => x.EditCostAuthorityObligationRequests(obligationRequest.PrimaryKey));
        }

        private static string MakeProjectNewObligationsText() =>
            $"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} Create New Obligation Item Budget Projections";

        public static HtmlString EditCostAuthorityObligationRequestsButton(this ProjectFirmaModels.Models.ObligationRequest obligationRequest)
        {
            var disabledState = obligationRequest.ObligationRequestStatus != ObligationRequestStatus.Draft ? ModalDialogFormHelper.DisabledState.Disabled : ModalDialogFormHelper.DisabledState.NotDisabled;
            var disabledHoverText = disabledState == ModalDialogFormHelper.DisabledState.Disabled
                ? "You cannot Add Obligation Item Budget Projections because this Obligation Request is not in a Draft state."
                : null;
            return ModalDialogFormHelper.ModalDialogFormLink(MakeProjectNewObligationsText(), EditCostAuthorityObligationRequestsUrl(obligationRequest),
                $"Create new Obligation Item Budget Projections", 1100, "Save",
                "Cancel",
                new List<string> { "btn", "btn-firma" }, null, null, disabledState, disabledHoverText);
        }


    }

}