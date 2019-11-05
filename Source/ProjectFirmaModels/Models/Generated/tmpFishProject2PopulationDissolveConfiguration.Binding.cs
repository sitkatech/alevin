//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject2PopulationDissolve]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class tmpFishProject2PopulationDissolveConfiguration : EntityTypeConfiguration<tmpFishProject2PopulationDissolve>
    {
        public tmpFishProject2PopulationDissolveConfiguration() : this("dbo"){}

        public tmpFishProject2PopulationDissolveConfiguration(string schema)
        {
            ToTable("tmpFishProject2PopulationDissolve", schema);
            HasKey(x => x.tmpFishProject2PopulationDissolveID);
            Property(x => x.OBJECTID).HasColumnName(@"OBJECTID").HasColumnType("int").IsOptional();
            Property(x => x.DPS).HasColumnName(@"DPS").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.POPULATION).HasColumnName(@"POPULATION").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.STATUS).HasColumnName(@"STATUS").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.RUN_TIMING).HasColumnName(@"RUN_TIMING").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.SHAPE_Length).HasColumnName(@"SHAPE_Length").HasColumnType("float").IsOptional();
            Property(x => x.SHAPE_Area).HasColumnName(@"SHAPE_Area").HasColumnType("float").IsOptional();
            Property(x => x.GEOM).HasColumnName(@"GEOM").HasColumnType("geometry").IsOptional();
            Property(x => x.tmpFishProject2PopulationDissolveID).HasColumnName(@"tmpFishProject2PopulationDissolveID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}