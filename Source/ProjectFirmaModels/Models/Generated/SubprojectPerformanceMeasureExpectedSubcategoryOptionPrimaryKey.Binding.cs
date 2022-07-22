//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectPerformanceMeasureExpectedSubcategoryOption
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureExpectedSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectPerformanceMeasureExpectedSubcategoryOption>
    {
        public SubprojectPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(SubprojectPerformanceMeasureExpectedSubcategoryOption subprojectPerformanceMeasureExpectedSubcategoryOption) : base(subprojectPerformanceMeasureExpectedSubcategoryOption){}

        public static implicit operator SubprojectPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new SubprojectPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(SubprojectPerformanceMeasureExpectedSubcategoryOption subprojectPerformanceMeasureExpectedSubcategoryOption)
        {
            return new SubprojectPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(subprojectPerformanceMeasureExpectedSubcategoryOption);
        }
    }
}