//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreementPacificNorthActivity
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementPacificNorthActivityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreementPacificNorthActivity>
    {
        public ReclamationAgreementPacificNorthActivityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementPacificNorthActivityPrimaryKey(ReclamationAgreementPacificNorthActivity reclamationAgreementPacificNorthActivity) : base(reclamationAgreementPacificNorthActivity){}

        public static implicit operator ReclamationAgreementPacificNorthActivityPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementPacificNorthActivityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementPacificNorthActivityPrimaryKey(ReclamationAgreementPacificNorthActivity reclamationAgreementPacificNorthActivity)
        {
            return new ReclamationAgreementPacificNorthActivityPrimaryKey(reclamationAgreementPacificNorthActivity);
        }
    }
}