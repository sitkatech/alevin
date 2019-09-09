//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingPersonsTable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingPersonsTableConfiguration : EntityTypeConfiguration<ReclamationStagingPersonsTable>
    {
        public ReclamationStagingPersonsTableConfiguration() : this("dbo"){}

        public ReclamationStagingPersonsTableConfiguration(string schema)
        {
            ToTable("ReclamationStagingPersonsTable", schema);
            HasKey(x => x.ReclamationStagingPersonsTableID);
            Property(x => x.ReclamationStagingPersonsTableID).HasColumnName(@"ReclamationStagingPersonsTableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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