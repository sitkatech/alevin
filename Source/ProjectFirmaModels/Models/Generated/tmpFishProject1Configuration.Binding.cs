//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject1]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class tmpFishProject1Configuration : EntityTypeConfiguration<tmpFishProject1>
    {
        public tmpFishProject1Configuration() : this("dbo"){}

        public tmpFishProject1Configuration(string schema)
        {
            ToTable("tmpFishProject1", schema);
            HasKey(x => x.tmpFishProject1ID);
            Property(x => x.OBJECTID).HasColumnName(@"OBJECTID").HasColumnType("int").IsOptional();
            Property(x => x.hydrologic_OBJECTID).HasColumnName(@"hydrologic_OBJECTID").HasColumnType("int").IsOptional();
            Property(x => x.hydrologic_HU_Area_SqKm).HasColumnName(@"hydrologic_HU_Area_SqKm").HasColumnType("float").IsOptional();
            Property(x => x.hydrologic_HU_States).HasColumnName(@"hydrologic_HU_States").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.hydrologic_HU_LoadDate).HasColumnName(@"hydrologic_HU_LoadDate").HasColumnType("datetime2").IsOptional();
            Property(x => x.hydrologic_HUC_12).HasColumnName(@"hydrologic_HUC_12").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(12);
            Property(x => x.hydrologic_HU_12_Name).HasColumnName(@"hydrologic_HU_12_Name").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(120);
            Property(x => x.hydrologic_HU_12_Type).HasColumnName(@"hydrologic_HU_12_Type").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(254);
            Property(x => x.hydrologic_HU_12_Mod).HasColumnName(@"hydrologic_HU_12_Mod").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.hydrologic_C_GNIS_NAME).HasColumnName(@"hydrologic_C_GNIS_NAME").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(80);
            Property(x => x.hydrologic_C_FWA_ID).HasColumnName(@"hydrologic_C_FWA_ID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(143);
            Property(x => x.hydrologic_C_LOCAL_ID).HasColumnName(@"hydrologic_C_LOCAL_ID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(143);
            Property(x => x.hydrologic_C_AREA_HA).HasColumnName(@"hydrologic_C_AREA_HA").HasColumnType("float").IsOptional();
            Property(x => x.hydrologic_HU_SPLIT).HasColumnName(@"hydrologic_HU_SPLIT").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(5);
            Property(x => x.hydrologic_FEATURE_ID).HasColumnName(@"hydrologic_FEATURE_ID").HasColumnType("int").IsOptional();
            Property(x => x.hydrologic_FEATURE_NOTES).HasColumnName(@"hydrologic_FEATURE_NOTES").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.link_OBJECTID).HasColumnName(@"link_OBJECTID").HasColumnType("int").IsOptional();
            Property(x => x.link_FEATURE_ID).HasColumnName(@"link_FEATURE_ID").HasColumnType("int").IsOptional();
            Property(x => x.link_WCR_POP_ID).HasColumnName(@"link_WCR_POP_ID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.link_FEATURE_ACCESS).HasColumnName(@"link_FEATURE_ACCESS").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.link_POP_NOTES).HasColumnName(@"link_POP_NOTES").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.link_DPS_ID).HasColumnName(@"link_DPS_ID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.link_DPS_NOTES).HasColumnName(@"link_DPS_NOTES").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.OBJECTID_1).HasColumnName(@"OBJECTID_1").HasColumnType("int").IsOptional();
            Property(x => x.DPS).HasColumnName(@"DPS").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.DPS_ID).HasColumnName(@"DPS_ID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.FRN).HasColumnName(@"FRN").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(40);
            Property(x => x.LISTING_DESCRIPTION).HasColumnName(@"LISTING_DESCRIPTION").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.LISTING_STATUS).HasColumnName(@"LISTING_STATUS").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.SPECIES).HasColumnName(@"SPECIES").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.TRT).HasColumnName(@"TRT").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.OBJECTID_12).HasColumnName(@"OBJECTID_12").HasColumnType("int").IsOptional();
            Property(x => x.WCR_POP_ID).HasColumnName(@"WCR_POP_ID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.TRT_POP_ID).HasColumnName(@"TRT_POP_ID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.NWFSC_POP_ID).HasColumnName(@"NWFSC_POP_ID").HasColumnType("int").IsOptional();
            Property(x => x.POPULATION).HasColumnName(@"POPULATION").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.TYPE).HasColumnName(@"TYPE").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.STATUS).HasColumnName(@"STATUS").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.RUN_TIMING).HasColumnName(@"RUN_TIMING").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.EXTINCTION_RISK).HasColumnName(@"EXTINCTION_RISK").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.MIDLEVEL_GROUP).HasColumnName(@"MIDLEVEL_GROUP").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.SHAPE_Length).HasColumnName(@"SHAPE_Length").HasColumnType("float").IsOptional();
            Property(x => x.SHAPE_Area).HasColumnName(@"SHAPE_Area").HasColumnType("float").IsOptional();
            Property(x => x.GEOM).HasColumnName(@"GEOM").HasColumnType("geometry").IsOptional();
            Property(x => x.tmpFishProject1ID).HasColumnName(@"tmpFishProject1ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}