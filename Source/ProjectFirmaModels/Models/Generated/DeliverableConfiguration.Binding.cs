//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Deliverable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DeliverableConfiguration : EntityTypeConfiguration<Deliverable>
    {
        public DeliverableConfiguration() : this("Reclamation"){}

        public DeliverableConfiguration(string schema)
        {
            ToTable("Deliverable", schema);
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
            HasOptional(a => a.DeliverableType).WithMany(b => b.DeliverablesWhereYouAreTheDeliverableType).HasForeignKey(c => c.DeliverableTypeID).WillCascadeOnDelete(false); // FK_Deliverable_DeliverableType_DeliverableTypeID_ReclamationDeliverableTypeID
            HasOptional(a => a.CostAuthorityAgreement).WithMany(b => b.DeliverablesWhereYouAreTheCostAuthorityAgreement).HasForeignKey(c => c.CostAuthorityAgreementID).WillCascadeOnDelete(false); // FK_Deliverable_ReclamationStagingCostAuthorityAgreement_CostAuthorityAgreementID_ReclamationStagingCostAuthorityAgreementID
            HasOptional(a => a.ReclamationStagingAgreementStatusTable).WithMany(b => b.Deliverables).HasForeignKey(c => c.ReclamationStagingAgreementStatusTableID).WillCascadeOnDelete(false); // FK_Deliverable_ReclamationStagingAgreementStatusTable_ReclamationStagingAgreementStatusTableID
            HasOptional(a => a.Person).WithMany(b => b.Deliverables).HasForeignKey(c => c.PersonID).WillCascadeOnDelete(false); // FK_Deliverable_Person_PersonID
        }
    }
}