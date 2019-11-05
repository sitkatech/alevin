//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.tmpFishProject2PopulationDissolve
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class tmpFishProject2PopulationDissolvePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<tmpFishProject2PopulationDissolve>
    {
        public tmpFishProject2PopulationDissolvePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public tmpFishProject2PopulationDissolvePrimaryKey(tmpFishProject2PopulationDissolve tmpFishProject2PopulationDissolve) : base(tmpFishProject2PopulationDissolve){}

        public static implicit operator tmpFishProject2PopulationDissolvePrimaryKey(int primaryKeyValue)
        {
            return new tmpFishProject2PopulationDissolvePrimaryKey(primaryKeyValue);
        }

        public static implicit operator tmpFishProject2PopulationDissolvePrimaryKey(tmpFishProject2PopulationDissolve tmpFishProject2PopulationDissolve)
        {
            return new tmpFishProject2PopulationDissolvePrimaryKey(tmpFishProject2PopulationDissolve);
        }
    }
}