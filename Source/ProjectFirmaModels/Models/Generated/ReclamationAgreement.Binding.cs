//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationAgreement]
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
    // Table [Reclamation].[ReclamationAgreement] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationAgreement]")]
    public partial class ReclamationAgreement : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationAgreement()
        {
            this.ObligationNumbers = new HashSet<ObligationNumber>();
            this.ReclamationAgreementPacificNorthActivities = new HashSet<ReclamationAgreementPacificNorthActivity>();
            this.ReclamationAgreementReclamationCostAuthorities = new HashSet<ReclamationAgreementReclamationCostAuthority>();
            this.ReclamationAgreementRequestsWhereYouAreTheAgreement = new HashSet<ReclamationAgreementRequest>();
            this.ReclamationStagingCostAuthorityAgreementsWhereYouAreTheAgreement = new HashSet<ReclamationStagingCostAuthorityAgreement>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreement(int reclamationAgreementID, int? original_ReclamationAgreementID, string agreementNumber, double? contractorLU, bool isContingent, bool isIncrementalFunding, string oldAgreementNumber, string cOR, double? technicalRepresentative, string bOC, string contractNumber, string expirationDate, string financialReporting, int? organizationID, int contractTypeID) : this()
        {
            this.ReclamationAgreementID = reclamationAgreementID;
            this.Original_ReclamationAgreementID = original_ReclamationAgreementID;
            this.AgreementNumber = agreementNumber;
            this.ContractorLU = contractorLU;
            this.IsContingent = isContingent;
            this.IsIncrementalFunding = isIncrementalFunding;
            this.OldAgreementNumber = oldAgreementNumber;
            this.COR = cOR;
            this.TechnicalRepresentative = technicalRepresentative;
            this.BOC = bOC;
            this.ContractNumber = contractNumber;
            this.ExpirationDate = expirationDate;
            this.FinancialReporting = financialReporting;
            this.OrganizationID = organizationID;
            this.ContractTypeID = contractTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreement(bool isContingent, bool isIncrementalFunding, int contractTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IsContingent = isContingent;
            this.IsIncrementalFunding = isIncrementalFunding;
            this.ContractTypeID = contractTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReclamationAgreement(bool isContingent, bool isIncrementalFunding, ReclamationContractType contractType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IsContingent = isContingent;
            this.IsIncrementalFunding = isIncrementalFunding;
            this.ContractTypeID = contractType.ReclamationContractTypeID;
            this.ContractType = contractType;
            contractType.ReclamationAgreementsWhereYouAreTheContractType.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationAgreement CreateNewBlank(ReclamationContractType contractType)
        {
            return new ReclamationAgreement(default(bool), default(bool), contractType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ObligationNumbers.Any() || ReclamationAgreementPacificNorthActivities.Any() || ReclamationAgreementReclamationCostAuthorities.Any() || ReclamationAgreementRequestsWhereYouAreTheAgreement.Any() || ReclamationStagingCostAuthorityAgreementsWhereYouAreTheAgreement.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationAgreement).Name, typeof(ObligationNumber).Name, typeof(ReclamationAgreementPacificNorthActivity).Name, typeof(ReclamationAgreementReclamationCostAuthority).Name, typeof(ReclamationAgreementRequest).Name, typeof(ReclamationStagingCostAuthorityAgreement).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationAgreements.Remove(this);
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

            foreach(var x in ObligationNumbers.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationAgreementPacificNorthActivities.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationAgreementReclamationCostAuthorities.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationAgreementRequestsWhereYouAreTheAgreement.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationStagingCostAuthorityAgreementsWhereYouAreTheAgreement.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationAgreementID { get; set; }
        public int? Original_ReclamationAgreementID { get; set; }
        public string AgreementNumber { get; set; }
        public double? ContractorLU { get; set; }
        public bool IsContingent { get; set; }
        public bool IsIncrementalFunding { get; set; }
        public string OldAgreementNumber { get; set; }
        public string COR { get; set; }
        public double? TechnicalRepresentative { get; set; }
        public string BOC { get; set; }
        public string ContractNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string FinancialReporting { get; set; }
        public int? OrganizationID { get; set; }
        public int ContractTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationAgreementID; } set { ReclamationAgreementID = value; } }

        public virtual ICollection<ObligationNumber> ObligationNumbers { get; set; }
        public virtual ICollection<ReclamationAgreementPacificNorthActivity> ReclamationAgreementPacificNorthActivities { get; set; }
        public virtual ICollection<ReclamationAgreementReclamationCostAuthority> ReclamationAgreementReclamationCostAuthorities { get; set; }
        public virtual ICollection<ReclamationAgreementRequest> ReclamationAgreementRequestsWhereYouAreTheAgreement { get; set; }
        public virtual ICollection<ReclamationStagingCostAuthorityAgreement> ReclamationStagingCostAuthorityAgreementsWhereYouAreTheAgreement { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ReclamationContractType ContractType { get; set; }

        public static class FieldLengths
        {
            public const int AgreementNumber = 255;
            public const int OldAgreementNumber = 255;
            public const int COR = 255;
            public const int BOC = 255;
            public const int ContractNumber = 255;
            public const int ExpirationDate = 255;
            public const int FinancialReporting = 255;
        }
    }
}