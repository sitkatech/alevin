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
using CodeFirstStoreFunctions;
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
            this.CustomPageRoles = new HashSet<CustomPageRole>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPage(int customPageID, string customPageDisplayName, string customPageVanityUrl, string customPageContent, int? documentLibraryID, int firmaMenuItemID, int? sortOrder) : this()
        {
            this.CustomPageID = customPageID;
            this.CustomPageDisplayName = customPageDisplayName;
            this.CustomPageVanityUrl = customPageVanityUrl;
            this.CustomPageContent = customPageContent;
            this.DocumentLibraryID = documentLibraryID;
            this.FirmaMenuItemID = firmaMenuItemID;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPage(string customPageDisplayName, string customPageVanityUrl, int firmaMenuItemID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CustomPageDisplayName = customPageDisplayName;
            this.CustomPageVanityUrl = customPageVanityUrl;
            this.FirmaMenuItemID = firmaMenuItemID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CustomPage(string customPageDisplayName, string customPageVanityUrl, FirmaMenuItem firmaMenuItem) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CustomPageDisplayName = customPageDisplayName;
            this.CustomPageVanityUrl = customPageVanityUrl;
            this.FirmaMenuItemID = firmaMenuItem.FirmaMenuItemID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CustomPage CreateNewBlank(FirmaMenuItem firmaMenuItem)
        {
            return new CustomPage(default(string), default(string), firmaMenuItem);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return CustomPageImages.Any() || CustomPageRoles.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(CustomPageImages.Any())
            {
                dependentObjects.Add(typeof(CustomPageImage).Name);
            }

            if(CustomPageRoles.Any())
            {
                dependentObjects.Add(typeof(CustomPageRole).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CustomPage).Name, typeof(CustomPageImage).Name, typeof(CustomPageRole).Name};


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

            foreach(var x in CustomPageRoles.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int CustomPageID { get; set; }
        public int TenantID { get; set; }
        public string CustomPageDisplayName { get; set; }
        public string CustomPageVanityUrl { get; set; }
        public string CustomPageContent { get; set; }
        [NotMapped]
        public HtmlString CustomPageContentHtmlString
        { 
            get { return CustomPageContent == null ? null : new HtmlString(CustomPageContent); }
            set { CustomPageContent = value?.ToString(); }
        }
        public int? DocumentLibraryID { get; set; }
        public int FirmaMenuItemID { get; set; }
        public int? SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CustomPageID; } set { CustomPageID = value; } }

        public virtual ICollection<CustomPageImage> CustomPageImages { get; set; }
        public virtual ICollection<CustomPageRole> CustomPageRoles { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual DocumentLibrary DocumentLibrary { get; set; }
        public FirmaMenuItem FirmaMenuItem { get { return FirmaMenuItem.AllLookupDictionary[FirmaMenuItemID]; } }

        public static class FieldLengths
        {
            public const int CustomPageDisplayName = 100;
            public const int CustomPageVanityUrl = 100;
        }
    }
}