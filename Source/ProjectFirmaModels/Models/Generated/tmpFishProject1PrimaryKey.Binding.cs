//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.tmpFishProject1
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class tmpFishProject1PrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<tmpFishProject1>
    {
        public tmpFishProject1PrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public tmpFishProject1PrimaryKey(tmpFishProject1 tmpFishProject1) : base(tmpFishProject1){}

        public static implicit operator tmpFishProject1PrimaryKey(int primaryKeyValue)
        {
            return new tmpFishProject1PrimaryKey(primaryKeyValue);
        }

        public static implicit operator tmpFishProject1PrimaryKey(tmpFishProject1 tmpFishProject1)
        {
            return new tmpFishProject1PrimaryKey(tmpFishProject1);
        }
    }
}