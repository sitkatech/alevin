//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Deliverable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DeliverableConfiguration : EntityTypeConfiguration<Deliverable>
    {
        public DeliverableConfiguration() : this("dbo"){}

        public DeliverableConfiguration(string schema)
        {
            ToTable("Deliverable", schema);
            HasKey(x => x.DeliverableID);
            Property(x => x.DeliverableID).HasColumnName(@"DeliverableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationDeliverableID).HasColumnName(@"ReclamationDeliverableID").HasColumnType("int").IsOptional();
            Property(x => x.ReclamationCostAuthorityAgreementID).HasColumnName(@"ReclamationCostAuthorityAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.ReclamationAgreementStatusID).HasColumnName(@"ReclamationAgreementStatusID").HasColumnType("int").IsOptional();
            Property(x => x.ReclamationDeliverableTypeID).HasColumnName(@"ReclamationDeliverableTypeID").HasColumnType("int").IsOptional();
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(500);
            Property(x => x.DueDate).HasColumnName(@"DueDate").HasColumnType("datetime").IsOptional();
            Property(x => x.DateDelivered).HasColumnName(@"DateDelivered").HasColumnType("datetime").IsOptional();
            Property(x => x.IsTaskCompleted).HasColumnName(@"IsTaskCompleted").HasColumnType("bit").IsRequired();
            Property(x => x.IsTaskCanceled).HasColumnName(@"IsTaskCanceled").HasColumnType("bit").IsRequired();
            Property(x => x.ReclamationPersonsTableID).HasColumnName(@"ReclamationPersonsTableID").HasColumnType("int").IsOptional();

        }
    }
}