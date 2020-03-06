//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.HCategory
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class HCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<HCategory>
    {
        public HCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public HCategoryPrimaryKey(HCategory hCategory) : base(hCategory){}

        public static implicit operator HCategoryPrimaryKey(int primaryKeyValue)
        {
            return new HCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator HCategoryPrimaryKey(HCategory hCategory)
        {
            return new HCategoryPrimaryKey(hCategory);
        }
    }
}