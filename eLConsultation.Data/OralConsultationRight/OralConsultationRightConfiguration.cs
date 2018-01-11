using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationRightConfiguration : EntityTypeConfiguration<OralConsultationRight>
    {
        public OralConsultationRightConfiguration()
        {
            this.ToTable("dbo.OralConsultationRight");
            this.HasKey<int>(s => s.OralConsultationRightID);
            this.Property(s => s.OralConsultationRightID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.OralConsultation)
            .WithMany(o => o.OralConsultationRights)
            .HasForeignKey(o => o.OralConsultationID)
            .WillCascadeOnDelete(true);

        }
    }
}
