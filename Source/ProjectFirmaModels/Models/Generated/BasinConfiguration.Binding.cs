//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Basin]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class BasinConfiguration : EntityTypeConfiguration<Basin>
    {
        public BasinConfiguration() : this("dbo"){}

        public BasinConfiguration(string schema)
        {
            ToTable("Basin", schema);
            HasKey(x => x.BasinID);
            Property(x => x.BasinID).HasColumnName(@"BasinID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BasinAbbreviation).HasColumnName(@"BasinAbbreviation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.BasinName).HasColumnName(@"BasinName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}