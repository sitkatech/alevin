//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectActionItem]
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
    // Table [dbo].[SubprojectActionItem] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[SubprojectActionItem]")]
    public partial class SubprojectActionItem : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SubprojectActionItem()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectActionItem(int subprojectActionItemID, int actionItemStateID, string subprojectActionItemText, int assignedToPersonID, DateTime assignedOnDate, DateTime dueByDate, DateTime? completedOnDate, int? subprojectProjectStatusID, int subprojectID) : this()
        {
            this.SubprojectActionItemID = subprojectActionItemID;
            this.ActionItemStateID = actionItemStateID;
            this.SubprojectActionItemText = subprojectActionItemText;
            this.AssignedToPersonID = assignedToPersonID;
            this.AssignedOnDate = assignedOnDate;
            this.DueByDate = dueByDate;
            this.CompletedOnDate = completedOnDate;
            this.SubprojectProjectStatusID = subprojectProjectStatusID;
            this.SubprojectID = subprojectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectActionItem(int actionItemStateID, int assignedToPersonID, DateTime assignedOnDate, DateTime dueByDate, int subprojectID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectActionItemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ActionItemStateID = actionItemStateID;
            this.AssignedToPersonID = assignedToPersonID;
            this.AssignedOnDate = assignedOnDate;
            this.DueByDate = dueByDate;
            this.SubprojectID = subprojectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SubprojectActionItem(ActionItemState actionItemState, Person assignedToPerson, DateTime assignedOnDate, DateTime dueByDate, Subproject subproject) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectActionItemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ActionItemStateID = actionItemState.ActionItemStateID;
            this.AssignedToPersonID = assignedToPerson.PersonID;
            this.AssignedToPerson = assignedToPerson;
            assignedToPerson.SubprojectActionItemsWhereYouAreTheAssignedToPerson.Add(this);
            this.AssignedOnDate = assignedOnDate;
            this.DueByDate = dueByDate;
            this.SubprojectID = subproject.SubprojectID;
            this.Subproject = subproject;
            subproject.SubprojectActionItems.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SubprojectActionItem CreateNewBlank(ActionItemState actionItemState, Person assignedToPerson, Subproject subproject)
        {
            return new SubprojectActionItem(actionItemState, assignedToPerson, default(DateTime), default(DateTime), subproject);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SubprojectActionItem).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSubprojectActionItems.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int SubprojectActionItemID { get; set; }
        public int TenantID { get; set; }
        public int ActionItemStateID { get; set; }
        public string SubprojectActionItemText { get; set; }
        public int AssignedToPersonID { get; set; }
        public DateTime AssignedOnDate { get; set; }
        public DateTime DueByDate { get; set; }
        public DateTime? CompletedOnDate { get; set; }
        public int? SubprojectProjectStatusID { get; set; }
        public int SubprojectID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SubprojectActionItemID; } set { SubprojectActionItemID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public ActionItemState ActionItemState { get { return ActionItemState.AllLookupDictionary[ActionItemStateID]; } }
        public virtual Person AssignedToPerson { get; set; }
        public virtual SubprojectProjectStatus SubprojectProjectStatus { get; set; }
        public virtual Subproject Subproject { get; set; }

        public static class FieldLengths
        {
            public const int SubprojectActionItemText = 5000;
        }
    }
}