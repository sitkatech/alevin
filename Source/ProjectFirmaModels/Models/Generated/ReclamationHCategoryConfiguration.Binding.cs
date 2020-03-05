//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationHCategory]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationHCategoryConfiguration : EntityTypeConfiguration<ReclamationHCategory>
    {
        public ReclamationHCategoryConfiguration() : this("Reclamation"){}

        public ReclamationHCategoryConfiguration(string schema)
        {
            ToTable("ReclamationHCategory", schema);
            HasKey(x => x.ReclamationHCategoryID);
            Property(x => x.ReclamationHCategoryID).HasColumnName(@"ReclamationHCategoryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.HabitatCategoryName).HasColumnName(@"HabitatCategoryName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);

            // Foreign keys

        }
    }
}