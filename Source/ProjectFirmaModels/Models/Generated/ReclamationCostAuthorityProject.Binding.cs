//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationCostAuthorityProject]
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
    // Table [dbo].[ReclamationCostAuthorityProject] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationCostAuthorityProject]")]
    public partial class ReclamationCostAuthorityProject : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationCostAuthorityProject()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationCostAuthorityProject(int reclamationCostAuthorityProjectID, int reclamationCostAuthorityID, int projectID) : this()
        {
            this.ReclamationCostAuthorityProjectID = reclamationCostAuthorityProjectID;
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationCostAuthorityProject(int reclamationCostAuthorityID, int projectID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationCostAuthorityProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReclamationCostAuthorityProject(ReclamationCostAuthority reclamationCostAuthority, Project project) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationCostAuthorityProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ReclamationCostAuthorityID = reclamationCostAuthority.ReclamationCostAuthorityID;
            this.ReclamationCostAuthority = reclamationCostAuthority;
            reclamationCostAuthority.ReclamationCostAuthorityProjects.Add(this);
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ReclamationCostAuthorityProjects.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationCostAuthorityProject CreateNewBlank(ReclamationCostAuthority reclamationCostAuthority, Project project)
        {
            return new ReclamationCostAuthorityProject(reclamationCostAuthority, project);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationCostAuthorityProject).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationCostAuthorityProjects.Remove(this);
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
        [NotMapped]
        public int PrimaryKey { get { return ReclamationCostAuthorityProjectID; } set { ReclamationCostAuthorityProjectID = value; } }

        public virtual ReclamationCostAuthority ReclamationCostAuthority { get; set; }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {

        }
    }
}