//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StageImpApGenSheet]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class StageImpApGenSheetConfiguration : EntityTypeConfiguration<StageImpApGenSheet>
    {
        public StageImpApGenSheetConfiguration() : this("dbo"){}

        public StageImpApGenSheetConfiguration(string schema)
        {
            ToTable("StageImpApGenSheet", schema);
            HasKey(x => x.StageImpApGenSheetID);
            Property(x => x.StageImpApGenSheetID).HasColumnName(@"StageImpApGenSheetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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

        }
    }
}