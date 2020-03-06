//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[DepartmentCode]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DepartmentCodeConfiguration : EntityTypeConfiguration<DepartmentCode>
    {
        public DepartmentCodeConfiguration() : this("Reclamation"){}

        public DepartmentCodeConfiguration(string schema)
        {
            ToTable("DepartmentCode", schema);
            HasKey(x => x.DepartmentCodeID);
            Property(x => x.DepartmentCodeID).HasColumnName(@"DepartmentCodeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationDepartmentCodeName).HasColumnName(@"ReclamationDepartmentCodeName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}