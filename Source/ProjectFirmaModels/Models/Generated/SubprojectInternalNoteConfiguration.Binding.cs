//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectInternalNote]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectInternalNoteConfiguration : EntityTypeConfiguration<SubprojectInternalNote>
    {
        public SubprojectInternalNoteConfiguration() : this("dbo"){}

        public SubprojectInternalNoteConfiguration(string schema)
        {
            ToTable("SubprojectInternalNote", schema);
            HasKey(x => x.SubprojectInternalNoteID);
            Property(x => x.SubprojectInternalNoteID).HasColumnName(@"SubprojectInternalNoteID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectID).HasColumnName(@"SubprojectID").HasColumnType("int").IsRequired();
            Property(x => x.Note).HasColumnName(@"Note").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.CreatePersonID).HasColumnName(@"CreatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.UpdatePersonID).HasColumnName(@"UpdatePersonID").HasColumnType("int").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.Subproject).WithMany(b => b.SubprojectInternalNotes).HasForeignKey(c => c.SubprojectID).WillCascadeOnDelete(false); // FK_SubprojectInternalNote_Subproject_SubprojectID
            HasOptional(a => a.CreatePerson).WithMany(b => b.SubprojectInternalNotesWhereYouAreTheCreatePerson).HasForeignKey(c => c.CreatePersonID).WillCascadeOnDelete(false); // FK_SubprojectInternalNote_Person_CreatePersonID_PersonID
            HasOptional(a => a.UpdatePerson).WithMany(b => b.SubprojectInternalNotesWhereYouAreTheUpdatePerson).HasForeignKey(c => c.UpdatePersonID).WillCascadeOnDelete(false); // FK_SubprojectInternalNote_Person_UpdatePersonID_PersonID
        }
    }
}