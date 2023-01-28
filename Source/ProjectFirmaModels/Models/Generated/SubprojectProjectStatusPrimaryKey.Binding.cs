//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectProjectStatus
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectProjectStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectProjectStatus>
    {
        public SubprojectProjectStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectProjectStatusPrimaryKey(SubprojectProjectStatus subprojectProjectStatus) : base(subprojectProjectStatus){}

        public static implicit operator SubprojectProjectStatusPrimaryKey(int primaryKeyValue)
        {
            return new SubprojectProjectStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectProjectStatusPrimaryKey(SubprojectProjectStatus subprojectProjectStatus)
        {
            return new SubprojectProjectStatusPrimaryKey(subprojectProjectStatus);
        }
    }
}