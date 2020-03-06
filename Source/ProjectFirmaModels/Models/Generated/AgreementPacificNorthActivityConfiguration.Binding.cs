//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementPacificNorthActivity]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AgreementPacificNorthActivityConfiguration : EntityTypeConfiguration<AgreementPacificNorthActivity>
    {
        public AgreementPacificNorthActivityConfiguration() : this("Reclamation"){}

        public AgreementPacificNorthActivityConfiguration(string schema)
        {
            ToTable("AgreementPacificNorthActivity", schema);
            HasKey(x => x.ReclamationAgreementPacificNorthActivityID);
            Property(x => x.ReclamationAgreementPacificNorthActivityID).HasColumnName(@"ReclamationAgreementPacificNorthActivityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationAgreementID).HasColumnName(@"ReclamationAgreementID").HasColumnType("int").IsRequired();
            Property(x => x.ReclamationPacificNorthActivityListID).HasColumnName(@"ReclamationPacificNorthActivityListID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ReclamationAgreement).WithMany(b => b.AgreementPacificNorthActivities).HasForeignKey(c => c.ReclamationAgreementID).WillCascadeOnDelete(false); // FK_AgreementPacificNorthActivity_Agreement_ReclamationAgreementID
            HasRequired(a => a.ReclamationPacificNorthActivityList).WithMany(b => b.AgreementPacificNorthActivities).HasForeignKey(c => c.ReclamationPacificNorthActivityListID).WillCascadeOnDelete(false); // FK_AgreementPacificNorthActivity_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityListID
        }
    }
}