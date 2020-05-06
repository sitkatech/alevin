//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementPnBudget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class WbsElementPnBudgetConfiguration : EntityTypeConfiguration<WbsElementPnBudget>
    {
        public WbsElementPnBudgetConfiguration() : this("ImportFinancial"){}

        public WbsElementPnBudgetConfiguration(string schema)
        {
            ToTable("WbsElementPnBudget", schema);
            HasKey(x => x.WbsElementPnBudgetID);
            Property(x => x.WbsElementPnBudgetID).HasColumnName(@"WbsElementPnBudgetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WbsElementID).HasColumnName(@"WbsElementID").HasColumnType("int").IsRequired();
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsOptional();
            Property(x => x.PnBudgetFundTypeID).HasColumnName(@"PnBudgetFundTypeID").HasColumnType("int").IsRequired();
            Property(x => x.FundingSourceID).HasColumnName(@"FundingSourceID").HasColumnType("int").IsRequired();
            Property(x => x.FundsCenter).HasColumnName(@"FundsCenter").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(x => x.FiscalQuarterID).HasColumnName(@"FiscalQuarterID").HasColumnType("int").IsRequired();
            Property(x => x.FiscalYear).HasColumnName(@"FiscalYear").HasColumnType("int").IsRequired();
            Property(x => x.CommitmentItemID).HasColumnName(@"CommitmentItemID").HasColumnType("int").IsOptional();
            Property(x => x.BudgetObjectCodeID).HasColumnName(@"BudgetObjectCodeID").HasColumnType("int").IsOptional();
            Property(x => x.FIDocNumber).HasColumnName(@"FIDocNumber").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Recoveries).HasColumnName(@"Recoveries").HasColumnType("float").IsOptional();
            Property(x => x.CommittedButNotObligated).HasColumnName(@"CommittedButNotObligated").HasColumnType("float").IsOptional();
            Property(x => x.TotalObligations).HasColumnName(@"TotalObligations").HasColumnType("float").IsOptional();
            Property(x => x.TotalExpenditures).HasColumnName(@"TotalExpenditures").HasColumnType("float").IsOptional();
            Property(x => x.UndeliveredOrders).HasColumnName(@"UndeliveredOrders").HasColumnType("float").IsOptional();

            // Foreign keys
            HasRequired(a => a.WbsElement).WithMany(b => b.WbsElementPnBudgets).HasForeignKey(c => c.WbsElementID).WillCascadeOnDelete(false); // FK_WbsElementPnBudget_WbsElement_WbsElementID
            HasOptional(a => a.CostAuthority).WithMany(b => b.WbsElementPnBudgets).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_WbsElementPnBudget_CostAuthority_CostAuthorityID
            HasRequired(a => a.PnBudgetFundType).WithMany(b => b.WbsElementPnBudgets).HasForeignKey(c => c.PnBudgetFundTypeID).WillCascadeOnDelete(false); // FK_WbsElementPnBudget_PnBudgetFundType_PnBudgetFundTypeID
            HasRequired(a => a.FundingSource).WithMany(b => b.WbsElementPnBudgets).HasForeignKey(c => c.FundingSourceID).WillCascadeOnDelete(false); // FK_WbsElementPnBudget_FundingSource_FundingSourceID
            HasRequired(a => a.FiscalQuarter).WithMany(b => b.WbsElementPnBudgets).HasForeignKey(c => c.FiscalQuarterID).WillCascadeOnDelete(false); // FK_WbsElementPnBudget_FiscalQuarter_FiscalQuarterID
            HasOptional(a => a.CommitmentItem).WithMany(b => b.WbsElementPnBudgets).HasForeignKey(c => c.CommitmentItemID).WillCascadeOnDelete(false); // FK_WbsElementPnBudget_CommitmentItem_CommitmentItemID
            HasOptional(a => a.BudgetObjectCode).WithMany(b => b.WbsElementPnBudgets).HasForeignKey(c => c.BudgetObjectCodeID).WillCascadeOnDelete(false); // FK_WbsElementPnBudget_BudgetObjectCode_BudgetObjectCodeID
        }
    }
}