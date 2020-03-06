//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationAgreementRequestSubmissionNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementRequestSubmissionNoteConfiguration : EntityTypeConfiguration<ReclamationAgreementRequestSubmissionNote>
    {
        public ReclamationAgreementRequestSubmissionNoteConfiguration() : this("Reclamation"){}

        public ReclamationAgreementRequestSubmissionNoteConfiguration(string schema)
        {
            ToTable("ReclamationAgreementRequestSubmissionNote", schema);
            HasKey(x => x.ReclamationAgreementRequestSubmissionNoteID);
            Property(x => x.ReclamationAgreementRequestSubmissionNoteID).HasColumnName(@"ReclamationAgreementRequestSubmissionNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationAgreementRequestID).HasColumnName(@"ReclamationAgreementRequestID").HasColumnType("int").IsRequired();
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.ReclamationAgreementRequest).WithMany(b => b.ReclamationAgreementRequestSubmissionNotes).HasForeignKey(c => c.ReclamationAgreementRequestID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequestSubmissionNote_AgreementRequest_ReclamationAgreementRequestID
            HasOptional(a => a.CreatePerson).WithMany(b => b.ReclamationAgreementRequestSubmissionNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequestSubmissionNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.ReclamationAgreementRequestSubmissionNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ReclamationAgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID
        }
    }
}