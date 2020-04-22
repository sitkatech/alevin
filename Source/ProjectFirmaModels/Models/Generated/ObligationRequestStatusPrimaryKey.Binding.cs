//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ObligationRequestStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ObligationRequestStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ObligationRequestStatus>
    {
        public ObligationRequestStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ObligationRequestStatusPrimaryKey(ObligationRequestStatus obligationRequestStatus) : base(obligationRequestStatus){}

        public static implicit operator ObligationRequestStatusPrimaryKey(int primaryKeyValue)
        {
            return new ObligationRequestStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ObligationRequestStatusPrimaryKey(ObligationRequestStatus obligationRequestStatus)
        {
            return new ObligationRequestStatusPrimaryKey(obligationRequestStatus);
        }
    }
}