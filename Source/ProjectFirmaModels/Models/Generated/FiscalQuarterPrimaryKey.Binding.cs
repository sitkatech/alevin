//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FiscalQuarter
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FiscalQuarterPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FiscalQuarter>
    {
        public FiscalQuarterPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FiscalQuarterPrimaryKey(FiscalQuarter fiscalQuarter) : base(fiscalQuarter){}

        public static implicit operator FiscalQuarterPrimaryKey(int primaryKeyValue)
        {
            return new FiscalQuarterPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FiscalQuarterPrimaryKey(FiscalQuarter fiscalQuarter)
        {
            return new FiscalQuarterPrimaryKey(fiscalQuarter);
        }
    }
}