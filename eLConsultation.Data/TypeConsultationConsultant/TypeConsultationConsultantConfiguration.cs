using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationConsultantConfiguration : EntityTypeConfiguration<TypeConsultationConsultant>
    {
        public TypeConsultationConsultantConfiguration()
        {
            this.ToTable("dbo.TypeConsultationConsultant");
            this.HasKey<int>(s => s.TypeConsultationConsultantID);
            this.Property(s => s.TypeConsultationConsultantID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.TypeConsultation)
            .WithMany(o => o.TypeConsultationConsultants)
            .HasForeignKey(o => o.TypeConsultationID)
            .WillCascadeOnDelete(true);
        }
    }
}
