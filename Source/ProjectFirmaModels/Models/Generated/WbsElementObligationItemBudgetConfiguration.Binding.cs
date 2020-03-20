//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementObligationItemBudget]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class WbsElementObligationItemBudgetConfiguration : EntityTypeConfiguration<WbsElementObligationItemBudget>
    {
        public WbsElementObligationItemBudgetConfiguration() : this("ImportFinancial"){}

        public WbsElementObligationItemBudgetConfiguration(string schema)
        {
            ToTable("WbsElementObligationItemBudget", schema);
            HasKey(x => x.WbsElementObligationItemBudgetID);
            Property(x => x.WbsElementObligationItemBudgetID).HasColumnName(@"WbsElementObligationItemBudgetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WbsElementID).HasColumnName(@"WbsElementID").HasColumnType("int").IsRequired();
            Property(x => x.ObligationItemID).HasColumnName(@"ObligationItemID").HasColumnType("int").IsRequired();
            Property(x => x.Obligation).HasColumnName(@"Obligation").HasColumnType("float").IsOptional();
            Property(x => x.GoodsReceipt).HasColumnName(@"GoodsReceipt").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.Invoiced).HasColumnName(@"Invoiced").HasColumnType("float").IsOptional();
            Property(x => x.Disbursed).HasColumnName(@"Disbursed").HasColumnType("float").IsOptional();
            Property(x => x.UnexpendedBalance).HasColumnName(@"UnexpendedBalance").HasColumnType("float").IsOptional();
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsRequired();
            Property(x => x.CreatedOnKey).HasColumnName(@"CreatedOnKey").HasColumnType("datetime").IsOptional();
            Property(x => x.DateOfUpdateKey).HasColumnName(@"DateOfUpdateKey").HasColumnType("datetime").IsOptional();
            Property(x => x.PostingDateKey).HasColumnName(@"PostingDateKey").HasColumnType("datetime").IsOptional();
            Property(x => x.PostingDatePerSplKey).HasColumnName(@"PostingDatePerSplKey").HasColumnType("datetime").IsOptional();
            Property(x => x.DocumentDateOfBlKey).HasColumnName(@"DocumentDateOfBlKey").HasColumnType("datetime").IsOptional();
            Property(x => x.BudgetObjectCodeID).HasColumnName(@"BudgetObjectCodeID").HasColumnType("int").IsOptional();
            Property(x => x.FundID).HasColumnName(@"FundID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.WbsElement).WithMany(b => b.WbsElementObligationItemBudgets).HasForeignKey(c => c.WbsElementID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemBudget_WbsElement_WbsElementID
            HasRequired(a => a.ObligationItem).WithMany(b => b.WbsElementObligationItemBudgets).HasForeignKey(c => c.ObligationItemID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemBudget_ObligationItem_ObligationItemID
            HasRequired(a => a.CostAuthority).WithMany(b => b.WbsElementObligationItemBudgets).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemBudget_CostAuthority_CostAuthorityID
            HasOptional(a => a.BudgetObjectCode).WithMany(b => b.WbsElementObligationItemBudgets).HasForeignKey(c => c.BudgetObjectCodeID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemBudget_BudgetObjectCode_BudgetObjectCodeID
            HasRequired(a => a.Fund).WithMany(b => b.WbsElementObligationItemBudgets).HasForeignKey(c => c.FundID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemBudget_Fund_FundID
        }
    }
}