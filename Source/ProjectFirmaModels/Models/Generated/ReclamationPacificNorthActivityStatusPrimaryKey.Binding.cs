//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationPacificNorthActivityStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPacificNorthActivityStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationPacificNorthActivityStatus>
    {
        public ReclamationPacificNorthActivityStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationPacificNorthActivityStatusPrimaryKey(ReclamationPacificNorthActivityStatus reclamationPacificNorthActivityStatus) : base(reclamationPacificNorthActivityStatus){}

        public static implicit operator ReclamationPacificNorthActivityStatusPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationPacificNorthActivityStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationPacificNorthActivityStatusPrimaryKey(ReclamationPacificNorthActivityStatus reclamationPacificNorthActivityStatus)
        {
            return new ReclamationPacificNorthActivityStatusPrimaryKey(reclamationPacificNorthActivityStatus);
        }
    }
}