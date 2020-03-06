//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationCostAuthorityAgreementRequest]
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
    // Table [Reclamation].[ReclamationCostAuthorityAgreementRequest] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationCostAuthorityAgreementRequest]")]
    public partial class ReclamationCostAuthorityAgreementRequest : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationCostAuthorityAgreementRequest()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationCostAuthorityAgreementRequest(int reclamationCostAuthorityAgreementRequestID, int costAuthorityID, int agreementRequestID, decimal? projectedObligation, string reclamationCostAuthorityAgreementRequestNote) : this()
        {
            this.ReclamationCostAuthorityAgreementRequestID = reclamationCostAuthorityAgreementRequestID;
            this.CostAuthorityID = costAuthorityID;
            this.AgreementRequestID = agreementRequestID;
            this.ProjectedObligation = projectedObligation;
            this.ReclamationCostAuthorityAgreementRequestNote = reclamationCostAuthorityAgreementRequestNote;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationCostAuthorityAgreementRequest(int costAuthorityID, int agreementRequestID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationCostAuthorityAgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CostAuthorityID = costAuthorityID;
            this.AgreementRequestID = agreementRequestID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReclamationCostAuthorityAgreementRequest(ReclamationCostAuthority costAuthority, AgreementRequest agreementRequest) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationCostAuthorityAgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CostAuthorityID = costAuthority.ReclamationCostAuthorityID;
            this.CostAuthority = costAuthority;
            costAuthority.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheCostAuthority.Add(this);
            this.AgreementRequestID = agreementRequest.ReclamationAgreementRequestID;
            this.AgreementRequest = agreementRequest;
            agreementRequest.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationCostAuthorityAgreementRequest CreateNewBlank(ReclamationCostAuthority costAuthority, AgreementRequest agreementRequest)
        {
            return new ReclamationCostAuthorityAgreementRequest(costAuthority, agreementRequest);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationCostAuthorityAgreementRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationCostAuthorityAgreementRequests.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationCostAuthorityAgreementRequestID { get; set; }
        public int CostAuthorityID { get; set; }
        public int AgreementRequestID { get; set; }
        public decimal? ProjectedObligation { get; set; }
        public string ReclamationCostAuthorityAgreementRequestNote { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationCostAuthorityAgreementRequestID; } set { ReclamationCostAuthorityAgreementRequestID = value; } }

        public virtual ReclamationCostAuthority CostAuthority { get; set; }
        public virtual AgreementRequest AgreementRequest { get; set; }

        public static class FieldLengths
        {
            public const int ReclamationCostAuthorityAgreementRequestNote = 800;
        }
    }
}