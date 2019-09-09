//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementPacificNorthActivity]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementPacificNorthActivityConfiguration : EntityTypeConfiguration<ReclamationAgreementPacificNorthActivity>
    {
        public ReclamationAgreementPacificNorthActivityConfiguration() : this("dbo"){}

        public ReclamationAgreementPacificNorthActivityConfiguration(string schema)
        {
            ToTable("ReclamationAgreementPacificNorthActivity", schema);
            HasKey(x => x.ReclamationAgreementPacificNorthActivityID);
            Property(x => x.ReclamationAgreementPacificNorthActivityID).HasColumnName(@"ReclamationAgreementPacificNorthActivityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationAgreementID).HasColumnName(@"ReclamationAgreementID").HasColumnType("int").IsRequired();
            Property(x => x.ReclamationPacificNorthActivityListID).HasColumnName(@"ReclamationPacificNorthActivityListID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ReclamationAgreement).WithMany(b => b.ReclamationAgreementPacificNorthActivities).HasForeignKey(c => c.ReclamationAgreementID).WillCascadeOnDelete(false); // FK_ReclamationAgreementPacificNorthActivity_ReclamationAgreement_ReclamationAgreementID
            HasRequired(a => a.ReclamationPacificNorthActivityList).WithMany(b => b.ReclamationAgreementPacificNorthActivities).HasForeignKey(c => c.ReclamationPacificNorthActivityListID).WillCascadeOnDelete(false); // FK_ReclamationAgreementPacificNorthActivity_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityListID
        }
    }
}