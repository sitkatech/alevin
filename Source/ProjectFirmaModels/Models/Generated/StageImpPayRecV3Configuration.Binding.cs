//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StageImpPayRecV3]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class StageImpPayRecV3Configuration : EntityTypeConfiguration<StageImpPayRecV3>
    {
        public StageImpPayRecV3Configuration() : this("dbo"){}

        public StageImpPayRecV3Configuration(string schema)
        {
            ToTable("StageImpPayRecV3", schema);
            HasKey(x => x.StageImpPayRecV3ID);
            Property(x => x.StageImpPayRecV3ID).HasColumnName(@"StageImpPayRecV3ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BusinessAreaKey).HasColumnName(@"BusinessAreaKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FABudgetActivityKey).HasColumnName(@"FABudgetActivityKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FunctionalAreaText).HasColumnName(@"FunctionalAreaText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationNumberKey).HasColumnName(@"ObligationNumberKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationItemKey).HasColumnName(@"ObligationItemKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundKey).HasColumnName(@"FundKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundedProgramKeyNotCompounded).HasColumnName(@"FundedProgramKeyNotCompounded").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElementKey).HasColumnName(@"WBSElementKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElementText).HasColumnName(@"WBSElementText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.BudgetObjectClassKey).HasColumnName(@"BudgetObjectClassKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorKey).HasColumnName(@"VendorKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorText).HasColumnName(@"VendorText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Obligation).HasColumnName(@"Obligation").HasColumnType("float").IsOptional();
            Property(x => x.GoodsReceipt).HasColumnName(@"GoodsReceipt").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Invoiced).HasColumnName(@"Invoiced").HasColumnType("float").IsOptional();
            Property(x => x.Disbursed).HasColumnName(@"Disbursed").HasColumnType("float").IsOptional();
            Property(x => x.UnexpendedBalance).HasColumnName(@"UnexpendedBalance").HasColumnType("float").IsOptional();

        }
    }
}