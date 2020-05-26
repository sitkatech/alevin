//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResourceData]
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
    // Table [dbo].[FileResourceData] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FileResourceData]")]
    public partial class FileResourceData : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FileResourceData()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FileResourceData(int fileResourceDataID, int fileResourceID, byte[] data) : this()
        {
            this.FileResourceDataID = fileResourceDataID;
            this.FileResourceID = fileResourceID;
            this.Data = data;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FileResourceData(int fileResourceID, byte[] data) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FileResourceDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceID = fileResourceID;
            this.Data = data;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FileResourceData(FileResource fileResource, byte[] data) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FileResourceDataID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.FileResourceDatas.Add(this);
            this.Data = data;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FileResourceData CreateNewBlank(FileResource fileResource)
        {
            return new FileResourceData(fileResource, default(byte[]));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FileResourceData).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFileResourceDatas.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FileResourceDataID { get; set; }
        public int TenantID { get; set; }
        public int FileResourceID { get; set; }
        public byte[] Data { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FileResourceDataID; } set { FileResourceDataID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}