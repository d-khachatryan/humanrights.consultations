using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    class ResponseQualityConfiguration : EntityTypeConfiguration<ResponseQuality>
    {
        public ResponseQualityConfiguration()
        {
            this.ToTable("dbo.ResponseQuality");
            this.HasKey<int>(s => s.ResponseQualityID);
            this.Property(s => s.ResponseQualityID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ResponseQualityName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
