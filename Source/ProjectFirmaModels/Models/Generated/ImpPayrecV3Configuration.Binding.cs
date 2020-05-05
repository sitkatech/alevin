//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpPayrecV3]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ImpPayrecV3Configuration : EntityTypeConfiguration<ImpPayrecV3>
    {
        public ImpPayrecV3Configuration() : this("ImportFinancial"){}

        public ImpPayrecV3Configuration(string schema)
        {
            ToTable("ImpPayrecV3", schema);
            HasKey(x => x.impPayRecV3ID);
            Property(x => x.impPayRecV3ID).HasColumnName(@"impPayRecV3ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BusinessAreaKey).HasColumnName(@"BusinessAreaKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FABudgetActivityKey).HasColumnName(@"FABudgetActivityKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FunctionalAreaText).HasColumnName(@"FunctionalAreaText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationNumberKey).HasColumnName(@"ObligationNumberKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationItemKey).HasColumnName(@"ObligationItemKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundKey).HasColumnName(@"FundKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundedProgramKey).HasColumnName(@"FundedProgramKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElementKey).HasColumnName(@"WBSElementKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElementText).HasColumnName(@"WBSElementText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.BudgetObjectClassKey).HasColumnName(@"BudgetObjectClassKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorKey).HasColumnName(@"VendorKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorText).HasColumnName(@"VendorText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Obligation).HasColumnName(@"Obligation").HasColumnType("float").IsOptional();
            Property(x => x.GoodsReceipt).HasColumnName(@"GoodsReceipt").HasColumnType("float").IsOptional();
            Property(x => x.Invoiced).HasColumnName(@"Invoiced").HasColumnType("float").IsOptional();
            Property(x => x.Disbursed).HasColumnName(@"Disbursed").HasColumnType("float").IsOptional();
            Property(x => x.UnexpendedBalance).HasColumnName(@"UnexpendedBalance").HasColumnType("float").IsOptional();
            Property(x => x.CreatedOnKey).HasColumnName(@"CreatedOnKey").HasColumnType("datetime").IsOptional();
            Property(x => x.DateOfUpdateKey).HasColumnName(@"DateOfUpdateKey").HasColumnType("datetime").IsOptional();
            Property(x => x.PostingDateKey).HasColumnName(@"PostingDateKey").HasColumnType("datetime").IsOptional();
            Property(x => x.PostingDatePerSplKey).HasColumnName(@"PostingDatePerSplKey").HasColumnType("datetime").IsOptional();
            Property(x => x.DocumentDateOfBlKey).HasColumnName(@"DocumentDateOfBlKey").HasColumnType("datetime").IsOptional();

        }
    }
}