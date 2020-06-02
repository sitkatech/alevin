//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCustomAttributeUpdateValue
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeUpdateValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCustomAttributeUpdateValue>
    {
        public ProjectCustomAttributeUpdateValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCustomAttributeUpdateValuePrimaryKey(ProjectCustomAttributeUpdateValue projectCustomAttributeUpdateValue) : base(projectCustomAttributeUpdateValue){}

        public static implicit operator ProjectCustomAttributeUpdateValuePrimaryKey(int primaryKeyValue)
        {
            return new ProjectCustomAttributeUpdateValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCustomAttributeUpdateValuePrimaryKey(ProjectCustomAttributeUpdateValue projectCustomAttributeUpdateValue)
        {
            return new ProjectCustomAttributeUpdateValuePrimaryKey(projectCustomAttributeUpdateValue);
        }
    }
}