//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostAuthorityWorkBreakdownStructurePacificNorthActivityList
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityWorkBreakdownStructurePacificNorthActivityListPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostAuthorityWorkBreakdownStructurePacificNorthActivityList>
    {
        public CostAuthorityWorkBreakdownStructurePacificNorthActivityListPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostAuthorityWorkBreakdownStructurePacificNorthActivityListPrimaryKey(CostAuthorityWorkBreakdownStructurePacificNorthActivityList costAuthorityWorkBreakdownStructurePacificNorthActivityList) : base(costAuthorityWorkBreakdownStructurePacificNorthActivityList){}

        public static implicit operator CostAuthorityWorkBreakdownStructurePacificNorthActivityListPrimaryKey(int primaryKeyValue)
        {
            return new CostAuthorityWorkBreakdownStructurePacificNorthActivityListPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostAuthorityWorkBreakdownStructurePacificNorthActivityListPrimaryKey(CostAuthorityWorkBreakdownStructurePacificNorthActivityList costAuthorityWorkBreakdownStructurePacificNorthActivityList)
        {
            return new CostAuthorityWorkBreakdownStructurePacificNorthActivityListPrimaryKey(costAuthorityWorkBreakdownStructurePacificNorthActivityList);
        }
    }
}