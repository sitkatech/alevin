//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityObligationRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityObligationRequestConfiguration : EntityTypeConfiguration<CostAuthorityObligationRequest>
    {
        public CostAuthorityObligationRequestConfiguration() : this("Reclamation"){}

        public CostAuthorityObligationRequestConfiguration(string schema)
        {
            ToTable("CostAuthorityObligationRequest", schema);
            HasKey(x => x.CostAuthorityObligationRequestID);
            Property(x => x.CostAuthorityObligationRequestID).HasColumnName(@"CostAuthorityObligationRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsRequired();
            Property(x => x.ObligationRequestID).HasColumnName(@"ObligationRequestID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectedObligation).HasColumnName(@"ProjectedObligation").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.CostAuthorityObligationRequestNote).HasColumnName(@"CostAuthorityObligationRequestNote").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(800);

            // Foreign keys
            HasRequired(a => a.CostAuthority).WithMany(b => b.CostAuthorityObligationRequests).HasForeignKey(c => c.CostAuthorityID).WillCascadeOnDelete(false); // FK_CostAuthorityObligationRequest_CostAuthority_CostAuthorityID
            HasRequired(a => a.ObligationRequest).WithMany(b => b.CostAuthorityObligationRequests).HasForeignKey(c => c.ObligationRequestID).WillCascadeOnDelete(false); // FK_CostAuthorityObligationRequest_ObligationRequest_ObligationRequestID
        }
    }
}