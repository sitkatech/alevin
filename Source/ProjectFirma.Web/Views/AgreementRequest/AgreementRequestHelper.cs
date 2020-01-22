/*-----------------------------------------------------------------------
<copyright file="ProjectCreateHelper.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public static class AgreementRequestHelper
    {
        private static readonly string NewAgreementRequestUrl =
            SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(x => x.New());

        private static string GetAddNewAgreementRequestText() =>
            $"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} Create a new {FieldDefinitionEnum.AgreementRequest.ToType().GetFieldDefinitionLabel()}";


        public static HtmlString AddAgreementRequestButton()
        {
            return ModalDialogFormHelper.ModalDialogFormLink(GetAddNewAgreementRequestText(), NewAgreementRequestUrl,
                $"Add a {FieldDefinitionEnum.AgreementRequest.ToType().GetFieldDefinitionLabel()}", 900, "Save",
                "Cancel",
                new List<string> {"btn", "btn-firma"}, null, null);
        }


        private static string EditCostAuthorityAgreementRequestsUrl(this ReclamationAgreementRequest reclamationAgreementRequest)
        {
            return SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(x => x.EditCostAuthorityAgreementRequests(reclamationAgreementRequest.PrimaryKey));
        }

        private static string MakeProjectNewObligationsText() =>
            $"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} Project new Obligations";

        public static HtmlString EditCostAuthorityAgreementRequestsButton(this ReclamationAgreementRequest reclamationAgreementRequest)
        {
            return ModalDialogFormHelper.ModalDialogFormLink(MakeProjectNewObligationsText(), EditCostAuthorityAgreementRequestsUrl(reclamationAgreementRequest),
                $"Project new Obligations by CAWBS", 900, "Save",
                "Cancel",
                new List<string> { "btn", "btn-firma" }, null, null);
        }


    }

}