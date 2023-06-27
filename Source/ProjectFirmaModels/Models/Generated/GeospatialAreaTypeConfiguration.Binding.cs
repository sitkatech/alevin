//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaTypeConfiguration : EntityTypeConfiguration<GeospatialAreaType>
    {
        public GeospatialAreaTypeConfiguration() : this("dbo"){}

        public GeospatialAreaTypeConfiguration(string schema)
        {
            ToTable("GeospatialAreaType", schema);
            HasKey(x => x.GeospatialAreaTypeID);
            Property(x => x.GeospatialAreaTypeID).HasColumnName(@"GeospatialAreaTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaTypeName).HasColumnName(@"GeospatialAreaTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.GeospatialAreaTypeNamePluralized).HasColumnName(@"GeospatialAreaTypeNamePluralized").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.GeospatialAreaIntroContent).HasColumnName(@"GeospatialAreaIntroContent").HasColumnType("varchar").IsOptional();
            Property(x => x.GeospatialAreaTypeDefinition).HasColumnName(@"GeospatialAreaTypeDefinition").HasColumnType("varchar").IsOptional();
            Property(x => x.GeospatialAreaLayerName).HasColumnName(@"GeospatialAreaLayerName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(255);
            Property(x => x.DisplayOnAllProjectMaps).HasColumnName(@"DisplayOnAllProjectMaps").HasColumnType("bit").IsRequired();
            Property(x => x.OnByDefaultOnProjectMap).HasColumnName(@"OnByDefaultOnProjectMap").HasColumnType("bit").IsRequired();
            Property(x => x.IsPopulation).HasColumnName(@"IsPopulation").HasColumnType("bit").IsRequired();
            Property(x => x.EsuDpsGeospatialAreaTypeID).HasColumnName(@"EsuDpsGeospatialAreaTypeID").HasColumnType("int").IsOptional();
            Property(x => x.MPGGeospatialAreaTypeID).HasColumnName(@"MPGGeospatialAreaTypeID").HasColumnType("int").IsOptional();
            Property(x => x.PopulationGeospatialAreaTypeID).HasColumnName(@"PopulationGeospatialAreaTypeID").HasColumnType("int").IsOptional();
            Property(x => x.IncludeInBiOpAnnualReport).HasColumnName(@"IncludeInBiOpAnnualReport").HasColumnType("bit").IsRequired();
            Property(x => x.OnByDefaultOnOtherMaps).HasColumnName(@"OnByDefaultOnOtherMaps").HasColumnType("bit").IsRequired();
            Property(x => x.ServiceUrl).HasColumnName(@"ServiceUrl").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(1000);
            Property(x => x.MapLegendImageFileResourceInfoID).HasColumnName(@"MapLegendImageFileResourceInfoID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.EsuDpsGeospatialAreaType).WithMany(b => b.GeospatialAreaTypesWhereYouAreTheEsuDpsGeospatialAreaType).HasForeignKey(c => c.EsuDpsGeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID_GeospatialAreaTypeID
            HasOptional(a => a.MPGGeospatialAreaType).WithMany(b => b.GeospatialAreaTypesWhereYouAreTheMPGGeospatialAreaType).HasForeignKey(c => c.MPGGeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID_GeospatialAreaTypeID
            HasOptional(a => a.PopulationGeospatialAreaType).WithMany(b => b.GeospatialAreaTypesWhereYouAreThePopulationGeospatialAreaType).HasForeignKey(c => c.PopulationGeospatialAreaTypeID).WillCascadeOnDelete(false); // FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID_GeospatialAreaTypeID
            HasOptional(a => a.MapLegendImageFileResourceInfo).WithMany(b => b.GeospatialAreaTypesWhereYouAreTheMapLegendImageFileResourceInfo).HasForeignKey(c => c.MapLegendImageFileResourceInfoID).WillCascadeOnDelete(false); // FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_FileResourceInfoID
        }
    }
}