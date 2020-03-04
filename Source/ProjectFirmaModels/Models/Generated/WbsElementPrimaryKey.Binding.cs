//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.WbsElement
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class WbsElementPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<WbsElement>
    {
        public WbsElementPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WbsElementPrimaryKey(WbsElement wbsElement) : base(wbsElement){}

        public static implicit operator WbsElementPrimaryKey(int primaryKeyValue)
        {
            return new WbsElementPrimaryKey(primaryKeyValue);
        }

        public static implicit operator WbsElementPrimaryKey(WbsElement wbsElement)
        {
            return new WbsElementPrimaryKey(wbsElement);
        }
    }
}