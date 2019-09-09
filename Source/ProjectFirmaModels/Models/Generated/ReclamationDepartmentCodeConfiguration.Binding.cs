//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationDepartmentCode]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationDepartmentCodeConfiguration : EntityTypeConfiguration<ReclamationDepartmentCode>
    {
        public ReclamationDepartmentCodeConfiguration() : this("dbo"){}

        public ReclamationDepartmentCodeConfiguration(string schema)
        {
            ToTable("ReclamationDepartmentCode", schema);
            HasKey(x => x.ReclamationDepartmentCodeID);
            Property(x => x.ReclamationDepartmentCodeID).HasColumnName(@"ReclamationDepartmentCodeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationDepartmentCodeName).HasColumnName(@"ReclamationDepartmentCodeName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}