﻿using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class FinancialDataByProjectAndCawbsForGeospatialAreaGridSpec : GridSpec<FinancialDataByProjectAndCawbsForGeospatialArea>
    {
        public FinancialDataByProjectAndCawbsForGeospatialAreaGridSpec(FirmaSession currentFirmaSession)
        {
            //Add(geospatialAreaType.GeospatialAreaTypeName, a => UrlTemplate.MakeHrefString(GeospatialAreaModelExtensions.GetDetailUrl(a.GeospatialAreaID), a.GetGeospatialAreaShortNameWithColor()), 300, DhtmlxGridColumnFilterType.Html);
            //Add($"# of {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", a => a.ProjectViewableByUserCount, 65);

            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.GetDetailUrl(), x.Project.ProjectName), 300, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString(),
                x => x.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 200,
                DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Fiscal Year", x => x.WbsElementPnBudget.FiscalYear.ToString(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);

            Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), x => x.WbsElementPnBudget.TotalObligations, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.TotalExpenditures.ToType().ToGridHeaderString(), x => x.WbsElementPnBudget.TotalExpenditures, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);

            Add("FI Doc Number", x => x.WbsElementPnBudget.FIDocNumber, 100);

            Add("Budget Object Code", x => x.WbsElementPnBudget.BudgetObjectCode?.BudgetObjectCodeName, 100, DhtmlxGridColumnFilterType.Text);

        }
    }
}