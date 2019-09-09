//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingAgreementStatusTable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingAgreementStatusTablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingAgreementStatusTable>
    {
        public ReclamationStagingAgreementStatusTablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingAgreementStatusTablePrimaryKey(ReclamationStagingAgreementStatusTable reclamationStagingAgreementStatusTable) : base(reclamationStagingAgreementStatusTable){}

        public static implicit operator ReclamationStagingAgreementStatusTablePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingAgreementStatusTablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingAgreementStatusTablePrimaryKey(ReclamationStagingAgreementStatusTable reclamationStagingAgreementStatusTable)
        {
            return new ReclamationStagingAgreementStatusTablePrimaryKey(reclamationStagingAgreementStatusTable);
        }
    }
}