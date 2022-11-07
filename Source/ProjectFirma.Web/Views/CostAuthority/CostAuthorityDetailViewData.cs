/*-----------------------------------------------------------------------
<copyright file="CostAuthorityDetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirma.Web.Views.PnBudget;
using ProjectFirma.Web.Views.Project;

//using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Agreement
{
    public class CostAuthorityDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.CostAuthority CostAuthority { get; }

        public bool IsAdmin { get; }
        public string IndexUrl { get; }
        public string AgreementIndexUrl { get; }
        public bool UserHasCostAuthorityManagePermissions { get; }
        public string BasicProjectInfoProjectGridName { get; }
        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoProjectGridDataUrl { get; }
        public string AgreementGridName { get;  }
        public AgreementGridSpec AgreementGridSpec { get; }
        public string AgreementGridDataUrl { get; }

        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForAgreement { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostAuthorityWorkBreakdownStructure { get; }

        public bool HasPnBudgetViewPermission { get; }

        public PnBudgetGridSpec PnBudgetGridSpec { get; }
        public string PnBudgetGridName { get; }
        public string PnBudgetGridDataUrl { get; }

        public bool HasObligationViewPermission { get; }

        public ContractualInvoiceGridSpec ContractualInvoiceGridSpec { get; }
        public string ContractualInvoiceGridName { get; }
        public string ContractualInvoiceGridDataUrl { get; }

        /*
        public ObligationItemBudgetGridSpec ObligationItemBudgetGridSpec { get; }
        public string ObligationItemBudgetGridName { get; }
        public string ObligationItemBudgetGridDataUrl { get; }
        */

        public CostAuthorityDetailViewData(FirmaSession currentFirmaSession,
                                           ProjectFirmaModels.Models.CostAuthority costAuthority) : base(currentFirmaSession)
        {
            CostAuthority = costAuthority;

            PageTitle = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()}: {costAuthority.CostAuthorityWorkBreakdownStructure}";
            EntityName = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} Detail";

            UserHasCostAuthorityManagePermissions = new CostAuthorityManageFeature().HasPermissionByPerson(CurrentPerson);
            IsAdmin = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            IndexUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(ca => ca.CostAuthorityIndex());
            AgreementIndexUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(ac => ac.AgreementIndex());

            FieldDefinitionForAgreement = FieldDefinitionEnum.Agreement.ToType();
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForCostAuthorityWorkBreakdownStructure = FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType();

            BasicProjectInfoProjectGridName = "costAuthorityProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentFirmaSession, true, CostAuthority)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} associated with {FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} {costAuthority.CostAuthorityWorkBreakdownStructure}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with {FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} {costAuthority.CostAuthorityWorkBreakdownStructure}",
                SaveFiltersInCookie = true
            };
            BasicProjectInfoProjectGridDataUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(cac => cac.CostAuthorityProjectsGridJsonData(costAuthority));

            AgreementGridName = "costAuthorityAgreementListGrid";
            AgreementGridSpec = new AgreementGridSpec(CurrentFirmaSession)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Agreement.ToType().GetFieldDefinitionLabel()} associated with {FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} {costAuthority.CostAuthorityWorkBreakdownStructure}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Agreement.ToType().GetFieldDefinitionLabelPluralized()} associated with {FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} {costAuthority.CostAuthorityWorkBreakdownStructure}",
                SaveFiltersInCookie = true
            };
            AgreementGridDataUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(cac => cac.CostAuthorityAgreementGridJsonData(costAuthority));

            HasPnBudgetViewPermission = new PnBudgetViewFeature().HasPermissionByFirmaSession(currentFirmaSession);

            PnBudgetGridName = "PnBudgetsGrid";
            PnBudgetGridSpec = new PnBudgetGridSpec(currentFirmaSession);
            PnBudgetGridDataUrl = SitkaRoute<PnBudgetController>.BuildUrlFromExpression(c => c.PnBudgetsForCostAuthorityGridJsonData(costAuthority.CostAuthorityWorkBreakdownStructure));

            HasObligationViewPermission = new ObligationViewFeature().HasPermissionByFirmaSession(currentFirmaSession);

            ContractualInvoiceGridName = "contractualInvoiceGrid";
            ContractualInvoiceGridSpec = new ContractualInvoiceGridSpec(currentFirmaSession);
            ContractualInvoiceGridDataUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(cac => cac.ContractualInvoiceGridJsonData(costAuthority));

        //ObligationItemBudgetGridName = "obligationItemBudgets";
        //ObligationItemBudgetGridSpec = new ObligationItemBudgetGridSpec(currentFirmaSession);
        //ObligationItemBudgetGridDataUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(oc => oc.ObligationItemBudgetGridJsonData(costAuthority));
    }


    }
}
