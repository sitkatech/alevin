//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationLocation
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationLocationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationLocation>
    {
        public ReclamationLocationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationLocationPrimaryKey(ReclamationLocation reclamationLocation) : base(reclamationLocation){}

        public static implicit operator ReclamationLocationPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationLocationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationLocationPrimaryKey(ReclamationLocation reclamationLocation)
        {
            return new ReclamationLocationPrimaryKey(reclamationLocation);
        }
    }
}