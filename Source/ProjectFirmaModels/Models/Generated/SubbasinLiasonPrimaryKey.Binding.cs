//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubbasinLiason
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubbasinLiasonPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubbasinLiason>
    {
        public SubbasinLiasonPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubbasinLiasonPrimaryKey(SubbasinLiason subbasinLiason) : base(subbasinLiason){}

        public static implicit operator SubbasinLiasonPrimaryKey(int primaryKeyValue)
        {
            return new SubbasinLiasonPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubbasinLiasonPrimaryKey(SubbasinLiason subbasinLiason)
        {
            return new SubbasinLiasonPrimaryKey(subbasinLiason);
        }
    }
}