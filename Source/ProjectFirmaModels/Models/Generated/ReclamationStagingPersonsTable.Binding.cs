//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingPersonsTable]
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
    // Table [Reclamation].[ReclamationStagingPersonsTable] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationStagingPersonsTable]")]
    public partial class ReclamationStagingPersonsTable : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingPersonsTable()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingPersonsTable(int reclamationStagingPersonsTableID, int? reclamationStaffID, string firstName, string lastName, string location, string phone, string deptartmentCode, string rTSContact) : this()
        {
            this.ReclamationStagingPersonsTableID = reclamationStagingPersonsTableID;
            this.ReclamationStaffID = reclamationStaffID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Location = location;
            this.Phone = phone;
            this.DeptartmentCode = deptartmentCode;
            this.RTSContact = rTSContact;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingPersonsTable CreateNewBlank()
        {
            return new ReclamationStagingPersonsTable();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingPersonsTable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingPersonsTables.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationStagingPersonsTableID { get; set; }
        public int? ReclamationStaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string DeptartmentCode { get; set; }
        public string RTSContact { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingPersonsTableID; } set { ReclamationStagingPersonsTableID = value; } }



        public static class FieldLengths
        {
            public const int FirstName = 255;
            public const int LastName = 255;
            public const int Location = 255;
            public const int Phone = 255;
            public const int DeptartmentCode = 255;
            public const int RTSContact = 255;
        }
    }
}