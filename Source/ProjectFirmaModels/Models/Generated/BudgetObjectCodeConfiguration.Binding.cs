//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[BudgetObjectCode]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class BudgetObjectCodeConfiguration : EntityTypeConfiguration<BudgetObjectCode>
    {
        public BudgetObjectCodeConfiguration() : this("Reclamation"){}

        public BudgetObjectCodeConfiguration(string schema)
        {
            ToTable("BudgetObjectCode", schema);
            HasKey(x => x.BudgetObjectCodeID);
            Property(x => x.BudgetObjectCodeID).HasColumnName(@"BudgetObjectCodeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BudgetObjectCodeName).HasColumnName(@"BudgetObjectCodeName").HasColumnType("nvarchar").IsRequired().HasMaxLength(6);
            Property(x => x.BudgetObjectCodeItemDescription).HasColumnName(@"BudgetObjectCodeItemDescription").HasColumnType("nvarchar").IsRequired().HasMaxLength(1000);
            Property(x => x.BudgetObjectCodeDefinition).HasColumnName(@"BudgetObjectCodeDefinition").HasColumnType("nvarchar").IsOptional().HasMaxLength(1000);
            Property(x => x.FbmsYear).HasColumnName(@"FbmsYear").HasColumnType("int").IsRequired();
            Property(x => x.Reportable1099).HasColumnName(@"Reportable1099").HasColumnType("bit").IsOptional();
            Property(x => x.Explanation1099).HasColumnName(@"Explanation1099").HasColumnType("nvarchar").IsOptional().HasMaxLength(1000);

            // Foreign keys

        }
    }
}