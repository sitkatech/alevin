using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Agreement associations for Project {0}", FieldDefinitionEnum.Project)]
    public class ProjectAgreementEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureForProject _firmaFeatureWithContextImpl;

        public ProjectAgreementEditFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureForProject(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, Project contextModelObject)
        {

            // These permissions are lifted from ProjectUpdateCreateEditSubmitFeature, and may well be wrong for this purpose
            /*
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            if (contextModelObject.IsProposal())
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()} cannot be updated through the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update process.");
            }

            if (!contextModelObject.IsUpdatableViaProjectUpdateProcess())
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()} is not updateable via the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update process");
            }

            var projectIsEditableByUser = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(person, contextModelObject).HasPermission || contextModelObject.IsMyProject(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.ProjectID} is not editable by you.");
            }
            */

            // Start with just a person check for the moment
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            // Success / Valid
            return new PermissionCheckResult();
        }
    }
}