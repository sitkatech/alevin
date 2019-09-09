//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingObligationsTable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingObligationsTablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingObligationsTable>
    {
        public ReclamationStagingObligationsTablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingObligationsTablePrimaryKey(ReclamationStagingObligationsTable reclamationStagingObligationsTable) : base(reclamationStagingObligationsTable){}

        public static implicit operator ReclamationStagingObligationsTablePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingObligationsTablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingObligationsTablePrimaryKey(ReclamationStagingObligationsTable reclamationStagingObligationsTable)
        {
            return new ReclamationStagingObligationsTablePrimaryKey(reclamationStagingObligationsTable);
        }
    }
}