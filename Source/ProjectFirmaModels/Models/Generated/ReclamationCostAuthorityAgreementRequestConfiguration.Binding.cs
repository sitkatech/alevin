//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationCostAuthorityAgreementRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationCostAuthorityAgreementRequestConfiguration : EntityTypeConfiguration<ReclamationCostAuthorityAgreementRequest>
    {
        public ReclamationCostAuthorityAgreementRequestConfiguration() : this("dbo"){}

        public ReclamationCostAuthorityAgreementRequestConfiguration(string schema)
        {
            ToTable("ReclamationCostAuthorityAgreementRequest", schema);
            HasKey(x => x.ReclamationCostAuthorityAgreementRequestID);
            Property(x => x.ReclamationCostAuthorityAgreementRequestID).HasColumnName(@"ReclamationCostAuthorityAgreementRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsRequired();
            Property(x => x.AgreementRequestID).HasColumnName(@"AgreementRequestID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectedObligation).HasColumnName(@"ProjectedObligation").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.ReclamationCostAuthorityAgreementRequestNote).HasColumnName(@"ReclamationCostAuthorityAgreementRequestNote").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(800);

            // Foreign keys
            HasRequired(a => a.CostAuthority).WithMany(b => b.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheCostAuthority).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_ReclamationCostAuthorityAgreementRequest_ReclamationCostAuthority_CostAuthorityID_ReclamationCostAuthorityID
            HasRequired(a => a.AgreementRequest).WithMany(b => b.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest).HasForeignKey(c => c.AgreementRequestID).WillCascadeOnDelete(false); // FK_ReclamationCostAuthorityAgreementRequest_ReclamationAgreementRequest_AgreementRequestID_ReclamationAgreementRequestID
        }
    }
}