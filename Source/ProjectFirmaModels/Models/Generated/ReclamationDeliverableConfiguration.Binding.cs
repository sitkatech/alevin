//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationDeliverable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationDeliverableConfiguration : EntityTypeConfiguration<ReclamationDeliverable>
    {
        public ReclamationDeliverableConfiguration() : this("dbo"){}

        public ReclamationDeliverableConfiguration(string schema)
        {
            ToTable("ReclamationDeliverable", schema);
            HasKey(x => x.ReclamationDeliverableID);
            Property(x => x.ReclamationDeliverableID).HasColumnName(@"ReclamationDeliverableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DeliverableTypeID).HasColumnName(@"DeliverableTypeID").HasColumnType("int").IsOptional();
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(500);
            Property(x => x.DueDate).HasColumnName(@"DueDate").HasColumnType("datetime").IsOptional();
            Property(x => x.DateDelivered).HasColumnName(@"DateDelivered").HasColumnType("datetime").IsOptional();
            Property(x => x.IsTaskCompleted).HasColumnName(@"IsTaskCompleted").HasColumnType("bit").IsRequired();
            Property(x => x.IsTaskCanceled).HasColumnName(@"IsTaskCanceled").HasColumnType("bit").IsRequired();
            Property(x => x.CostAuthorityAgreementID).HasColumnName(@"CostAuthorityAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.ReclamationStagingAgreementStatusTableID).HasColumnName(@"ReclamationStagingAgreementStatusTableID").HasColumnType("int").IsOptional();
            Property(x => x.PersonID).HasColumnName(@"PersonID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.DeliverableType).WithMany(b => b.ReclamationDeliverablesWhereYouAreTheDeliverableType).HasForeignKey(c => c.DeliverableTypeID).WillCascadeOnDelete(false); // FK_ReclamationDeliverable_ReclamationDeliverableType_DeliverableTypeID_ReclamationDeliverableTypeID
            HasOptional(a => a.CostAuthorityAgreement).WithMany(b => b.ReclamationDeliverablesWhereYouAreTheCostAuthorityAgreement).HasForeignKey(c => c.CostAuthorityAgreementID).WillCascadeOnDelete(false); // FK_ReclamationDeliverable_ReclamationStagingCostAuthorityAgreement_CostAuthorityAgreementID_ReclamationStagingCostAuthorityAgree
            HasOptional(a => a.ReclamationStagingAgreementStatusTable).WithMany(b => b.ReclamationDeliverables).HasForeignKey(c => c.ReclamationStagingAgreementStatusTableID).WillCascadeOnDelete(false); // FK_ReclamationDeliverable_ReclamationStagingAgreementStatusTable_ReclamationStagingAgreementStatusTableID
            HasOptional(a => a.Person).WithMany(b => b.ReclamationDeliverables).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_ReclamationDeliverable_Person_PersonID
        }
    }
}