//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Location]
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
    // Table [Reclamation].[Location] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[Location]")]
    public partial class Location : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Location()
        {
            this.PeopleWhereYouAreTheReclamationLocation = new HashSet<Person>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Location(int locationID, string reclamationLocationName, string reclamationLocationAbbreviation) : this()
        {
            this.LocationID = locationID;
            this.ReclamationLocationName = reclamationLocationName;
            this.ReclamationLocationAbbreviation = reclamationLocationAbbreviation;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Location CreateNewBlank()
        {
            return new Location();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PeopleWhereYouAreTheReclamationLocation.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(PeopleWhereYouAreTheReclamationLocation.Any())
            {
                dependentObjects.Add(typeof(Person).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Location).Name, typeof(Person).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.Locations.Remove(this);
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

            foreach(var x in PeopleWhereYouAreTheReclamationLocation.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int LocationID { get; set; }
        public string ReclamationLocationName { get; set; }
        public string ReclamationLocationAbbreviation { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return LocationID; } set { LocationID = value; } }

        public virtual ICollection<Person> PeopleWhereYouAreTheReclamationLocation { get; set; }

        public static class FieldLengths
        {
            public const int ReclamationLocationName = 255;
            public const int ReclamationLocationAbbreviation = 255;
        }
    }
}