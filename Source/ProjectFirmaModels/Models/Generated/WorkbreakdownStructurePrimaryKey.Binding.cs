//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.WorkbreakdownStructure
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class WorkbreakdownStructurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<WorkbreakdownStructure>
    {
        public WorkbreakdownStructurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WorkbreakdownStructurePrimaryKey(WorkbreakdownStructure workbreakdownStructure) : base(workbreakdownStructure){}

        public static implicit operator WorkbreakdownStructurePrimaryKey(int primaryKeyValue)
        {
            return new WorkbreakdownStructurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator WorkbreakdownStructurePrimaryKey(WorkbreakdownStructure workbreakdownStructure)
        {
            return new WorkbreakdownStructurePrimaryKey(workbreakdownStructure);
        }
    }
}