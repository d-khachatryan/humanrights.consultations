using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationConsultantConfiguration : EntityTypeConfiguration<OralConsultationConsultant>
    {
        public OralConsultationConsultantConfiguration()
        {
            this.ToTable("dbo.OralConsultationConsultant");
            this.HasKey<int>(s => s.OralConsultationConsultantID);
            this.Property(s => s.OralConsultationConsultantID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.OralConsultation)
            .WithMany(o => o.OralConsultationConsultants)
            .HasForeignKey(o => o.OralConsultationID)
            .WillCascadeOnDelete(true);

        }
    }
}
