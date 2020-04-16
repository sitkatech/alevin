//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NpccProvince]
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
    // Table [dbo].[NpccProvince] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[NpccProvince]")]
    public partial class NpccProvince : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected NpccProvince()
        {
            this.NpccSubbasinProvinces = new HashSet<NpccSubbasinProvince>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public NpccProvince(int npccProvinceID, string npccProvinceName, DbGeometry npccProvinceFeature, string npccProvinceDescriptionContent) : this()
        {
            this.NpccProvinceID = npccProvinceID;
            this.NpccProvinceName = npccProvinceName;
            this.NpccProvinceFeature = npccProvinceFeature;
            this.NpccProvinceDescriptionContent = npccProvinceDescriptionContent;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public NpccProvince(string npccProvinceName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.NpccProvinceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.NpccProvinceName = npccProvinceName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static NpccProvince CreateNewBlank()
        {
            return new NpccProvince(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return NpccSubbasinProvinces.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(NpccProvince).Name, typeof(NpccSubbasinProvince).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllNpccProvinces.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in NpccSubbasinProvinces.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int NpccProvinceID { get; set; }
        public int TenantID { get; set; }
        public string NpccProvinceName { get; set; }
        public DbGeometry NpccProvinceFeature { get; set; }
        public string NpccProvinceDescriptionContent { get; set; }
        [NotMapped]
        public HtmlString NpccProvinceDescriptionContentHtmlString
        { 
            get { return NpccProvinceDescriptionContent == null ? null : new HtmlString(NpccProvinceDescriptionContent); }
            set { NpccProvinceDescriptionContent = value?.ToString(); }
        }
        [NotMapped]
        public int PrimaryKey { get { return NpccProvinceID; } set { NpccProvinceID = value; } }

        public virtual ICollection<NpccSubbasinProvince> NpccSubbasinProvinces { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int NpccProvinceName = 150;
        }
    }
}