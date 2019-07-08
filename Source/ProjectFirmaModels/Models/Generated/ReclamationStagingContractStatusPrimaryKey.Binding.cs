//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingContractStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingContractStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingContractStatus>
    {
        public ReclamationStagingContractStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingContractStatusPrimaryKey(ReclamationStagingContractStatus reclamationStagingContractStatus) : base(reclamationStagingContractStatus){}

        public static implicit operator ReclamationStagingContractStatusPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingContractStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingContractStatusPrimaryKey(ReclamationStagingContractStatus reclamationStagingContractStatus)
        {
            return new ReclamationStagingContractStatusPrimaryKey(reclamationStagingContractStatus);
        }
    }
}