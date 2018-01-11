using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationPermissionConfiguration : EntityTypeConfiguration<TypeConsultationPermission>
    {
        public TypeConsultationPermissionConfiguration()
        {
            this.ToTable("dbo.TypeConsultationPermission");
            this.HasKey<int>(s => s.TypeConsultationPermissionID);
            this.Property(s => s.TypeConsultationPermissionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.TypeConsultation)
            .WithMany(o => o.TypeConsultationPermissionss)
            .HasForeignKey(o => o.TypeConsultationID)
            .WillCascadeOnDelete(true);

        }
    }
}
