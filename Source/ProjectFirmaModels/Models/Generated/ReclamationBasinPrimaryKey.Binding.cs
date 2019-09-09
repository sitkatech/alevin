//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationBasin
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationBasinPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationBasin>
    {
        public ReclamationBasinPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationBasinPrimaryKey(ReclamationBasin reclamationBasin) : base(reclamationBasin){}

        public static implicit operator ReclamationBasinPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationBasinPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationBasinPrimaryKey(ReclamationBasin reclamationBasin)
        {
            return new ReclamationBasinPrimaryKey(reclamationBasin);
        }
    }
}