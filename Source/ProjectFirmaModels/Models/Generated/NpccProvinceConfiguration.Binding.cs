//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NpccProvince]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class NpccProvinceConfiguration : EntityTypeConfiguration<NpccProvince>
    {
        public NpccProvinceConfiguration() : this("dbo"){}

        public NpccProvinceConfiguration(string schema)
        {
            ToTable("NpccProvince", schema);
            HasKey(x => x.NpccProvinceID);
            Property(x => x.NpccProvinceID).HasColumnName(@"NpccProvinceID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.NpccProvinceName).HasColumnName(@"NpccProvinceName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(150);
            Property(x => x.NpccProvinceFeature).HasColumnName(@"NpccProvinceFeature").HasColumnType("geometry").IsOptional();
            Property(x => x.NpccProvinceDescriptionContent).HasColumnName(@"NpccProvinceDescriptionContent").HasColumnType("varchar").IsOptional();

            // Foreign keys

        }
    }
}