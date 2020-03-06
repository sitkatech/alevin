//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Location]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class LocationConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationConfiguration() : this("Reclamation"){}

        public LocationConfiguration(string schema)
        {
            ToTable("Location", schema);
            HasKey(x => x.LocationID);
            Property(x => x.LocationID).HasColumnName(@"LocationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationLocationName).HasColumnName(@"ReclamationLocationName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.ReclamationLocationAbbreviation).HasColumnName(@"ReclamationLocationAbbreviation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}