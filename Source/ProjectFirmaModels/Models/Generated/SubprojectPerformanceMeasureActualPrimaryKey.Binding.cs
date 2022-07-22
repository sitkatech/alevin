//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectPerformanceMeasureActual
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureActualPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectPerformanceMeasureActual>
    {
        public SubprojectPerformanceMeasureActualPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectPerformanceMeasureActualPrimaryKey(SubprojectPerformanceMeasureActual subprojectPerformanceMeasureActual) : base(subprojectPerformanceMeasureActual){}

        public static implicit operator SubprojectPerformanceMeasureActualPrimaryKey(int primaryKeyValue)
        {
            return new SubprojectPerformanceMeasureActualPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectPerformanceMeasureActualPrimaryKey(SubprojectPerformanceMeasureActual subprojectPerformanceMeasureActual)
        {
            return new SubprojectPerformanceMeasureActualPrimaryKey(subprojectPerformanceMeasureActual);
        }
    }
}