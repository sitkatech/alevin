//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject2Dissolve]
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
    // Table [dbo].[tmpFishProject2Dissolve] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[tmpFishProject2Dissolve]")]
    public partial class tmpFishProject2Dissolve : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected tmpFishProject2Dissolve()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public tmpFishProject2Dissolve(int? oBJECTID, string dPS, double? sHAPE_Length, double? sHAPE_Area, DbGeometry gEOM, int tmpFishProject2DissolveID) : this()
        {
            this.OBJECTID = oBJECTID;
            this.DPS = dPS;
            this.SHAPE_Length = sHAPE_Length;
            this.SHAPE_Area = sHAPE_Area;
            this.GEOM = gEOM;
            this.tmpFishProject2DissolveID = tmpFishProject2DissolveID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static tmpFishProject2Dissolve CreateNewBlank()
        {
            return new tmpFishProject2Dissolve();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(tmpFishProject2Dissolve).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.tmpFishProject2Dissolves.Remove(this);
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
        public double? SHAPE_Length { get; set; }
        public double? SHAPE_Area { get; set; }
        public DbGeometry GEOM { get; set; }
        [Key]
        public int tmpFishProject2DissolveID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return tmpFishProject2DissolveID; } set { tmpFishProject2DissolveID = value; } }



        public static class FieldLengths
        {
            public const int DPS = 100;
        }
    }
}