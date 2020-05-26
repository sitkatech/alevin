//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[PnBudgetFundType]
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
    // Table [ImportFinancial].[PnBudgetFundType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[PnBudgetFundType]")]
    public partial class PnBudgetFundType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PnBudgetFundType()
        {
            this.WbsElementPnBudgets = new HashSet<WbsElementPnBudget>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PnBudgetFundType(int pnBudgetFundTypeID, string pnBudgetFundTypeName, string pnBudgetFundTypeDisplayName) : this()
        {
            this.PnBudgetFundTypeID = pnBudgetFundTypeID;
            this.PnBudgetFundTypeName = pnBudgetFundTypeName;
            this.PnBudgetFundTypeDisplayName = pnBudgetFundTypeDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PnBudgetFundType(string pnBudgetFundTypeName, string pnBudgetFundTypeDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PnBudgetFundTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PnBudgetFundTypeName = pnBudgetFundTypeName;
            this.PnBudgetFundTypeDisplayName = pnBudgetFundTypeDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PnBudgetFundType CreateNewBlank()
        {
            return new PnBudgetFundType(default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PnBudgetFundType).Name, typeof(WbsElementPnBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PnBudgetFundTypes.Remove(this);
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
        public int PnBudgetFundTypeID { get; set; }
        public string PnBudgetFundTypeName { get; set; }
        public string PnBudgetFundTypeDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PnBudgetFundTypeID; } set { PnBudgetFundTypeID = value; } }

        public virtual ICollection<WbsElementPnBudget> WbsElementPnBudgets { get; set; }

        public static class FieldLengths
        {
            public const int PnBudgetFundTypeName = 100;
            public const int PnBudgetFundTypeDisplayName = 100;
        }
    }
}