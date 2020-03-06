//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementRequestSubmissionNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AgreementRequestSubmissionNoteConfiguration : EntityTypeConfiguration<AgreementRequestSubmissionNote>
    {
        public AgreementRequestSubmissionNoteConfiguration() : this("Reclamation"){}

        public AgreementRequestSubmissionNoteConfiguration(string schema)
        {
            ToTable("AgreementRequestSubmissionNote", schema);
            HasKey(x => x.AgreementRequestSubmissionNoteID);
            Property(x => x.AgreementRequestSubmissionNoteID).HasColumnName(@"AgreementRequestSubmissionNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationAgreementRequestID).HasColumnName(@"ReclamationAgreementRequestID").HasColumnType("int").IsRequired();
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.ReclamationAgreementRequest).WithMany(b => b.AgreementRequestSubmissionNotesWhereYouAreTheReclamationAgreementRequest).HasForeignKey(c => c.ReclamationAgreementRequestID).WillCascadeOnDelete(false); // FK_AgreementRequestSubmissionNote_AgreementRequest_ReclamationAgreementRequestID_AgreementRequestID
            HasOptional(a => a.CreatePerson).WithMany(b => b.AgreementRequestSubmissionNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_AgreementRequestSubmissionNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.AgreementRequestSubmissionNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_AgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID
        }
    }
}