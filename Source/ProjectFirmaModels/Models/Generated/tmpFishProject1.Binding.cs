//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject1]
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
    // Table [dbo].[tmpFishProject1] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[tmpFishProject1]")]
    public partial class tmpFishProject1 : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected tmpFishProject1()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public tmpFishProject1(int? oBJECTID, int? hydrologic_OBJECTID, double? hydrologic_HU_Area_SqKm, string hydrologic_HU_States, DateTime? hydrologic_HU_LoadDate, string hydrologic_HUC_12, string hydrologic_HU_12_Name, string hydrologic_HU_12_Type, string hydrologic_HU_12_Mod, string hydrologic_C_GNIS_NAME, string hydrologic_C_FWA_ID, string hydrologic_C_LOCAL_ID, double? hydrologic_C_AREA_HA, string hydrologic_HU_SPLIT, int? hydrologic_FEATURE_ID, string hydrologic_FEATURE_NOTES, int? link_OBJECTID, int? link_FEATURE_ID, string link_WCR_POP_ID, string link_FEATURE_ACCESS, string link_POP_NOTES, string link_DPS_ID, string link_DPS_NOTES, int? oBJECTID_1, string dPS, string dPS_ID, string fRN, string lISTING_DESCRIPTION, string lISTING_STATUS, string sPECIES, string tRT, int? oBJECTID_12, string wCR_POP_ID, string tRT_POP_ID, int? nWFSC_POP_ID, string pOPULATION, string tYPE, string sTATUS, string rUN_TIMING, string eXTINCTION_RISK, string mIDLEVEL_GROUP, double? sHAPE_Length, double? sHAPE_Area, DbGeometry gEOM, int tmpFishProject1ID) : this()
        {
            this.OBJECTID = oBJECTID;
            this.hydrologic_OBJECTID = hydrologic_OBJECTID;
            this.hydrologic_HU_Area_SqKm = hydrologic_HU_Area_SqKm;
            this.hydrologic_HU_States = hydrologic_HU_States;
            this.hydrologic_HU_LoadDate = hydrologic_HU_LoadDate;
            this.hydrologic_HUC_12 = hydrologic_HUC_12;
            this.hydrologic_HU_12_Name = hydrologic_HU_12_Name;
            this.hydrologic_HU_12_Type = hydrologic_HU_12_Type;
            this.hydrologic_HU_12_Mod = hydrologic_HU_12_Mod;
            this.hydrologic_C_GNIS_NAME = hydrologic_C_GNIS_NAME;
            this.hydrologic_C_FWA_ID = hydrologic_C_FWA_ID;
            this.hydrologic_C_LOCAL_ID = hydrologic_C_LOCAL_ID;
            this.hydrologic_C_AREA_HA = hydrologic_C_AREA_HA;
            this.hydrologic_HU_SPLIT = hydrologic_HU_SPLIT;
            this.hydrologic_FEATURE_ID = hydrologic_FEATURE_ID;
            this.hydrologic_FEATURE_NOTES = hydrologic_FEATURE_NOTES;
            this.link_OBJECTID = link_OBJECTID;
            this.link_FEATURE_ID = link_FEATURE_ID;
            this.link_WCR_POP_ID = link_WCR_POP_ID;
            this.link_FEATURE_ACCESS = link_FEATURE_ACCESS;
            this.link_POP_NOTES = link_POP_NOTES;
            this.link_DPS_ID = link_DPS_ID;
            this.link_DPS_NOTES = link_DPS_NOTES;
            this.OBJECTID_1 = oBJECTID_1;
            this.DPS = dPS;
            this.DPS_ID = dPS_ID;
            this.FRN = fRN;
            this.LISTING_DESCRIPTION = lISTING_DESCRIPTION;
            this.LISTING_STATUS = lISTING_STATUS;
            this.SPECIES = sPECIES;
            this.TRT = tRT;
            this.OBJECTID_12 = oBJECTID_12;
            this.WCR_POP_ID = wCR_POP_ID;
            this.TRT_POP_ID = tRT_POP_ID;
            this.NWFSC_POP_ID = nWFSC_POP_ID;
            this.POPULATION = pOPULATION;
            this.TYPE = tYPE;
            this.STATUS = sTATUS;
            this.RUN_TIMING = rUN_TIMING;
            this.EXTINCTION_RISK = eXTINCTION_RISK;
            this.MIDLEVEL_GROUP = mIDLEVEL_GROUP;
            this.SHAPE_Length = sHAPE_Length;
            this.SHAPE_Area = sHAPE_Area;
            this.GEOM = gEOM;
            this.tmpFishProject1ID = tmpFishProject1ID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static tmpFishProject1 CreateNewBlank()
        {
            return new tmpFishProject1();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(tmpFishProject1).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.tmpFishProject1s.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        public int? OBJECTID { get; set; }
        public int? hydrologic_OBJECTID { get; set; }
        public double? hydrologic_HU_Area_SqKm { get; set; }
        public string hydrologic_HU_States { get; set; }
        public DateTime? hydrologic_HU_LoadDate { get; set; }
        public string hydrologic_HUC_12 { get; set; }
        public string hydrologic_HU_12_Name { get; set; }
        public string hydrologic_HU_12_Type { get; set; }
        public string hydrologic_HU_12_Mod { get; set; }
        public string hydrologic_C_GNIS_NAME { get; set; }
        public string hydrologic_C_FWA_ID { get; set; }
        public string hydrologic_C_LOCAL_ID { get; set; }
        public double? hydrologic_C_AREA_HA { get; set; }
        public string hydrologic_HU_SPLIT { get; set; }
        public int? hydrologic_FEATURE_ID { get; set; }
        public string hydrologic_FEATURE_NOTES { get; set; }
        public int? link_OBJECTID { get; set; }
        public int? link_FEATURE_ID { get; set; }
        public string link_WCR_POP_ID { get; set; }
        public string link_FEATURE_ACCESS { get; set; }
        public string link_POP_NOTES { get; set; }
        public string link_DPS_ID { get; set; }
        public string link_DPS_NOTES { get; set; }
        public int? OBJECTID_1 { get; set; }
        public string DPS { get; set; }
        public string DPS_ID { get; set; }
        public string FRN { get; set; }
        public string LISTING_DESCRIPTION { get; set; }
        public string LISTING_STATUS { get; set; }
        public string SPECIES { get; set; }
        public string TRT { get; set; }
        public int? OBJECTID_12 { get; set; }
        public string WCR_POP_ID { get; set; }
        public string TRT_POP_ID { get; set; }
        public int? NWFSC_POP_ID { get; set; }
        public string POPULATION { get; set; }
        public string TYPE { get; set; }
        public string STATUS { get; set; }
        public string RUN_TIMING { get; set; }
        public string EXTINCTION_RISK { get; set; }
        public string MIDLEVEL_GROUP { get; set; }
        public double? SHAPE_Length { get; set; }
        public double? SHAPE_Area { get; set; }
        public DbGeometry GEOM { get; set; }
        [Key]
        public int tmpFishProject1ID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return tmpFishProject1ID; } set { tmpFishProject1ID = value; } }



        public static class FieldLengths
        {
            public const int hydrologic_HU_States = 50;
            public const int hydrologic_HUC_12 = 12;
            public const int hydrologic_HU_12_Name = 120;
            public const int hydrologic_HU_12_Type = 254;
            public const int hydrologic_HU_12_Mod = 50;
            public const int hydrologic_C_GNIS_NAME = 80;
            public const int hydrologic_C_FWA_ID = 143;
            public const int hydrologic_C_LOCAL_ID = 143;
            public const int hydrologic_HU_SPLIT = 5;
            public const int hydrologic_FEATURE_NOTES = 500;
            public const int link_WCR_POP_ID = 255;
            public const int link_FEATURE_ACCESS = 255;
            public const int link_POP_NOTES = 255;
            public const int link_DPS_ID = 255;
            public const int link_DPS_NOTES = 255;
            public const int DPS = 100;
            public const int DPS_ID = 10;
            public const int FRN = 40;
            public const int LISTING_DESCRIPTION = 2000;
            public const int LISTING_STATUS = 50;
            public const int SPECIES = 50;
            public const int TRT = 100;
            public const int WCR_POP_ID = 255;
            public const int TRT_POP_ID = 255;
            public const int POPULATION = 255;
            public const int TYPE = 255;
            public const int STATUS = 255;
            public const int RUN_TIMING = 255;
            public const int EXTINCTION_RISK = 255;
            public const int MIDLEVEL_GROUP = 100;
        }
    }
}