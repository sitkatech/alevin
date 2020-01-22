using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add and Edit Action Items")]
    public class ActionItemManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ActionItem>
    {
        private readonly FirmaFeatureWithContextImpl<ActionItem> _firmaFeatureWithContextImpl;

        public ActionItemManageFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ActionItem>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ActionItem contextModelObject)
        {
            var person = firmaSession.Person;
            var project = contextModelObject.Project;
            var isProposal = project.IsProposal();
            if (isProposal)
            {
                return new PermissionCheckResult(
                    $"You cannot edit {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()} because it is in the Proposal stage.");
            }
            bool isProjectStewardButCannotStewardThisProject = person != null && firmaSession.Role.RoleID == Role.ProjectSteward.RoleID && !person.CanStewardProject(project);
            bool doesNotHavePermissionByPerson = !HasPermissionByFirmaSession(firmaSession);
            var forbidAdmin = doesNotHavePermissionByPerson || isProjectStewardButCannotStewardThisProject;
            if (forbidAdmin)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to edit {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            }
            return new PermissionCheckResult();
        }

        public void DemandPermission(FirmaSession firmaSession, ActionItem contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}