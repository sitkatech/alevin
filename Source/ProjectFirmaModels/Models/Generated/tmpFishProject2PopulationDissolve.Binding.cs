//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject2PopulationDissolve]
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
    // Table [dbo].[tmpFishProject2PopulationDissolve] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[tmpFishProject2PopulationDissolve]")]
    public partial class tmpFishProject2PopulationDissolve : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected tmpFishProject2PopulationDissolve()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public tmpFishProject2PopulationDissolve(int? oBJECTID, string dPS, string pOPULATION, string sTATUS, string rUN_TIMING, double? sHAPE_Length, double? sHAPE_Area, DbGeometry gEOM, int tmpFishProject2PopulationDissolveID) : this()
        {
            this.OBJECTID = oBJECTID;
            this.DPS = dPS;
            this.POPULATION = pOPULATION;
            this.STATUS = sTATUS;
            this.RUN_TIMING = rUN_TIMING;
            this.SHAPE_Length = sHAPE_Length;
            this.SHAPE_Area = sHAPE_Area;
            this.GEOM = gEOM;
            this.tmpFishProject2PopulationDissolveID = tmpFishProject2PopulationDissolveID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static tmpFishProject2PopulationDissolve CreateNewBlank()
        {
            return new tmpFishProject2PopulationDissolve();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(tmpFishProject2PopulationDissolve).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.tmpFishProject2PopulationDissolves.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        public int? OBJECTID { get; set; }
        public string DPS { get; set; }
        public string POPULATION { get; set; }
        public string STATUS { get; set; }
        public string RUN_TIMING { get; set; }
        public double? SHAPE_Length { get; set; }
        public double? SHAPE_Area { get; set; }
        public DbGeometry GEOM { get; set; }
        [Key]
        public int tmpFishProject2PopulationDissolveID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return tmpFishProject2PopulationDissolveID; } set { tmpFishProject2PopulationDissolveID = value; } }



        public static class FieldLengths
        {
            public const int DPS = 100;
            public const int POPULATION = 255;
            public const int STATUS = 255;
            public const int RUN_TIMING = 255;
        }
    }
}