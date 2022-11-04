﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage {0}", FieldDefinitionEnum.ProjectInternalNote)]
    public class ProjectInternalNoteManageAsAdminFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectInternalNote>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectInternalNote> _firmaFeatureWithContextImpl;

        public ProjectInternalNoteManageAsAdminFeature()
            : base(new List<Role> { Role.Normal, Role.ESAAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectInternalNote>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ProjectInternalNote contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectInternalNote contextModelObject)
        {
            var hasPermissionByFirmaSession = HasPermissionByFirmaSession(firmaSession);
            if (!hasPermissionByFirmaSession)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.Project.GetDisplayName()}");
            }


            if (contextModelObject.Project.IsProposal() || contextModelObject.Project.IsPendingProject())
            {
                return new ProjectCreateFeature().HasPermission(firmaSession, contextModelObject.Project);
            }

            return new ProjectEditAsAdminFeature().HasPermission(firmaSession, contextModelObject.Project);
        }
    }
}