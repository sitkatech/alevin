//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.WorkBreakdownStructure
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class WorkBreakdownStructurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<WorkBreakdownStructure>
    {
        public WorkBreakdownStructurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WorkBreakdownStructurePrimaryKey(WorkBreakdownStructure workBreakdownStructure) : base(workBreakdownStructure){}

        public static implicit operator WorkBreakdownStructurePrimaryKey(int primaryKeyValue)
        {
            return new WorkBreakdownStructurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator WorkBreakdownStructurePrimaryKey(WorkBreakdownStructure workBreakdownStructure)
        {
            return new WorkBreakdownStructurePrimaryKey(workBreakdownStructure);
        }
    }
}