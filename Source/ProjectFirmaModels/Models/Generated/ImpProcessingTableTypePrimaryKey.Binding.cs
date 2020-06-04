//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ImpProcessingTableType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ImpProcessingTableTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ImpProcessingTableType>
    {
        public ImpProcessingTableTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ImpProcessingTableTypePrimaryKey(ImpProcessingTableType impProcessingTableType) : base(impProcessingTableType){}

        public static implicit operator ImpProcessingTableTypePrimaryKey(int primaryKeyValue)
        {
            return new ImpProcessingTableTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ImpProcessingTableTypePrimaryKey(ImpProcessingTableType impProcessingTableType)
        {
            return new ImpProcessingTableTypePrimaryKey(impProcessingTableType);
        }
    }
}