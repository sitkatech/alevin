//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ProjectFundingSourceBudgetUpdate]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceBudgetUpdateConfiguration : EntityTypeConfiguration<ProjectFundingSourceBudgetUpdate>
    {
        public ProjectFundingSourceBudgetUpdateConfiguration() : this("Reclamation"){}

        public ProjectFundingSourceBudgetUpdateConfiguration(string schema)
        {
            ToTable("ProjectFundingSourceBudgetUpdate", schema);
            HasKey(x => x.ProjectFundingSourceBudgetUpdateID);
            Property(x => x.ProjectFundingSourceBudgetUpdateID).HasColumnName(@"ProjectFundingSourceBudgetUpdateID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectUpdateBatchID).HasColumnName(@"ProjectUpdateBatchID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectedAmount).HasColumnName(@"ProjectedAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.CalendarYear).HasColumnName(@"CalendarYear").HasColumnType("int").IsOptional();
            Property(x => x.CostTypeID).HasColumnName(@"CostTypeID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasRequired(a => a.ProjectUpdateBatch).WithMany(b => b.ProjectFundingSourceBudgetUpdates).HasForeignKey(c => c.ProjectUpdateBatchID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudgetUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
            HasRequired(a => a.FundingSource).WithMany(b => b.ProjectFundingSourceBudgetUpdates).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudgetUpdate_FundingSource_FundingSourceID
            HasOptional(a => a.CostType).WithMany(b => b.ProjectFundingSourceBudgetUpdates).HasForeignKey(c => c.CostTypeID).WillCascadeOnDelete(false); // FK_ProjectFundingSourceBudgetUpdate_CostType_CostTypeID
        }
    }
}