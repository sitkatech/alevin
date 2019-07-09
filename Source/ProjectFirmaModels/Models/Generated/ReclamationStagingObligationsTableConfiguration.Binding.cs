//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingObligationsTable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingObligationsTableConfiguration : EntityTypeConfiguration<ReclamationStagingObligationsTable>
    {
        public ReclamationStagingObligationsTableConfiguration() : this("dbo"){}

        public ReclamationStagingObligationsTableConfiguration(string schema)
        {
            ToTable("ReclamationStagingObligationsTable", schema);
            HasKey(x => x.ReclamationStagingObligationsTableID);
            Property(x => x.ReclamationStagingObligationsTableID).HasColumnName(@"ReclamationStagingObligationsTableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OriginalObligationsID).HasColumnName(@"OriginalObligationsID").HasColumnType("int").IsOptional();
            Property(x => x.OriginalAgreementStatusID).HasColumnName(@"OriginalAgreementStatusID").HasColumnType("int").IsOptional();
            Property(x => x.MonthEnding).HasColumnName(@"MonthEnding").HasColumnType("datetime").IsOptional();
            Property(x => x.Amount).HasColumnName(@"Amount").HasColumnType("money").IsOptional().HasPrecision(19,4);

        }
    }
}