//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PacificNorthActivityType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PacificNorthActivityTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PacificNorthActivityType>
    {
        public PacificNorthActivityTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PacificNorthActivityTypePrimaryKey(PacificNorthActivityType pacificNorthActivityType) : base(pacificNorthActivityType){}

        public static implicit operator PacificNorthActivityTypePrimaryKey(int primaryKeyValue)
        {
            return new PacificNorthActivityTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PacificNorthActivityTypePrimaryKey(PacificNorthActivityType pacificNorthActivityType)
        {
            return new PacificNorthActivityTypePrimaryKey(pacificNorthActivityType);
        }
    }
}