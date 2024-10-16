//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ProjectFundingSourceBudget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceBudgetConfiguration : EntityTypeConfiguration<ProjectFundingSourceBudget>
    {
        public ProjectFundingSourceBudgetConfiguration() : this("Reclamation"){}

        public ProjectFundingSourceBudgetConfiguration(string schema)
        {
            ToTable("ProjectFundingSourceBudget", schema);
            HasKey(x => x.ProjectFundingSourceBudgetID);
            Property(x => x.ProjectFundingSourceBudgetID).HasColumnName(@"ProjectFundingSourceBudgetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectedAmount).HasColumnName(@"ProjectedAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsOptional();
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectFundingSourceBudgets).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudget_Project_ProjectID
            HasRequired(a => a.FundingSource).WithMany(b => b.ProjectFundingSourceBudgets).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID
            HasOptional(a => a.CostType).WithMany(b => b.ProjectFundingSourceBudgets).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudget_CostType_CostTypeID
        }
    }
}