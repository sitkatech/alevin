//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AgreementPacificNorthActivity
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AgreementPacificNorthActivityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AgreementPacificNorthActivity>
    {
        public AgreementPacificNorthActivityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AgreementPacificNorthActivityPrimaryKey(AgreementPacificNorthActivity agreementPacificNorthActivity) : base(agreementPacificNorthActivity){}

        public static implicit operator AgreementPacificNorthActivityPrimaryKey(int primaryKeyValue)
        {
            return new AgreementPacificNorthActivityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AgreementPacificNorthActivityPrimaryKey(AgreementPacificNorthActivity agreementPacificNorthActivity)
        {
            return new AgreementPacificNorthActivityPrimaryKey(agreementPacificNorthActivity);
        }
    }
}