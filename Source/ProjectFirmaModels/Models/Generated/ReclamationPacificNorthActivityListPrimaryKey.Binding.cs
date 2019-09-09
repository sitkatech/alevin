//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationPacificNorthActivityList
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPacificNorthActivityListPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationPacificNorthActivityList>
    {
        public ReclamationPacificNorthActivityListPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationPacificNorthActivityListPrimaryKey(ReclamationPacificNorthActivityList reclamationPacificNorthActivityList) : base(reclamationPacificNorthActivityList){}

        public static implicit operator ReclamationPacificNorthActivityListPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationPacificNorthActivityListPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationPacificNorthActivityListPrimaryKey(ReclamationPacificNorthActivityList reclamationPacificNorthActivityList)
        {
            return new ReclamationPacificNorthActivityListPrimaryKey(reclamationPacificNorthActivityList);
        }
    }
}