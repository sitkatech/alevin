//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.WbsElementObligationItemInvoice
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class WbsElementObligationItemInvoicePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<WbsElementObligationItemInvoice>
    {
        public WbsElementObligationItemInvoicePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WbsElementObligationItemInvoicePrimaryKey(WbsElementObligationItemInvoice wbsElementObligationItemInvoice) : base(wbsElementObligationItemInvoice){}

        public static implicit operator WbsElementObligationItemInvoicePrimaryKey(int primaryKeyValue)
        {
            return new WbsElementObligationItemInvoicePrimaryKey(primaryKeyValue);
        }

        public static implicit operator WbsElementObligationItemInvoicePrimaryKey(WbsElementObligationItemInvoice wbsElementObligationItemInvoice)
        {
            return new WbsElementObligationItemInvoicePrimaryKey(wbsElementObligationItemInvoice);
        }
    }
}