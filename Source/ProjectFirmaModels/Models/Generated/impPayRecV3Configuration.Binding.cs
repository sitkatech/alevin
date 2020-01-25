//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[impPayRecV3]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class impPayRecV3Configuration : EntityTypeConfiguration<impPayRecV3>
    {
        public impPayRecV3Configuration() : this("dbo"){}

        public impPayRecV3Configuration(string schema)
        {
            ToTable("impPayRecV3", schema);
            HasKey(x => x.impPayRecV3ID);
            Property(x => x.impPayRecV3ID).HasColumnName(@"impPayRecV3ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Business area - Key).HasColumnName(@"Business area - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FA Budget Activity - Key).HasColumnName(@"FA Budget Activity - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Functional area - Text).HasColumnName(@"Functional area - Text").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Obligation Number - Key).HasColumnName(@"Obligation Number - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Obligation Item - Key).HasColumnName(@"Obligation Item - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Fund - Key).HasColumnName(@"Fund - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Funded Program - Key (Not Compounded)).HasColumnName(@"Funded Program - Key (Not Compounded)").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBS Element - Key).HasColumnName(@"WBS Element - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBS Element - Text).HasColumnName(@"WBS Element - Text").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Budget Object Class - Key).HasColumnName(@"Budget Object Class - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Vendor - Key).HasColumnName(@"Vendor - Key").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Vendor - Text).HasColumnName(@"Vendor - Text").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Obligation).HasColumnName(@"Obligation").HasColumnType("float").IsOptional();
            Property(x => x.Goods Receipt).HasColumnName(@"Goods Receipt").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Invoiced).HasColumnName(@"Invoiced").HasColumnType("float").IsOptional();
            Property(x => x.Disbursed).HasColumnName(@"Disbursed").HasColumnType("float").IsOptional();
            Property(x => x.Unexpended Balance).HasColumnName(@"Unexpended Balance").HasColumnType("float").IsOptional();

        }
    }
}