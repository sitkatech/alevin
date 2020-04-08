//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[BudgetObjectCodeGroup]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class BudgetObjectCodeGroupConfiguration : EntityTypeConfiguration<BudgetObjectCodeGroup>
    {
        public BudgetObjectCodeGroupConfiguration() : this("Reclamation"){}

        public BudgetObjectCodeGroupConfiguration(string schema)
        {
            ToTable("BudgetObjectCodeGroup", schema);
            HasKey(x => x.BudgetObjectCodeGroupID);
            Property(x => x.BudgetObjectCodeGroupID).HasColumnName(@"BudgetObjectCodeGroupID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BudgetObjectCodeGroupPrefix).HasColumnName(@"BudgetObjectCodeGroupPrefix").HasColumnType("nvarchar").IsRequired().HasMaxLength(5);
            Property(x => x.BudgetObjectCodeGroupName).HasColumnName(@"BudgetObjectCodeGroupName").HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
            Property(x => x.BudgetObjectCodeGroupDefinition).HasColumnName(@"BudgetObjectCodeGroupDefinition").HasColumnType("nvarchar").IsOptional().HasMaxLength(500);
            Property(x => x.ParentBudgetObjectCodeGroupID).HasColumnName(@"ParentBudgetObjectCodeGroupID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.ParentBudgetObjectCodeGroup).WithMany(b => b.BudgetObjectCodeGroupsWhereYouAreTheParentBudgetObjectCodeGroup).HasForeignKey(c => c.ParentBudgetObjectCodeGroupID).WillCascadeOnDelete(false); // FK_BudgetObjectCodeGroup_BudgetObjectCodeGroup_ParentBudgetObjectCodeGroupID_BudgetObjectCodeGroupID
        }
    }
}