using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationRightConfiguration : EntityTypeConfiguration<TypeConsultationRight>
    {
        public TypeConsultationRightConfiguration()
        {
            this.ToTable("dbo.TypeConsultationRight");
            this.HasKey<int>(s => s.TypeConsultationRightID);
            this.Property(s => s.TypeConsultationRightID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.TypeConsultation)
            .WithMany(o => o.TypeConsultationRights)
            .HasForeignKey(o => o.TypeConsultationID)
            .WillCascadeOnDelete(true);
        }
    }
}
