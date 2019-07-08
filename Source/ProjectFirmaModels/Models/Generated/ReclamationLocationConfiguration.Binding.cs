//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationLocation]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationLocationConfiguration : EntityTypeConfiguration<ReclamationLocation>
    {
        public ReclamationLocationConfiguration() : this("dbo"){}

        public ReclamationLocationConfiguration(string schema)
        {
            ToTable("ReclamationLocation", schema);
            HasKey(x => x.ReclamationLocationID);
            Property(x => x.ReclamationLocationID).HasColumnName(@"ReclamationLocationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationLocationName).HasColumnName(@"ReclamationLocationName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.ReclamationLocationAbbreviation).HasColumnName(@"ReclamationLocationAbbreviation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}