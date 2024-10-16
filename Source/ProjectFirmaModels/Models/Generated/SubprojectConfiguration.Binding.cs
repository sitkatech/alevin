//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Subproject]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectConfiguration : EntityTypeConfiguration<Subproject>
    {
        public SubprojectConfiguration() : this("dbo"){}

        public SubprojectConfiguration(string schema)
        {
            ToTable("Subproject", schema);
            HasKey(x => x.SubprojectID);
            Property(x => x.SubprojectID).HasColumnName(@"SubprojectID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectStageID).HasColumnName(@"SubprojectStageID").HasColumnType("int").IsRequired();
            Property(x => x.ImplementationStartYear).HasColumnName(@"ImplementationStartYear").HasColumnType("int").IsOptional();
            Property(x => x.CompletionYear).HasColumnName(@"CompletionYear").HasColumnType("int").IsOptional();
            Property(x => x.SubprojectName).HasColumnName(@"SubprojectName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(140);
            Property(x => x.SubprojectDescription).HasColumnName(@"SubprojectDescription").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(4000);

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.Subprojects).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_Subproject_Project_ProjectID
        }
    }
}