//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityAgreementRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityAgreementRequestConfiguration : EntityTypeConfiguration<CostAuthorityAgreementRequest>
    {
        public CostAuthorityAgreementRequestConfiguration() : this("Reclamation"){}

        public CostAuthorityAgreementRequestConfiguration(string schema)
        {
            ToTable("CostAuthorityAgreementRequest", schema);
            HasKey(x => x.CostAuthorityAgreementRequestID);
            Property(x => x.CostAuthorityAgreementRequestID).HasColumnName(@"CostAuthorityAgreementRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsRequired();
            Property(x => x.AgreementRequestID).HasColumnName(@"AgreementRequestID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectedObligation).HasColumnName(@"ProjectedObligation").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.ReclamationCostAuthorityAgreementRequestNote).HasColumnName(@"ReclamationCostAuthorityAgreementRequestNote").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(800);

            // Foreign keys
            HasRequired(a => a.CostAuthority).WithMany(b => b.CostAuthorityAgreementRequests).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_CostAuthorityAgreementRequest_CostAuthority_CostAuthorityID
            HasRequired(a => a.AgreementRequest).WithMany(b => b.CostAuthorityAgreementRequests).HasForeignKey(c => c.AgreementRequestID).WillCascadeOnDelete(false); // FK_CostAuthorityAgreementRequest_AgreementRequest_AgreementRequestID
        }
    }
}