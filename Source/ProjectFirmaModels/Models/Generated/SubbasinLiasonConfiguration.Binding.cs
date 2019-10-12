//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubbasinLiason]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubbasinLiasonConfiguration : EntityTypeConfiguration<SubbasinLiason>
    {
        public SubbasinLiasonConfiguration() : this("dbo"){}

        public SubbasinLiasonConfiguration(string schema)
        {
            ToTable("SubbasinLiason", schema);
            HasKey(x => x.SubbasinLiasonID);
            Property(x => x.SubbasinLiasonID).HasColumnName(@"SubbasinLiasonID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.GeospatialAreaID).HasColumnName(@"GeospatialAreaID").HasColumnType("int").IsRequired();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsRequired();

            // Foreign keys

        }
    }
}