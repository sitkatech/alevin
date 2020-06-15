//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImportFinancialImpPayRecUnexpendedV3]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ImportFinancialImpPayRecUnexpendedV3Configuration : EntityTypeConfiguration<ImportFinancialImpPayRecUnexpendedV3>
    {
        public ImportFinancialImpPayRecUnexpendedV3Configuration() : this("ImportFinancial"){}

        public ImportFinancialImpPayRecUnexpendedV3Configuration(string schema)
        {
            ToTable("ImportFinancialImpPayRecUnexpendedV3", schema);
            HasKey(x => x.ImportFinancialImpPayRecUnexpendedV3ID);
            Property(x => x.ImportFinancialImpPayRecUnexpendedV3ID).HasColumnName(@"ImportFinancialImpPayRecUnexpendedV3ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BusinessArea).HasColumnName(@"BusinessArea").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FABudgetActivity).HasColumnName(@"FABudgetActivity").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FunctionalArea).HasColumnName(@"FunctionalArea").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationNumber).HasColumnName(@"ObligationNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ObligationItem).HasColumnName(@"ObligationItem").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Fund).HasColumnName(@"Fund").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundedProgram).HasColumnName(@"FundedProgram").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
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