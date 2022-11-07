/*-----------------------------------------------------------------------
<copyright file="ObligationItemDetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common.DhtmlWrappers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirma.Web.Views.ObligationItem;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationItem
{
    public class ObligationItemDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.ObligationItem ObligationItem { get; }
        public string ObligationItemIndexUrl { get; }

        public ContractualInvoiceGridSpec ContractualInvoiceGridSpec { get; }
        public string ContractualInvoiceGridName { get; }
        public string ContractualInvoiceGridDataUrl { get; }


        public ObligationItemDetailViewData(FirmaSession currentFirmaSession,
                                        ProjectFirmaModels.Models.ObligationItem obligationItem) : base(currentFirmaSession)
        {
            PageTitle = $"{FieldDefinitionEnum.ObligationItem.ToType().FieldDefinitionDisplayName}: {obligationItem.GetDisplayName()}";
            EntityName = $"{FieldDefinitionEnum.ObligationItem.ToType().FieldDefinitionDisplayName} Detail";
            
            ObligationItem = obligationItem;
            ObligationItemIndexUrl = SitkaRoute<ObligationItemController>.BuildUrlFromExpression(c => c.ObligationItemIndex());

            ContractualInvoiceGridName = "contractualInvoiceGrid";
            ContractualInvoiceGridSpec = new ContractualInvoiceGridSpec(currentFirmaSession);
            ContractualInvoiceGridDataUrl = SitkaRoute<ObligationController>.BuildUrlFromExpression(oc => oc.ContractualObligationByObligationItemGridJsonData(ObligationItem));
        }


    }
}
