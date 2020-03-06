//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityProject]
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
    // Table [Reclamation].[CostAuthorityProject] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[CostAuthorityProject]")]
    public partial class CostAuthorityProject : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostAuthorityProject()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthorityProject(int reclamationCostAuthorityProjectID, int reclamationCostAuthorityID, int projectID, bool isPrimaryProjectCawbs, string primaryProjectCawbsUniqueString) : this()
        {
            this.ReclamationCostAuthorityProjectID = reclamationCostAuthorityProjectID;
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
            this.ProjectID = projectID;
            this.IsPrimaryProjectCawbs = isPrimaryProjectCawbs;
            this.PrimaryProjectCawbsUniqueString = primaryProjectCawbsUniqueString;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthorityProject(int reclamationCostAuthorityID, int projectID, bool isPrimaryProjectCawbs) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationCostAuthorityProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
            this.ProjectID = projectID;
            this.IsPrimaryProjectCawbs = isPrimaryProjectCawbs;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CostAuthorityProject(CostAuthority reclamationCostAuthority, Project project, bool isPrimaryProjectCawbs) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationCostAuthorityProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ReclamationCostAuthorityID = reclamationCostAuthority.ReclamationCostAuthorityID;
            this.ReclamationCostAuthority = reclamationCostAuthority;
            reclamationCostAuthority.CostAuthorityProjects.Add(this);
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.CostAuthorityProjects.Add(this);
            this.IsPrimaryProjectCawbs = isPrimaryProjectCawbs;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostAuthorityProject CreateNewBlank(CostAuthority reclamationCostAuthority, Project project)
        {
            return new CostAuthorityProject(reclamationCostAuthority, project, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostAuthorityProject).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.CostAuthorityProjects.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationCostAuthorityProjectID { get; set; }
        public int ReclamationCostAuthorityID { get; set; }
        public int ProjectID { get; set; }
        public bool IsPrimaryProjectCawbs { get; set; }
        public string PrimaryProjectCawbsUniqueString { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationCostAuthorityProjectID; } set { ReclamationCostAuthorityProjectID = value; } }

        public virtual CostAuthority ReclamationCostAuthority { get; set; }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {
            public const int PrimaryProjectCawbsUniqueString = 500;
        }
    }
}