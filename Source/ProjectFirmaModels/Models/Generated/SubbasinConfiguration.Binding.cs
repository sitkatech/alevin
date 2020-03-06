//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Subbasin]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubbasinConfiguration : EntityTypeConfiguration<Subbasin>
    {
        public SubbasinConfiguration() : this("Reclamation"){}

        public SubbasinConfiguration(string schema)
        {
            ToTable("Subbasin", schema);
            HasKey(x => x.SubbasinID);
            Property(x => x.SubbasinID).HasColumnName(@"SubbasinID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SubbasinName).HasColumnName(@"SubbasinName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}