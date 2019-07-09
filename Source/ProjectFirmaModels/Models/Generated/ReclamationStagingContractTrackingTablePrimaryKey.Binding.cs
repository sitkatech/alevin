//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingContractTrackingTable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingContractTrackingTablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingContractTrackingTable>
    {
        public ReclamationStagingContractTrackingTablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingContractTrackingTablePrimaryKey(ReclamationStagingContractTrackingTable reclamationStagingContractTrackingTable) : base(reclamationStagingContractTrackingTable){}

        public static implicit operator ReclamationStagingContractTrackingTablePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingContractTrackingTablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingContractTrackingTablePrimaryKey(ReclamationStagingContractTrackingTable reclamationStagingContractTrackingTable)
        {
            return new ReclamationStagingContractTrackingTablePrimaryKey(reclamationStagingContractTrackingTable);
        }
    }
}