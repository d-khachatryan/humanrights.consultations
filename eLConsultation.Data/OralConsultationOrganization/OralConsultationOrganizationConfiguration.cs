using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class OralConsultationOrganizationConfiguration : EntityTypeConfiguration<OralConsultationOrganization>
    {
        public OralConsultationOrganizationConfiguration()
        {
            this.ToTable("dbo.OralConsultationOrganization");
            this.HasKey<int>(s => s.OralConsultationOrganizationID);
            this.Property(s => s.OralConsultationOrganizationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.OralConsultation)
            .WithMany(o => o.OralConsultationOrganizations)
            .HasForeignKey(o => o.OralConsultationID)
            .WillCascadeOnDelete(true);

        }
    }
}
