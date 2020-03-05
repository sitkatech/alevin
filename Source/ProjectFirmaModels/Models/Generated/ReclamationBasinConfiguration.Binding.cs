//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationBasin]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationBasinConfiguration : EntityTypeConfiguration<ReclamationBasin>
    {
        public ReclamationBasinConfiguration() : this("Reclamation"){}

        public ReclamationBasinConfiguration(string schema)
        {
            ToTable("ReclamationBasin", schema);
            HasKey(x => x.ReclamationBasinID);
            Property(x => x.ReclamationBasinID).HasColumnName(@"ReclamationBasinID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BasinAbbreviation).HasColumnName(@"BasinAbbreviation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.BasinName).HasColumnName(@"BasinName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}