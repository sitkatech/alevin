//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingCostAuthorityAgreement
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingCostAuthorityAgreementPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingCostAuthorityAgreement>
    {
        public ReclamationStagingCostAuthorityAgreementPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingCostAuthorityAgreementPrimaryKey(ReclamationStagingCostAuthorityAgreement reclamationStagingCostAuthorityAgreement) : base(reclamationStagingCostAuthorityAgreement){}

        public static implicit operator ReclamationStagingCostAuthorityAgreementPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingCostAuthorityAgreementPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingCostAuthorityAgreementPrimaryKey(ReclamationStagingCostAuthorityAgreement reclamationStagingCostAuthorityAgreement)
        {
            return new ReclamationStagingCostAuthorityAgreementPrimaryKey(reclamationStagingCostAuthorityAgreement);
        }
    }
}