//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationCostAuthorityProject]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationCostAuthorityProjectConfiguration : EntityTypeConfiguration<ReclamationCostAuthorityProject>
    {
        public ReclamationCostAuthorityProjectConfiguration() : this("dbo"){}

        public ReclamationCostAuthorityProjectConfiguration(string schema)
        {
            ToTable("ReclamationCostAuthorityProject", schema);
            HasKey(x => x.ReclamationCostAuthorityProjectID);
            Property(x => x.ReclamationCostAuthorityProjectID).HasColumnName(@"ReclamationCostAuthorityProjectID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationCostAuthorityID).HasColumnName(@"ReclamationCostAuthorityID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ReclamationCostAuthority).WithMany(b => b.ReclamationCostAuthorityProjects).HasForeignKey(c => c.ReclamationCostAuthorityID).WillCascadeOnDelete(false); // FK_ReclamationCostAuthorityProject_ReclamationCostAuthority_ReclamationCostAuthorityID
            HasRequired(a => a.Project).WithMany(b => b.ReclamationCostAuthorityProjects).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ReclamationCostAuthorityProject_Project_ProjectID
        }
    }
}