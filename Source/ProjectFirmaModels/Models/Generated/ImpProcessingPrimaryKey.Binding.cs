//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ImpProcessing
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ImpProcessingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ImpProcessing>
    {
        public ImpProcessingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ImpProcessingPrimaryKey(ImpProcessing impProcessing) : base(impProcessing){}

        public static implicit operator ImpProcessingPrimaryKey(int primaryKeyValue)
        {
            return new ImpProcessingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ImpProcessingPrimaryKey(ImpProcessing impProcessing)
        {
            return new ImpProcessingPrimaryKey(impProcessing);
        }
    }
}