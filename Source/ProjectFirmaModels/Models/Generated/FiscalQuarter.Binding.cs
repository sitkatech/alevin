//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[FiscalQuarter]
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
    // Table [ImportFinancial].[FiscalQuarter] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[FiscalQuarter]")]
    public partial class FiscalQuarter : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FiscalQuarter()
        {
            this.WbsElementPnBudgets = new HashSet<WbsElementPnBudget>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FiscalQuarter(int fiscalQuarterID, int fiscalQuarterNumber, string fiscalQuarterName, string fiscalQuarterDisplayName, int fiscalQuarterStartCalendarMonth, int fiscalQuarterStartCalendarDay) : this()
        {
            this.FiscalQuarterID = fiscalQuarterID;
            this.FiscalQuarterNumber = fiscalQuarterNumber;
            this.FiscalQuarterName = fiscalQuarterName;
            this.FiscalQuarterDisplayName = fiscalQuarterDisplayName;
            this.FiscalQuarterStartCalendarMonth = fiscalQuarterStartCalendarMonth;
            this.FiscalQuarterStartCalendarDay = fiscalQuarterStartCalendarDay;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FiscalQuarter(int fiscalQuarterNumber, string fiscalQuarterName, string fiscalQuarterDisplayName, int fiscalQuarterStartCalendarMonth, int fiscalQuarterStartCalendarDay) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FiscalQuarterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FiscalQuarterNumber = fiscalQuarterNumber;
            this.FiscalQuarterName = fiscalQuarterName;
            this.FiscalQuarterDisplayName = fiscalQuarterDisplayName;
            this.FiscalQuarterStartCalendarMonth = fiscalQuarterStartCalendarMonth;
            this.FiscalQuarterStartCalendarDay = fiscalQuarterStartCalendarDay;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FiscalQuarter CreateNewBlank()
        {
            return new FiscalQuarter(default(int), default(string), default(string), default(int), default(int));
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(WbsElementPnBudgets.Any())
            {
                dependentObjects.Add(typeof(WbsElementPnBudget).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FiscalQuarter).Name, typeof(WbsElementPnBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.FiscalQuarters.Remove(this);
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
        public int FiscalQuarterID { get; set; }
        public int FiscalQuarterNumber { get; set; }
        public string FiscalQuarterName { get; set; }
        public string FiscalQuarterDisplayName { get; set; }
        public int FiscalQuarterStartCalendarMonth { get; set; }
        public int FiscalQuarterStartCalendarDay { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FiscalQuarterID; } set { FiscalQuarterID = value; } }

        public virtual ICollection<WbsElementPnBudget> WbsElementPnBudgets { get; set; }

        public static class FieldLengths
        {
            public const int FiscalQuarterName = 100;
            public const int FiscalQuarterDisplayName = 100;
        }
    }
}