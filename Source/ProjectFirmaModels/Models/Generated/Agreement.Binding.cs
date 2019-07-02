//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Agreement]
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
    // Table [dbo].[Agreement] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[Agreement]")]
    public partial class Agreement : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Agreement()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Agreement(int agreementID, int? reclamationAgreementID, string agreementNumber, double? contractorLU, string contractType, bool isContingent, bool isIncrementalFunding, string oldAgreementNumber, string cOR, double? technicalRepresentative, string bOC, string contractNumber, string expirationDate, string financialReporting, int? organizationID) : this()
        {
            this.AgreementID = agreementID;
            this.ReclamationAgreementID = reclamationAgreementID;
            this.AgreementNumber = agreementNumber;
            this.ContractorLU = contractorLU;
            this.ContractType = contractType;
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
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Agreement(bool isContingent, bool isIncrementalFunding) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AgreementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IsContingent = isContingent;
            this.IsIncrementalFunding = isIncrementalFunding;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Agreement CreateNewBlank()
        {
            return new Agreement(default(bool), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Agreement).Name};


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
            
            Delete(dbContext);
        }

        [Key]
        public int AgreementID { get; set; }
        public int? ReclamationAgreementID { get; set; }
        public string AgreementNumber { get; set; }
        public double? ContractorLU { get; set; }
        public string ContractType { get; set; }
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
        [NotMapped]
        public int PrimaryKey { get { return AgreementID; } set { AgreementID = value; } }

        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int AgreementNumber = 255;
            public const int ContractType = 255;
            public const int OldAgreementNumber = 255;
            public const int COR = 255;
            public const int BOC = 255;
            public const int ContractNumber = 255;
            public const int ExpirationDate = 255;
            public const int FinancialReporting = 255;
        }
    }
}