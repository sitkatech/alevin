//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationAgreementReclamationCostAuthority]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementReclamationCostAuthorityConfiguration : EntityTypeConfiguration<ReclamationAgreementReclamationCostAuthority>
    {
        public ReclamationAgreementReclamationCostAuthorityConfiguration() : this("Reclamation"){}

        public ReclamationAgreementReclamationCostAuthorityConfiguration(string schema)
        {
            ToTable("ReclamationAgreementReclamationCostAuthority", schema);
            HasKey(x => x.ReclamationAgreementReclamationCostAuthorityID);
            Property(x => x.ReclamationAgreementReclamationCostAuthorityID).HasColumnName(@"ReclamationAgreementReclamationCostAuthorityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationAgreementID).HasColumnName(@"ReclamationAgreementID").HasColumnType("int").IsRequired();
            Property(x => x.ReclamationCostAuthorityID).HasColumnName(@"ReclamationCostAuthorityID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ReclamationAgreement).WithMany(b => b.ReclamationAgreementReclamationCostAuthorities).HasForeignKey(c => c.ReclamationAgreementID).WillCascadeOnDelete(false); // FK_ReclamationAgreementReclamationCostAuthority_ReclamationAgreement_ReclamationAgreementID
            HasRequired(a => a.ReclamationCostAuthority).WithMany(b => b.ReclamationAgreementReclamationCostAuthorities).HasForeignKey(c => c.ReclamationCostAuthorityID).WillCascadeOnDelete(false); // FK_ReclamationAgreementReclamationCostAuthority_ReclamationCostAuthority_ReclamationCostAuthorityID
        }
    }
}