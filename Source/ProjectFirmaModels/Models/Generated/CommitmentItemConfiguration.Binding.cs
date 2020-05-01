//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[CommitmentItem]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CommitmentItemConfiguration : EntityTypeConfiguration<CommitmentItem>
    {
        public CommitmentItemConfiguration() : this("ImportFinancial"){}

        public CommitmentItemConfiguration(string schema)
        {
            ToTable("CommitmentItem", schema);
            HasKey(x => x.CommitmentItemID);
            Property(x => x.CommitmentItemID).HasColumnName(@"CommitmentItemID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CommitmentItemName).HasColumnName(@"CommitmentItemName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}