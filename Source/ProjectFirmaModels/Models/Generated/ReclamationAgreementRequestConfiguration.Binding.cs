//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementRequest]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementRequestConfiguration : EntityTypeConfiguration<ReclamationAgreementRequest>
    {
        public ReclamationAgreementRequestConfiguration() : this("dbo"){}

        public ReclamationAgreementRequestConfiguration(string schema)
        {
            ToTable("ReclamationAgreementRequest", schema);
            HasKey(x => x.ReclamationAgreementRequestID);
            Property(x => x.ReclamationAgreementRequestID).HasColumnName(@"ReclamationAgreementRequestID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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

            // Foreign keys
            HasRequired(a => a.ContractType).WithMany(b => b.ReclamationAgreementRequestsWhereYouAreTheContractType).HasForeignKey(c => c.ContractTypeID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequest_ReclamationContractType_ContractTypeID_ReclamationContractTypeID
            HasOptional(a => a.RecipientOrganization).WithMany(b => b.ReclamationAgreementRequestsWhereYouAreTheRecipientOrganization).HasForeignKey(c => c.RecipientOrganizationID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequest_Organization_RecipientOrganizationID_OrganizationID
            HasOptional(a => a.TechnicalRepresentativePerson).WithMany(b => b.ReclamationAgreementRequestsWhereYouAreTheTechnicalRepresentativePerson).HasForeignKey(c => c.TechnicalRepresentativePersonID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequest_Person_TechnicalRepresentativePersonID_PersonID
            HasRequired(a => a.CreatePerson).WithMany(b => b.ReclamationAgreementRequestsWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequest_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.ReclamationAgreementRequestsWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequest_Person_UpdatePersonID_PersonID
        }
    }
}