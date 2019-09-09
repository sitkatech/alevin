//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementPacificNorthActivity]
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
    // Table [dbo].[ReclamationAgreementPacificNorthActivity] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationAgreementPacificNorthActivity]")]
    public partial class ReclamationAgreementPacificNorthActivity : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationAgreementPacificNorthActivity()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementPacificNorthActivity(int reclamationAgreementPacificNorthActivityID, int reclamationAgreementID, int reclamationPacificNorthActivityListID) : this()
        {
            this.ReclamationAgreementPacificNorthActivityID = reclamationAgreementPacificNorthActivityID;
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ReclamationPacificNorthActivityListID = reclamationPacificNorthActivityListID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementPacificNorthActivity(int reclamationAgreementID, int reclamationPacificNorthActivityListID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementPacificNorthActivityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ReclamationPacificNorthActivityListID = reclamationPacificNorthActivityListID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReclamationAgreementPacificNorthActivity(ReclamationAgreement reclamationAgreement, ReclamationPacificNorthActivityList reclamationPacificNorthActivityList) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementPacificNorthActivityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ReclamationAgreementID = reclamationAgreement.ReclamationAgreementID;
            this.ReclamationAgreement = reclamationAgreement;
            reclamationAgreement.ReclamationAgreementPacificNorthActivities.Add(this);
            this.ReclamationPacificNorthActivityListID = reclamationPacificNorthActivityList.ReclamationPacificNorthActivityListID;
            this.ReclamationPacificNorthActivityList = reclamationPacificNorthActivityList;
            reclamationPacificNorthActivityList.ReclamationAgreementPacificNorthActivities.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationAgreementPacificNorthActivity CreateNewBlank(ReclamationAgreement reclamationAgreement, ReclamationPacificNorthActivityList reclamationPacificNorthActivityList)
        {
            return new ReclamationAgreementPacificNorthActivity(reclamationAgreement, reclamationPacificNorthActivityList);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationAgreementPacificNorthActivity).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationAgreementPacificNorthActivities.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationAgreementPacificNorthActivityID { get; set; }
        public int ReclamationAgreementID { get; set; }
        public int ReclamationPacificNorthActivityListID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationAgreementPacificNorthActivityID; } set { ReclamationAgreementPacificNorthActivityID = value; } }

        public virtual ReclamationAgreement ReclamationAgreement { get; set; }
        public virtual ReclamationPacificNorthActivityList ReclamationPacificNorthActivityList { get; set; }

        public static class FieldLengths
        {

        }
    }
}