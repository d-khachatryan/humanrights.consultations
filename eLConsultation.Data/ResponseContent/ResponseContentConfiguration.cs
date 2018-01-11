using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    class ResponseContentConfiguration : EntityTypeConfiguration<ResponseContent>
    {
        public ResponseContentConfiguration()
        {
            this.ToTable("dbo.ResponseContent");
            this.HasKey<int>(s => s.ResponseContentID);
            this.Property(s => s.ResponseContentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ResponseContentName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
