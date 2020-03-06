//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementReclamationCostAuthority]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AgreementReclamationCostAuthorityConfiguration : EntityTypeConfiguration<AgreementReclamationCostAuthority>
    {
        public AgreementReclamationCostAuthorityConfiguration() : this("Reclamation"){}

        public AgreementReclamationCostAuthorityConfiguration(string schema)
        {
            ToTable("AgreementReclamationCostAuthority", schema);
            HasKey(x => x.ReclamationAgreementReclamationCostAuthorityID);
            Property(x => x.ReclamationAgreementReclamationCostAuthorityID).HasColumnName(@"ReclamationAgreementReclamationCostAuthorityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationAgreementID).HasColumnName(@"ReclamationAgreementID").HasColumnType("int").IsRequired();
            Property(x => x.ReclamationCostAuthorityID).HasColumnName(@"ReclamationCostAuthorityID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ReclamationAgreement).WithMany(b => b.AgreementReclamationCostAuthoritiesWhereYouAreTheReclamationAgreement).HasForeignKey(c => c.ReclamationAgreementID).WillCascadeOnDelete(false); // FK_AgreementReclamationCostAuthority_Agreement_ReclamationAgreementID_AgreementID
            HasRequired(a => a.ReclamationCostAuthority).WithMany(b => b.AgreementReclamationCostAuthorities).HasForeignKey(c => c.ReclamationCostAuthorityID).WillCascadeOnDelete(false); // FK_AgreementReclamationCostAuthority_CostAuthority_ReclamationCostAuthorityID
        }
    }
}