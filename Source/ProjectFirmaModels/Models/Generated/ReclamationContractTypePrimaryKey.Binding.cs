//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationContractType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationContractTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationContractType>
    {
        public ReclamationContractTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationContractTypePrimaryKey(ReclamationContractType reclamationContractType) : base(reclamationContractType){}

        public static implicit operator ReclamationContractTypePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationContractTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationContractTypePrimaryKey(ReclamationContractType reclamationContractType)
        {
            return new ReclamationContractTypePrimaryKey(reclamationContractType);
        }
    }
}