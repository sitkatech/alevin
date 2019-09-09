//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationDepartmentCode]
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
    // Table [dbo].[ReclamationDepartmentCode] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationDepartmentCode]")]
    public partial class ReclamationDepartmentCode : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationDepartmentCode()
        {
            this.People = new HashSet<Person>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationDepartmentCode(int reclamationDepartmentCodeID, string reclamationDepartmentCodeName) : this()
        {
            this.ReclamationDepartmentCodeID = reclamationDepartmentCodeID;
            this.ReclamationDepartmentCodeName = reclamationDepartmentCodeName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationDepartmentCode CreateNewBlank()
        {
            return new ReclamationDepartmentCode();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return People.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationDepartmentCode).Name, typeof(Person).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationDepartmentCodes.Remove(this);
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

            foreach(var x in People.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationDepartmentCodeID { get; set; }
        public string ReclamationDepartmentCodeName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationDepartmentCodeID; } set { ReclamationDepartmentCodeID = value; } }

        public virtual ICollection<Person> People { get; set; }

        public static class FieldLengths
        {
            public const int ReclamationDepartmentCodeName = 255;
        }
    }
}