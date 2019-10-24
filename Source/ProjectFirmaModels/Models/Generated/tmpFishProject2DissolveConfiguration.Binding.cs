//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject2Dissolve]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class tmpFishProject2DissolveConfiguration : EntityTypeConfiguration<tmpFishProject2Dissolve>
    {
        public tmpFishProject2DissolveConfiguration() : this("dbo"){}

        public tmpFishProject2DissolveConfiguration(string schema)
        {
            ToTable("tmpFishProject2Dissolve", schema);
            HasKey(x => x.tmpFishProject2DissolveID);
            Property(x => x.OBJECTID).HasColumnName(@"OBJECTID").HasColumnType("int").IsOptional();
            Property(x => x.DPS).HasColumnName(@"DPS").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.SHAPE_Length).HasColumnName(@"SHAPE_Length").HasColumnType("float").IsOptional();
            Property(x => x.SHAPE_Area).HasColumnName(@"SHAPE_Area").HasColumnType("float").IsOptional();
            Property(x => x.GEOM).HasColumnName(@"GEOM").HasColumnType("geometry").IsOptional();
            Property(x => x.tmpFishProject2DissolveID).HasColumnName(@"tmpFishProject2DissolveID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}