//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpApGenSheet]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ImpApGenSheetConfiguration : EntityTypeConfiguration<ImpApGenSheet>
    {
        public ImpApGenSheetConfiguration() : this("ImportFinancial"){}

        public ImpApGenSheetConfiguration(string schema)
        {
            ToTable("ImpApGenSheet", schema);
            HasKey(x => x.impApGenSheetID);
            Property(x => x.impApGenSheetID).HasColumnName(@"impApGenSheetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PONumberKey).HasColumnName(@"PONumberKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.PurchOrdLineItmKey).HasColumnName(@"PurchOrdLineItmKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ReferenceKey).HasColumnName(@"ReferenceKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorKey).HasColumnName(@"VendorKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorText).HasColumnName(@"VendorText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundKey).HasColumnName(@"FundKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FundedProgramKey).HasColumnName(@"FundedProgramKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElementKey).HasColumnName(@"WBSElementKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSElementText).HasColumnName(@"WBSElementText").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.BudgetObjectClassKey).HasColumnName(@"BudgetObjectClassKey").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.DebitAmount).HasColumnName(@"DebitAmount").HasColumnType("float").IsOptional();
            Property(x => x.CreditAmount).HasColumnName(@"CreditAmount").HasColumnType("float").IsOptional();
            Property(x => x.DebitCreditTotal).HasColumnName(@"DebitCreditTotal").HasColumnType("float").IsOptional();
            Property(x => x.CreatedOnKey).HasColumnName(@"CreatedOnKey").HasColumnType("datetime").IsOptional();
            Property(x => x.PostingDateKey).HasColumnName(@"PostingDateKey").HasColumnType("datetime").IsOptional();

        }
    }
}