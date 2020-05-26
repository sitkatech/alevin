//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingPostedObligation]
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
    // Table [Reclamation].[ReclamationStagingPostedObligation] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationStagingPostedObligation]")]
    public partial class ReclamationStagingPostedObligation : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingPostedObligation()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingPostedObligation(int reclamationStagingPostedObligationID, int? originalPostedObligationsID, int? originalReclamationCostAuthorityAgreementID, int? originalAgreementStatusID, string fund, string program, string jobNumber, string bOC, int? fiscalYear, string agreementNumber, string contractorName, double? mods, double? line, DateTime? beginDate, DateTime? lastOfMonthEnding, decimal? lastOfAmount, string amount) : this()
        {
            this.ReclamationStagingPostedObligationID = reclamationStagingPostedObligationID;
            this.OriginalPostedObligationsID = originalPostedObligationsID;
            this.OriginalReclamationCostAuthorityAgreementID = originalReclamationCostAuthorityAgreementID;
            this.OriginalAgreementStatusID = originalAgreementStatusID;
            this.Fund = fund;
            this.Program = program;
            this.JobNumber = jobNumber;
            this.BOC = bOC;
            this.FiscalYear = fiscalYear;
            this.AgreementNumber = agreementNumber;
            this.ContractorName = contractorName;
            this.Mods = mods;
            this.Line = line;
            this.BeginDate = beginDate;
            this.LastOfMonthEnding = lastOfMonthEnding;
            this.LastOfAmount = lastOfAmount;
            this.Amount = amount;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingPostedObligation CreateNewBlank()
        {
            return new ReclamationStagingPostedObligation();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingPostedObligation).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingPostedObligations.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationStagingPostedObligationID { get; set; }
        public int? OriginalPostedObligationsID { get; set; }
        public int? OriginalReclamationCostAuthorityAgreementID { get; set; }
        public int? OriginalAgreementStatusID { get; set; }
        public string Fund { get; set; }
        public string Program { get; set; }
        public string JobNumber { get; set; }
        public string BOC { get; set; }
        public int? FiscalYear { get; set; }
        public string AgreementNumber { get; set; }
        public string ContractorName { get; set; }
        public double? Mods { get; set; }
        public double? Line { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? LastOfMonthEnding { get; set; }
        public decimal? LastOfAmount { get; set; }
        public string Amount { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingPostedObligationID; } set { ReclamationStagingPostedObligationID = value; } }



        public static class FieldLengths
        {
            public const int Fund = 255;
            public const int Program = 255;
            public const int JobNumber = 255;
            public const int BOC = 255;
            public const int AgreementNumber = 255;
            public const int ContractorName = 255;
            public const int Amount = 255;
        }
    }
}