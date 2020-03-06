//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementCostAuthority]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AgreementCostAuthorityConfiguration : EntityTypeConfiguration<AgreementCostAuthority>
    {
        public AgreementCostAuthorityConfiguration() : this("Reclamation"){}

        public AgreementCostAuthorityConfiguration(string schema)
        {
            ToTable("AgreementCostAuthority", schema);
            HasKey(x => x.AgreementCostAuthorityID);
            Property(x => x.AgreementCostAuthorityID).HasColumnName(@"AgreementCostAuthorityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AgreementID).HasColumnName(@"AgreementID").HasColumnType("int").IsRequired();
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Agreement).WithMany(b => b.AgreementCostAuthorities).HasForeignKey(c => c.AgreementID).WillCascadeOnDelete(false); // FK_AgreementCostAuthority_Agreement_AgreementID
            HasRequired(a => a.CostAuthority).WithMany(b => b.AgreementCostAuthoritiesWhereYouAreTheCostAuthority).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_AgreementCostAuthority_CostAuthority_CostAuthorityID_ReclamationCostAuthorityID
        }
    }
}