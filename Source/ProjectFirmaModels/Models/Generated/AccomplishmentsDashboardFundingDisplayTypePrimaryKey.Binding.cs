//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AccomplishmentsDashboardFundingDisplayType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AccomplishmentsDashboardFundingDisplayTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AccomplishmentsDashboardFundingDisplayType>
    {
        public AccomplishmentsDashboardFundingDisplayTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AccomplishmentsDashboardFundingDisplayTypePrimaryKey(AccomplishmentsDashboardFundingDisplayType accomplishmentsDashboardFundingDisplayType) : base(accomplishmentsDashboardFundingDisplayType){}

        public static implicit operator AccomplishmentsDashboardFundingDisplayTypePrimaryKey(int primaryKeyValue)
        {
            return new AccomplishmentsDashboardFundingDisplayTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator AccomplishmentsDashboardFundingDisplayTypePrimaryKey(AccomplishmentsDashboardFundingDisplayType accomplishmentsDashboardFundingDisplayType)
        {
            return new AccomplishmentsDashboardFundingDisplayTypePrimaryKey(accomplishmentsDashboardFundingDisplayType);
        }
    }
}