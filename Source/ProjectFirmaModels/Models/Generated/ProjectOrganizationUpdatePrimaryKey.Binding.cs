//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectOrganizationUpdate
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectOrganizationUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectOrganizationUpdate>
    {
        public ProjectOrganizationUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectOrganizationUpdatePrimaryKey(ProjectOrganizationUpdate projectOrganizationUpdate) : base(projectOrganizationUpdate){}

        public static implicit operator ProjectOrganizationUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectOrganizationUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectOrganizationUpdatePrimaryKey(ProjectOrganizationUpdate projectOrganizationUpdate)
        {
            return new ProjectOrganizationUpdatePrimaryKey(projectOrganizationUpdate);
        }
    }
}