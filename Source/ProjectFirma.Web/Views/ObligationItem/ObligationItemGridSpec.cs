﻿using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationItem
{
    public class ObligationItemGridSpec : GridSpec<ProjectFirmaModels.Models.ObligationItem>
    {
        public ObligationItemGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = FieldDefinitionEnum.ObligationItem.ToType().GetFieldDefinitionLabel();
            ObjectNamePlural = FieldDefinitionEnum.ObligationItem.ToType().GetFieldDefinitionLabelPluralized();
            SaveFiltersInCookie = true;

            Add("Obligation Number", oi => UrlTemplate.MakeHrefString(oi.ObligationNumber.GetDetailUrl(), oi.ObligationNumber.ObligationNumberKey), 150, DhtmlxGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.ObligationItem.ToType().FieldDefinitionDisplayName} Key", oi => UrlTemplate.MakeHrefString(oi.GetDetailUrl() ,oi.ObligationItemKey), 80, DhtmlxGridColumnFilterType.Numeric);
            Add("Vendor", oi => oi.Vendor.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
        }


    }
}