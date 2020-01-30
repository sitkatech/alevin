using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add and Edit Action Items")]
    public class ActionItemManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ActionItem>
    {
        private readonly FirmaFeatureWithContextImpl<ActionItem> _firmaFeatureWithContextImpl;

        public ActionItemManageFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward, Role.Normal })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ActionItem>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ActionItem contextModelObject)
        {

            var project = contextModelObject.Project;

            if (project.IsRejected() || project.IsProposal() || project.IsPendingProject())
            {
                return new ProjectCreateFeature().HasPermission(firmaSession, project);
            }
            else
            {
                var hasPermissionByPerson = HasPermissionByFirmaSession(firmaSession);
                if (!hasPermissionByPerson)
                {
                    return new PermissionCheckResult($"You do not have permission to manage {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
                }

                var projectIsEditableByUser = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(firmaSession, project).HasPermission || project.IsMyProject(firmaSession);
                if (projectIsEditableByUser)
                {
                    return new PermissionCheckResult();
                }

                return new PermissionCheckResult($"You do not have permission to manage {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
            }

        }

        public void DemandPermission(FirmaSession firmaSession, ActionItem contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}