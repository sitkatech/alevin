//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Location
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class LocationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Location>
    {
        public LocationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LocationPrimaryKey(Location location) : base(location){}

        public static implicit operator LocationPrimaryKey(int primaryKeyValue)
        {
            return new LocationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LocationPrimaryKey(Location location)
        {
            return new LocationPrimaryKey(location);
        }
    }
}