//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingContractStatus]
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
    // Table [dbo].[ReclamationStagingContractStatus] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationStagingContractStatus]")]
    public partial class ReclamationStagingContractStatus : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingContractStatus()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingContractStatus(int reclamationStagingContractStatusID, string reclamationStagingContractStatusName, int? steps, string reclamationStagingContractStatusType) : this()
        {
            this.ReclamationStagingContractStatusID = reclamationStagingContractStatusID;
            this.ReclamationStagingContractStatusName = reclamationStagingContractStatusName;
            this.Steps = steps;
            this.ReclamationStagingContractStatusType = reclamationStagingContractStatusType;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingContractStatus CreateNewBlank()
        {
            return new ReclamationStagingContractStatus();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingContractStatus).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingContractStatuses.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationStagingContractStatusID { get; set; }
        public string ReclamationStagingContractStatusName { get; set; }
        public int? Steps { get; set; }
        public string ReclamationStagingContractStatusType { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingContractStatusID; } set { ReclamationStagingContractStatusID = value; } }



        public static class FieldLengths
        {
            public const int ReclamationStagingContractStatusName = 255;
            public const int ReclamationStagingContractStatusType = 255;
        }
    }
}