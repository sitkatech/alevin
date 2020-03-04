//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[Vendor]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Vendor GetVendor(this IQueryable<Vendor> vendors, int vendorID)
        {
            var vendor = vendors.SingleOrDefault(x => x.VendorID == vendorID);
            Check.RequireNotNullThrowNotFound(vendor, "Vendor", vendorID);
            return vendor;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteVendor(this IQueryable<Vendor> vendors, List<int> vendorIDList)
        {
            if(vendorIDList.Any())
            {
                vendors.Where(x => vendorIDList.Contains(x.VendorID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteVendor(this IQueryable<Vendor> vendors, ICollection<Vendor> vendorsToDelete)
        {
            if(vendorsToDelete.Any())
            {
                var vendorIDList = vendorsToDelete.Select(x => x.VendorID).ToList();
                vendors.Where(x => vendorIDList.Contains(x.VendorID)).Delete();
            }
        }

        public static void DeleteVendor(this IQueryable<Vendor> vendors, int vendorID)
        {
            DeleteVendor(vendors, new List<int> { vendorID });
        }

        public static void DeleteVendor(this IQueryable<Vendor> vendors, Vendor vendorToDelete)
        {
            DeleteVendor(vendors, new List<Vendor> { vendorToDelete });
        }
    }
}