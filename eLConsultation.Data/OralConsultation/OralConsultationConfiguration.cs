using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationConfiguration : EntityTypeConfiguration<OralConsultation>
    {
        public OralConsultationConfiguration()
        {
            this.ToTable("dbo.OralConsultation");
            this.HasKey<int>(s => s.OralConsultationID);
            this.Property(s => s.OralConsultationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
