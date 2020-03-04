//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Vendor
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class VendorPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Vendor>
    {
        public VendorPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public VendorPrimaryKey(Vendor vendor) : base(vendor){}

        public static implicit operator VendorPrimaryKey(int primaryKeyValue)
        {
            return new VendorPrimaryKey(primaryKeyValue);
        }

        public static implicit operator VendorPrimaryKey(Vendor vendor)
        {
            return new VendorPrimaryKey(vendor);
        }
    }
}