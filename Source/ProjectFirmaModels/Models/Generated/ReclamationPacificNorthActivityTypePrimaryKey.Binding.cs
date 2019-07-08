//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationPacificNorthActivityType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPacificNorthActivityTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationPacificNorthActivityType>
    {
        public ReclamationPacificNorthActivityTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationPacificNorthActivityTypePrimaryKey(ReclamationPacificNorthActivityType reclamationPacificNorthActivityType) : base(reclamationPacificNorthActivityType){}

        public static implicit operator ReclamationPacificNorthActivityTypePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationPacificNorthActivityTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationPacificNorthActivityTypePrimaryKey(ReclamationPacificNorthActivityType reclamationPacificNorthActivityType)
        {
            return new ReclamationPacificNorthActivityTypePrimaryKey(reclamationPacificNorthActivityType);
        }
    }
}