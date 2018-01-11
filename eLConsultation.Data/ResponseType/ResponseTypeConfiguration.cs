using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    class ResponseTypeConfiguration : EntityTypeConfiguration<ResponseType>
    {
        public ResponseTypeConfiguration()
        {
            this.ToTable("dbo.ResponseType");
            this.HasKey<int>(s => s.ResponseTypeID);
            this.Property(s => s.ResponseTypeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ResponseTypeName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
