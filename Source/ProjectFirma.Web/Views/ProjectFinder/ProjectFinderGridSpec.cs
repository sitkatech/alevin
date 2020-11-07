﻿using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFinder
{
    public class ProjectFinderGridSpec : GridSpec<PartnerOrganizationMatchMakerScore>
    {
        public ProjectFinderGridSpec()
        {
            SkinRowHeight = 30;
            InitWidthsByPercentage = true;

            var allClassificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList();
            var tenantHasMultipleClassificationSystems = allClassificationSystems.Count > 1;
            var panelTitle = tenantHasMultipleClassificationSystems
                ? FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabelPluralized()
                : new EnglishPluralizationService().Pluralize(allClassificationSystems.First().ClassificationSystemName);

            Add(FieldDefinitionEnum.MatchScore.ToType().GetFieldDefinitionLabel(), x => (decimal) x.PartnerOrganizationFitnessScoreNumber, 5);
            Add(FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel(), x => x.Project.GetDisplayNameAsUrl(), 20, DhtmlxGridColumnFilterType.Html);
            Add("Lead Implementer", x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 20, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.MatchmakerKeyword.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.MatchmakerKeyword].Matched.ToCheckboxImageOrEmptyForGrid(), 8, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.AreaOfInterest].Matched.ToCheckboxImageOrEmptyForGrid(), 8, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.TaxonomySystemName.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.TaxonomySystem].Matched.ToCheckboxImageOrEmptyForGrid(), 8, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(panelTitle, x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.Classification].Matched.ToCheckboxImageOrEmptyForGrid(), 8, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.PerformanceMeasure].Matched.ToCheckboxImageOrEmptyForGrid(), 8, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Map", x => GetMapButtonForProject(x.Project), 15, DhtmlxGridColumnFilterType.None);
        }

        public static HtmlString GetMapButtonForProject(ProjectFirmaModels.Models.Project project)
        {
            if (project.HasProjectLocationPoint)
            {
                return new HtmlString($"<form onsubmit=\"return false;\"data-id=\"{project.ProjectID}\"><button title=\"Zoom to this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} on the map\" class=\"grid-map-marker grid-map-marker-enabled\" type=\"submit\"><span class=\"glyphicon glyphicon-map-marker\"></span></button></form>");

            }
            return new HtmlString($"<button class=\"grid-map-marker grid-map-marker-disabled\" type=\"button\"><span onmouseover=\"ProjectFirma.Views.Methods.addTooltipPopup(this, 'No {FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is available. You can click the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} name for more information.')\" class=\"glyphicon glyphicon-map-marker\"></span></button>");
        }
    }
}