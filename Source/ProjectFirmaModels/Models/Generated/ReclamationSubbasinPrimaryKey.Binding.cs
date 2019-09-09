//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationSubbasin
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationSubbasinPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationSubbasin>
    {
        public ReclamationSubbasinPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationSubbasinPrimaryKey(ReclamationSubbasin reclamationSubbasin) : base(reclamationSubbasin){}

        public static implicit operator ReclamationSubbasinPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationSubbasinPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationSubbasinPrimaryKey(ReclamationSubbasin reclamationSubbasin)
        {
            return new ReclamationSubbasinPrimaryKey(reclamationSubbasin);
        }
    }
}