//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[WorkBreakdownStructure]
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
    // Table [dbo].[WorkBreakdownStructure] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[WorkBreakdownStructure]")]
    public partial class WorkBreakdownStructure : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected WorkBreakdownStructure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WorkBreakdownStructure(int workBreakdownStructureID, string workBreakdownStructureNumber) : this()
        {
            this.WorkBreakdownStructureID = workBreakdownStructureID;
            this.WorkBreakdownStructureNumber = workBreakdownStructureNumber;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public WorkBreakdownStructure(string workBreakdownStructureNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WorkBreakdownStructureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.WorkBreakdownStructureNumber = workBreakdownStructureNumber;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static WorkBreakdownStructure CreateNewBlank()
        {
            return new WorkBreakdownStructure(default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(WorkBreakdownStructure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.WorkBreakdownStructures.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int WorkBreakdownStructureID { get; set; }
        public string WorkBreakdownStructureNumber { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return WorkBreakdownStructureID; } set { WorkBreakdownStructureID = value; } }



        public static class FieldLengths
        {
            public const int WorkBreakdownStructureNumber = 50;
        }
    }
}