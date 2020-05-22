//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateHistory]
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
    // Table [dbo].[ProjectUpdateHistory] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectUpdateHistory]")]
    public partial class ProjectUpdateHistory : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectUpdateHistory()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateHistory(int projectUpdateHistoryID, int projectUpdateBatchID, int projectUpdateStateID, int updatePersonID, DateTime transitionDate) : this()
        {
            this.ProjectUpdateHistoryID = projectUpdateHistoryID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectUpdateStateID = projectUpdateStateID;
            this.UpdatePersonID = updatePersonID;
            this.TransitionDate = transitionDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateHistory(int projectUpdateBatchID, int projectUpdateStateID, int updatePersonID, DateTime transitionDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateHistoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectUpdateStateID = projectUpdateStateID;
            this.UpdatePersonID = updatePersonID;
            this.TransitionDate = transitionDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectUpdateHistory(ProjectUpdateBatch projectUpdateBatch, ProjectUpdateState projectUpdateState, Person updatePerson, DateTime transitionDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateHistoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectUpdateHistories.Add(this);
            this.ProjectUpdateStateID = projectUpdateState.ProjectUpdateStateID;
            this.UpdatePersonID = updatePerson.PersonID;
            this.UpdatePerson = updatePerson;
            updatePerson.ProjectUpdateHistoriesWhereYouAreTheUpdatePerson.Add(this);
            this.TransitionDate = transitionDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectUpdateHistory CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, ProjectUpdateState projectUpdateState, Person updatePerson)
        {
            return new ProjectUpdateHistory(projectUpdateBatch, projectUpdateState, updatePerson, default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectUpdateHistory).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectUpdateHistories.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectUpdateHistoryID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int ProjectUpdateStateID { get; set; }
        public int UpdatePersonID { get; set; }
        public DateTime TransitionDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateHistoryID; } set { ProjectUpdateHistoryID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public ProjectUpdateState ProjectUpdateState { get { return ProjectUpdateState.AllLookupDictionary[ProjectUpdateStateID]; } }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {

        }
    }
}