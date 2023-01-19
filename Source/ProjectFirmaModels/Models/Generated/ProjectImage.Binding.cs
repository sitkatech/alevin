//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImage]
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
    // Table [dbo].[ProjectImage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectImage]")]
    public partial class ProjectImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectImage()
        {
            this.ProjectImageUpdates = new HashSet<ProjectImageUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectImage(int projectImageID, int fileResourceInfoID, int projectID, int projectImageTimingID, string caption, string credit, bool isKeyPhoto, bool includeInFactSheet) : this()
        {
            this.ProjectImageID = projectImageID;
            this.FileResourceInfoID = fileResourceInfoID;
            this.ProjectID = projectID;
            this.ProjectImageTimingID = projectImageTimingID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
            this.IncludeInFactSheet = includeInFactSheet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectImage(int fileResourceInfoID, int projectID, int projectImageTimingID, string caption, string credit, bool isKeyPhoto, bool includeInFactSheet) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceInfoID = fileResourceInfoID;
            this.ProjectID = projectID;
            this.ProjectImageTimingID = projectImageTimingID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
            this.IncludeInFactSheet = includeInFactSheet;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectImage(FileResourceInfo fileResourceInfo, Project project, ProjectImageTiming projectImageTiming, string caption, string credit, bool isKeyPhoto, bool includeInFactSheet) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceInfoID = fileResourceInfo.FileResourceInfoID;
            this.FileResourceInfo = fileResourceInfo;
            fileResourceInfo.ProjectImages.Add(this);
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectImages.Add(this);
            this.ProjectImageTimingID = projectImageTiming.ProjectImageTimingID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
            this.IncludeInFactSheet = includeInFactSheet;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectImage CreateNewBlank(FileResourceInfo fileResourceInfo, Project project, ProjectImageTiming projectImageTiming)
        {
            return new ProjectImage(fileResourceInfo, project, projectImageTiming, default(string), default(string), default(bool), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectImageUpdates.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ProjectImageUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectImageUpdate).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectImage).Name, typeof(ProjectImageUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectImages.Remove(this);
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

            foreach(var x in ProjectImageUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectImageID { get; set; }
        public int TenantID { get; set; }
        public int FileResourceInfoID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectImageTimingID { get; set; }
        public string Caption { get; set; }
        public string Credit { get; set; }
        public bool IsKeyPhoto { get; set; }
        public bool IncludeInFactSheet { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectImageID; } set { ProjectImageID = value; } }

        public virtual ICollection<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FileResourceInfo FileResourceInfo { get; set; }
        public virtual Project Project { get; set; }
        public ProjectImageTiming ProjectImageTiming { get { return ProjectImageTiming.AllLookupDictionary[ProjectImageTimingID]; } }

        public static class FieldLengths
        {
            public const int Caption = 200;
            public const int Credit = 200;
        }
    }
}