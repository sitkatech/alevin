//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostAuthorityProject
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityProjectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostAuthorityProject>
    {
        public CostAuthorityProjectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostAuthorityProjectPrimaryKey(CostAuthorityProject costAuthorityProject) : base(costAuthorityProject){}

        public static implicit operator CostAuthorityProjectPrimaryKey(int primaryKeyValue)
        {
            return new CostAuthorityProjectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostAuthorityProjectPrimaryKey(CostAuthorityProject costAuthorityProject)
        {
            return new CostAuthorityProjectPrimaryKey(costAuthorityProject);
        }
    }
}