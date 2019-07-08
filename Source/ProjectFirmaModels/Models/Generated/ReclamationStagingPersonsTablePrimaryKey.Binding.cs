//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingPersonsTable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingPersonsTablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingPersonsTable>
    {
        public ReclamationStagingPersonsTablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingPersonsTablePrimaryKey(ReclamationStagingPersonsTable reclamationStagingPersonsTable) : base(reclamationStagingPersonsTable){}

        public static implicit operator ReclamationStagingPersonsTablePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingPersonsTablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingPersonsTablePrimaryKey(ReclamationStagingPersonsTable reclamationStagingPersonsTable)
        {
            return new ReclamationStagingPersonsTablePrimaryKey(reclamationStagingPersonsTable);
        }
    }
}