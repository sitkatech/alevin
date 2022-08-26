//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Subproject]
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
    // Table [dbo].[Subproject] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Subproject]")]
    public partial class Subproject : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Subproject()
        {
            this.SubprojectInternalNotes = new HashSet<SubprojectInternalNote>();
            this.SubprojectNotes = new HashSet<SubprojectNote>();
            this.SubprojectPerformanceMeasureActuals = new HashSet<SubprojectPerformanceMeasureActual>();
            this.SubprojectPerformanceMeasureExpecteds = new HashSet<SubprojectPerformanceMeasureExpected>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Subproject(int subprojectID, int projectID, int subprojectStageID, int? implementationStartYear, int? completionYear, string subprojectName, string subprojectDescription) : this()
        {
            this.SubprojectID = subprojectID;
            this.ProjectID = projectID;
            this.SubprojectStageID = subprojectStageID;
            this.ImplementationStartYear = implementationStartYear;
            this.CompletionYear = completionYear;
            this.SubprojectName = subprojectName;
            this.SubprojectDescription = subprojectDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Subproject(int projectID, int subprojectStageID, string subprojectName, string subprojectDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.SubprojectStageID = subprojectStageID;
            this.SubprojectName = subprojectName;
            this.SubprojectDescription = subprojectDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Subproject(Project project, ProjectStage subprojectStage, string subprojectName, string subprojectDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.Subprojects.Add(this);
            this.SubprojectStageID = subprojectStage.ProjectStageID;
            this.SubprojectName = subprojectName;
            this.SubprojectDescription = subprojectDescription;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Subproject CreateNewBlank(Project project, ProjectStage subprojectStage)
        {
            return new Subproject(project, subprojectStage, default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SubprojectInternalNotes.Any() || SubprojectNotes.Any() || SubprojectPerformanceMeasureActuals.Any() || SubprojectPerformanceMeasureExpecteds.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(SubprojectInternalNotes.Any())
            {
                dependentObjects.Add(typeof(SubprojectInternalNote).Name);
            }

            if(SubprojectNotes.Any())
            {
                dependentObjects.Add(typeof(SubprojectNote).Name);
            }

            if(SubprojectPerformanceMeasureActuals.Any())
            {
                dependentObjects.Add(typeof(SubprojectPerformanceMeasureActual).Name);
            }

            if(SubprojectPerformanceMeasureExpecteds.Any())
            {
                dependentObjects.Add(typeof(SubprojectPerformanceMeasureExpected).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Subproject).Name, typeof(SubprojectInternalNote).Name, typeof(SubprojectNote).Name, typeof(SubprojectPerformanceMeasureActual).Name, typeof(SubprojectPerformanceMeasureExpected).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSubprojects.Remove(this);
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

            foreach(var x in SubprojectInternalNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in SubprojectNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in SubprojectPerformanceMeasureActuals.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in SubprojectPerformanceMeasureExpecteds.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int SubprojectID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int SubprojectStageID { get; set; }
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
        public string SubprojectName { get; set; }
        public string SubprojectDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SubprojectID; } set { SubprojectID = value; } }

        public virtual ICollection<SubprojectInternalNote> SubprojectInternalNotes { get; set; }
        public virtual ICollection<SubprojectNote> SubprojectNotes { get; set; }
        public virtual ICollection<SubprojectPerformanceMeasureActual> SubprojectPerformanceMeasureActuals { get; set; }
        public virtual ICollection<SubprojectPerformanceMeasureExpected> SubprojectPerformanceMeasureExpecteds { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public ProjectStage SubprojectStage { get { return ProjectStage.AllLookupDictionary[SubprojectStageID]; } }

        public static class FieldLengths
        {
            public const int SubprojectName = 140;
            public const int SubprojectDescription = 4000;
        }
    }
}