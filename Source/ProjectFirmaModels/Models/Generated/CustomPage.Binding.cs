//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPage]
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
    // Table [dbo].[CustomPage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[CustomPage]")]
    public partial class CustomPage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CustomPage()
        {
            this.CustomPageImages = new HashSet<CustomPageImage>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPage(int customPageID, string customPageDisplayName, string customPageVanityUrl, int customPageDisplayTypeID, string customPageContent, int? documentLibraryID) : this()
        {
            this.CustomPageID = customPageID;
            this.CustomPageDisplayName = customPageDisplayName;
            this.CustomPageVanityUrl = customPageVanityUrl;
            this.CustomPageDisplayTypeID = customPageDisplayTypeID;
            this.CustomPageContent = customPageContent;
            this.DocumentLibraryID = documentLibraryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPage(string customPageDisplayName, string customPageVanityUrl, int customPageDisplayTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CustomPageDisplayName = customPageDisplayName;
            this.CustomPageVanityUrl = customPageVanityUrl;
            this.CustomPageDisplayTypeID = customPageDisplayTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CustomPage(string customPageDisplayName, string customPageVanityUrl, CustomPageDisplayType customPageDisplayType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CustomPageDisplayName = customPageDisplayName;
            this.CustomPageVanityUrl = customPageVanityUrl;
            this.CustomPageDisplayTypeID = customPageDisplayType.CustomPageDisplayTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CustomPage CreateNewBlank(CustomPageDisplayType customPageDisplayType)
        {
            return new CustomPage(default(string), default(string), customPageDisplayType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return CustomPageImages.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CustomPage).Name, typeof(CustomPageImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllCustomPages.Remove(this);
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

            foreach(var x in CustomPageImages.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int CustomPageID { get; set; }
        public int TenantID { get; set; }
        public string CustomPageDisplayName { get; set; }
        public string CustomPageVanityUrl { get; set; }
        public int CustomPageDisplayTypeID { get; set; }
        public string CustomPageContent { get; set; }
        [NotMapped]
        public HtmlString CustomPageContentHtmlString
        { 
            get { return CustomPageContent == null ? null : new HtmlString(CustomPageContent); }
            set { CustomPageContent = value?.ToString(); }
        }
        public int? DocumentLibraryID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CustomPageID; } set { CustomPageID = value; } }

        public virtual ICollection<CustomPageImage> CustomPageImages { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public CustomPageDisplayType CustomPageDisplayType { get { return CustomPageDisplayType.AllLookupDictionary[CustomPageDisplayTypeID]; } }
        public virtual DocumentLibrary DocumentLibrary { get; set; }

        public static class FieldLengths
        {
            public const int CustomPageDisplayName = 100;
            public const int CustomPageVanityUrl = 100;
        }
    }
}