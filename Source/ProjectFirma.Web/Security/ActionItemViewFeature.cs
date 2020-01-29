using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Action Items under the context of a project")]
    public class ActionItemViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ActionItemViewFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward, Role.Normal })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            if (contextModelObject.IsRejected() || contextModelObject.IsProposal() || contextModelObject.IsPendingProject())
            {
                return new ProjectCreateFeature().HasPermission(firmaSession, contextModelObject);
            }
            else
            {
                var hasPermissionByPerson = HasPermissionByFirmaSession(firmaSession);
                if (!hasPermissionByPerson)
                {
                    return new PermissionCheckResult($"You do not have permission to view {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
                }

                var projectIsEditableByUser = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(firmaSession, contextModelObject).HasPermission || contextModelObject.IsMyProject(firmaSession);
                if (projectIsEditableByUser)
                {
                    return new PermissionCheckResult();
                }

                return new PermissionCheckResult($"You do not have permission to view {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
            }
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}