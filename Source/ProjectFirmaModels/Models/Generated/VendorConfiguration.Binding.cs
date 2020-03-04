//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[Vendor]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class VendorConfiguration : EntityTypeConfiguration<Vendor>
    {
        public VendorConfiguration() : this("ImportFinancial"){}

        public VendorConfiguration(string schema)
        {
            ToTable("Vendor", schema);
            HasKey(x => x.VendorID);
            Property(x => x.VendorID).HasColumnName(@"VendorID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.VendorKey).HasColumnName(@"VendorKey").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.VendorText).HasColumnName(@"VendorText").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);

        }
    }
}