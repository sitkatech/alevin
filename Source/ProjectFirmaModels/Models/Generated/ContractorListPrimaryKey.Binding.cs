//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ContractorList
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ContractorListPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ContractorList>
    {
        public ContractorListPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ContractorListPrimaryKey(ContractorList contractorList) : base(contractorList){}

        public static implicit operator ContractorListPrimaryKey(int primaryKeyValue)
        {
            return new ContractorListPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ContractorListPrimaryKey(ContractorList contractorList)
        {
            return new ContractorListPrimaryKey(contractorList);
        }
    }
}