//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Staging].[StageImpUnexpendedBalancePayRecV3]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class StageImpUnexpendedBalancePayRecV3Configuration : EntityTypeConfiguration<StageImpUnexpendedBalancePayRecV3>
    {
        public StageImpUnexpendedBalancePayRecV3Configuration() : this("Staging"){}

        public StageImpUnexpendedBalancePayRecV3Configuration(string schema)
        {
            ToTable("StageImpUnexpendedBalancePayRecV3", schema);
            HasKey(x => x.StageImpUnexpendedBalancePayRecV3ID);
            Property(x => x.StageImpUnexpendedBalancePayRecV3ID).HasColumnName(@"StageImpUnexpendedBalancePayRecV3ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BusinessArea).HasColumnName(@"BusinessArea").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FABudgetActivity).HasColumnName(@"FABudgetActivity").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FunctionalArea).HasColumnName(@"FunctionalArea").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationNumber).HasColumnName(@"ObligationNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationItem).HasColumnName(@"ObligationItem").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Fund).HasColumnName(@"Fund").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            //Property(x => x.FundedProgram).HasColumnName(@"FundedProgram").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElement).HasColumnName(@"WBSElement").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElementDescription).HasColumnName(@"WBSElementDescription").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.BudgetObjectClass).HasColumnName(@"BudgetObjectClass").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Vendor).HasColumnName(@"Vendor").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorName).HasColumnName(@"VendorName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.PostingDatePerSpl).HasColumnName(@"PostingDatePerSpl").HasColumnType("datetime").IsOptional();
            Property(x => x.UnexpendedBalance).HasColumnName(@"UnexpendedBalance").HasColumnType("float").IsOptional();

        }
    }
}