﻿/*-----------------------------------------------------------------------
<copyright file="BasicProjectInfoGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class CostAuthorityObligationRequestGridSpec : GridSpec<ProjectFirmaModels.Models.CostAuthorityObligationRequest>
    {
        public CostAuthorityObligationRequestGridSpec(FirmaSession currentFirmaSession, bool isInDraft, List<int> costAuthorityIDListOnObligation)
        {
            Add("Delete"
                , x => !isInDraft ? new HtmlString("<span style='cursor: not-allowed;' class='glyphicon glyphicon-trash blue disabled' title='You cannot delete this because it is in draft'><span class='sr-only'>You cannot delete this because it is in draft</span></span>")  
                    : costAuthorityIDListOnObligation.Contains(x.CostAuthorityID) ? new HtmlString("<span style='cursor: not-allowed;' class='glyphicon glyphicon-trash blue disabled' title='You cannot delete this because it is on the Obligation'><span class='sr-only'>You cannot delete this because it is on the Obligation</span></span>")
                    : ModalDialogFormHelper.MakeDeleteIconLink(x.GetDeleteUrl(), "Delete This Projected Obligation", true)
                , 30
                , AgGridColumnFilterType.None);
            Add("Edit", x => ModalDialogFormHelper.MakeEditIconLink(x.GetEditUrl(), "Edit Projected Obligation", true), 30, AgGridColumnFilterType.None);
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString("CAWBS"), x => x.CostAuthority.CostAuthorityWorkBreakdownStructure, 300, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.AccountStructureDescription.ToType().ToGridHeaderString(), x => x.CostAuthority.AccountStructureDescription, 300, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectedObligation.ToType().ToGridHeaderString(), x => x.ProjectedObligation, 300, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.BudgetObjectCode.ToType().ToGridHeaderString(), a => a.BudgetObjectCode?.GetDisplayName(), 120, AgGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.RecipientOrganization.ToType().ToGridHeaderString(), a => a.RecipientOrganization?.GetDisplayName(), 120, AgGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.TechnicalRepresentative.ToType().ToGridHeaderString(), a => a.TechnicalRepresentativePerson?.GetFullNameFirstLast(), 120, AgGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.CostAuthorityObligationRequestNote.ToType().ToGridHeaderString("Notes"), x => x.CostAuthorityObligationRequestNote, 300, AgGridColumnFilterType.Text);
            
        }
    }
}
