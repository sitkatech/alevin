//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpProcessing]
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
    // Table [ImportFinancial].[ImpProcessing] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[ImpProcessing]")]
    public partial class ImpProcessing : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ImpProcessing()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImpProcessing(int impProcessingID, int impProcessingTableTypeID, DateTime? uploadDate, DateTime? lastProcessedDate) : this()
        {
            this.ImpProcessingID = impProcessingID;
            this.ImpProcessingTableTypeID = impProcessingTableTypeID;
            this.UploadDate = uploadDate;
            this.LastProcessedDate = lastProcessedDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImpProcessing(int impProcessingTableTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ImpProcessingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ImpProcessingTableTypeID = impProcessingTableTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ImpProcessing(ImpProcessingTableType impProcessingTableType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ImpProcessingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ImpProcessingTableTypeID = impProcessingTableType.ImpProcessingTableTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ImpProcessing CreateNewBlank(ImpProcessingTableType impProcessingTableType)
        {
            return new ImpProcessing(impProcessingTableType);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ImpProcessing).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ImpProcessings.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ImpProcessingID { get; set; }
        public int ImpProcessingTableTypeID { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? LastProcessedDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ImpProcessingID; } set { ImpProcessingID = value; } }

        public ImpProcessingTableType ImpProcessingTableType { get { return ImpProcessingTableType.AllLookupDictionary[ImpProcessingTableTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}