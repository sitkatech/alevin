//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreementProject
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementProjectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreementProject>
    {
        public ReclamationAgreementProjectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementProjectPrimaryKey(ReclamationAgreementProject reclamationAgreementProject) : base(reclamationAgreementProject){}

        public static implicit operator ReclamationAgreementProjectPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementProjectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementProjectPrimaryKey(ReclamationAgreementProject reclamationAgreementProject)
        {
            return new ReclamationAgreementProjectPrimaryKey(reclamationAgreementProject);
        }
    }
}