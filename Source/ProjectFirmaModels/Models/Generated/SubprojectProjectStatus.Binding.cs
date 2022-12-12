//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectProjectStatus]
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
    // Table [dbo].[SubprojectProjectStatus] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[SubprojectProjectStatus]")]
    public partial class SubprojectProjectStatus : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SubprojectProjectStatus()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectProjectStatus(int subprojectProjectStatusID, int subprojectID, int projectStatusID, DateTime subprojectProjectStatusUpdateDate, int subprojectProjectStatusCreatePersonID, DateTime subprojectProjectStatusCreateDate, int? subprojectProjectStatusLastEditedPersonID, DateTime? subprojectProjectStatusLastEditedDate, bool isFinalStatusUpdate, string lessonsLearned, string subprojectProjectStatusRecentActivities, string subprojectProjectStatusUpcomingActivities, string subprojectProjectStatusRisksOrIssues, string subprojectProjectStatusComment) : this()
        {
            this.SubprojectProjectStatusID = subprojectProjectStatusID;
            this.SubprojectID = subprojectID;
            this.ProjectStatusID = projectStatusID;
            this.SubprojectProjectStatusUpdateDate = subprojectProjectStatusUpdateDate;
            this.SubprojectProjectStatusCreatePersonID = subprojectProjectStatusCreatePersonID;
            this.SubprojectProjectStatusCreateDate = subprojectProjectStatusCreateDate;
            this.SubprojectProjectStatusLastEditedPersonID = subprojectProjectStatusLastEditedPersonID;
            this.SubprojectProjectStatusLastEditedDate = subprojectProjectStatusLastEditedDate;
            this.IsFinalStatusUpdate = isFinalStatusUpdate;
            this.LessonsLearned = lessonsLearned;
            this.SubprojectProjectStatusRecentActivities = subprojectProjectStatusRecentActivities;
            this.SubprojectProjectStatusUpcomingActivities = subprojectProjectStatusUpcomingActivities;
            this.SubprojectProjectStatusRisksOrIssues = subprojectProjectStatusRisksOrIssues;
            this.SubprojectProjectStatusComment = subprojectProjectStatusComment;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectProjectStatus(int subprojectID, int projectStatusID, DateTime subprojectProjectStatusUpdateDate, int subprojectProjectStatusCreatePersonID, DateTime subprojectProjectStatusCreateDate, bool isFinalStatusUpdate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectProjectStatusID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SubprojectID = subprojectID;
            this.ProjectStatusID = projectStatusID;
            this.SubprojectProjectStatusUpdateDate = subprojectProjectStatusUpdateDate;
            this.SubprojectProjectStatusCreatePersonID = subprojectProjectStatusCreatePersonID;
            this.SubprojectProjectStatusCreateDate = subprojectProjectStatusCreateDate;
            this.IsFinalStatusUpdate = isFinalStatusUpdate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SubprojectProjectStatus(Subproject subproject, ProjectStatus projectStatus, DateTime subprojectProjectStatusUpdateDate, Person subprojectProjectStatusCreatePerson, DateTime subprojectProjectStatusCreateDate, bool isFinalStatusUpdate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectProjectStatusID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SubprojectID = subproject.SubprojectID;
            this.Subproject = subproject;
            subproject.SubprojectProjectStatuses.Add(this);
            this.ProjectStatusID = projectStatus.ProjectStatusID;
            this.ProjectStatus = projectStatus;
            projectStatus.SubprojectProjectStatuses.Add(this);
            this.SubprojectProjectStatusUpdateDate = subprojectProjectStatusUpdateDate;
            this.SubprojectProjectStatusCreatePersonID = subprojectProjectStatusCreatePerson.PersonID;
            this.SubprojectProjectStatusCreatePerson = subprojectProjectStatusCreatePerson;
            subprojectProjectStatusCreatePerson.SubprojectProjectStatusesWhereYouAreTheSubprojectProjectStatusCreatePerson.Add(this);
            this.SubprojectProjectStatusCreateDate = subprojectProjectStatusCreateDate;
            this.IsFinalStatusUpdate = isFinalStatusUpdate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SubprojectProjectStatus CreateNewBlank(Subproject subproject, ProjectStatus projectStatus, Person subprojectProjectStatusCreatePerson)
        {
            return new SubprojectProjectStatus(subproject, projectStatus, default(DateTime), subprojectProjectStatusCreatePerson, default(DateTime), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SubprojectProjectStatus).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSubprojectProjectStatuses.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int SubprojectProjectStatusID { get; set; }
        public int TenantID { get; set; }
        public int SubprojectID { get; set; }
        public int ProjectStatusID { get; set; }
        public DateTime SubprojectProjectStatusUpdateDate { get; set; }
        public int SubprojectProjectStatusCreatePersonID { get; set; }
        public DateTime SubprojectProjectStatusCreateDate { get; set; }
        public int? SubprojectProjectStatusLastEditedPersonID { get; set; }
        public DateTime? SubprojectProjectStatusLastEditedDate { get; set; }
        public bool IsFinalStatusUpdate { get; set; }
        public string LessonsLearned { get; set; }
        public string SubprojectProjectStatusRecentActivities { get; set; }
        public string SubprojectProjectStatusUpcomingActivities { get; set; }
        public string SubprojectProjectStatusRisksOrIssues { get; set; }
        public string SubprojectProjectStatusComment { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SubprojectProjectStatusID; } set { SubprojectProjectStatusID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Subproject Subproject { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual Person SubprojectProjectStatusCreatePerson { get; set; }
        public virtual Person SubprojectProjectStatusLastEditedPerson { get; set; }

        public static class FieldLengths
        {
            public const int LessonsLearned = 2500;
            public const int SubprojectProjectStatusRecentActivities = 2000;
            public const int SubprojectProjectStatusUpcomingActivities = 2000;
            public const int SubprojectProjectStatusRisksOrIssues = 2000;
            public const int SubprojectProjectStatusComment = 2000;
        }
    }
}