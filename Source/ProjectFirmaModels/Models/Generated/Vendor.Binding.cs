//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[Vendor]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [ImportFinancial].[Vendor] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[Vendor]")]
    public partial class Vendor : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Vendor()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Vendor(int vendorID, string vendorKey, string vendorText) : this()
        {
            this.VendorID = vendorID;
            this.VendorKey = vendorKey;
            this.VendorText = vendorText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Vendor(string vendorKey, string vendorText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.VendorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.VendorKey = vendorKey;
            this.VendorText = vendorText;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Vendor CreateNewBlank()
        {
            return new Vendor(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Vendor).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.Vendors.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int VendorID { get; set; }
        public string VendorKey { get; set; }
        public string VendorText { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return VendorID; } set { VendorID = value; } }



        public static class FieldLengths
        {
            public const int VendorKey = 100;
            public const int VendorText = 500;
        }
    }
}