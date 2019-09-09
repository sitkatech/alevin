//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementProject]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementProjectConfiguration : EntityTypeConfiguration<ReclamationAgreementProject>
    {
        public ReclamationAgreementProjectConfiguration() : this("dbo"){}

        public ReclamationAgreementProjectConfiguration(string schema)
        {
            ToTable("ReclamationAgreementProject", schema);
            HasKey(x => x.ReclamationAgreementProjectID);
            Property(x => x.ReclamationAgreementProjectID).HasColumnName(@"ReclamationAgreementProjectID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationAgreementID).HasColumnName(@"ReclamationAgreementID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ReclamationAgreement).WithMany(b => b.ReclamationAgreementProjects).HasForeignKey(c => c.ReclamationAgreementID).WillCascadeOnDelete(false); // FK_ReclamationAgreementProject_ReclamationAgreement_ReclamationAgreementID
            HasRequired(a => a.Project).WithMany(b => b.ReclamationAgreementProjects).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ReclamationAgreementProject_Project_ProjectID
        }
    }
}