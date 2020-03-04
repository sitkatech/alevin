//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ObligationNumber
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ObligationNumberPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ObligationNumber>
    {
        public ObligationNumberPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ObligationNumberPrimaryKey(ObligationNumber obligationNumber) : base(obligationNumber){}

        public static implicit operator ObligationNumberPrimaryKey(int primaryKeyValue)
        {
            return new ObligationNumberPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ObligationNumberPrimaryKey(ObligationNumber obligationNumber)
        {
            return new ObligationNumberPrimaryKey(obligationNumber);
        }
    }
}