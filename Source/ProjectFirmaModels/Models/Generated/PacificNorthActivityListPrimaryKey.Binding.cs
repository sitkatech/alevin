//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PacificNorthActivityList
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PacificNorthActivityListPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PacificNorthActivityList>
    {
        public PacificNorthActivityListPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PacificNorthActivityListPrimaryKey(PacificNorthActivityList pacificNorthActivityList) : base(pacificNorthActivityList){}

        public static implicit operator PacificNorthActivityListPrimaryKey(int primaryKeyValue)
        {
            return new PacificNorthActivityListPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PacificNorthActivityListPrimaryKey(PacificNorthActivityList pacificNorthActivityList)
        {
            return new PacificNorthActivityListPrimaryKey(pacificNorthActivityList);
        }
    }
}