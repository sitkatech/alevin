//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingCostAuthorityAgreement]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingCostAuthorityAgreementConfiguration : EntityTypeConfiguration<ReclamationStagingCostAuthorityAgreement>
    {
        public ReclamationStagingCostAuthorityAgreementConfiguration() : this("Reclamation"){}

        public ReclamationStagingCostAuthorityAgreementConfiguration(string schema)
        {
            ToTable("ReclamationStagingCostAuthorityAgreement", schema);
            HasKey(x => x.ReclamationStagingCostAuthorityAgreementID);
            Property(x => x.ReclamationStagingCostAuthorityAgreementID).HasColumnName(@"ReclamationStagingCostAuthorityAgreementID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OriginalReclamationCostAuthorityAgreementID).HasColumnName(@"OriginalReclamationCostAuthorityAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.CostAuthorityWorkBreakdownStructure).HasColumnName(@"CostAuthorityWorkBreakdownStructure").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.CostAuthorityNumber).HasColumnName(@"CostAuthorityNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.AgreementNumber).HasColumnName(@"AgreementNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.PacificNorthActivityNumber).HasColumnName(@"PacificNorthActivityNumber").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityName).HasColumnName(@"PacificNorthActivityName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.AgreementID).HasColumnName(@"AgreementID").HasColumnType("int").IsOptional();
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.Agreement).WithMany(b => b.ReclamationStagingCostAuthorityAgreementsWhereYouAreTheAgreement).HasForeignKey(c => c.AgreementID).WillCascadeOnDelete(false); // FK_ReclamationStagingCostAuthorityAgreement_ReclamationAgreement_AgreementID_ReclamationAgreementID
            HasOptional(a => a.CostAuthority).WithMany(b => b.ReclamationStagingCostAuthorityAgreementsWhereYouAreTheCostAuthority).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_ReclamationStagingCostAuthorityAgreement_ReclamationCostAuthority_CostAuthorityID_ReclamationCostAuthorityID
        }
    }
}