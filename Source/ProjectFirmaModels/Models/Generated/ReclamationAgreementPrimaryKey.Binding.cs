//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreement
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreement>
    {
        public ReclamationAgreementPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementPrimaryKey(ReclamationAgreement reclamationAgreement) : base(reclamationAgreement){}

        public static implicit operator ReclamationAgreementPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementPrimaryKey(ReclamationAgreement reclamationAgreement)
        {
            return new ReclamationAgreementPrimaryKey(reclamationAgreement);
        }
    }
}