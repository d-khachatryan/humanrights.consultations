using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace eLConsultation.Data
{
    class SettingConfiguration : EntityTypeConfiguration<Setting>
    {
        public SettingConfiguration()
        {
            this.ToTable("dbo.Setting");
            this.HasKey<string>(s => s.SettingItem);
            this.Property(s => s.SettingGroup).HasColumnType("nvarchar").HasMaxLength(50);
            this.Property(s => s.SettingItem).HasColumnType("nvarchar").HasMaxLength(50);
            this.Property(s => s.SettingValue).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
