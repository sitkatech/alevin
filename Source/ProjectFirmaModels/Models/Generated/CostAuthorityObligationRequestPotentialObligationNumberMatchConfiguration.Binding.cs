//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityObligationRequestPotentialObligationNumberMatch]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityObligationRequestPotentialObligationNumberMatchConfiguration : EntityTypeConfiguration<CostAuthorityObligationRequestPotentialObligationNumberMatch>
    {
        public CostAuthorityObligationRequestPotentialObligationNumberMatchConfiguration() : this("Reclamation"){}

        public CostAuthorityObligationRequestPotentialObligationNumberMatchConfiguration(string schema)
        {
            ToTable("CostAuthorityObligationRequestPotentialObligationNumberMatch", schema);
            HasKey(x => x.CostAuthorityObligationRequestPotentialObligationNumberMatchID);
            Property(x => x.CostAuthorityObligationRequestPotentialObligationNumberMatchID).HasColumnName(@"CostAuthorityObligationRequestPotentialObligationNumberMatchID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CostAuthorityObligationRequestID).HasColumnName(@"CostAuthorityObligationRequestID").HasColumnType("int").IsRequired();
            Property(x => x.ObligationNumberID).HasColumnName(@"ObligationNumberID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.CostAuthorityObligationRequest).WithMany(b => b.CostAuthorityObligationRequestPotentialObligationNumberMatches).HasForeignKey(c => c.CostAuthorityObligationRequestID).WillCascadeOnDelete(false); // FK_CostAuthorityObligationRequestPotentialObligationNumberMatch_CostAuthorityObligationRequest_CostAuthorityObligationRequestID
            HasRequired(a => a.ObligationNumber).WithMany(b => b.CostAuthorityObligationRequestPotentialObligationNumberMatches).HasForeignKey(c => c.ObligationNumberID).WillCascadeOnDelete(false); // FK_CostAuthorityObligationRequestPotentialObligationNumberMatch_ObligationNumber_ObligationNumberID
        }
    }
}