//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementProject]
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
    // Table [dbo].[ReclamationAgreementProject] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationAgreementProject]")]
    public partial class ReclamationAgreementProject : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationAgreementProject()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementProject(int reclamationAgreementProjectID, int reclamationAgreementID, int projectID) : this()
        {
            this.ReclamationAgreementProjectID = reclamationAgreementProjectID;
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementProject(int reclamationAgreementID, int projectID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ProjectID = projectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReclamationAgreementProject(ReclamationAgreement reclamationAgreement, Project project) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ReclamationAgreementID = reclamationAgreement.ReclamationAgreementID;
            this.ReclamationAgreement = reclamationAgreement;
            reclamationAgreement.ReclamationAgreementProjects.Add(this);
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ReclamationAgreementProjects.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationAgreementProject CreateNewBlank(ReclamationAgreement reclamationAgreement, Project project)
        {
            return new ReclamationAgreementProject(reclamationAgreement, project);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationAgreementProject).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationAgreementProjects.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationAgreementProjectID { get; set; }
        public int ReclamationAgreementID { get; set; }
        public int ProjectID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationAgreementProjectID; } set { ReclamationAgreementProjectID = value; } }

        public virtual ReclamationAgreement ReclamationAgreement { get; set; }
        public virtual Project Project { get; set; }

        public static class FieldLengths
        {

        }
    }
}