//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpProcessing]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ImpProcessingConfiguration : EntityTypeConfiguration<ImpProcessing>
    {
        public ImpProcessingConfiguration() : this("ImportFinancial"){}

        public ImpProcessingConfiguration(string schema)
        {
            ToTable("ImpProcessing", schema);
            HasKey(x => x.ImpProcessingID);
            Property(x => x.ImpProcessingID).HasColumnName(@"ImpProcessingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ImpProcessingTableTypeID).HasColumnName(@"ImpProcessingTableTypeID").HasColumnType("int").IsRequired();
            Property(x => x.UploadDate).HasColumnName(@"UploadDate").HasColumnType("datetime").IsOptional();
            Property(x => x.UploadPersonID).HasColumnName(@"UploadPersonID").HasColumnType("int").IsOptional();
            Property(x => x.UploadedFiscalYears).HasColumnName(@"UploadedFiscalYears").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.LastProcessedDate).HasColumnName(@"LastProcessedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.LastProcessedPersonID).HasColumnName(@"LastProcessedPersonID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.UploadPerson).WithMany(b => b.ImpProcessingsWhereYouAreTheUploadPerson).HasForeignKey(c => c.UploadPersonID).WillCascadeOnDelete(false); // FK_ImpProcessing_Person_UploadPersonID_PersonID
            HasOptional(a => a.LastProcessedPerson).WithMany(b => b.ImpProcessingsWhereYouAreTheLastProcessedPerson).HasForeignKey(c => c.LastProcessedPersonID).WillCascadeOnDelete(false); // FK_ImpProcessing_Person_LastProcessedPersonID_PersonID
        }
    }
}