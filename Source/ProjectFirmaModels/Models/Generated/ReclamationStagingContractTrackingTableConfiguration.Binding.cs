//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingContractTrackingTable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingContractTrackingTableConfiguration : EntityTypeConfiguration<ReclamationStagingContractTrackingTable>
    {
        public ReclamationStagingContractTrackingTableConfiguration() : this("Reclamation"){}

        public ReclamationStagingContractTrackingTableConfiguration(string schema)
        {
            ToTable("ReclamationStagingContractTrackingTable", schema);
            HasKey(x => x.ReclamationStagingContractTrackingTableID);
            Property(x => x.ReclamationStagingContractTrackingTableID).HasColumnName(@"ReclamationStagingContractTrackingTableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OriginalContractTrackingID).HasColumnName(@"OriginalContractTrackingID").HasColumnType("int").IsOptional();
            Property(x => x.OriginalAgreementStatusID).HasColumnName(@"OriginalAgreementStatusID").HasColumnType("int").IsOptional();
            Property(x => x.StatusDate).HasColumnName(@"StatusDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ReclamationStagingContractStatusID).HasColumnName(@"ReclamationStagingContractStatusID").HasColumnType("int").IsOptional();
            Property(x => x.RequisitionNumber).HasColumnName(@"RequisitionNumber").HasColumnType("int").IsOptional();

        }
    }
}