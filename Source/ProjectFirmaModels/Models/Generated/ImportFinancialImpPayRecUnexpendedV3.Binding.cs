//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImportFinancialImpPayRecUnexpendedV3]
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
    // Table [ImportFinancial].[ImportFinancialImpPayRecUnexpendedV3] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[ImportFinancialImpPayRecUnexpendedV3]")]
    public partial class ImportFinancialImpPayRecUnexpendedV3 : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ImportFinancialImpPayRecUnexpendedV3()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImportFinancialImpPayRecUnexpendedV3(int importFinancialImpPayRecUnexpendedV3ID, string businessArea, string fABudgetActivity, string functionalArea, string obligationNumber, string obligationItem, string fund, string wBSElement, string wBSElementDescription, string budgetObjectClass, string vendor, string vendorName, DateTime? postingDatePerSpl, double? unexpendedBalance) : this()
        {
            this.ImportFinancialImpPayRecUnexpendedV3ID = importFinancialImpPayRecUnexpendedV3ID;
            this.BusinessArea = businessArea;
            this.FABudgetActivity = fABudgetActivity;
            this.FunctionalArea = functionalArea;
            this.ObligationNumber = obligationNumber;
            this.ObligationItem = obligationItem;
            this.Fund = fund;
            this.WBSElement = wBSElement;
            this.WBSElementDescription = wBSElementDescription;
            this.BudgetObjectClass = budgetObjectClass;
            this.Vendor = vendor;
            this.VendorName = vendorName;
            this.PostingDatePerSpl = postingDatePerSpl;
            this.UnexpendedBalance = unexpendedBalance;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ImportFinancialImpPayRecUnexpendedV3 CreateNewBlank()
        {
            return new ImportFinancialImpPayRecUnexpendedV3();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ImportFinancialImpPayRecUnexpendedV3).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ImportFinancialImpPayRecUnexpendedV3s.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ImportFinancialImpPayRecUnexpendedV3ID { get; set; }
        public string BusinessArea { get; set; }
        public string FABudgetActivity { get; set; }
        public string FunctionalArea { get; set; }
        public string ObligationNumber { get; set; }
        public string ObligationItem { get; set; }
        public string Fund { get; set; }
        public string WBSElement { get; set; }
        public string WBSElementDescription { get; set; }
        public string BudgetObjectClass { get; set; }
        public string Vendor { get; set; }
        public string VendorName { get; set; }
        public DateTime? PostingDatePerSpl { get; set; }
        public double? UnexpendedBalance { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ImportFinancialImpPayRecUnexpendedV3ID; } set { ImportFinancialImpPayRecUnexpendedV3ID = value; } }



        public static class FieldLengths
        {
            public const int BusinessArea = 255;
            public const int FABudgetActivity = 255;
            public const int FunctionalArea = 255;
            public const int ObligationNumber = 255;
            public const int ObligationItem = 255;
            public const int Fund = 255;
            public const int WBSElement = 255;
            public const int WBSElementDescription = 255;
            public const int BudgetObjectClass = 255;
            public const int Vendor = 255;
            public const int VendorName = 255;
        }
    }
}