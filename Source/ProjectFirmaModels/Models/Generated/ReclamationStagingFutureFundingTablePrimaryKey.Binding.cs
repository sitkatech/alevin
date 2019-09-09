//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingFutureFundingTable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingFutureFundingTablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingFutureFundingTable>
    {
        public ReclamationStagingFutureFundingTablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingFutureFundingTablePrimaryKey(ReclamationStagingFutureFundingTable reclamationStagingFutureFundingTable) : base(reclamationStagingFutureFundingTable){}

        public static implicit operator ReclamationStagingFutureFundingTablePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingFutureFundingTablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingFutureFundingTablePrimaryKey(ReclamationStagingFutureFundingTable reclamationStagingFutureFundingTable)
        {
            return new ReclamationStagingFutureFundingTablePrimaryKey(reclamationStagingFutureFundingTable);
        }
    }
}