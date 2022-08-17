using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SubprojectModelExtensions
    {
        public static List<Subproject> GetSubprojectFindResultsForSubprojectNameAndDescriptionAndNumber(this IQueryable<Subproject> subprojects, string subprojectKeyword)
        {
            return
                subprojects.Where(x => x.SubprojectName.Contains(subprojectKeyword) || x.SubprojectDescription.Contains(subprojectKeyword))
                    .OrderBy(x => x.SubprojectName)
                    .ToList();
        }
        public static HtmlString GetDisplayNameAsUrl(this Subproject subproject) => UrlTemplate.MakeHrefString("#", subproject.SubprojectName);

    }
}