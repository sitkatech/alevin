//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElement]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class WbsElementConfiguration : EntityTypeConfiguration<WbsElement>
    {
        public WbsElementConfiguration() : this("ImportFinancial"){}

        public WbsElementConfiguration(string schema)
        {
            ToTable("WbsElement", schema);
            HasKey(x => x.WbsElementID);
            Property(x => x.WbsElementID).HasColumnName(@"WbsElementID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WbsElementKey).HasColumnName(@"WbsElementKey").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.WbsElementText).HasColumnName(@"WbsElementText").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);

            // Foreign keys

        }
    }
}