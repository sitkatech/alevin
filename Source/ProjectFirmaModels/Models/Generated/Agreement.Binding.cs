//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Agreement]
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
    // Table [Reclamation].[Agreement] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[Agreement]")]
    public partial class Agreement : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Agreement()
        {
            this.ObligationNumbersWhereYouAreTheReclamationAgreement = new HashSet<ObligationNumber>();
            this.AgreementCostAuthorities = new HashSet<AgreementCostAuthority>();
            this.AgreementPacificNorthActivitiesWhereYouAreTheReclamationAgreement = new HashSet<AgreementPacificNorthActivity>();
            this.AgreementRequests = new HashSet<AgreementRequest>();
            this.ReclamationStagingCostAuthorityAgreements = new HashSet<ReclamationStagingCostAuthorityAgreement>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Agreement(int agreementID, int? original_ReclamationAgreementID, string agreementNumber, double? contractorLU, bool isContingent, bool isIncrementalFunding, string oldAgreementNumber, string cOR, double? technicalRepresentative, string bOC, string contractNumber, string expirationDate, string financialReporting, int? organizationID, int contractTypeID) : this()
        {
            this.AgreementID = agreementID;
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
        public Agreement(bool isContingent, bool isIncrementalFunding, int contractTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AgreementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IsContingent = isContingent;
            this.IsIncrementalFunding = isIncrementalFunding;
            this.ContractTypeID = contractTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Agreement(bool isContingent, bool isIncrementalFunding, ContractType contractType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AgreementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IsContingent = isContingent;
            this.IsIncrementalFunding = isIncrementalFunding;
            this.ContractTypeID = contractType.ReclamationContractTypeID;
            this.ContractType = contractType;
            contractType.AgreementsWhereYouAreTheContractType.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Agreement CreateNewBlank(ContractType contractType)
        {
            return new Agreement(default(bool), default(bool), contractType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ObligationNumbersWhereYouAreTheReclamationAgreement.Any() || AgreementCostAuthorities.Any() || AgreementPacificNorthActivitiesWhereYouAreTheReclamationAgreement.Any() || AgreementRequests.Any() || ReclamationStagingCostAuthorityAgreements.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Agreement).Name, typeof(ObligationNumber).Name, typeof(AgreementCostAuthority).Name, typeof(AgreementPacificNorthActivity).Name, typeof(AgreementRequest).Name, typeof(ReclamationStagingCostAuthorityAgreement).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.Agreements.Remove(this);
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

            foreach(var x in ObligationNumbersWhereYouAreTheReclamationAgreement.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in AgreementCostAuthorities.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in AgreementPacificNorthActivitiesWhereYouAreTheReclamationAgreement.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in AgreementRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationStagingCostAuthorityAgreements.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int AgreementID { get; set; }
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
        public int PrimaryKey { get { return AgreementID; } set { AgreementID = value; } }

        public virtual ICollection<ObligationNumber> ObligationNumbersWhereYouAreTheReclamationAgreement { get; set; }
        public virtual ICollection<AgreementCostAuthority> AgreementCostAuthorities { get; set; }
        public virtual ICollection<AgreementPacificNorthActivity> AgreementPacificNorthActivitiesWhereYouAreTheReclamationAgreement { get; set; }
        public virtual ICollection<AgreementRequest> AgreementRequests { get; set; }
        public virtual ICollection<ReclamationStagingCostAuthorityAgreement> ReclamationStagingCostAuthorityAgreements { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ContractType ContractType { get; set; }

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