//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardGeospatialArea]
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
    // Table [dbo].[PersonStewardGeospatialArea] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PersonStewardGeospatialArea]")]
    public partial class PersonStewardGeospatialArea : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonStewardGeospatialArea()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonStewardGeospatialArea(int personStewardGeospatialAreaID, int personID, int geospatialAreaID) : this()
        {
            this.PersonStewardGeospatialAreaID = personStewardGeospatialAreaID;
            this.PersonID = personID;
            this.GeospatialAreaID = geospatialAreaID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonStewardGeospatialArea(int personID, int geospatialAreaID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonStewardGeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.GeospatialAreaID = geospatialAreaID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonStewardGeospatialArea(Person person, GeospatialArea geospatialArea) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonStewardGeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonStewardGeospatialAreas.Add(this);
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.PersonStewardGeospatialAreas.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonStewardGeospatialArea CreateNewBlank(Person person, GeospatialArea geospatialArea)
        {
            return new PersonStewardGeospatialArea(person, geospatialArea);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonStewardGeospatialArea).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPersonStewardGeospatialAreas.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PersonStewardGeospatialAreaID { get; set; }
        public int TenantID { get; set; }
        public int PersonID { get; set; }
        public int GeospatialAreaID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonStewardGeospatialAreaID; } set { PersonStewardGeospatialAreaID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person Person { get; set; }
        public virtual GeospatialArea GeospatialArea { get; set; }

        public static class FieldLengths
        {

        }
    }
}