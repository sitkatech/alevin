//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PacificNorthActivityStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PacificNorthActivityStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PacificNorthActivityStatus>
    {
        public PacificNorthActivityStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PacificNorthActivityStatusPrimaryKey(PacificNorthActivityStatus pacificNorthActivityStatus) : base(pacificNorthActivityStatus){}

        public static implicit operator PacificNorthActivityStatusPrimaryKey(int primaryKeyValue)
        {
            return new PacificNorthActivityStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PacificNorthActivityStatusPrimaryKey(PacificNorthActivityStatus pacificNorthActivityStatus)
        {
            return new PacificNorthActivityStatusPrimaryKey(pacificNorthActivityStatus);
        }
    }
}