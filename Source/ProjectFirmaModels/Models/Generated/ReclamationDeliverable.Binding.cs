//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationDeliverable]
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
    // Table [dbo].[ReclamationDeliverable] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationDeliverable]")]
    public partial class ReclamationDeliverable : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationDeliverable()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationDeliverable(int reclamationDeliverableID, int? original_ReclamationDeliverableID, int? reclamationAgreementStatusID, int? deliverableTypeID, string description, DateTime? dueDate, DateTime? dateDelivered, bool isTaskCompleted, bool isTaskCanceled, int? reclamationPersonsTableID, int? costAuthorityAgreementID) : this()
        {
            this.ReclamationDeliverableID = reclamationDeliverableID;
            this.Original_ReclamationDeliverableID = original_ReclamationDeliverableID;
            this.ReclamationAgreementStatusID = reclamationAgreementStatusID;
            this.DeliverableTypeID = deliverableTypeID;
            this.Description = description;
            this.DueDate = dueDate;
            this.DateDelivered = dateDelivered;
            this.IsTaskCompleted = isTaskCompleted;
            this.IsTaskCanceled = isTaskCanceled;
            this.ReclamationPersonsTableID = reclamationPersonsTableID;
            this.CostAuthorityAgreementID = costAuthorityAgreementID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationDeliverable(bool isTaskCompleted, bool isTaskCanceled) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationDeliverableID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IsTaskCompleted = isTaskCompleted;
            this.IsTaskCanceled = isTaskCanceled;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationDeliverable CreateNewBlank()
        {
            return new ReclamationDeliverable(default(bool), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationDeliverable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationDeliverables.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationDeliverableID { get; set; }
        public int? Original_ReclamationDeliverableID { get; set; }
        public int? ReclamationAgreementStatusID { get; set; }
        public int? DeliverableTypeID { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateDelivered { get; set; }
        public bool IsTaskCompleted { get; set; }
        public bool IsTaskCanceled { get; set; }
        public int? ReclamationPersonsTableID { get; set; }
        public int? CostAuthorityAgreementID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationDeliverableID; } set { ReclamationDeliverableID = value; } }

        public virtual ReclamationDeliverableType DeliverableType { get; set; }
        public virtual ReclamationStagingCostAuthorityAgreement CostAuthorityAgreement { get; set; }

        public static class FieldLengths
        {
            public const int Description = 500;
        }
    }
}