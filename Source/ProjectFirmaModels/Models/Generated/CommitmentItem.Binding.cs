//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[CommitmentItem]
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
    // Table [ImportFinancial].[CommitmentItem] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[CommitmentItem]")]
    public partial class CommitmentItem : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CommitmentItem()
        {
            this.WbsElementPnBudgets = new HashSet<WbsElementPnBudget>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommitmentItem(int commitmentItemID, string commitmentItemName) : this()
        {
            this.CommitmentItemID = commitmentItemID;
            this.CommitmentItemName = commitmentItemName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommitmentItem(string commitmentItemName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CommitmentItemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CommitmentItemName = commitmentItemName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CommitmentItem CreateNewBlank()
        {
            return new CommitmentItem(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return WbsElementPnBudgets.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CommitmentItem).Name, typeof(WbsElementPnBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.CommitmentItems.Remove(this);
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

            foreach(var x in WbsElementPnBudgets.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int CommitmentItemID { get; set; }
        public string CommitmentItemName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CommitmentItemID; } set { CommitmentItemID = value; } }

        public virtual ICollection<WbsElementPnBudget> WbsElementPnBudgets { get; set; }

        public static class FieldLengths
        {
            public const int CommitmentItemName = 100;
        }
    }
}