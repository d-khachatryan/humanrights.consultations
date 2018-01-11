using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationRecipientConfiguration : EntityTypeConfiguration<TypeConsultationRecipient>
    {
        public TypeConsultationRecipientConfiguration()
        {
            this.ToTable("dbo.TypeConsultationRecipient");
            this.HasKey<int>(s => s.TypeConsultationRecipientID);
            this.Property(s => s.TypeConsultationRecipientID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.TypeConsultation)
            .WithMany(o => o.TypeConsultationRecipients)
            .HasForeignKey(o => o.TypeConsultationID)
            .WillCascadeOnDelete(true);
        }
    }
}
