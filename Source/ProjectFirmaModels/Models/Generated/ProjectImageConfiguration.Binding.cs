//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ProjectImageConfiguration : EntityTypeConfiguration<ProjectImage>
    {
        public ProjectImageConfiguration() : this("dbo"){}

        public ProjectImageConfiguration(string schema)
        {
            ToTable("ProjectImage", schema);
            HasKey(x => x.ProjectImageID);
            Property(x => x.ProjectImageID).HasColumnName(@"ProjectImageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.FileResourceInfoID).HasColumnName(@"FileResourceInfoID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectImageTimingID).HasColumnName(@"ProjectImageTimingID").HasColumnType("int").IsRequired();
            Property(x => x.Caption).HasColumnName(@"Caption").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Credit).HasColumnName(@"Credit").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.IsKeyPhoto).HasColumnName(@"IsKeyPhoto").HasColumnType("bit").IsRequired();
            Property(x => x.IncludeInFactSheet).HasColumnName(@"IncludeInFactSheet").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.FileResourceInfo).WithMany(b => b.ProjectImages).HasForeignKey(c => c.FileResourceInfoID).WillCascadeOnDelete(false); // FK_ProjectImage_FileResourceInfo_FileResourceInfoID
            HasRequired(a => a.Project).WithMany(b => b.ProjectImages).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ProjectImage_Project_ProjectID
        }
    }
}