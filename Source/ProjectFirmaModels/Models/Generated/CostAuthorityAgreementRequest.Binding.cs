//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityAgreementRequest]
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
    // Table [Reclamation].[CostAuthorityAgreementRequest] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[CostAuthorityAgreementRequest]")]
    public partial class CostAuthorityAgreementRequest : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostAuthorityAgreementRequest()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthorityAgreementRequest(int costAuthorityAgreementRequestID, int costAuthorityID, int agreementRequestID, decimal? projectedObligation, string reclamationCostAuthorityAgreementRequestNote) : this()
        {
            this.CostAuthorityAgreementRequestID = costAuthorityAgreementRequestID;
            this.CostAuthorityID = costAuthorityID;
            this.AgreementRequestID = agreementRequestID;
            this.ProjectedObligation = projectedObligation;
            this.ReclamationCostAuthorityAgreementRequestNote = reclamationCostAuthorityAgreementRequestNote;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthorityAgreementRequest(int costAuthorityID, int agreementRequestID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostAuthorityAgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CostAuthorityID = costAuthorityID;
            this.AgreementRequestID = agreementRequestID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CostAuthorityAgreementRequest(CostAuthority costAuthority, AgreementRequest agreementRequest) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostAuthorityAgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CostAuthorityID = costAuthority.CostAuthorityID;
            this.CostAuthority = costAuthority;
            costAuthority.CostAuthorityAgreementRequests.Add(this);
            this.AgreementRequestID = agreementRequest.AgreementRequestID;
            this.AgreementRequest = agreementRequest;
            agreementRequest.CostAuthorityAgreementRequests.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostAuthorityAgreementRequest CreateNewBlank(CostAuthority costAuthority, AgreementRequest agreementRequest)
        {
            return new CostAuthorityAgreementRequest(costAuthority, agreementRequest);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostAuthorityAgreementRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.CostAuthorityAgreementRequests.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int CostAuthorityAgreementRequestID { get; set; }
        public int CostAuthorityID { get; set; }
        public int AgreementRequestID { get; set; }
        public decimal? ProjectedObligation { get; set; }
        public string ReclamationCostAuthorityAgreementRequestNote { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CostAuthorityAgreementRequestID; } set { CostAuthorityAgreementRequestID = value; } }

        public virtual CostAuthority CostAuthority { get; set; }
        public virtual AgreementRequest AgreementRequest { get; set; }

        public static class FieldLengths
        {
            public const int ReclamationCostAuthorityAgreementRequestNote = 800;
        }
    }
}