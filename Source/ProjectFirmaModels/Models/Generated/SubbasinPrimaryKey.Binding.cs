//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Subbasin
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubbasinPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Subbasin>
    {
        public SubbasinPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubbasinPrimaryKey(Subbasin subbasin) : base(subbasin){}

        public static implicit operator SubbasinPrimaryKey(int primaryKeyValue)
        {
            return new SubbasinPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubbasinPrimaryKey(Subbasin subbasin)
        {
            return new SubbasinPrimaryKey(subbasin);
        }
    }
}