using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SubprojectProjectStatusModelExtensions
    {
        public static string GetDropdownDisplayName(this SubprojectProjectStatus subprojectProjectStatus)
        {
            return $"{subprojectProjectStatus.SubprojectProjectStatusCreateDate:MM/dd/yyyy} - {subprojectProjectStatus.SubprojectProjectStatusCreatePerson.GetFullNameFirstLast()} - {subprojectProjectStatus.ProjectStatus.ProjectStatusDisplayName}";
        }

        public static readonly UrlTemplate<int, int> EditSubprojectProjectStatusUrlTemplate = new UrlTemplate<int, int>(SitkaRoute<SubprojectProjectStatusController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int)));
        public static string GetEditSubprojectProjectStatusUrl(this SubprojectProjectStatus subprojectProjectStatus)
        {
            return EditSubprojectProjectStatusUrlTemplate.ParameterReplace(subprojectProjectStatus.SubprojectID, subprojectProjectStatus.SubprojectProjectStatusID);
        }

        public static readonly UrlTemplate<int, int> DeleteSubprojectProjectStatusUrlTemplate = new UrlTemplate<int, int>(SitkaRoute<SubprojectProjectStatusController>.BuildUrlFromExpression(t => t.DeleteSubprojectProjectStatus(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int)));
        public static string GetDeleteSubprojectProjectStatusUrl(this SubprojectProjectStatus subprojectProjectStatus)
        {
            return DeleteSubprojectProjectStatusUrlTemplate.ParameterReplace(subprojectProjectStatus.SubprojectID, subprojectProjectStatus.SubprojectProjectStatusID);
        }

        public static readonly UrlTemplate<int, int> SubprojectProjectStatusDetailsUrlTemplate = new UrlTemplate<int, int>(SitkaRoute<SubprojectProjectStatusController>.BuildUrlFromExpression(t => t.Details(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int)));
        public static string GetSubprojectProjectStatusDetailsUrl(this SubprojectProjectStatus subprojectProjectStatus)
        {
            return SubprojectProjectStatusDetailsUrlTemplate.ParameterReplace(subprojectProjectStatus.SubprojectID, subprojectProjectStatus.SubprojectProjectStatusID);
        }
    }
}