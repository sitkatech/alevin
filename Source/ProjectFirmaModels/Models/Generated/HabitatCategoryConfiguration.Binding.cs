//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[HabitatCategory]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class HabitatCategoryConfiguration : EntityTypeConfiguration<HabitatCategory>
    {
        public HabitatCategoryConfiguration() : this("dbo"){}

        public HabitatCategoryConfiguration(string schema)
        {
            ToTable("HabitatCategory", schema);
            HasKey(x => x.HabitatCategoryID);
            Property(x => x.HabitatCategoryID).HasColumnName(@"HabitatCategoryID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.HabitatCategoryName).HasColumnName(@"HabitatCategoryName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);

            // Foreign keys

        }
    }
}