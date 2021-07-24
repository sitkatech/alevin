//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPage]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CustomPageConfiguration : EntityTypeConfiguration<CustomPage>
    {
        public CustomPageConfiguration() : this("dbo"){}

        public CustomPageConfiguration(string schema)
        {
            ToTable("CustomPage", schema);
            HasKey(x => x.CustomPageID);
            Property(x => x.CustomPageID).HasColumnName(@"CustomPageID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.CustomPageDisplayName).HasColumnName(@"CustomPageDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.CustomPageVanityUrl).HasColumnName(@"CustomPageVanityUrl").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.CustomPageContent).HasColumnName(@"CustomPageContent").HasColumnType("varchar").IsOptional();
            Property(x => x.DocumentLibraryID).HasColumnName(@"DocumentLibraryID").HasColumnType("int").IsOptional();
            Property(x => x.FirmaMenuItemID).HasColumnName(@"FirmaMenuItemID").HasColumnType("int").IsRequired();
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.DocumentLibrary).WithMany(b => b.CustomPages).HasForeignKey(c => c.DocumentLibraryID).WillCascadeOnDelete(false); // FK_CustomPage_DocumentLibrary_DocumentLibraryID
        }
    }
}