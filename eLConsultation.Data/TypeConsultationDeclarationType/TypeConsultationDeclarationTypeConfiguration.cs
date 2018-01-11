using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLConsultation.Data
{
    public class TypeConsultationDeclarationTypeConfiguration : EntityTypeConfiguration<TypeConsultationDeclarationType>
    {
        public TypeConsultationDeclarationTypeConfiguration()
        {
            this.ToTable("dbo.TypeConsultationDeclarationType");
            this.HasKey<int>(s => s.TypeConsultationDeclarationTypeID);
            this.Property(s => s.TypeConsultationDeclarationTypeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.TypeConsultation)
            .WithMany(o => o.TypeConsultationDeclarationTypes)
            .HasForeignKey(o => o.TypeConsultationID)
            .WillCascadeOnDelete(true);
        }
    }
}
