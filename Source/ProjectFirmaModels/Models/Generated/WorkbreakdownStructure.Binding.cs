//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[WorkbreakdownStructure]
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
    // Table [Reclamation].[WorkbreakdownStructure] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[WorkbreakdownStructure]")]
    public partial class WorkbreakdownStructure : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected WorkbreakdownStructure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WorkbreakdownStructure(int workbreakdownStructureID, string workBreakdownStructureNumber) : this()
        {
            this.WorkbreakdownStructureID = workbreakdownStructureID;
            this.WorkBreakdownStructureNumber = workBreakdownStructureNumber;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public WorkbreakdownStructure(string workBreakdownStructureNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WorkbreakdownStructureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.WorkBreakdownStructureNumber = workBreakdownStructureNumber;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static WorkbreakdownStructure CreateNewBlank()
        {
            return new WorkbreakdownStructure(default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(WorkbreakdownStructure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.WorkbreakdownStructures.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int WorkbreakdownStructureID { get; set; }
        public string WorkBreakdownStructureNumber { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return WorkbreakdownStructureID; } set { WorkbreakdownStructureID = value; } }



        public static class FieldLengths
        {
            public const int WorkBreakdownStructureNumber = 50;
        }
    }
}