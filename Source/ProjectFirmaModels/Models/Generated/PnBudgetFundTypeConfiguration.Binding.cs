//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[PnBudgetFundType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PnBudgetFundTypeConfiguration : EntityTypeConfiguration<PnBudgetFundType>
    {
        public PnBudgetFundTypeConfiguration() : this("ImportFinancial"){}

        public PnBudgetFundTypeConfiguration(string schema)
        {
            ToTable("PnBudgetFundType", schema);
            HasKey(x => x.PnBudgetFundTypeID);
            Property(x => x.PnBudgetFundTypeID).HasColumnName(@"PnBudgetFundTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PnBudgetFundTypeName).HasColumnName(@"PnBudgetFundTypeName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.PnBudgetFundTypeDisplayName).HasColumnName(@"PnBudgetFundTypeDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}