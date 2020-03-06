//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[HCategory]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class HCategoryConfiguration : EntityTypeConfiguration<HCategory>
    {
        public HCategoryConfiguration() : this("Reclamation"){}

        public HCategoryConfiguration(string schema)
        {
            ToTable("HCategory", schema);
            HasKey(x => x.HCategoryID);
            Property(x => x.HCategoryID).HasColumnName(@"HCategoryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.HabitatCategoryName).HasColumnName(@"HabitatCategoryName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);

            // Foreign keys

        }
    }
}