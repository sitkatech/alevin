//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ContractType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ContractTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ContractType>
    {
        public ContractTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ContractTypePrimaryKey(ContractType contractType) : base(contractType){}

        public static implicit operator ContractTypePrimaryKey(int primaryKeyValue)
        {
            return new ContractTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ContractTypePrimaryKey(ContractType contractType)
        {
            return new ContractTypePrimaryKey(contractType);
        }
    }
}