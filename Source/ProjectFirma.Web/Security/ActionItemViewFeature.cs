using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add and Edit Action Items")]
    public class ActionItemViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ActionItemViewFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            var person = firmaSession.Person;
            var project = contextModelObject;
            var isProposal = project.IsProposal();
            if (isProposal)
            {
                return new PermissionCheckResult(
                    $"You cannot view this {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()} because the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()} is in the Proposal stage.");
            }
            bool isProjectStewardButCannotStewardThisProject = person != null && firmaSession.Role.RoleID == Role.ProjectSteward.RoleID && !person.CanStewardProject(project);
            bool doesNotHavePermissionByPerson = !HasPermissionByFirmaSession(firmaSession);
            var forbidAdmin = doesNotHavePermissionByPerson || isProjectStewardButCannotStewardThisProject;
            if (forbidAdmin)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to view this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
            }
            return new PermissionCheckResult();
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}