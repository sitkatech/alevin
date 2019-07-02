//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostAuthorityAgreement
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityAgreementPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostAuthorityAgreement>
    {
        public CostAuthorityAgreementPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostAuthorityAgreementPrimaryKey(CostAuthorityAgreement costAuthorityAgreement) : base(costAuthorityAgreement){}

        public static implicit operator CostAuthorityAgreementPrimaryKey(int primaryKeyValue)
        {
            return new CostAuthorityAgreementPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostAuthorityAgreementPrimaryKey(CostAuthorityAgreement costAuthorityAgreement)
        {
            return new CostAuthorityAgreementPrimaryKey(costAuthorityAgreement);
        }
    }
}