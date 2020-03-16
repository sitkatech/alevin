//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ObligationItem]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ObligationItemConfiguration : EntityTypeConfiguration<ObligationItem>
    {
        public ObligationItemConfiguration() : this("ImportFinancial"){}

        public ObligationItemConfiguration(string schema)
        {
            ToTable("ObligationItem", schema);
            HasKey(x => x.ObligationItemID);
            Property(x => x.ObligationItemID).HasColumnName(@"ObligationItemID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ObligationItemKey).HasColumnName(@"ObligationItemKey").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ObligationNumberID).HasColumnName(@"ObligationNumberID").HasColumnType("int").IsRequired();
            Property(x => x.VendorID).HasColumnName(@"VendorID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ObligationNumber).WithMany(b => b.ObligationItems).HasForeignKey(c => c.ObligationNumberID).WillCascadeOnDelete(false); // FK_ObligationItem_ObligationNumber_ObligationNumberID
            HasRequired(a => a.Vendor).WithMany(b => b.ObligationItems).HasForeignKey(c => c.VendorID).WillCascadeOnDelete(false); // FK_ObligationItem_Vendor_VendorID
        }
    }
}