//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationWorkBreakdownStructure]
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
    // Table [dbo].[ReclamationWorkBreakdownStructure] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationWorkBreakdownStructure]")]
    public partial class ReclamationWorkBreakdownStructure : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationWorkBreakdownStructure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationWorkBreakdownStructure(int reclamationWorkBreakdownStructureID, string workBreakdownStructureNumber) : this()
        {
            this.ReclamationWorkBreakdownStructureID = reclamationWorkBreakdownStructureID;
            this.WorkBreakdownStructureNumber = workBreakdownStructureNumber;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationWorkBreakdownStructure(string workBreakdownStructureNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationWorkBreakdownStructureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.WorkBreakdownStructureNumber = workBreakdownStructureNumber;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationWorkBreakdownStructure CreateNewBlank()
        {
            return new ReclamationWorkBreakdownStructure(default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationWorkBreakdownStructure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationWorkBreakdownStructures.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationWorkBreakdownStructureID { get; set; }
        public string WorkBreakdownStructureNumber { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationWorkBreakdownStructureID; } set { ReclamationWorkBreakdownStructureID = value; } }



        public static class FieldLengths
        {
            public const int WorkBreakdownStructureNumber = 50;
        }
    }
}