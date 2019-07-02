//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationFund]
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
    // Table [dbo].[ReclamationFund] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationFund]")]
    public partial class ReclamationFund : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationFund()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationFund(int reclamationFundID, string reclamationFundNumber, string description) : this()
        {
            this.ReclamationFundID = reclamationFundID;
            this.ReclamationFundNumber = reclamationFundNumber;
            this.Description = description;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationFund CreateNewBlank()
        {
            return new ReclamationFund();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationFund).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationFunds.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationFundID { get; set; }
        public string ReclamationFundNumber { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationFundID; } set { ReclamationFundID = value; } }



        public static class FieldLengths
        {
            public const int ReclamationFundNumber = 255;
            public const int Description = 255;
        }
    }
}