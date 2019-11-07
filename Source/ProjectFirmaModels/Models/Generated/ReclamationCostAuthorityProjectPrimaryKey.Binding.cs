//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationCostAuthorityProject
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationCostAuthorityProjectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationCostAuthorityProject>
    {
        public ReclamationCostAuthorityProjectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationCostAuthorityProjectPrimaryKey(ReclamationCostAuthorityProject reclamationCostAuthorityProject) : base(reclamationCostAuthorityProject){}

        public static implicit operator ReclamationCostAuthorityProjectPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationCostAuthorityProjectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationCostAuthorityProjectPrimaryKey(ReclamationCostAuthorityProject reclamationCostAuthorityProject)
        {
            return new ReclamationCostAuthorityProjectPrimaryKey(reclamationCostAuthorityProject);
        }
    }
}