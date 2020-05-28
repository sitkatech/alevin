﻿using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.FundingSourceCustomAttributeType
{
    public class ManageViewData : FirmaViewData
    {
        public FundingSourceCustomAttributeTypeGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string NewFundingSourceCustomAttributeTypeUrl { get; }
        public bool HasManagePermissions { get; }

        public ManageViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage neptunePage)
            : base(currentFirmaSession, neptunePage)
        {
            EntityName = "Attribute Type";
            PageTitle = $"{FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()}";

            NewFundingSourceCustomAttributeTypeUrl = SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(t => t.New());
            GridSpec = new FundingSourceCustomAttributeTypeGridSpec()
            {
                ObjectNameSingular = "Attribute Type",
                ObjectNamePlural = "Attribute Types",
                SaveFiltersInCookie = true
        };

            GridName = "fundingSourceCustomAttributeTypeGrid";
            GridDataUrl = SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(tc => tc.FundingSourceCustomAttributeTypeGridJsonData());

            HasManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }
    }
}
