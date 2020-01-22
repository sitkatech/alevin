using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add and Edit Action Items")]
    public class ActionItemEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ActionItemEditFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            var person = firmaSession.Person;
            var isProposal = contextModelObject.IsProposal();
            if (isProposal)
            {
                return new PermissionCheckResult(
                    $"You cannot edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()} because it is in the Proposal stage.");
            }
            bool isProjectStewardButCannotStewardThisProject = person != null && firmaSession.Role.RoleID == Role.ProjectSteward.RoleID && !person.CanStewardProject(contextModelObject);
            bool doesNotHavePermissionByPerson = !HasPermissionByFirmaSession(firmaSession);
            var forbidAdmin = doesNotHavePermissionByPerson || isProjectStewardButCannotStewardThisProject;
            if (forbidAdmin)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }
            return new PermissionCheckResult();
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}