//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ObligationNumber]
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
    // Table [ImportFinancial].[ObligationNumber] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[ObligationNumber]")]
    public partial class ObligationNumber : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ObligationNumber()
        {
            this.ObligationItems = new HashSet<ObligationItem>();
            this.CostAuthorityObligationRequestPotentialObligationNumberMatches = new HashSet<CostAuthorityObligationRequestPotentialObligationNumberMatch>();
            this.ObligationRequests = new HashSet<ObligationRequest>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationNumber(int obligationNumberID, string obligationNumberKey, int? reclamationAgreementID) : this()
        {
            this.ObligationNumberID = obligationNumberID;
            this.ObligationNumberKey = obligationNumberKey;
            this.ReclamationAgreementID = reclamationAgreementID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationNumber(string obligationNumberKey) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ObligationNumberID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ObligationNumberKey = obligationNumberKey;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ObligationNumber CreateNewBlank()
        {
            return new ObligationNumber(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ObligationItems.Any() || CostAuthorityObligationRequestPotentialObligationNumberMatches.Any() || ObligationRequests.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ObligationItems.Any())
            {
                dependentObjects.Add(typeof(ObligationItem).Name);
            }

            if(CostAuthorityObligationRequestPotentialObligationNumberMatches.Any())
            {
                dependentObjects.Add(typeof(CostAuthorityObligationRequestPotentialObligationNumberMatch).Name);
            }

            if(ObligationRequests.Any())
            {
                dependentObjects.Add(typeof(ObligationRequest).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ObligationNumber).Name, typeof(ObligationItem).Name, typeof(CostAuthorityObligationRequestPotentialObligationNumberMatch).Name, typeof(ObligationRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ObligationNumbers.Remove(this);
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

            foreach(var x in ObligationItems.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorityObligationRequestPotentialObligationNumberMatches.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ObligationRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ObligationNumberID { get; set; }
        public string ObligationNumberKey { get; set; }
        public int? ReclamationAgreementID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ObligationNumberID; } set { ObligationNumberID = value; } }

        public virtual ICollection<ObligationItem> ObligationItems { get; set; }
        public virtual ICollection<CostAuthorityObligationRequestPotentialObligationNumberMatch> CostAuthorityObligationRequestPotentialObligationNumberMatches { get; set; }
        public virtual ICollection<ObligationRequest> ObligationRequests { get; set; }
        public virtual Agreement ReclamationAgreement { get; set; }

        public static class FieldLengths
        {
            public const int ObligationNumberKey = 100;
        }
    }
}