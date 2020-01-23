/*-----------------------------------------------------------------------
<copyright file="BasicProjectInfoGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public class CostAuthorityAgreementRequestGridSpec : GridSpec<ProjectFirmaModels.Models.ReclamationCostAuthorityAgreementRequest>
    {
        public CostAuthorityAgreementRequestGridSpec(FirmaSession currentFirmaSession, bool isInDraft, List<int> costAuthorityIDListOnAgreement)
        {
            Add(string.Empty
                , x => !isInDraft ? new HtmlString("<span style='cursor: not-allowed;' class='glyphicon glyphicon-trash blue disabled' title='You cannot delete this because it is in draft'><span class='sr-only'>You cannot delete this because it is in draft</span></span>")  
                    : costAuthorityIDListOnAgreement.Contains(x.CostAuthorityID) ? new HtmlString("<span style='cursor: not-allowed;' class='glyphicon glyphicon-trash blue disabled' title='You cannot delete this because it is on the Agreement'><span class='sr-only'>You cannot delete this because it is on the Agreement</span></span>")
                    : ModalDialogFormHelper.MakeDeleteIconLink(x.GetDeleteUrl(), "Delete This Projected Obligation", true)
                , 30
                , DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => ModalDialogFormHelper.MakeEditIconLink(x.GetEditUrl(), "Edit Projected Obligation", true), 30, DhtmlxGridColumnFilterType.None);
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString("CAWBS"), x => x.CostAuthority.CostAuthorityWorkBreakdownStructure, 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.AccountStructureDescription.ToType().ToGridHeaderString(), x => x.CostAuthority.AccountStructureDescription, 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectedObligation.ToType().ToGridHeaderString(), x => x.ProjectedObligation, 300, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.CostAuthorityAgreementRequestNote.ToType().ToGridHeaderString("Notes"), x => x.ReclamationCostAuthorityAgreementRequestNote, 300, DhtmlxGridColumnFilterType.Text);
            
        }
    }
}
