using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationPermissionConfiguration : EntityTypeConfiguration<OralConsultationPermission>
    {
        public OralConsultationPermissionConfiguration()
        {
            this.ToTable("dbo.OralConsultationPermission");
            this.HasKey<int>(s => s.OralConsultationPermissionID);
            this.Property(s => s.OralConsultationPermissionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.OralConsultation)
            .WithMany(o => o.OralConsultationPermissionss)
            .HasForeignKey(o => o.OralConsultationID)
            .WillCascadeOnDelete(true);
        }
    }
}
