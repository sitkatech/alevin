//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationPersonsTable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPersonsTableConfiguration : EntityTypeConfiguration<ReclamationPersonsTable>
    {
        public ReclamationPersonsTableConfiguration() : this("dbo"){}

        public ReclamationPersonsTableConfiguration(string schema)
        {
            ToTable("ReclamationPersonsTable", schema);
            HasKey(x => x.ReclamationPersonsTableID);
            Property(x => x.ReclamationPersonsTableID).HasColumnName(@"ReclamationPersonsTableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationStaffID).HasColumnName(@"ReclamationStaffID").HasColumnType("int").IsOptional();
            Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Location).HasColumnName(@"Location").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.DeptartmentCode).HasColumnName(@"DeptartmentCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.RTSContact).HasColumnName(@"RTSContact").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

        }
    }
}