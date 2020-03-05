//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationFund]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationFundConfiguration : EntityTypeConfiguration<ReclamationFund>
    {
        public ReclamationFundConfiguration() : this("Reclamation"){}

        public ReclamationFundConfiguration(string schema)
        {
            ToTable("ReclamationFund", schema);
            HasKey(x => x.ReclamationFundID);
            Property(x => x.ReclamationFundID).HasColumnName(@"ReclamationFundID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationFundNumber).HasColumnName(@"ReclamationFundNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

        }
    }
}