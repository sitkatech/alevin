//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ObligationNumber]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ObligationNumberConfiguration : EntityTypeConfiguration<ObligationNumber>
    {
        public ObligationNumberConfiguration() : this("ImportFinancial"){}

        public ObligationNumberConfiguration(string schema)
        {
            ToTable("ObligationNumber", schema);
            HasKey(x => x.ObligationNumberID);
            Property(x => x.ObligationNumberID).HasColumnName(@"ObligationNumberID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ObligationNumberKey).HasColumnName(@"ObligationNumberKey").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ReclamationAgreementID).HasColumnName(@"ReclamationAgreementID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.ReclamationAgreement).WithMany(b => b.ObligationNumbers).HasForeignKey(c => c.ReclamationAgreementID).WillCascadeOnDelete(false); // FK_ObligationNumber_ReclamationAgreement_ReclamationAgreementID
        }
    }
}