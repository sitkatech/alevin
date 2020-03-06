//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AgreementRequestConfiguration : EntityTypeConfiguration<AgreementRequest>
    {
        public AgreementRequestConfiguration() : this("Reclamation"){}

        public AgreementRequestConfiguration(string schema)
        {
            ToTable("AgreementRequest", schema);
            HasKey(x => x.ReclamationAgreementRequestID);
            Property(x => x.ReclamationAgreementRequestID).HasColumnName(@"ReclamationAgreementRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IsModification).HasColumnName(@"IsModification").HasColumnType("bit").IsRequired();
            Property(x => x.AgreementID).HasColumnName(@"AgreementID").HasColumnType("int").IsOptional();
            Property(x => x.ContractTypeID).HasColumnName(@"ContractTypeID").HasColumnType("int").IsRequired();
            Property(x => x.AgreementRequestStatusID).HasColumnName(@"AgreementRequestStatusID").HasColumnType("int").IsRequired();
            Property(x => x.DescriptionOfNeed).HasColumnName(@"DescriptionOfNeed").HasColumnType("nvarchar").IsRequired().HasMaxLength(250);
            Property(x => x.ReclamationAgreementRequestFundingPriorityID).HasColumnName(@"ReclamationAgreementRequestFundingPriorityID").HasColumnType("int").IsOptional();
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
            HasOptional(a => a.Agreement).WithMany(b => b.AgreementRequestsWhereYouAreTheAgreement).HasForeignKey(c => c.AgreementID).WillCascadeOnDelete(false); // FK_AgreementRequest_Agreement_AgreementID_ReclamationAgreementID
            HasRequired(a => a.ContractType).WithMany(b => b.AgreementRequestsWhereYouAreTheContractType).HasForeignKey(c => c.ContractTypeID).WillCascadeOnDelete(false); // FK_AgreementRequest_ContractType_ContractTypeID_ReclamationContractTypeID
            HasOptional(a => a.RecipientOrganization).WithMany(b => b.AgreementRequestsWhereYouAreTheRecipientOrganization).HasForeignKey(c => c.RecipientOrganizationID).WillCascadeOnDelete(false); // FK_AgreementRequest_Organization_RecipientOrganizationID_OrganizationID
            HasOptional(a => a.TechnicalRepresentativePerson).WithMany(b => b.AgreementRequestsWhereYouAreTheTechnicalRepresentativePerson).HasForeignKey(c => c.TechnicalRepresentativePersonID).WillCascadeOnDelete(false); // FK_AgreementRequest_Person_TechnicalRepresentativePersonID_PersonID
            HasRequired(a => a.CreatePerson).WithMany(b => b.AgreementRequestsWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_AgreementRequest_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.AgreementRequestsWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_AgreementRequest_Person_UpdatePersonID_PersonID
        }
    }
}