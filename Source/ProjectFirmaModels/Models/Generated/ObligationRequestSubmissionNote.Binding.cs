//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequestSubmissionNote]
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
    // Table [Reclamation].[ObligationRequestSubmissionNote] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ObligationRequestSubmissionNote]")]
    public partial class ObligationRequestSubmissionNote : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ObligationRequestSubmissionNote()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationRequestSubmissionNote(int obligationRequestSubmissionNoteID, int obligationRequestID, string note, int? createPersonID, DateTime createDate, int? updatePersonID, DateTime? updateDate) : this()
        {
            this.ObligationRequestSubmissionNoteID = obligationRequestSubmissionNoteID;
            this.ObligationRequestID = obligationRequestID;
            this.Note = note;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
            this.UpdatePersonID = updatePersonID;
            this.UpdateDate = updateDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationRequestSubmissionNote(int obligationRequestID, string note, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ObligationRequestSubmissionNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ObligationRequestID = obligationRequestID;
            this.Note = note;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ObligationRequestSubmissionNote(ObligationRequest obligationRequest, string note, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ObligationRequestSubmissionNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ObligationRequestID = obligationRequest.ObligationRequestID;
            this.ObligationRequest = obligationRequest;
            obligationRequest.ObligationRequestSubmissionNotes.Add(this);
            this.Note = note;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ObligationRequestSubmissionNote CreateNewBlank(ObligationRequest obligationRequest)
        {
            return new ObligationRequestSubmissionNote(obligationRequest, default(string), default(DateTime));
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ObligationRequestSubmissionNote).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ObligationRequestSubmissionNotes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ObligationRequestSubmissionNoteID { get; set; }
        public int ObligationRequestID { get; set; }
        public string Note { get; set; }
        public int? CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdatePersonID { get; set; }
        public DateTime? UpdateDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ObligationRequestSubmissionNoteID; } set { ObligationRequestSubmissionNoteID = value; } }

        public virtual ObligationRequest ObligationRequest { get; set; }
        public virtual Person CreatePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int Note = 8000;
        }
    }
}