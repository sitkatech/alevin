//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationSubbasin]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationSubbasinConfiguration : EntityTypeConfiguration<ReclamationSubbasin>
    {
        public ReclamationSubbasinConfiguration() : this("dbo"){}

        public ReclamationSubbasinConfiguration(string schema)
        {
            ToTable("ReclamationSubbasin", schema);
            HasKey(x => x.ReclamationSubbasinID);
            Property(x => x.ReclamationSubbasinID).HasColumnName(@"ReclamationSubbasinID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SubbasinName).HasColumnName(@"SubbasinName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}