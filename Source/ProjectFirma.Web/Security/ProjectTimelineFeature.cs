﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can access project timeline")]
    public class ProjectTimelineFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectTimelineFeature() : base(new List<Role> {Role.ESAAdmin, Role.Admin, Role.ProjectSteward, Role.Normal})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureForProject(this);
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
                var hasPermissionByFirmaSession = HasPermissionByFirmaSession(firmaSession);
                if (!hasPermissionByFirmaSession)
                {
                    return new PermissionCheckResult("You do not have permission to access the Project History Timeline");
                }

                bool isUsersProject = contextModelObject.IsMyProject(firmaSession);
                bool userHasUpdateAdminPermission = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(firmaSession, contextModelObject).HasPermission;
                var projectIsEditableByUser = userHasUpdateAdminPermission || isUsersProject;
                if (projectIsEditableByUser)
                {
                    return new PermissionCheckResult();
                }

                return new PermissionCheckResult("You do not have permission to access the Project History Timeline");
            }

        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}