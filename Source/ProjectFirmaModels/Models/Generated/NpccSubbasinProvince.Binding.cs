//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NpccSubbasinProvince]
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
    // Table [dbo].[NpccSubbasinProvince] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[NpccSubbasinProvince]")]
    public partial class NpccSubbasinProvince : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected NpccSubbasinProvince()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public NpccSubbasinProvince(int npccSubbasinProvinceID, int subbasinID, int npccProvinceID) : this()
        {
            this.NpccSubbasinProvinceID = npccSubbasinProvinceID;
            this.SubbasinID = subbasinID;
            this.NpccProvinceID = npccProvinceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public NpccSubbasinProvince(int subbasinID, int npccProvinceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NpccSubbasinProvinceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SubbasinID = subbasinID;
            this.NpccProvinceID = npccProvinceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public NpccSubbasinProvince(GeospatialArea subbasin, NpccProvince npccProvince) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NpccSubbasinProvinceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SubbasinID = subbasin.GeospatialAreaID;
            this.Subbasin = subbasin;
            subbasin.NpccSubbasinProvincesWhereYouAreTheSubbasin.Add(this);
            this.NpccProvinceID = npccProvince.NpccProvinceID;
            this.NpccProvince = npccProvince;
            npccProvince.NpccSubbasinProvinces.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static NpccSubbasinProvince CreateNewBlank(GeospatialArea subbasin, NpccProvince npccProvince)
        {
            return new NpccSubbasinProvince(subbasin, npccProvince);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(NpccSubbasinProvince).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllNpccSubbasinProvinces.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int NpccSubbasinProvinceID { get; set; }
        public int TenantID { get; set; }
        public int SubbasinID { get; set; }
        public int NpccProvinceID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return NpccSubbasinProvinceID; } set { NpccSubbasinProvinceID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialArea Subbasin { get; set; }
        public virtual NpccProvince NpccProvince { get; set; }

        public static class FieldLengths
        {

        }
    }
}