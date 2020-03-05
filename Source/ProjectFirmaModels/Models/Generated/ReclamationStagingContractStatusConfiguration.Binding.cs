//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingContractStatus]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingContractStatusConfiguration : EntityTypeConfiguration<ReclamationStagingContractStatus>
    {
        public ReclamationStagingContractStatusConfiguration() : this("Reclamation"){}

        public ReclamationStagingContractStatusConfiguration(string schema)
        {
            ToTable("ReclamationStagingContractStatus", schema);
            HasKey(x => x.ReclamationStagingContractStatusID);
            Property(x => x.ReclamationStagingContractStatusID).HasColumnName(@"ReclamationStagingContractStatusID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ReclamationStagingContractStatusName).HasColumnName(@"ReclamationStagingContractStatusName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Steps).HasColumnName(@"Steps").HasColumnType("int").IsOptional();
            Property(x => x.ReclamationStagingContractStatusType).HasColumnName(@"ReclamationStagingContractStatusType").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

        }
    }
}