//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationFund
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationFundPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationFund>
    {
        public ReclamationFundPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationFundPrimaryKey(ReclamationFund reclamationFund) : base(reclamationFund){}

        public static implicit operator ReclamationFundPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationFundPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationFundPrimaryKey(ReclamationFund reclamationFund)
        {
            return new ReclamationFundPrimaryKey(reclamationFund);
        }
    }
}