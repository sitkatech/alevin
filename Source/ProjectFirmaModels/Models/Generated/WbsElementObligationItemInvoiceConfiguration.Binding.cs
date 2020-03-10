//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementObligationItemInvoice]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class WbsElementObligationItemInvoiceConfiguration : EntityTypeConfiguration<WbsElementObligationItemInvoice>
    {
        public WbsElementObligationItemInvoiceConfiguration() : this("ImportFinancial"){}

        public WbsElementObligationItemInvoiceConfiguration(string schema)
        {
            ToTable("WbsElementObligationItemInvoice", schema);
            HasKey(x => x.WbsElementObligationItemInvoiceID);
            Property(x => x.WbsElementObligationItemInvoiceID).HasColumnName(@"WbsElementObligationItemInvoiceID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WbsElementID).HasColumnName(@"WbsElementID").HasColumnType("int").IsRequired();
            Property(x => x.ObligationItemID).HasColumnName(@"ObligationItemID").HasColumnType("int").IsRequired();
            Property(x => x.DebitAmount).HasColumnName(@"DebitAmount").HasColumnType("float").IsOptional();
            Property(x => x.CreditAmount).HasColumnName(@"CreditAmount").HasColumnType("float").IsOptional();
            Property(x => x.DebitCreditTotal).HasColumnName(@"DebitCreditTotal").HasColumnType("float").IsOptional();
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.WbsElement).WithMany(b => b.WbsElementObligationItemInvoices).HasForeignKey(c => c.WbsElementID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemInvoice_WbsElement_WbsElementID
            HasRequired(a => a.ObligationItem).WithMany(b => b.WbsElementObligationItemInvoices).HasForeignKey(c => c.ObligationItemID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemInvoice_ObligationItem_ObligationItemID
            HasRequired(a => a.CostAuthority).WithMany(b => b.WbsElementObligationItemInvoices).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_WbsElementObligationItemInvoice_CostAuthority_CostAuthorityID
        }
    }
}