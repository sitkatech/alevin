//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectPerformanceMeasureActualSubcategoryOption
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureActualSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectPerformanceMeasureActualSubcategoryOption>
    {
        public SubprojectPerformanceMeasureActualSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectPerformanceMeasureActualSubcategoryOptionPrimaryKey(SubprojectPerformanceMeasureActualSubcategoryOption subprojectPerformanceMeasureActualSubcategoryOption) : base(subprojectPerformanceMeasureActualSubcategoryOption){}

        public static implicit operator SubprojectPerformanceMeasureActualSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new SubprojectPerformanceMeasureActualSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectPerformanceMeasureActualSubcategoryOptionPrimaryKey(SubprojectPerformanceMeasureActualSubcategoryOption subprojectPerformanceMeasureActualSubcategoryOption)
        {
            return new SubprojectPerformanceMeasureActualSubcategoryOptionPrimaryKey(subprojectPerformanceMeasureActualSubcategoryOption);
        }
    }
}