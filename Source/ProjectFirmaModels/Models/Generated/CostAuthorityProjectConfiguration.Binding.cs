//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityProject]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityProjectConfiguration : EntityTypeConfiguration<CostAuthorityProject>
    {
        public CostAuthorityProjectConfiguration() : this("Reclamation"){}

        public CostAuthorityProjectConfiguration(string schema)
        {
            ToTable("CostAuthorityProject", schema);
            HasKey(x => x.ReclamationCostAuthorityProjectID);
            Property(x => x.ReclamationCostAuthorityProjectID).HasColumnName(@"ReclamationCostAuthorityProjectID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationCostAuthorityID).HasColumnName(@"ReclamationCostAuthorityID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.IsPrimaryProjectCawbs).HasColumnName(@"IsPrimaryProjectCawbs").HasColumnType("bit").IsRequired();
            Property(x => x.PrimaryProjectCawbsUniqueString).HasColumnName(@"PrimaryProjectCawbsUniqueString").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Foreign keys
            HasRequired(a => a.ReclamationCostAuthority).WithMany(b => b.CostAuthorityProjects).HasForeignKey(c => c.ReclamationCostAuthorityID).WillCascadeOnDelete(false); // FK_CostAuthorityProject_CostAuthority_ReclamationCostAuthorityID
            HasRequired(a => a.Project).WithMany(b => b.CostAuthorityProjects).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_CostAuthorityProject_Project_ProjectID
        }
    }
}