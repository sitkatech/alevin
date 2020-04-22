//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityObligationRequest]
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
    // Table [Reclamation].[CostAuthorityObligationRequest] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[CostAuthorityObligationRequest]")]
    public partial class CostAuthorityObligationRequest : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostAuthorityObligationRequest()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthorityObligationRequest(int costAuthorityObligationRequestID, int costAuthorityID, int obligationRequestID, decimal? projectedObligation, string costAuthorityObligationRequestNote) : this()
        {
            this.CostAuthorityObligationRequestID = costAuthorityObligationRequestID;
            this.CostAuthorityID = costAuthorityID;
            this.ObligationRequestID = obligationRequestID;
            this.ProjectedObligation = projectedObligation;
            this.CostAuthorityObligationRequestNote = costAuthorityObligationRequestNote;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthorityObligationRequest(int costAuthorityID, int obligationRequestID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostAuthorityObligationRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CostAuthorityID = costAuthorityID;
            this.ObligationRequestID = obligationRequestID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CostAuthorityObligationRequest(CostAuthority costAuthority, ObligationRequest obligationRequest) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostAuthorityObligationRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CostAuthorityID = costAuthority.CostAuthorityID;
            this.CostAuthority = costAuthority;
            costAuthority.CostAuthorityObligationRequests.Add(this);
            this.ObligationRequestID = obligationRequest.ObligationRequestID;
            this.ObligationRequest = obligationRequest;
            obligationRequest.CostAuthorityObligationRequests.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostAuthorityObligationRequest CreateNewBlank(CostAuthority costAuthority, ObligationRequest obligationRequest)
        {
            return new CostAuthorityObligationRequest(costAuthority, obligationRequest);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostAuthorityObligationRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.CostAuthorityObligationRequests.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int CostAuthorityObligationRequestID { get; set; }
        public int CostAuthorityID { get; set; }
        public int ObligationRequestID { get; set; }
        public decimal? ProjectedObligation { get; set; }
        public string CostAuthorityObligationRequestNote { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CostAuthorityObligationRequestID; } set { CostAuthorityObligationRequestID = value; } }

        public virtual CostAuthority CostAuthority { get; set; }
        public virtual ObligationRequest ObligationRequest { get; set; }

        public static class FieldLengths
        {
            public const int CostAuthorityObligationRequestNote = 800;
        }
    }
}