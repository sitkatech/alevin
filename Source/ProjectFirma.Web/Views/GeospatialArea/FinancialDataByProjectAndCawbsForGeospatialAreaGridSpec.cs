using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
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

            Add("Project Name", x => x.Project.ProjectName, 180, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
        }
    }
}