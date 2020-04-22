//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequestSubmissionNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ObligationRequestSubmissionNoteConfiguration : EntityTypeConfiguration<ObligationRequestSubmissionNote>
    {
        public ObligationRequestSubmissionNoteConfiguration() : this("Reclamation"){}

        public ObligationRequestSubmissionNoteConfiguration(string schema)
        {
            ToTable("ObligationRequestSubmissionNote", schema);
            HasKey(x => x.ObligationRequestSubmissionNoteID);
            Property(x => x.ObligationRequestSubmissionNoteID).HasColumnName(@"ObligationRequestSubmissionNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ObligationRequestID).HasColumnName(@"ObligationRequestID").HasColumnType("int").IsRequired();
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.ObligationRequest).WithMany(b => b.ObligationRequestSubmissionNotes).HasForeignKey(c => c.ObligationRequestID).WillCascadeOnDelete(false); // FK_ObligationRequestSubmissionNote_ObligationRequest_ObligationRequestID
            HasOptional(a => a.CreatePerson).WithMany(b => b.ObligationRequestSubmissionNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_ObligationRequestSubmissionNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.ObligationRequestSubmissionNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_ObligationRequestSubmissionNote_Person_UpdatePersonID_PersonID
        }
    }
}