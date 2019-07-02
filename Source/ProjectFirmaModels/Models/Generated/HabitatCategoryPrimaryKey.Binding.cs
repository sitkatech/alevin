//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.HabitatCategory
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class HabitatCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<HabitatCategory>
    {
        public HabitatCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public HabitatCategoryPrimaryKey(HabitatCategory habitatCategory) : base(habitatCategory){}

        public static implicit operator HabitatCategoryPrimaryKey(int primaryKeyValue)
        {
            return new HabitatCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator HabitatCategoryPrimaryKey(HabitatCategory habitatCategory)
        {
            return new HabitatCategoryPrimaryKey(habitatCategory);
        }
    }
}