//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectPerformanceMeasureExpected
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureExpectedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectPerformanceMeasureExpected>
    {
        public SubprojectPerformanceMeasureExpectedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectPerformanceMeasureExpectedPrimaryKey(SubprojectPerformanceMeasureExpected subprojectPerformanceMeasureExpected) : base(subprojectPerformanceMeasureExpected){}

        public static implicit operator SubprojectPerformanceMeasureExpectedPrimaryKey(int primaryKeyValue)
        {
            return new SubprojectPerformanceMeasureExpectedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectPerformanceMeasureExpectedPrimaryKey(SubprojectPerformanceMeasureExpected subprojectPerformanceMeasureExpected)
        {
            return new SubprojectPerformanceMeasureExpectedPrimaryKey(subprojectPerformanceMeasureExpected);
        }
    }
}