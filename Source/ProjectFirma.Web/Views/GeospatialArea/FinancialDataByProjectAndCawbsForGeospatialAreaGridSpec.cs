using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
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
            //Add(geospatialAreaType.GeospatialAreaTypeName, a => UrlTemplate.MakeHrefString(GeospatialAreaModelExtensions.GetDetailUrl(a.GeospatialAreaID), a.GetGeospatialAreaShortNameWithColor()), 300, AgGridColumnFilterType.Html);
            //Add($"# of {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", a => a.ProjectViewableByUserCount, 65);

            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.GetDetailUrl(), x.Project.ProjectName), 300, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString(),
                x => x.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 200,
                AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Fiscal Year", x => x.WbsElementPnBudget.FiscalYear.ToString(), 80, AgGridColumnFilterType.SelectFilterStrict);

            Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), x => x.WbsElementPnBudget.TotalObligations, 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.TotalExpenditures.ToType().ToGridHeaderString(), x => x.WbsElementPnBudget.TotalExpenditures, 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);

            Add("FI Doc Number", x => x.WbsElementPnBudget.FIDocNumber, 100);

            Add("Budget Object Code", x => x.WbsElementPnBudget.BudgetObjectCode?.BudgetObjectCodeName, 100, AgGridColumnFilterType.Text);

        }
    }
}