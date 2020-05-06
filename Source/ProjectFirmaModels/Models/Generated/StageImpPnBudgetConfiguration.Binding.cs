//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Staging].[StageImpPnBudget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class StageImpPnBudgetConfiguration : EntityTypeConfiguration<StageImpPnBudget>
    {
        public StageImpPnBudgetConfiguration() : this("Staging"){}

        public StageImpPnBudgetConfiguration(string schema)
        {
            ToTable("StageImpPnBudget", schema);
            HasKey(x => x.StageImpPnBudgetID);
            Property(x => x.StageImpPnBudgetID).HasColumnName(@"StageImpPnBudgetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FundedProgram).HasColumnName(@"FundedProgram").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundType).HasColumnName(@"FundType").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Fund).HasColumnName(@"Fund").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundsCenter).HasColumnName(@"FundsCenter").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FiscalYearPeriod).HasColumnName(@"FiscalYearPeriod").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.CommitmentItem).HasColumnName(@"CommitmentItem").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FiDocNumber).HasColumnName(@"FiDocNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Recoveries).HasColumnName(@"Recoveries").HasColumnType("float").IsOptional();
            Property(x => x.CommittedButNotObligated).HasColumnName(@"CommittedButNotObligated").HasColumnType("float").IsOptional();
            Property(x => x.TotalObligations).HasColumnName(@"TotalObligations").HasColumnType("float").IsOptional();
            Property(x => x.TotalExpenditures).HasColumnName(@"TotalExpenditures").HasColumnType("float").IsOptional();
            Property(x => x.UndeliveredOrders).HasColumnName(@"UndeliveredOrders").HasColumnType("float").IsOptional();

        }
    }
}