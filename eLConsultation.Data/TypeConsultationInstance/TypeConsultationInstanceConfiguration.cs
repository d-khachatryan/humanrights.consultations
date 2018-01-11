using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationInstanceConfiguration : EntityTypeConfiguration<TypeConsultationInstance>
    {
        public TypeConsultationInstanceConfiguration()
        {
            this.ToTable("dbo.TypeConsultationInstance");
            this.HasKey<int>(s => s.TypeConsultationInstanceID);
            this.Property(s => s.TypeConsultationInstanceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.TypeConsultation)
            .WithMany(o => o.TypeConsultationInstances)
            .HasForeignKey(o => o.TypeConsultationID)
            .WillCascadeOnDelete(true);
        }
    }
}
