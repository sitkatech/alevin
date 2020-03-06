//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Basin
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class BasinPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Basin>
    {
        public BasinPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public BasinPrimaryKey(Basin basin) : base(basin){}

        public static implicit operator BasinPrimaryKey(int primaryKeyValue)
        {
            return new BasinPrimaryKey(primaryKeyValue);
        }

        public static implicit operator BasinPrimaryKey(Basin basin)
        {
            return new BasinPrimaryKey(basin);
        }
    }
}