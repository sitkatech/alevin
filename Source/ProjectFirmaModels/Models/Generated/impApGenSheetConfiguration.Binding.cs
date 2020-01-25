//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[impApGenSheet]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class impApGenSheetConfiguration : EntityTypeConfiguration<impApGenSheet>
    {
        public impApGenSheetConfiguration() : this("dbo"){}

        public impApGenSheetConfiguration(string schema)
        {
            ToTable("impApGenSheet", schema);
            HasKey(x => x.impApGenSheetID);
            Property(x => x.impApGenSheetID).HasColumnName(@"impApGenSheetID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PO Number - Key).HasColumnName(@"PO Number - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Purch Ord Line Itm - Key).HasColumnName(@"Purch Ord Line Itm - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Reference - Key).HasColumnName(@"Reference - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Vendor - Key).HasColumnName(@"Vendor - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Vendor - Text).HasColumnName(@"Vendor - Text").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Fund - Key).HasColumnName(@"Fund - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Funded Program - Key).HasColumnName(@"Funded Program - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBS Element - Key).HasColumnName(@"WBS Element - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBS Element - Text).HasColumnName(@"WBS Element - Text").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Budget Object Class - Key).HasColumnName(@"Budget Object Class - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Debit Amount).HasColumnName(@"Debit Amount").HasColumnType("float").IsOptional();
            Property(x => x.Credit Amount).HasColumnName(@"Credit Amount").HasColumnType("float").IsOptional();
            Property(x => x.Debit/Credit Total).HasColumnName(@"Debit/Credit Total").HasColumnType("float").IsOptional();

        }
    }
}