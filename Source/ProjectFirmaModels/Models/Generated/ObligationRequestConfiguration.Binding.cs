//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ObligationRequestConfiguration : EntityTypeConfiguration<ObligationRequest>
    {
        public ObligationRequestConfiguration() : this("Reclamation"){}

        public ObligationRequestConfiguration(string schema)
        {
            ToTable("ObligationRequest", schema);
            HasKey(x => x.ObligationRequestID);
            Property(x => x.ObligationRequestID).HasColumnName(@"ObligationRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IsModification).HasColumnName(@"IsModification").HasColumnType("bit").IsRequired();
            Property(x => x.AgreementID).HasColumnName(@"AgreementID").HasColumnType("int").IsOptional();
            Property(x => x.ContractTypeID).HasColumnName(@"ContractTypeID").HasColumnType("int").IsRequired();
            Property(x => x.ObligationRequestStatusID).HasColumnName(@"ObligationRequestStatusID").HasColumnType("int").IsRequired();
            Property(x => x.DescriptionOfNeed).HasColumnName(@"DescriptionOfNeed").HasColumnType("nvarchar").IsRequired().HasMaxLength(250);
            Property(x => x.ReclamationObligationRequestFundingPriorityID).HasColumnName(@"ReclamationObligationRequestFundingPriorityID").HasColumnType("int").IsOptional();
            Property(x => x.RecipientOrganizationID).HasColumnName(@"RecipientOrganizationID").HasColumnType("int").IsOptional();
            Property(x => x.TechnicalRepresentativePersonID).HasColumnName(@"TechnicalRepresentativePersonID").HasColumnType("int").IsOptional();
            Property(x => x.TargetAwardDate).HasColumnName(@"TargetAwardDate").HasColumnType("datetime").IsOptional();
            Property(x => x.PALT).HasColumnName(@"PALT").HasColumnType("int").IsOptional();
            Property(x => x.TargetSubmittalDate).HasColumnName(@"TargetSubmittalDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.RequisitionNumber).HasColumnName(@"RequisitionNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.RequisitionDate).HasColumnName(@"RequisitionDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ContractSpecialist).HasColumnName(@"ContractSpecialist").HasColumnType("nvarchar").IsOptional().HasMaxLength(250);
            Property(x => x.AssignedDate).HasColumnName(@"AssignedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.DateSentForDeptReview).HasColumnName(@"DateSentForDeptReview").HasColumnType("datetime").IsOptional();
            Property(x => x.DCApprovalDate).HasColumnName(@"DCApprovalDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ActualAwardDate).HasColumnName(@"ActualAwardDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasOptional(a => a.Agreement).WithMany(b => b.ObligationRequests).HasForeignKey(c => c.AgreementID).WillCascadeOnDelete(false); // FK_ObligationRequest_Agreement_AgreementID
            HasRequired(a => a.ContractType).WithMany(b => b.ObligationRequests).HasForeignKey(c => c.ContractTypeID).WillCascadeOnDelete(false); // FK_ObligationRequest_ContractType_ContractTypeID
            HasOptional(a => a.RecipientOrganization).WithMany(b => b.ObligationRequestsWhereYouAreTheRecipientOrganization).HasForeignKey(c => c.RecipientOrganizationID).WillCascadeOnDelete(false); // FK_ObligationRequest_Organization_RecipientOrganizationID_OrganizationID
            HasOptional(a => a.TechnicalRepresentativePerson).WithMany(b => b.ObligationRequestsWhereYouAreTheTechnicalRepresentativePerson).HasForeignKey(c => c.TechnicalRepresentativePersonID).WillCascadeOnDelete(false); // FK_ObligationRequest_Person_TechnicalRepresentativePersonID_PersonID
            HasRequired(a => a.CreatePerson).WithMany(b => b.ObligationRequestsWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ObligationRequest_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.ObligationRequestsWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ObligationRequest_Person_UpdatePersonID_PersonID
        }
    }
}