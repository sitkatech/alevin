//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NpccSubbasinProvince]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class NpccSubbasinProvinceConfiguration : EntityTypeConfiguration<NpccSubbasinProvince>
    {
        public NpccSubbasinProvinceConfiguration() : this("dbo"){}

        public NpccSubbasinProvinceConfiguration(string schema)
        {
            ToTable("NpccSubbasinProvince", schema);
            HasKey(x => x.NpccSubbasinProvinceID);
            Property(x => x.NpccSubbasinProvinceID).HasColumnName(@"NpccSubbasinProvinceID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SubbasinID).HasColumnName(@"SubbasinID").HasColumnType("int").IsRequired();
            Property(x => x.NpccProvinceID).HasColumnName(@"NpccProvinceID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Subbasin).WithMany(b => b.NpccSubbasinProvincesWhereYouAreTheSubbasin).HasForeignKey(c => c.SubbasinID).WillCascadeOnDelete(false); // FK_NpccSubbasinProvince_GeospatialArea_SubbasinID_GeospatialAreaID
            HasRequired(a => a.NpccProvince).WithMany(b => b.NpccSubbasinProvinces).HasForeignKey(c => c.NpccProvinceID).WillCascadeOnDelete(false); // FK_NpccSubbasinProvince_NpccProvince_NpccProvinceID
        }
    }
}