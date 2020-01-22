//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionItem]
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
    // Table [dbo].[ActionItem] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ActionItem]")]
    public partial class ActionItem : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ActionItem()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ActionItem(int actionItemID, int actionItemStateID, string actionItemText, int assignedToPersonID, DateTime assignedOnDate, DateTime dueByDate, DateTime? completedOnDate, int? projectProjectStatusID, int projectID) : this()
        {
            this.ActionItemID = actionItemID;
            this.ActionItemStateID = actionItemStateID;
            this.ActionItemText = actionItemText;
            this.AssignedToPersonID = assignedToPersonID;
            this.AssignedOnDate = assignedOnDate;
            this.DueByDate = dueByDate;
            this.CompletedOnDate = completedOnDate;
            this.ProjectProjectStatusID = projectProjectStatusID;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ActionItem(int actionItemStateID, int assignedToPersonID, DateTime assignedOnDate, DateTime dueByDate, int projectID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ActionItemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ActionItemStateID = actionItemStateID;
            this.AssignedToPersonID = assignedToPersonID;
            this.AssignedOnDate = assignedOnDate;
            this.DueByDate = dueByDate;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ActionItem(ActionItemState actionItemState, Person assignedToPerson, DateTime assignedOnDate, DateTime dueByDate, Project project) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ActionItemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ActionItemStateID = actionItemState.ActionItemStateID;
            this.AssignedToPersonID = assignedToPerson.PersonID;
            this.AssignedToPerson = assignedToPerson;
            assignedToPerson.ActionItemsWhereYouAreTheAssignedToPerson.Add(this);
            this.AssignedOnDate = assignedOnDate;
            this.DueByDate = dueByDate;
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ActionItems.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ActionItem CreateNewBlank(ActionItemState actionItemState, Person assignedToPerson, Project project)
        {
            return new ActionItem(actionItemState, assignedToPerson, default(DateTime), default(DateTime), project);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ActionItem).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllActionItems.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ActionItemID { get; set; }
        public int TenantID { get; set; }
        public int ActionItemStateID { get; set; }
        public string ActionItemText { get; set; }
        public int AssignedToPersonID { get; set; }
        public DateTime AssignedOnDate { get; set; }
        public DateTime DueByDate { get; set; }
        public DateTime? CompletedOnDate { get; set; }
        public int? ProjectProjectStatusID { get; set; }
        public int ProjectID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ActionItemID; } set { ActionItemID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public ActionItemState ActionItemState { get { return ActionItemState.AllLookupDictionary[ActionItemStateID]; } }
        public virtual Person AssignedToPerson { get; set; }
        public virtual ProjectProjectStatus ProjectProjectStatus { get; set; }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {
            public const int ActionItemText = 5000;
        }
    }
}