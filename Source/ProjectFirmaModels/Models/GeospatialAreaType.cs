using System.Collections.Generic;
using System.Web;

namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaType : IFirmaPage, IAuditableEntity
    {
        public static readonly List<int> GeospatialAreaTypesIncludedInBiOpAnnualReport = new List<int> {21, 22};

        public HtmlString GetFirmaPageContentHtmlString() => GeospatialAreaIntroContentHtmlString;

        public string GetFirmaPageDisplayName() => GeospatialAreaTypeName;
        public bool HasPageContent() => !string.IsNullOrWhiteSpace(GeospatialAreaIntroContent);

        public string GetAuditDescriptionString() => GeospatialAreaTypeName;
    }
}