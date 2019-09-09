//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationHCategory
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationHCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationHCategory>
    {
        public ReclamationHCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationHCategoryPrimaryKey(ReclamationHCategory reclamationHCategory) : base(reclamationHCategory){}

        public static implicit operator ReclamationHCategoryPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationHCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationHCategoryPrimaryKey(ReclamationHCategory reclamationHCategory)
        {
            return new ReclamationHCategoryPrimaryKey(reclamationHCategory);
        }
    }
}