using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLConsultation.Data
{
    class TmpOralConsultationConsultantConfiguration : EntityTypeConfiguration<TmpOralConsultationConsultant>
    {
        public TmpOralConsultationConsultantConfiguration()
        {
            this.ToTable("dbo.TmpOralConsultationConsultant");
            this.HasKey<int>(s => s.ID);
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
