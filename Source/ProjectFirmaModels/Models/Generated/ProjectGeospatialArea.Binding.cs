//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialArea]
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
    // Table [dbo].[ProjectGeospatialArea] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectGeospatialArea]")]
    public partial class ProjectGeospatialArea : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectGeospatialArea()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialArea(int projectGeospatialAreaID, int projectID, int geospatialAreaID) : this()
        {
            this.ProjectGeospatialAreaID = projectGeospatialAreaID;
            this.ProjectID = projectID;
            this.GeospatialAreaID = geospatialAreaID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialArea(int projectID, int geospatialAreaID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.GeospatialAreaID = geospatialAreaID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectGeospatialArea(Project project, GeospatialArea geospatialArea) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectGeospatialAreas.Add(this);
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.ProjectGeospatialAreas.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectGeospatialArea CreateNewBlank(Project project, GeospatialArea geospatialArea)
        {
            return new ProjectGeospatialArea(project, geospatialArea);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectGeospatialArea).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectGeospatialAreas.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectGeospatialAreaID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int GeospatialAreaID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectGeospatialAreaID; } set { ProjectGeospatialAreaID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual GeospatialArea GeospatialArea { get; set; }

        public static class FieldLengths
        {

        }
    }
}