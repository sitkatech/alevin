//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.tmpFishProject2Dissolve
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class tmpFishProject2DissolvePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<tmpFishProject2Dissolve>
    {
        public tmpFishProject2DissolvePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public tmpFishProject2DissolvePrimaryKey(tmpFishProject2Dissolve tmpFishProject2Dissolve) : base(tmpFishProject2Dissolve){}

        public static implicit operator tmpFishProject2DissolvePrimaryKey(int primaryKeyValue)
        {
            return new tmpFishProject2DissolvePrimaryKey(primaryKeyValue);
        }

        public static implicit operator tmpFishProject2DissolvePrimaryKey(tmpFishProject2Dissolve tmpFishProject2Dissolve)
        {
            return new tmpFishProject2DissolvePrimaryKey(tmpFishProject2Dissolve);
        }
    }
}